using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoClient
{
    class VideoController : HardwareInfo
    {
        public VideoController(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_VideoController";
            headers = new string[] { "Name", "AdapterDACType", "AdapterRAM", "DeviceID", "DriverVersion", "DriverDate" };
            DBHeaders = new string[] { "Name", "AdapterDACType", "AdapterRAM", "DeviceID" };
        }
        public List<string> CheckConfigData(JSONConfigFile jsonFile)
        {
            List<Dictionary<string, string>> configData = jsonFile.DeserialezeAndLoad(className);
            return base.CheckConfigData(configData);
        }
    }
}
