using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoClient
{
    class Bios : HardwareInfo
    {
        public Bios(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_BIOS";
            headers = new string[] { "Name", "BIOSVersion", "CurrentLanguage", "Manufacturer", "SerialNumber", "ReleaseDate" };
            DBHeaders = new string[] { "Name", "BIOSVersion", "CurrentLanguage", "Manufacturer", "SerialNumber" };
        }

        public List<string> CheckConfigData(JSONConfigFile jsonFile)
        {
            List<Dictionary<string, string>> configData = jsonFile.DeserialezeAndLoad(className);
            return base.CheckConfigData(configData);
        }
    }
}
