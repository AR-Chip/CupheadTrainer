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
        private bool processOpened = false;

        public MainForm()
        {
            InitializeComponent();
            timerProcessFinder.Interval = 1000;
            timerProcessFinder.Tick += new EventHandler(timerProcessTick);
            timerProcessFinder.Start();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            processOpened = memory.OpenProcess("Cuphead");
            if (processOpened)
            {
                Thread.Sleep(1000);
                return;
            }

            //memory.WriteMemory("rsi+000000B4");
            //memory.

            Thread.Sleep(1000);
            backgroundWorker.ReportProgress(0);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (processOpened)
            {
                lblProcessStatus.Text = "Game Process was found!";
            }
            else
            {
                lblProcessStatus.Text = "Game process NOT found!";
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void timerProcessTick(object sender, EventArgs e)
        {
            processOpened = memory.OpenProcess("Cuphead");
            UpdateStatusLabel();
        }

        private void UpdateStatusLabel()
        {
            if (processOpened)
            {
                lblProcessStatus.Text = "Game Process was found!";
            }
            else
            {
                lblProcessStatus.Text = "Game process NOT found!";
            }
        }
    }
}