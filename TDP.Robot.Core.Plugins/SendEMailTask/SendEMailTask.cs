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
using System.Net;
using System.Net.Mail;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.SendEMailTask
{
    [Serializable]
    public class SendEMailTask : ITask
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        public void Init()
        {
            
        }

        public void Destroy()
        {
            
        }

        public ExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            ExecResult Result;
            DateTime StartDateTime = DateTime.Now;

            int ActualIterations = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                SendEMailTaskConfig TConfig = (SendEMailTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                for (int i = 0; i < IterationsCount; i++)
                {
                    SendEMailTaskConfig ConfigCopy = (SendEMailTaskConfig)CoreHelpers.CloneObjects(Config);
                    DynamicDataParser.Parse(ConfigCopy, dataChain, i);

                    using (SmtpClient MailClient = new SmtpClient(ConfigCopy.SMTPServer, int.Parse(ConfigCopy.Port)))
                    using (MailMessage Mail = new MailMessage())
                    {
                        Mail.Sender = new MailAddress(ConfigCopy.Sender);
                        Mail.From = new MailAddress(ConfigCopy.Sender);

                        foreach (string Recipient in ConfigCopy.Recipients)
                        {
                            Mail.To.Add(Recipient);
                        }

                        foreach (string CCRecipient in ConfigCopy.CC)
                        {
                            Mail.CC.Add(CCRecipient);
                        }

                        Mail.Subject = ConfigCopy.Subject;
                        Mail.Body = ConfigCopy.Message;

                        if (TConfig.Authenticate)
                        {
                            MailClient.Credentials = new NetworkCredential(ConfigCopy.Username, ConfigCopy.Password);
                        }

                        MailClient.EnableSsl = ConfigCopy.UseSSL;
                        MailClient.Port = int.Parse(ConfigCopy.Port);
                        MailClient.Send(Mail);

                        ActualIterations++;
                    }
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, StartDateTime, DateTime.Now, ActualIterations);
                Result = new ExecResult(true, DDataSet);

                if (!Config.DoNotLog)
                {
                    instanceLogger.Info($"Number of emails sent: {ActualIterations}");
                    instanceLogger.TaskCompleted(this);
                }
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                {
                    instanceLogger.Info($"Number of emails sent: {ActualIterations}");
                    instanceLogger.TaskError(this, ex);
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                Result = new ExecResult(false, DDataSet);
            }

            return Result;
        }
    }
}
