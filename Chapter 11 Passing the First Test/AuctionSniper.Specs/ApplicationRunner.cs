using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TestStack.White.UIItems.WindowItems;
using AuctionSniper.UI;
using TestStack.White;
using TestStack.White.UIItems;
using FluentAssertions;
using System.Threading.Tasks;

namespace AuctionSniper.Specs
{
    public class ApplicationRunner
    {
        public const string SNIPER_ID = "sniper";
        public const string SNIPER_PASSWORD = "sniper";
        private const string XMPP_HOSTNAME = "localhost";
        private const string STATUS_JOINING = "Joining";
        private const string STATUS_LOST = "Lost";

        private Window _auctionSniperWindow;

        internal void StartBiddingIn(FakeAuctionServer auction)
        {
            try
            {
                Task.Run((() => Program.Main(XMPP_HOSTNAME, SNIPER_ID, SNIPER_PASSWORD, auction.ItemId)));
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            _auctionSniperWindow = Desktop.Instance.Windows().Find(window => window.Title == Program.MAIN_WINDOW_NAME);
            ShowsSniperStatus(STATUS_JOINING);
        }

        internal void ShowSniperHasLostAuction()
        {
            ShowsSniperStatus(STATUS_LOST);
        }

        public void ShowsSniperStatus(string statusText)
        {
            Label lblStatus = _auctionSniperWindow.Get<Label>(Program.SNIPER_STATUS_NAME);
            lblStatus.Text.Should().BeEquivalentTo(statusText);
        }

        internal void Stop()
        {
            if (_auctionSniperWindow != null)
            {
                _auctionSniperWindow.Dispose();
            }
        }
    }
}
