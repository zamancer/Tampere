using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tampere.Notifiers
{
    public class TrayNotificator : INotificator
    {
        NotifyIcon _appNotifyIcon;

        const int DEFAULT_NOTIFICATION_TIMEOUT = 10;

        public TrayNotificator(NotifyIcon notifyIcon)
        {
            _appNotifyIcon = notifyIcon;
        }

        public void ShowNotification(string notificationMessage)
        {
            _appNotifyIcon.BalloonTipText = notificationMessage;
            _appNotifyIcon.ShowBalloonTip(DEFAULT_NOTIFICATION_TIMEOUT);
        }
    }
}
