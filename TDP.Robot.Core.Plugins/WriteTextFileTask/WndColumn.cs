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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.WriteTextFileTask
{
    public partial class WndColumn : WndPluginDetailConfigBase
    {
        public string HeaderTitle
        {
            get { return TxtHeaderTitle.Text; }
            set { TxtHeaderTitle.Text = value; }
        }

        public string FieldValue
        {
            get { return TxtFieldValue.Text; }
            set { TxtFieldValue.Text = value; }
        }

        public string FieldWidth
        {
            get { return TxtFieldWidth.Text; }
            set { TxtFieldWidth.Text = value; }
        }

        public WndColumn()
        {
            InitializeComponent();

            BtnDynDataHeaderTitle.Click += BtnDynDataButton_Click;
            BtnDynDataFieldValue.Click += BtnDynDataButton_Click;
            BtnDynDataFieldWidth.Click += BtnDynDataButton_Click;
        }
    }
}
