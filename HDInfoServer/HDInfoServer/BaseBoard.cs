using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Management;

namespace HDInfoServer
{
    class BaseBoard : HardwareInfo
    {
        public string Name;
        public string Manufacturer;
        public string Product;
        public string Status;
        public string PoweredOn;

        public BaseBoard(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_BaseBoard";
            tableName = "BaseBoards";
            headers = new string[] {  "Product", "Manufacturer" };
            DBHeaders = new string[] { "product", "manufacturer", "computer_id" };

        }
        public BaseBoard()
        {
            className = "Win32_BaseBoard";
            tableName = "BaseBoards";
            headers = new string[] { "Product", "Manufacturer" };
            DBHeaders = new string[] { "product", "manufacturer", "computer_id" };
        }
    }
}
