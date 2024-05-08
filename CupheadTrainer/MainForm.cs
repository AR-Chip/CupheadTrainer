using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace CupheadTrainer
{
    public partial class MainForm : Form
    {
        public Mem memory = new Mem();
        bool processOpened = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!memory.OpenProcess("Cuphead"))
                {
                    Thread.Sleep(1000);
                    return;
                }

                processOpened = true;
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(0);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (processOpened)
            {
                lblProcessStatus.Text = "Game Process was found!";
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}
