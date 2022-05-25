
namespace Konmairo.SpiceApi_IIDX_Ticker
{
    partial class IIDX_Ticker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IIDX_Ticker));
            this.TickerGetTimer = new System.Windows.Forms.Timer(this.components);
            this.CheckForArduino = new System.Windows.Forms.Timer(this.components);
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.infoCardReader = new System.Windows.Forms.Label();
            this.lblCardReader = new System.Windows.Forms.Label();
            this.infoTicker = new System.Windows.Forms.Label();
            this.lblTicker = new System.Windows.Forms.Label();
            this.infoSpiceAPI = new System.Windows.Forms.Label();
            this.lblSpiceAPI = new System.Windows.Forms.Label();
            this.CheckForSpiceAPI = new System.Windows.Forms.Timer(this.components);
            this.bwTickerArduino = new System.ComponentModel.BackgroundWorker();
            this.IIDXLogo = new System.Windows.Forms.PictureBox();
            this.KonmaiLogo = new System.Windows.Forms.PictureBox();
            this.bwSpiceAPI = new System.ComponentModel.BackgroundWorker();
            this.gbStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IIDXLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KonmaiLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TickerGetTimer
            // 
            this.TickerGetTimer.Interval = 50;
            this.TickerGetTimer.Tick += new System.EventHandler(this.TickerGetTimer_Tick);
            // 
            // CheckForArduino
            // 
            this.CheckForArduino.Enabled = true;
            this.CheckForArduino.Tick += new System.EventHandler(this.CheckForArduino_Tick);
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.lblPort);
            this.gbStatus.Controls.Add(this.infoCardReader);
            this.gbStatus.Controls.Add(this.lblCardReader);
            this.gbStatus.Controls.Add(this.infoTicker);
            this.gbStatus.Controls.Add(this.lblTicker);
            this.gbStatus.Controls.Add(this.infoSpiceAPI);
            this.gbStatus.Controls.Add(this.lblSpiceAPI);
            this.gbStatus.Location = new System.Drawing.Point(12, 54);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(366, 181);
            this.gbStatus.TabIndex = 3;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPort.Location = new System.Drawing.Point(254, 44);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(64, 15);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "(Port: 573)";
            // 
            // infoCardReader
            // 
            this.infoCardReader.AutoSize = true;
            this.infoCardReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.infoCardReader.ForeColor = System.Drawing.Color.DarkBlue;
            this.infoCardReader.Location = new System.Drawing.Point(192, 139);
            this.infoCardReader.Name = "infoCardReader";
            this.infoCardReader.Size = new System.Drawing.Size(97, 29);
            this.infoCardReader.TabIndex = 5;
            this.infoCardReader.Text = "SOON™";
            // 
            // lblCardReader
            // 
            this.lblCardReader.AutoSize = true;
            this.lblCardReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.lblCardReader.Location = new System.Drawing.Point(26, 139);
            this.lblCardReader.Name = "lblCardReader";
            this.lblCardReader.Size = new System.Drawing.Size(157, 29);
            this.lblCardReader.TabIndex = 4;
            this.lblCardReader.Text = "CardReader: ";
            // 
            // infoTicker
            // 
            this.infoTicker.AutoSize = true;
            this.infoTicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.infoTicker.ForeColor = System.Drawing.Color.Red;
            this.infoTicker.Location = new System.Drawing.Point(192, 90);
            this.infoTicker.Name = "infoTicker";
            this.infoTicker.Size = new System.Drawing.Size(49, 29);
            this.infoTicker.TabIndex = 3;
            this.infoTicker.Text = "NG";
            // 
            // lblTicker
            // 
            this.lblTicker.AutoSize = true;
            this.lblTicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.lblTicker.Location = new System.Drawing.Point(26, 90);
            this.lblTicker.Name = "lblTicker";
            this.lblTicker.Size = new System.Drawing.Size(93, 29);
            this.lblTicker.TabIndex = 2;
            this.lblTicker.Text = "Ticker: ";
            // 
            // infoSpiceAPI
            // 
            this.infoSpiceAPI.AutoSize = true;
            this.infoSpiceAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.infoSpiceAPI.ForeColor = System.Drawing.Color.Red;
            this.infoSpiceAPI.Location = new System.Drawing.Point(192, 38);
            this.infoSpiceAPI.Name = "infoSpiceAPI";
            this.infoSpiceAPI.Size = new System.Drawing.Size(49, 29);
            this.infoSpiceAPI.TabIndex = 1;
            this.infoSpiceAPI.Text = "NG";
            // 
            // lblSpiceAPI
            // 
            this.lblSpiceAPI.AutoSize = true;
            this.lblSpiceAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.lblSpiceAPI.Location = new System.Drawing.Point(26, 38);
            this.lblSpiceAPI.Name = "lblSpiceAPI";
            this.lblSpiceAPI.Size = new System.Drawing.Size(118, 29);
            this.lblSpiceAPI.TabIndex = 0;
            this.lblSpiceAPI.Text = "SpiceAPI:";
            // 
            // CheckForSpiceAPI
            // 
            this.CheckForSpiceAPI.Enabled = true;
            this.CheckForSpiceAPI.Tick += new System.EventHandler(this.CheckForSpiceAPI_Tick);
            // 
            // bwTickerArduino
            // 
            this.bwTickerArduino.WorkerSupportsCancellation = true;
            this.bwTickerArduino.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwTickerArduino_DoWork);
            // 
            // IIDXLogo
            // 
            this.IIDXLogo.BackColor = System.Drawing.SystemColors.Control;
            this.IIDXLogo.Image = ((System.Drawing.Image)(resources.GetObject("IIDXLogo.Image")));
            this.IIDXLogo.Location = new System.Drawing.Point(108, 253);
            this.IIDXLogo.Name = "IIDXLogo";
            this.IIDXLogo.Size = new System.Drawing.Size(271, 36);
            this.IIDXLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IIDXLogo.TabIndex = 6;
            this.IIDXLogo.TabStop = false;
            // 
            // KonmaiLogo
            // 
            this.KonmaiLogo.Image = ((System.Drawing.Image)(resources.GetObject("KonmaiLogo.Image")));
            this.KonmaiLogo.Location = new System.Drawing.Point(-4, -6);
            this.KonmaiLogo.Name = "KonmaiLogo";
            this.KonmaiLogo.Size = new System.Drawing.Size(145, 45);
            this.KonmaiLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.KonmaiLogo.TabIndex = 7;
            this.KonmaiLogo.TabStop = false;
            // 
            // bwSpiceAPI
            // 
            this.bwSpiceAPI.WorkerSupportsCancellation = true;
            this.bwSpiceAPI.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSpiceAPI_DoWork);
            // 
            // IIDX_Ticker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 301);
            this.Controls.Add(this.KonmaiLogo);
            this.Controls.Add(this.IIDXLogo);
            this.Controls.Add(this.gbStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "IIDX_Ticker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultimate LED Ticker";
            this.Load += new System.EventHandler(this.IIDX_Ticker_Load);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IIDXLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KonmaiLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TickerGetTimer;
        private System.Windows.Forms.Timer CheckForArduino;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Label infoSpiceAPI;
        private System.Windows.Forms.Label lblSpiceAPI;
        private System.Windows.Forms.Label infoCardReader;
        private System.Windows.Forms.Label lblCardReader;
        private System.Windows.Forms.Label infoTicker;
        private System.Windows.Forms.Label lblTicker;
        private System.Windows.Forms.Timer CheckForSpiceAPI;
        private System.ComponentModel.BackgroundWorker bwTickerArduino;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.PictureBox IIDXLogo;
        private System.Windows.Forms.PictureBox KonmaiLogo;
        private System.ComponentModel.BackgroundWorker bwSpiceAPI;
    }
}

