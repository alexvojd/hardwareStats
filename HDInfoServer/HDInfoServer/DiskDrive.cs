using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoServer
{
    class DiskDrive : HardwareInfo
    {
        public string Name;
        public string Index;
        public string Caption;
        public string Size;
        public string BytesPerSector;
        public string Capabilities;
        public string Manufacturer;
        public string FirmwareRevision;

        public DiskDrive(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_DiskDrive";
            tableName = "DiskDrivers";
            headers = new string[] { "Caption", "Size", "SerialNumber", "Manufacturer", "FirmwareRevision" };
            DBHeaders = new string[] { "caption", "size", "serialNumber", "manufacturer", "firmwareRev", "computer_id" };
        }
        public DiskDrive()
        {
            tableName = "DiskDrivers";
            className = "Win32_DiskDrive";
            headers = new string[] { "Caption", "Size", "SerialNumber", "Manufacturer", "FirmwareRevision" };
            DBHeaders = new string[] { "caption", "size", "serialNumber", "manufacturer", "firmwareRev", "computer_id" };
        }
    }
}
