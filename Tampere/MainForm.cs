using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tampere.Notifiers;
using Tampere.Operations;

namespace Tampere
{
    public partial class MainForm : Form
    {
        ContextMenu _contextMenu;
        Notifier _appNotifier;

        public MainForm()
        {
            InitializeComponent();
            InitializeContextMenu();
            InitializeAppNotifier();
        }

        private void InitializeContextMenu()
        {
            _contextMenu = new ContextMenu();

            var menuItem1 = new MenuItem("Clean PlaysTv");
            menuItem1.Click += cleanPlaysTv_Click;

            var menuItem2 = new MenuItem("Clean Desktop");
            menuItem2.Click += cleanDesktop_Click;

            var menuItem3 = new MenuItem("Close");
            menuItem3.Click += close_Click;

            _contextMenu.MenuItems.Add(menuItem1);
            _contextMenu.MenuItems.Add(menuItem2);
            _contextMenu.MenuItems.Add(menuItem3);
        }

        private void InitializeAppNotifier()
        {
            appNotifyIcon.ContextMenu = _contextMenu;
            appNotifyIcon.BalloonTipTitle = "Tampere";

            _appNotifier = Notifier.Instance;
            _appNotifier.Notificator = new TrayNotificator(appNotifyIcon);
            Task.Factory.StartNew(_appNotifier.Run);
        }

        private void cleanPlaysTv_Click(object sender, EventArgs e)
        {
            _appNotifier.EnqueueNotification("Archiving PlaysTV videos...");

            PlaysTvArchiver archiver = new PlaysTvArchiver();
            archiver.Run();
        }

        private void cleanDesktop_Click(object sender, EventArgs e)
        {
            _appNotifier.EnqueueNotification("Cleaning Desktop...");

            DesktopCleaner cleaner = new DesktopCleaner();
            cleaner.Run();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
