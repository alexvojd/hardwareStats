using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoClient
{
    class Processor : HardwareInfo
    {
        public Processor(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_Processor";
            headers = new string[] { "Name", "AddressWidth", "Description", "NumberOfCores", "ThreadCount" };
            DBHeaders = new string[] { "Name", "AddressWidth", "Description", "NumberOfCores", "ThreadCount" };
        }
        public List<string> CheckConfigData(JSONConfigFile jsonFile)
        {
            List<Dictionary<string, string>> configData = jsonFile.DeserialezeAndLoad(className);
            return base.CheckConfigData(configData);
        }
    }
}
