﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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

        private byte[] originalHealthBytes;

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
            if (e.ProgressPercentage != 1)
            {
                lblProcessStatus.Text = "Game Process was NOT found!";
                chkboxInfiniteHP.Enabled = false;
                chkboxInfiniteHP.Checked = false;
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

        private IntPtr GetModuleBaseAddress(string moduleName)
        {
            Process[] processes = Process.GetProcessesByName("Cuphead");
            foreach (ProcessModule module in processes[0].Modules)
            {
                if (module.ModuleName.Equals(moduleName, StringComparison.OrdinalIgnoreCase))
                {
                    return module.BaseAddress;
                }
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// A method that handles the infinite health checkbox.
        /// </summary>
        private void chkboxInfiniteHP_CheckedChanged(object sender, EventArgs e)
        {
            //IntPtr monoBaseAddress = GetModuleBaseAddress("mono.dll");
            string hpAddress = "mono.dll+00264A68,A0,D20,D8,20,60,60,B4";

            if (chkboxInfiniteHP.Checked && processOpened)
            {
                if (memory.FreezeValue(hpAddress, "int", "3"))
                {
                    MessageBox.Show("Works.");
                }
                else
                {
                    MessageBox.Show("Does not work.");
                }
            }
            else
            {
                memory.UnfreezeValue(hpAddress);
            }
        }
    }
}