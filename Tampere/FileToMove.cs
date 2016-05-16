using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tampere
{
    class FileToMove
    {
        public string OriginPath { get; private set; }

        public string DestPath { get; private set; }

        public FileToMove(string filename, string destinationPath)
        {
            this.OriginPath = filename;
            this.DestPath = destinationPath;
        }
    }
}
