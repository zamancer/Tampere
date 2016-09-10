using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tampere.FileManipulation;

namespace Tampere.Notifiers
{
    public class PlaysTvTrayNotifier
    {
        private NotifyIcon _notificationIcon;

        public PlaysTvTrayNotifier(NotifyIcon notificationIcon)
        {
            _notificationIcon = notificationIcon;
        }

        public void OnCompleted(FileMovement value)
        {
            _notificationIcon.BalloonTipText = String.Format("Deleted {0} video files...", value.FilesDeleted);
            _notificationIcon.ShowBalloonTip(150);
        }

        public void OnNext(FileMovement value)
        {
            _notificationIcon.BalloonTipText = String.Format("Copying file {0}/{1}...", value.FileNumber, value.FileTotal);
            _notificationIcon.ShowBalloonTip(150);
        }

        public void OnStart(FileMovement value)
        {
            _notificationIcon.BalloonTipText = String.Format("About to copy {0} video files...", value.FileTotal);
            _notificationIcon.ShowBalloonTip(150);
        }
    }
}
