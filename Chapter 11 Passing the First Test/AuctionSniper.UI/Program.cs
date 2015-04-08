using System;
using System.Windows.Forms;
using agsXMPP;
using agsXMPP.protocol.client;
using Message = agsXMPP.protocol.client.Message;

namespace AuctionSniper.UI
{
    public static class Program
    {
        private static MainWindow _mainWindow;
        public const string MAIN_WINDOW_NAME = "Auction Sniper Main";
        public const string SNIPER_STATUS_NAME = "lblSniperStatus";

        private const int ARG_HOSTNAME = 0;
        private const int ARG_USERNAME = 1;
        private const int ARG_PASSWORD = 2;
        private const int ARG_ITEM_ID = 3;

        public const string AUCTION_RESOURCE = "Auction";
        public const string AUCTION_ID_FORMAT = "auction-{0}" + "@{1}/" + AUCTION_RESOURCE;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _mainWindow = new MainWindow();
            _mainWindow.Text = MAIN_WINDOW_NAME;

            XmppClientConnection connection = Connection(args[ARG_HOSTNAME], args[ARG_USERNAME], args[ARG_PASSWORD]);

            connection.OnMessage += (sender, msg) => _mainWindow.ShowStatus(MainWindow.STATUS_LOST);
            connection.OnLogin += sender =>
            {
                Jid jid = new Jid(AuctionId(args[ARG_ITEM_ID], connection));
                Message message = new Message(jid);
                message.Type = MessageType.chat;
                connection.Send(message);
            };

            Application.Run(_mainWindow);
        }

        private static string AuctionId(string itemId, XmppClientConnection connection)
        {
            return String.Format(AUCTION_ID_FORMAT, itemId, connection.Server);
        }

        private static XmppClientConnection Connection(string hostname, string username, string password)
        {
            XmppClientConnection connection = new XmppClientConnection(hostname);
            connection.Username = username;
            connection.Password = password;

            connection.Open();
            return connection;
        }
    }
}
