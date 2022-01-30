﻿/*======================================================================================
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    [Serializable]
    public enum ProtocolEnum
    {
        FTP,
        SFTP
    }

    [Serializable]
    public enum CommandEnum
    {
        Copy,
        Delete
    }


    [Serializable]
    public class FtpSftpTaskConfig : ITaskConfig
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
        public bool DoNotLog { get; set; }
        public IterationMode PluginIterationMode { get; set; }
        public string IterationObject { get; set; }
        public int IterationsCount { get; set; }

        public ProtocolEnum Protocol { get; set; }

        [DynamicData]
        public string Host { get; set; }
        [DynamicData]
        public string Port { get; set; }
        [DynamicData]
        public string Username { get; set; }
        [DynamicData]
        public string Password { get; set; }

        public CommandEnum Command { get; set; }


        public List<FtpSftpCopyItem> CopyItems { get; } = new List<FtpSftpCopyItem>();

        public List<FtpSftpDeleteItem> DeleteItems { get; } = new List<FtpSftpDeleteItem>();
    }
}