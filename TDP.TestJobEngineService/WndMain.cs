using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.Robot.JobEngineLib;

namespace TDP.Robot.TestJobEngineService
{
    public partial class WndMain : Form
    {
        private JobEngine _JobEngine;

        public WndMain()
        {
            InitializeComponent();
        }

        private void BtnStartJobEngine_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            _JobEngine = new JobEngine();
            _JobEngine.Start(Application.StartupPath);
        }

        private void BtnStopJobEngine_Click(object sender, EventArgs e)
        {
            if (_JobEngine != null)
                _JobEngine.Stop();
        }
    }
}
