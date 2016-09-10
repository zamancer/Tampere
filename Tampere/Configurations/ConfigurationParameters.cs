using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tampere.Configurations
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
        }

        public void Load()
        {
            ConfigParamters.Add("lolDirectory", ConfigurationSettings.AppSettings.Get("lolDirectory"));
            ConfigParamters.Add("backupDirectory", ConfigurationSettings.AppSettings.Get("backupDirectory"));
            ConfigParamters.Add("desktopPath", ConfigurationSettings.AppSettings.Get("desktopPath"));
            ConfigParamters.Add("defaultInboxDirectoryName", ConfigurationSettings.AppSettings.Get("defaultInboxDirectoryName"));
        }
    }
}