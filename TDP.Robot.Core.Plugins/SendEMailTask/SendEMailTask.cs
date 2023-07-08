/*======================================================================================
    Copyright 2021 - 2023 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

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
    public class SendEMailTask : IterationTask
    {
        protected override void RunIteration(int currentIteration)
        {
            SendEMailTaskConfig TConfig = (SendEMailTaskConfig)_iterationConfig;

            using (SmtpClient MailClient = new SmtpClient(TConfig.SMTPServer, int.Parse(TConfig.Port)))
            using (MailMessage Mail = new MailMessage())
            {
                Mail.Sender = new MailAddress(TConfig.Sender);
                Mail.From = new MailAddress(TConfig.Sender);

                foreach (string Recipient in TConfig.Recipients)
                {
                    Mail.To.Add(Recipient);
                }

                foreach (string CCRecipient in TConfig.CC)
                {
                    Mail.CC.Add(CCRecipient);
                }

                foreach (string FileAttachment in TConfig.Attachments)
                {
                    Mail.Attachments.Add(new Attachment(FileAttachment));
                }

                Mail.Subject = TConfig.Subject;
                Mail.Body = TConfig.Message;

                if (TConfig.Authenticate)
                {
                    MailClient.Credentials = new NetworkCredential(TConfig.Username, TConfig.Password);
                }

                MailClient.EnableSsl = TConfig.UseSSL;
                MailClient.Port = int.Parse(TConfig.Port);
                MailClient.Send(Mail);
            }
        }
    }
}
