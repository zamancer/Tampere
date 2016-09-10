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
        public PlaysTvTrayNotifier()
        {
        }

        public void OnCompleted(FileMovement value)
        {
            var notificationMessage = String.Format("Deleted {0} video files...", value.FilesDeleted);

            Notifier.Instance.EnqueueNotification(notificationMessage);
        }

        public void OnNext(FileMovement value)
        {
            var notificationMessage = String.Format("Copying file {0}/{1}...", value.FileNumber, value.FileTotal);

            Notifier.Instance.EnqueueNotification(notificationMessage);
        }

        public void OnStart(FileMovement value)
        {
            var notificationMessage = String.Format("About to copy {0} video files...", value.FileTotal);

            Notifier.Instance.EnqueueNotification(notificationMessage);
        }
    }
}
