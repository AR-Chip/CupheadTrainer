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
        private Mem memory = new Mem();
        private bool processOpened = false;

        public MainForm()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            this.FormClosing += MainForm_FormClosing;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker.CancellationPending)
            {
                processOpened = memory.OpenProcess("Cuphead");
                backgroundWorker.ReportProgress(processOpened ? 1 : 0);
                Thread.Sleep(1000);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProcessStatus.Text = e.ProgressPercentage == 1 ? "Game Process was found!" : "Game process NOT found!";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }
    }
}