using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoClient
{
    class DiskDrive : HardwareInfo
    {
        public string Name;
        public string Index;
        public string Caption;
        public string Size;
        public string BytesPerSector;
        public string Capabilities;
        public string Manufacturer;
        public string FirmwareRevision;

        public DiskDrive(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_DiskDrive";
            headers = new string[] { "Caption", "Index", "Size", "SerialNumber", "BytesPerSector", "Capabilities", "Manufacturer", "FirmwareRevision" };
            DBHeaders = new string[] { "Caption", "Size", "SerialNumber", "Manufacturer", "FirmwareRevision" };
        }
        public List<string> CheckConfigData(JSONConfigFile jsonFile)
        {
            List<Dictionary<string, string>> configData = jsonFile.DeserialezeAndLoad(className);
            return base.CheckConfigData(configData);
        }
    }
}
