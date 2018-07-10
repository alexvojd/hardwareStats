using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Management;

namespace HDInfoClient
{
    class BaseBoard : HardwareInfo
    {
        public BaseBoard(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_BaseBoard";
            headers = new string[] { "Name", "Manufacturer", "Product", "Status", "PoweredOn" };
            DBHeaders = new string[] { "Product", "Manufacturer" };
        }
        public List<string> CheckConfigData(JSONConfigFile jsonFile)
        {
            List<Dictionary<string, string>> configData = jsonFile.DeserialezeAndLoad(className);
            return base.CheckConfigData(configData);
        }
    }
}
