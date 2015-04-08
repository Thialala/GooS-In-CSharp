using TechTalk.SpecFlow;

namespace AuctionSniper.Specs.Features.Steps
{
    [Binding]
    public class SingleItemJoinSteps
    {
        private FakeAuctionServer _auction;
        private ApplicationRunner _application;

        [BeforeScenario]
        public void Init()
        {
            _auction = new FakeAuctionServer("item-54321");
            _application = new ApplicationRunner();
        }

        [When(@"an auction is selling an item")]
        public void WhenAnAuctionIsSellingAnItem()
        {
            _auction.StartSellingItem();
        }

        [When(@"an Auction Sniper has started to bid in that auction")]
        public void WhenAnAuctionSniperHasStartedToBidInThatAuction()
        {
            _application.StartBiddingIn(_auction);
        }

        [Then(@"the auction will receive a Join request from the Auction Sniper")]
        public void ThenTheAuctionWillReceiveAJoinRequestFromTheAuctionSniper()
        {
            _auction.HasReceivedJoinRequestFromSniper();
        }

        [When(@"an auction announces that it is Closed")]
        public void WhenAnAuctionAnnouncesThatItIsClosed()
        {
            _auction.AnnounceClosed();
        }

        [Then(@"the Auction Sniper will show that it lost the auction")]
        public void ThenTheAuctionSniperWillShowThatItLostTheAuction()
        {
            _application.ShowSniperHasLostAuction();
        }

        [AfterScenario]
        public void Stop()
        {
            _application.Stop();
            _auction.Stop();
        }
    }
}
