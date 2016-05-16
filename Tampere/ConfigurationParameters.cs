using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tampere
{
    public class ConfigurationParameters
    {
        public Dictionary<string, string> ConfigParamters { get; private set; }

        private static ConfigurationParameters _instance;

        public static ConfigurationParameters Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationParameters();
                }

                return _instance;
            }
        }


        private ConfigurationParameters()
        {
            ConfigParamters = new Dictionary<string, string>();
            Load();
        }

        public void Load()
        {
            //TODO: Load from xml config file.
            
            ConfigParamters.Add("lolDirectory", @"C:\Users\Zam\Videos\PlaysTV\League of Legends");
            ConfigParamters.Add("backupDirectory", @"D:\Replays\LoL\Inbox");
            ConfigParamters.Add("desktopPath", @"C:\Users\Zam\Desktop");
            ConfigParamters.Add("defaultInboxDirectoryName", "DesktopInbox");
        }
    }
}
