using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoServer
{
    class NetworkAdapter : HardwareInfo
    {
        public NetworkAdapter(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_NetworkAdapterConfiguration";
            tableName = "NetworkAdapters";
            headers = new string[] { "Description", "ServiceName", "DefaultIPGateway", "DNSServerSearchOrder", "IPAddress", "IPSubnet", "MACAddress" };
            DBHeaders = new string[] { "description", "serviceName", "ipGateway", "dnsServer", "ipAddress", "ipSubnet", "macAddress", "computer_id" };

        }

        public NetworkAdapter()
        {
            tableName = "NetworkAdapters";
            className = "Win32_NetworkAdapterConfiguration";
            headers = new string[] { "Description", "ServiceName", "DefaultIPGateway", "DNSServerSearchOrder", "IPAddress", "IPSubnet", "MACAddress" };
            DBHeaders = new string[] { "description", "serviceName", "ipGateway", "dnsServer", "ipAddress", "ipSubnet", "macAddress", "computer_id" };
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
    }
}
