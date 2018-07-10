using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoClient
{
    class PhysicalMemory : HardwareInfo
    {
        public PhysicalMemory(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_PhysicalMemory";
            headers = new string[] { "Name", "BankLabel", "Capacity", "FormFactor", "Manufacturer", "DataWidth", "SerialNumber" };
            DBHeaders = new string[] { "Name", "BankLabel", "Capacity", "Manufacturer", "DataWidth" };
        }
        public List<string> CheckConfigData(JSONConfigFile jsonFile)
        {
            List<Dictionary<string, string>> configData = jsonFile.DeserialezeAndLoad(className);
            return base.CheckConfigData(configData);
        }
    }
}
