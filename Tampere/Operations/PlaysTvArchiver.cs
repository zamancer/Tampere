using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tampere.Configurations;
using Tampere.FileManipulation;
using Tampere.Notifiers;

namespace Tampere.Operations
{
    internal class PlaysTvArchiver
    {
        private string _lolDirectory;
        private string _backupDirectory;

        const string videoFilesExtension = ".mp4";

        private PlaysTvTrayNotifier _onFileMovement;

        internal PlaysTvArchiver(PlaysTvTrayNotifier onFileMovement)
        {
            _lolDirectory = ConfigurationParameters.Instance.ConfigParamters["lolDirectory"];
            _backupDirectory = ConfigurationParameters.Instance.ConfigParamters["backupDirectory"];

            _onFileMovement = onFileMovement;

            PrepareArchiveDestination();
        }

        private void PrepareArchiveDestination()
        {
            if (Directory.Exists(_backupDirectory))
            {
                Directory.CreateDirectory(_backupDirectory);
            }
        }

        internal void Run()
        {
            if (ThereAreFilesToArchive())
            {
                List<FileToMove> files2Move = GetPlaysTvFilesToMove();

                FileMovement fileMovementReport = new FileMovement { FileTotal = files2Move.Count };
                _onFileMovement.OnStart(fileMovementReport);

                for (int i = 0; i < files2Move.Count; i++)
                {
                    fileMovementReport.FileNumber = i + 1;
                    _onFileMovement.OnNext(fileMovementReport);

                    FileToMove f2m = files2Move[i];

                    File.Copy(f2m.OriginPath, f2m.DestPath, true);
                }

                DirectoryInfo lolVideosDirInfo = new DirectoryInfo(_lolDirectory);
                fileMovementReport.FilesDeleted = lolVideosDirInfo.GetFiles().Count();

                foreach (FileInfo file in lolVideosDirInfo.GetFiles())
                {
                    file.Delete();
                }

                _onFileMovement.OnCompleted(fileMovementReport);
            }
        }

        private bool ThereAreFilesToArchive()
        {
            if (Directory.Exists(_lolDirectory))
            {
                string[] files = Directory.GetFiles(_lolDirectory);

                return files.Count() > 0;
            }

            return false;
        }

        private List<FileToMove> GetPlaysTvFilesToMove()
        {
            string[] files = Directory.GetFiles(_lolDirectory);

            List<FileToMove> files2Move = new List<FileToMove>();

            foreach (string file in files)
            {
                string fileExtension = Path.GetExtension(file);

                if (fileExtension.Equals(videoFilesExtension))
                {
                    string filename = Path.GetFileName(file);
                    string destFilename = Path.Combine(_backupDirectory, filename);
                    FileToMove f2m = new FileToMove(file, destFilename);

                    files2Move.Add(f2m);
                }
            }

            return files2Move;
        }
    }
}