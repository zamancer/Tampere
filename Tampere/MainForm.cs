using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tampere.Notifiers;
using Tampere.Operations;

namespace Tampere
{
    public partial class MainForm : Form
    {
        private PlaysTvTrayNotifier _playsTvNotifier;

        public MainForm()
        {
            InitializeComponent();
            InitializeTrayApp();
        }

        private void InitializeTrayApp()
        {
            var contextMenu = new ContextMenu();
            
            var menuItem1 = new MenuItem("Clean PlaysTv");
            menuItem1.Click += cleanPlaysTv_Click;

            var menuItem2 = new MenuItem("Clean Desktop");
            menuItem2.Click += cleanDesktop_Click;

            var menuItem3 = new MenuItem("Close");
            menuItem3.Click += close_Click;

            contextMenu.MenuItems.Add(menuItem1);
            contextMenu.MenuItems.Add(menuItem2);
            contextMenu.MenuItems.Add(menuItem3);

            appNotifyIcon.ContextMenu = contextMenu;

            appNotifyIcon.BalloonTipTitle = "Tampere";

            _playsTvNotifier = new PlaysTvTrayNotifier(appNotifyIcon);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void cleanDesktop_Click(object sender, EventArgs e)
        {
            appNotifyIcon.BalloonTipText = "Cleaning Desktop...";
            appNotifyIcon.ShowBalloonTip(500);
            
        }

        private void cleanPlaysTv_Click(object sender, EventArgs e)
        {
            appNotifyIcon.BalloonTipText = "Archiving PlaysTV videos...";
            appNotifyIcon.ShowBalloonTip(50);

            PlaysTvArchiver archiver = new PlaysTvArchiver(_playsTvNotifier);
            archiver.Run();
        }
    }
}
