using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        /// <summary>
        /// A method that handles background logic such as continuously check if Cuphead process exists.
        /// </summary>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker.CancellationPending)
            {
                processOpened = memory.OpenProcess("Cuphead");
                backgroundWorker.ReportProgress(processOpened ? 1 : 0);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// A method to handle UI changes.
        /// </summary>
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //lblProcessStatus.Text = e.ProgressPercentage == 1 ? "Game Process was found!" : "Game process NOT found!";

            if (e.ProgressPercentage != 1)
            {
                lblProcessStatus.Text = "Game Process was NOT found!";
                chkboxInfiniteHP.Enabled = false;
            }
            else
            {
                lblProcessStatus.Text = "Game process found!";
                chkboxInfiniteHP.Enabled = true;
            }
        }

        /// <summary>
        /// Needed to ensure clean shutdown of application.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        /// <summary>
        /// A method that handles the infinite health checkbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkboxInfiniteHP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxInfiniteHP.Checked)
            {

            }
        }
    }
}