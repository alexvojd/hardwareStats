using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoServer
{
    class PhysicalMemory : HardwareInfo
    {
        public PhysicalMemory(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_PhysicalMemory";
            tableName = "PhysicalMemories";
            headers = new string[] { "Name", "BankLabel", "Capacity", "Manufacturer", "DataWidth" };
            DBHeaders = new string[] { "name", "bankLabel", "capacity", "manufacturer", "dataWidth", "computer_id" };
        }

        public PhysicalMemory()
        {
            tableName = "PhysicalMemories";
            className = "Win32_PhysicalMemory";
            headers = new string[] { "Name", "BankLabel", "Capacity", "Manufacturer", "DataWidth" };
            DBHeaders = new string[] { "name", "bankLabel", "capacity", "manufacturer", "dataWidth", "computer_id" };
        }
    }
}
