using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoClient
{
    class OperationSystem : HardwareInfo
    {
        public OperationSystem(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_OperatingSystem";
            headers = new string[] { "Caption", "SerialNumber", "OSType", "RegisteredUser", "BuildNumber", "Version", "WindowsDirectory", "FreePhysicalMemory", "FreeVirtualMemory" };

        }
        public List<string> CheckConfigData(JSONConfigFile jsonFile)
        {
            List<Dictionary<string, string>> configData = jsonFile.DeserialezeAndLoad(className);
            return base.CheckConfigData(configData);
        }
    }
}
