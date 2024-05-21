using System;
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

        private int[] originalCoinValues = new int[3];


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
                chkboxInfiniteCoin.Enabled = false;
                chkboxInfiniteCoin.Checked = false;
            }
            else
            {
                lblProcessStatus.Text = "Game process found!";
                chkboxInfiniteHP.Enabled = true;
                chkboxInfiniteCoin.Enabled = true;
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
        private void chkboxInfiniteHP_CheckedChanged(object sender, EventArgs e)
        {
            string hpAddress = "mono.dll+00264A68,A0,D20,D8,20,60,60,B4";
            

            if (chkboxInfiniteHP.Checked && processOpened)
            {
                if (memory.FreezeValue(hpAddress, "int", "27"))
                {
                    MessageBox.Show("Works");
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

        private void chkboxInfiniteCoin_CheckedChanged(object sender, EventArgs e)
        {
            string firstSlotCoinPointer = "mono.dll+002675E0,A0,4E8,30,20,28,10,28"; 
            string secondSlotCoinPointer = "mono.dll+002675E0,A0,4E8,30,28,28,10,28";
            string thirdSlotCoinPointer = "mono.dll+002675E0,A0,4E8,30,30,28,18,58";

            if (chkboxInfiniteCoin.Checked && processOpened)
            {
                originalCoinValues[0] = memory.ReadInt(firstSlotCoinPointer);
                originalCoinValues[1] = memory.ReadInt(secondSlotCoinPointer);
                originalCoinValues[2] = memory.ReadInt(thirdSlotCoinPointer);

                memory.FreezeValue(firstSlotCoinPointer, "int", "60");
                memory.FreezeValue(secondSlotCoinPointer, "int", "60");
                memory.FreezeValue(thirdSlotCoinPointer, "int", "60");
            }
            else
            {
                memory.UnfreezeValue(firstSlotCoinPointer); 
                memory.UnfreezeValue(secondSlotCoinPointer);
                memory.UnfreezeValue(thirdSlotCoinPointer);
                memory.WriteMemory(firstSlotCoinPointer, "int", originalCoinValues[0].ToString());
                memory.WriteMemory(secondSlotCoinPointer, "int", originalCoinValues[1].ToString());
                memory.WriteMemory(thirdSlotCoinPointer, "int", originalCoinValues[2].ToString());
            }
        }
    }
}