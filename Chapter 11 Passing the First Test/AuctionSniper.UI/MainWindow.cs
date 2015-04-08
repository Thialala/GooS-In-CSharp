using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionSniper.UI
{
    public partial class MainWindow : Form
    {
        public static string STATUS_LOST = "Lost";
        delegate void SetTextCallback(string text);

        public MainWindow()
        {
            InitializeComponent();
        }

        internal void ShowStatus(string statusText)
        {
            this.SetStatus(statusText);
        }

        private void SetStatus(string statusText)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            // https://msdn.microsoft.com/en-us/library/vstudio/ms171728(v=vs.100).aspx
            if (this.lblSniperStatus.InvokeRequired)
            {
                SetTextCallback d = SetStatus;
                this.Invoke(d, new object[] { statusText });
            }
            else
            {
                this.lblSniperStatus.Text = statusText;
            }
        }
    }
}
