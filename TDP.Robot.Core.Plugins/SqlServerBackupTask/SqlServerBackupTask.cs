/*======================================================================================
    Copyright 2021 - 2022 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

    This file is part of The Dummy Programmer Robot.

    The Dummy Programmer Robot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    The Dummy Programmer Robot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with The Dummy Programmer Robot.  If not, see <http://www.gnu.org/licenses/>.
======================================================================================*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.SqlServerBackupTask
{
    [Serializable]
    public class SqlServerBackupTask : IterationTask
    {
        private const int _BackupSuccess = -1;
        private const int _BackupSuccessChecksumError = -2;
        private const int _BackupError = -3;

        private int _successfulBackupsNumber = 0;
        private int _failedBackupsNumber = 0;

        private int BackupDatabase(string connectionString, string databaseName, string destination, string fileName, bool overwriteIfExists,
                                        bool checksum, bool continueOnError, string mediaName, UseCompressionEnum compression,
                                        IPluginInstanceLogger logger)
        {
            int Result = _BackupError;

            try
            {
                string FullPathDestination;
                if (string.IsNullOrEmpty(fileName.Trim()))
                    FullPathDestination = Path.Combine(destination, databaseName + ".bak");
                else
                    FullPathDestination = Path.Combine(destination, fileName);

                string SqlCommandBackup = @"
                DECLARE @DBNAME      NVARCHAR(1000) = @P_DBNAME
                DECLARE @PATH        NVARCHAR(1000) = @P_PATH
                DECLARE @MEDIANAME   NVARCHAR(1000) = @P_MEDIANAME

                BACKUP DATABASE @DBNAME TO  DISK = @PATH WITH NAME = @MEDIANAME
                ";

                if (overwriteIfExists)
                    SqlCommandBackup += ", INIT";

                if (checksum)
                    SqlCommandBackup += ", CHECKSUM";

                if (continueOnError)
                    SqlCommandBackup += ", CONTINUE_AFTER_ERROR";

                if (compression == UseCompressionEnum.CompressBackup)
                    SqlCommandBackup += ", COMPRESSION";
                else if (compression == UseCompressionEnum.DoNotCompressBackup)
                    SqlCommandBackup += ", NO_COMPRESSION";

                using (SqlConnection Cnt = new SqlConnection(connectionString))
                {
                    ManualResetEvent WaitInfoMessage = new ManualResetEvent(false);
                    Cnt.InfoMessage += (sender, e) =>
                    {
                        if (e.Message.Contains("BACKUP WITH CONTINUE_AFTER_ERROR successfully"))
                            Result = _BackupSuccessChecksumError;
                        else if (e.Message.Contains("BACKUP DATABASE successfully"))
                            Result = _BackupSuccess;

                        WaitInfoMessage.Set();
                    };

                    Cnt.Open();

                    using (SqlCommand Cmd = new SqlCommand(SqlCommandBackup, Cnt))
                    {
                        Cmd.Parameters.Add("@P_DBNAME", SqlDbType.NVarChar).Value = databaseName;
                        Cmd.Parameters.Add("@P_PATH", SqlDbType.NVarChar).Value = FullPathDestination;
                        Cmd.Parameters.Add("@P_MEDIANAME", SqlDbType.NVarChar).Value = mediaName;
                        Cmd.ExecuteNonQuery();
                        WaitInfoMessage.WaitOne();
                    }
                }
            }
            catch (Exception ex)
            {
                Result = _BackupError;
                logger.Error(this, $"Backup of database {databaseName} failed", ex);
            }

            return Result;
        }

        private int BackupTransactionLog(string connectionString, string databaseName, string destination, string fileName, bool overwriteIfExists,
                                            bool checksum, bool continueOnError, string mediaName, UseCompressionEnum compression,
                                            IPluginInstanceLogger logger)
        {
            int Result = _BackupError;

            try
            {
                string FullPathDestination;
                if (string.IsNullOrEmpty(fileName.Trim()))
                    FullPathDestination = Path.Combine(destination, databaseName + ".trn");
                else
                    FullPathDestination = Path.Combine(destination, fileName);

                string SqlCommandBackup = @"
                DECLARE @DBNAME      NVARCHAR(1000) = @P_DBNAME
                DECLARE @PATH        NVARCHAR(1000) = @P_PATH
                DECLARE @MEDIANAME   NVARCHAR(1000) = @P_MEDIANAME

                BACKUP LOG @DBNAME TO  DISK = @PATH WITH NAME = @MEDIANAME
                ";

                if (overwriteIfExists)
                    SqlCommandBackup += ", INIT";

                if (checksum)
                    SqlCommandBackup += ", CHECKSUM";

                if (continueOnError)
                    SqlCommandBackup += ", CONTINUE_AFTER_ERROR";

                if (compression == UseCompressionEnum.CompressBackup)
                    SqlCommandBackup += ", COMPRESSION";
                else if (compression == UseCompressionEnum.DoNotCompressBackup)
                    SqlCommandBackup += ", NO_COMPRESSION";

                using (SqlConnection Cnt = new SqlConnection(connectionString))
                {
                    ManualResetEvent WaitInfoMessage = new ManualResetEvent(false);
                    Cnt.InfoMessage += (sender, e) =>
                    {
                        if (e.Message.Contains("BACKUP WITH CONTINUE_AFTER_ERROR successfully"))
                            Result = _BackupSuccessChecksumError;
                        else if (e.Message.Contains("BACKUP LOG successfully"))
                            Result = _BackupSuccess;

                        WaitInfoMessage.Set();
                    };

                    Cnt.Open();

                    using (SqlCommand Cmd = new SqlCommand(SqlCommandBackup, Cnt))
                    {
                        Cmd.Parameters.Add("@P_DBNAME", SqlDbType.NVarChar).Value = databaseName;
                        Cmd.Parameters.Add("@P_PATH", SqlDbType.NVarChar).Value = FullPathDestination;
                        Cmd.Parameters.Add("@P_MEDIANAME", SqlDbType.NVarChar).Value = mediaName;
                        Cmd.ExecuteNonQuery();
                        WaitInfoMessage.WaitOne();
                    }
                }
            }
            catch (Exception ex)
            {
                Result = _BackupError;
                logger.Error(this, $"Backup of database {databaseName} failed", ex);
            }

            return Result;
        }

        private bool VerifyBackup(string connectionString, string databaseName, string destination, string fileName, BackupTypeEnum backupType, IPluginInstanceLogger logger)
        {
            bool Result = false;

            try
            {
                string FullPathDestination;

                if (string.IsNullOrEmpty(fileName))
                {
                    if (backupType == BackupTypeEnum.Full)
                        FullPathDestination = Path.Combine(destination, databaseName + ".bak");
                    else
                        FullPathDestination = Path.Combine(destination, databaseName + ".trn");
                }
                else
                {
                    FullPathDestination = Path.Combine(destination, fileName);
                }

                string SqlCommandVerifyBackup = @"
                DECLARE @P_BACKUPSET_ID   INT

                SELECT @P_BACKUPSET_ID = position FROM msdb..backupset WHERE database_name=@P_DBNAME 
                                                        AND backup_set_id=(SELECT MAX(backup_set_id) FROM msdb..backupset WHERE database_name=@P_DBNAME )
                
                IF @P_BACKUPSET_ID IS NULL BEGIN RAISERROR(N'Verify failed. Backup information not found.', 16, 1) END
                
                RESTORE VERIFYONLY FROM  DISK = @P_PATH WITH FILE = @P_BACKUPSET_ID,  NOUNLOAD,  NOREWIND
                IF @@ERROR <> 0 BEGIN RAISERROR(N'Verify failed. RESTORE command issued an error.', 16, 1) END
            ";

                using (SqlConnection Cnt = new SqlConnection(connectionString))
                {
                    ManualResetEvent WaitInfoMessage = new ManualResetEvent(false);
                    Cnt.InfoMessage += (sender, e) =>
                    {
                        if (e.Message.Contains("is valid."))
                            Result = true;
                        
                        WaitInfoMessage.Set();
                    };


                    Cnt.Open();

                    using (SqlCommand Cmd = new SqlCommand(SqlCommandVerifyBackup, Cnt))
                    {
                        Cmd.Parameters.Add("@P_DBNAME", SqlDbType.NVarChar).Value = databaseName;
                        Cmd.Parameters.Add("@P_PATH", SqlDbType.NVarChar).Value = FullPathDestination;
                        Cmd.ExecuteNonQuery();
                        WaitInfoMessage.WaitOne();
                    }
                }
            }
            catch (Exception ex)
            {
                Result = false;
                logger.Error(this, $"Verification of database {databaseName} failed", ex);
            }

            return Result;
        }

        protected override void RunIteration(int currentIteration)
        {
            _successfulBackupsNumber = 0;
            _failedBackupsNumber = 0;

            SqlServerBackupTaskConfig TConfig = (SqlServerBackupTaskConfig)_iterationConfig;

            string ConnectionString = $"Server={TConfig.Server};User ID={TConfig.Username};Password={TConfig.Password};{TConfig.ConnectionStringOptions}";

            List<string> DbToBackup;
            if (TConfig.DatabasesToBackup == DatabasesToBackupEnum.AllDatabases)
            {
                DbToBackup = SqlServerBackupTaskCommon.GetDatabaseList(ConnectionString);
            }
            else if (TConfig.DatabasesToBackup == DatabasesToBackupEnum.AllUserDatabases)
            {
                DbToBackup = SqlServerBackupTaskCommon.GetDatabaseList(ConnectionString, true);
            }
            else
            {
                DbToBackup = new List<string>();
                List<string> DatabaseList = SqlServerBackupTaskCommon.GetDatabaseList(ConnectionString);
                foreach (string DbName in TConfig.SelectedDatabases)
                {
                    if (DatabaseList.Contains(DbName))
                        DbToBackup.Add(DbName);
                    else
                        _instanceLogger.Info(this, $"Database '{DbName}' doesn't exist, skipping...");
                }
            }

            string PrevFileNameTemplate = TConfig.FileNameTemplate;
            foreach (string DbName in DbToBackup)
            {
                try
                {
                    TConfig.FileNameTemplate = PrevFileNameTemplate.Replace("{DatabaseName}", DbName);
                    _instanceLogger.Info(this, $"Backing up database '{DbName}'...");
                    int BackupResult;

                    if (TConfig.BackupType == BackupTypeEnum.Full)
                    {
                        BackupResult = BackupDatabase(ConnectionString, DbName, TConfig.DestinationPath, TConfig.FileNameTemplate, TConfig.OverwriteIfExists,
                                                        TConfig.PerformChecksum, TConfig.ContinueOnError,
                                                        $"TheDummyProgrammer-Backup-{DateTime.Now.Ticks}", TConfig.UseCompression, _instanceLogger);

                        if (BackupResult == _BackupSuccess)
                            _instanceLogger.Info(this, $"Backup database '{DbName}' completed");
                        else if (BackupResult == _BackupSuccessChecksumError)
                            _instanceLogger.Info(this, $"Backup database '{DbName}' completed, but checksum failed");
                        else
                            _instanceLogger.Info(this, $"Backup database '{DbName}' failed");
                    }
                    else
                    {
                        BackupResult = BackupTransactionLog(ConnectionString, DbName, TConfig.DestinationPath, TConfig.FileNameTemplate, TConfig.OverwriteIfExists,
                                                            TConfig.PerformChecksum, TConfig.ContinueOnError,
                                                            $"TheDummyProgrammer-TranLogBackup-{DateTime.Now.Ticks}", TConfig.UseCompression, _instanceLogger);

                        if (BackupResult == _BackupSuccess)
                            _instanceLogger.Info(this, $"Backup transaction log '{DbName}' completed");
                        else if (BackupResult == _BackupSuccessChecksumError)
                            _instanceLogger.Info(this, $"Backup transaction log '{DbName}' completed, but checksum failed");
                        else
                            _instanceLogger.Info(this, $"Backup transaction log '{DbName}' failed");
                    }

                    if (BackupResult == _BackupSuccess)
                        _successfulBackupsNumber++;
                    else
                        _failedBackupsNumber++;

                    if (BackupResult == _BackupSuccess || BackupResult == _BackupSuccessChecksumError)
                    {
                        if (TConfig.VerifyBackup)
                        {
                            _instanceLogger.Info(this, $"Starting backup verification '{DbName}'...");

                            if (VerifyBackup(ConnectionString, DbName, TConfig.DestinationPath, TConfig.FileNameTemplate, TConfig.BackupType, _instanceLogger))
                                _instanceLogger.Info(this, "Verification OK");
                            else
                                _instanceLogger.Info(this, "Verification failed");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _instanceLogger.Error(this, $"Error backing up database '{DbName}'", ex);
                }
            }
        }

        protected override void PostIterationSucceded(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {
            dDataSet.Add(SqlServerBackupTaskCommon.DynDataKeySuccessfulBackupsNumber, _successfulBackupsNumber);
            dDataSet.Add(SqlServerBackupTaskCommon.DynDataKeyFailedBackupsNumber, _failedBackupsNumber);
        }

        protected override void PostIterationFailed(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {
            dDataSet.Add(SqlServerBackupTaskCommon.DynDataKeySuccessfulBackupsNumber, _successfulBackupsNumber);
            dDataSet.Add(SqlServerBackupTaskCommon.DynDataKeyFailedBackupsNumber, _failedBackupsNumber);
        }
    }
}
