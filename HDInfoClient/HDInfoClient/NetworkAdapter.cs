using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoClient
{
    class NetworkAdapter : HardwareInfo
    {
        public NetworkAdapter(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_NetworkAdapterConfiguration";
            headers = new string[] { "Description", "ServiceName", "DefaultIPGateway", "DNSServerSearchOrder", "IPAddress", "IPSubnet", "MACAddress" };
            DBHeaders = new string[] { "Description", "ServiceName", "DefaultIPGateway", "DNSServerSearchOrder", "IPAddress", "IPSubnet", "MACAddress" };
        }

        public void DeleteNoDataNetAdapters()
        {
            List<Dictionary<string, string>> deletingItems = new List<Dictionary<string, string>>(data);
            int iterCount = headers.Length;
            deletingItems.ForEach(delegate (Dictionary<string, string> device_in_data)
            {
                try
                {
                    var noData = device_in_data.First(kvp => kvp.Value == "Данные устройством не передаются");
                    data.Remove(device_in_data);
                }
                catch (Exception e)
                {
                    
                }
                                
            });
            
        }
        public List<string> CheckConfigData(JSONConfigFile jsonFile)
        {
            List<Dictionary<string, string>> configData = jsonFile.DeserialezeAndLoad(className);
            return base.CheckConfigData(configData);
        }
    }
}
