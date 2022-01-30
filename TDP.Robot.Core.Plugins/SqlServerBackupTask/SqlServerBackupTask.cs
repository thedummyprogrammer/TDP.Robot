/*======================================================================================
    Copyright 2021 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

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
    public class SqlServerBackupTask : ITask
    {
        private const int _BackupSuccess = -1;
        private const int _BackupSuccessChecksumError = -2;
        private const int _BackupError = -3;

        public IFolder ParentFolder { get; set ; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }
        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        public void Init()
        {
            
        }

        public void Destroy()
        {
            
        }

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

        public ExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            ExecResult Result;
            DateTime StartDateTime = DateTime.Now;

            int ActualIterations = 0;
            int SuccessfulBackupsNumber = 0;
            int FailedBackupsNumber = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                SqlServerBackupTaskConfig TConfig = (SqlServerBackupTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                for (int i = 0; i < IterationsCount; i++)
                {
                    SqlServerBackupTaskConfig ConfigCopy = (SqlServerBackupTaskConfig)CoreHelpers.CloneObjects(Config);
                    DynamicDataParser.Parse(ConfigCopy, dataChain, i);

                    string ConnectionString = $"Server={ConfigCopy.Server};User ID={ConfigCopy.Username};Password={ConfigCopy.Password};{ConfigCopy.ConnectionStringOptions}";

                    List<string> DbToBackup;
                    if (ConfigCopy.DatabasesToBackup == DatabasesToBackupEnum.AllDatabases)
                    {
                        DbToBackup = SqlServerBackupTaskCommon.GetDatabaseList(ConnectionString);
                    }
                    else if (ConfigCopy.DatabasesToBackup == DatabasesToBackupEnum.AllUserDatabases)
                    {
                        DbToBackup = SqlServerBackupTaskCommon.GetDatabaseList(ConnectionString, true);
                    }
                    else
                    {
                        DbToBackup = new List<string>();
                        List<string> DatabaseList = SqlServerBackupTaskCommon.GetDatabaseList(ConnectionString);
                        foreach (string DbName in ConfigCopy.SelectedDatabases)
                        {
                            if (DatabaseList.Contains(DbName))
                                DbToBackup.Add(DbName);
                            else
                                instanceLogger.Info(this, $"Database '{DbName}' doesn't exist, skipping...");
                        }
                    }

                    string PrevFileNameTemplate = ConfigCopy.FileNameTemplate;
                    foreach (string DbName in DbToBackup)
                    {
                        try
                        {
                            ConfigCopy.FileNameTemplate = PrevFileNameTemplate.Replace("{DatabaseName}", DbName);
                            instanceLogger.Info(this, $"Backing up database '{DbName}'...");
                            int BackupResult;

                            if (ConfigCopy.BackupType == BackupTypeEnum.Full)
                            {
                                BackupResult = BackupDatabase(ConnectionString, DbName, ConfigCopy.DestinationPath, ConfigCopy.FileNameTemplate, ConfigCopy.OverwriteIfExists,
                                                                ConfigCopy.PerformChecksum, ConfigCopy.ContinueOnError,
                                                                $"TheDummyProgrammer-Backup-{DateTime.Now.Ticks}", ConfigCopy.UseCompression, instanceLogger);

                                if (BackupResult == _BackupSuccess)
                                    instanceLogger.Info(this, $"Backup database '{DbName}' completed");
                                else if (BackupResult == _BackupSuccessChecksumError)
                                    instanceLogger.Info(this, $"Backup database '{DbName}' completed, but checksum failed");
                                else
                                    instanceLogger.Info(this, $"Backup database '{DbName}' failed");
                            }
                            else
                            {
                                BackupResult = BackupTransactionLog(ConnectionString, DbName, ConfigCopy.DestinationPath, ConfigCopy.FileNameTemplate, ConfigCopy.OverwriteIfExists,
                                                                    ConfigCopy.PerformChecksum, ConfigCopy.ContinueOnError,
                                                                    $"TheDummyProgrammer-TranLogBackup-{DateTime.Now.Ticks}", ConfigCopy.UseCompression, instanceLogger);

                                if (BackupResult == _BackupSuccess)
                                    instanceLogger.Info(this, $"Backup transaction log '{DbName}' completed");
                                else if (BackupResult == _BackupSuccessChecksumError)
                                    instanceLogger.Info(this, $"Backup transaction log '{DbName}' completed, but checksum failed");
                                else
                                    instanceLogger.Info(this, $"Backup transaction log '{DbName}' failed");
                            }

                            if (BackupResult == _BackupSuccess)
                                SuccessfulBackupsNumber++;
                            else
                                FailedBackupsNumber++;

                            if (BackupResult == _BackupSuccess || BackupResult == _BackupSuccessChecksumError)
                            {
                                if (ConfigCopy.VerifyBackup)
                                {
                                    instanceLogger.Info(this, $"Starting backup verification '{DbName}'...");

                                    if (VerifyBackup(ConnectionString, DbName, ConfigCopy.DestinationPath, ConfigCopy.FileNameTemplate, ConfigCopy.BackupType, instanceLogger))
                                        instanceLogger.Info(this, "Verification OK");
                                    else
                                        instanceLogger.Info(this, "Verification failed");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            instanceLogger.Error(this, $"Error backing up database '{DbName}'", ex);
                        }
                    }

                    ActualIterations++;
                }        

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, StartDateTime, DateTime.Now, ActualIterations);
                DDataSet.Add(SqlServerBackupTaskCommon.DynDataKeySuccessfulBackupsNumber, SuccessfulBackupsNumber);
                DDataSet.Add(SqlServerBackupTaskCommon.DynDataKeyFailedBackupsNumber, FailedBackupsNumber);
                Result = new ExecResult(true, DDataSet);

                if (!Config.DoNotLog)
                    instanceLogger.TaskCompleted(this);
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskError(this, ex);

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                DDataSet.Add(SqlServerBackupTaskCommon.DynDataKeySuccessfulBackupsNumber, SuccessfulBackupsNumber);
                DDataSet.Add(SqlServerBackupTaskCommon.DynDataKeyFailedBackupsNumber, FailedBackupsNumber);

                Result = new ExecResult(false, DDataSet);
            }
            
            return Result;
        }
    }
}
