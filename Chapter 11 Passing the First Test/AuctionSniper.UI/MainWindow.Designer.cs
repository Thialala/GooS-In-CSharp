namespace AuctionSniper.UI
{
    partial class MainWindow
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
            this.lblSniperStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSniperStatus
            // 
            this.lblSniperStatus.AutoSize = true;
            this.lblSniperStatus.Location = new System.Drawing.Point(25, 26);
            this.lblSniperStatus.Name = "lblSniperStatus";
            this.lblSniperStatus.Size = new System.Drawing.Size(40, 13);
            this.lblSniperStatus.TabIndex = 0;
            this.lblSniperStatus.Text = "Joining";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 91);
            this.Controls.Add(this.lblSniperStatus);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSniperStatus;
    }
}

