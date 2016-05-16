using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tampere
{
    internal class FileMovementConsoleMonitor
    {
        internal void OnCompleted(FileMovement value)
        {
            Console.WriteLine(String.Format("Deleted {0} video files...", value.FilesDeleted));
        }

        internal void OnNext(FileMovement value)
        {
            Console.WriteLine(String.Format("Copying file {0}/{1}...", value.FileNumber, value.FileTotal));
        }

        internal void OnStart(FileMovement value)
        {
            Console.WriteLine(String.Format("About to copy {0} video files...", value.FileTotal));
        }
    }
}
