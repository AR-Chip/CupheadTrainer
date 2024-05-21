namespace CupheadTrainer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblProcess = new System.Windows.Forms.Label();
            this.lblProcessStatus = new System.Windows.Forms.Label();
            this.timerProcessFinder = new System.Windows.Forms.Timer(this.components);
            this.chkboxInfiniteHP = new System.Windows.Forms.CheckBox();
            this.chkboxInfiniteCoin = new System.Windows.Forms.CheckBox();
            this.chkboxInfiniteSP = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(16, 11);
            this.lblProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(60, 16);
            this.lblProcess.TabIndex = 0;
            this.lblProcess.Text = "Process:";
            // 
            // lblProcessStatus
            // 
            this.lblProcessStatus.AutoSize = true;
            this.lblProcessStatus.Location = new System.Drawing.Point(88, 11);
            this.lblProcessStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProcessStatus.Name = "lblProcessStatus";
            this.lblProcessStatus.Size = new System.Drawing.Size(30, 16);
            this.lblProcessStatus.TabIndex = 1;
            this.lblProcessStatus.Text = "N/A";
            // 
            // chkboxInfiniteHP
            // 
            this.chkboxInfiniteHP.AutoSize = true;
            this.chkboxInfiniteHP.Location = new System.Drawing.Point(19, 36);
            this.chkboxInfiniteHP.Margin = new System.Windows.Forms.Padding(4);
            this.chkboxInfiniteHP.Name = "chkboxInfiniteHP";
            this.chkboxInfiniteHP.Size = new System.Drawing.Size(88, 20);
            this.chkboxInfiniteHP.TabIndex = 2;
            this.chkboxInfiniteHP.Text = "Infinite HP";
            this.chkboxInfiniteHP.UseVisualStyleBackColor = true;
            this.chkboxInfiniteHP.CheckedChanged += new System.EventHandler(this.chkboxInfiniteHP_CheckedChanged);
            // 
            // chkboxInfiniteCoin
            // 
            this.chkboxInfiniteCoin.AutoSize = true;
            this.chkboxInfiniteCoin.Enabled = false;
            this.chkboxInfiniteCoin.Location = new System.Drawing.Point(19, 63);
            this.chkboxInfiniteCoin.Name = "chkboxInfiniteCoin";
            this.chkboxInfiniteCoin.Size = new System.Drawing.Size(96, 20);
            this.chkboxInfiniteCoin.TabIndex = 3;
            this.chkboxInfiniteCoin.Text = "Infinite Coin";
            this.chkboxInfiniteCoin.UseVisualStyleBackColor = true;
            this.chkboxInfiniteCoin.CheckedChanged += new System.EventHandler(this.chkboxInfiniteCoin_CheckedChanged);
            // 
            // chkboxInfiniteSP
            // 
            this.chkboxInfiniteSP.AutoSize = true;
            this.chkboxInfiniteSP.Location = new System.Drawing.Point(129, 26);
            this.chkboxInfiniteSP.Name = "chkboxInfiniteSP";
            this.chkboxInfiniteSP.Size = new System.Drawing.Size(74, 17);
            this.chkboxInfiniteSP.TabIndex = 3;
            this.chkboxInfiniteSP.Text = "Infinite SP";
            this.chkboxInfiniteSP.UseVisualStyleBackColor = true;
            this.chkboxInfiniteSP.CheckedChanged += new System.EventHandler(this.chkboxInfiniteSP_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 260);
            this.Controls.Add(this.chkboxInfiniteCoin);
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.chkboxInfiniteSP);
            this.Controls.Add(this.chkboxInfiniteHP);
            this.Controls.Add(this.lblProcessStatus);
            this.Controls.Add(this.lblProcess);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Cuphead v1.3.4 GOG Trainer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblProcessStatus;
        private System.Windows.Forms.Timer timerProcessFinder;
        private System.Windows.Forms.CheckBox chkboxInfiniteHP;
        private System.Windows.Forms.CheckBox chkboxInfiniteCoin;
        private System.Windows.Forms.CheckBox chkboxInfiniteSP;
    }
}

