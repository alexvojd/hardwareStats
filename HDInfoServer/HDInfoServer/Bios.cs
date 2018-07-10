using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoServer
{
    class Bios : HardwareInfo
    {
        public string Name;
        public string BIOSVersion;
        public string CurrentLanguage;
        public string Manufacturer;
        public string SerialNumber;
        public string ReleaseDate;

        public Bios(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_BIOS";
            tableName = "Bios";
            headers = new string[] { "Name", "BIOSVersion", "CurrentLanguage", "Manufacturer", "SerialNumber" };
            DBHeaders = new string[] { "name", "biosVersion", "language", "manufacturer", "serialNumber", "computer_id" };
        }

        public Bios()
        {
            className = "Win32_BIOS";
            tableName = "Bios";
            headers = new string[] { "Name", "BIOSVersion", "CurrentLanguage", "Manufacturer", "SerialNumber" };
            DBHeaders = new string[] { "name", "biosVersion", "language", "manufacturer", "serialNumber", "computer_id" };
        }

    }
}
