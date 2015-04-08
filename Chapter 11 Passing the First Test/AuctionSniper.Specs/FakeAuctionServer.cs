using System.Collections.Concurrent;
using System.Linq;
using agsXMPP;
using agsXMPP.protocol.client;
using NUnit.Framework;

namespace AuctionSniper.Specs
{
    public class FakeAuctionServer
    {
        public static string ITEM_ID_AS_LOGIN = "auction-{0}";
        public static string AUCTION_RESOURCE = "Auction";
        public static string XMPP_HOSTNAME = "localhost";
        private const string AUCTION_PASSWORD = "auction";
        private readonly string _itemId;
        private readonly XmppClientConnection _connection;
        private readonly ConcurrentBag<Jid> _contacts = new ConcurrentBag<Jid>();

        public FakeAuctionServer(string itemId)
        {
            this._itemId = itemId;
            this._connection = new XmppClientConnection(XMPP_HOSTNAME);
        }

        internal void StartSellingItem()
        {
            _connection.Username = string.Format(ITEM_ID_AS_LOGIN, _itemId);
            _connection.Password = AUCTION_PASSWORD;
            _connection.Resource = AUCTION_RESOURCE;
            _connection.OnMessage += ConnectionOnOnMessage;
            _connection.Open();

        }

        private void ConnectionOnOnMessage(object sender, Message msg)
        {
            _contacts.Add(msg.From);
        }

        internal void HasReceivedJoinRequestFromSniper()
        {
            Assert.That(_contacts.Count, Is.GreaterThan(0).After(5000, 1));
        }

        internal void AnnounceClosed()
        {
            Message message = new Message(_contacts.First());
            message.Type = MessageType.chat;
            _connection.Send(message);
        }

        public string ItemId
        {
            get { return _itemId; }
        }

        internal void Stop()
        {
            _connection.Close();
        }
    }
}
