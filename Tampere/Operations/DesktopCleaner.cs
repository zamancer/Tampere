using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tampere.Configurations;

namespace Tampere.Operations
{
    internal class DesktopCleaner
    {
        private string _desktopPath;

        private string _defaultInboxDirectoryName;

        private string _temporalDirectoryPath;

        internal DesktopCleaner()
        {
            _desktopPath = ConfigurationParameters.Instance.ConfigParamters["desktopPath"];

            _defaultInboxDirectoryName = ConfigurationParameters.Instance.ConfigParamters["defaultInboxDirectoryName"];

            _temporalDirectoryPath = Path.Combine(_desktopPath, _defaultInboxDirectoryName);
        }

        internal void Run()
        {
            PrepareInboxDirectory();

            string[] files = Directory.GetFiles(_desktopPath);

            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);

                string newpath = Path.Combine(_temporalDirectoryPath, filename);

                File.Copy(file, newpath, true);

                File.Delete(file);
            }
        }

        private void PrepareInboxDirectory()
        {
            if (!Directory.Exists(_temporalDirectoryPath))
            {
                Directory.CreateDirectory(_temporalDirectoryPath);
            }
        }
    }
}
