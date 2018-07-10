using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoServer
{
    class Processor : HardwareInfo
    {
        public Processor(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_Processor";
            tableName = "Processors";
            headers = new string[] { "Name", "AddressWidth", "Description", "NumberOfCores", "ThreadCount" };
            DBHeaders = new string[] { "name", "addressWidth", "description", "countOfCores", "threadCount", "computer_id" };
        }
        public Processor()
        {
            className = "Win32_Processor";
            tableName = "Processors";
            headers = new string[] { "Name", "AddressWidth", "Description", "NumberOfCores", "ThreadCount" };
            DBHeaders = new string[] { "name", "addressWidth", "description", "countOfCores", "threadCount", "computer_id" };
        }
    }
}
