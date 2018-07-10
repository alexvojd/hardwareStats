using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HDInfoServer
{
    class VideoController : HardwareInfo
    {
        public VideoController(ref ListView listView)
        {
            this.listView = listView;
            className = "Win32_VideoController";
            tableName = "VideoAdapters";
            headers = new string[] { "Name", "AdapterDACType", "AdapterRAM", "DeviceID" };
            DBHeaders = new string[] { "name", "adapterType", "adapterRAM", "deviceID", "computer_id" };
        }

        public VideoController()
        {
            tableName = "VideoAdapters";
            className = "Win32_VideoController";
            headers = new string[] { "Name", "AdapterDACType", "AdapterRAM", "DeviceID" };
            DBHeaders = new string[] { "name", "adapterType", "adapterRAM", "deviceID", "computer_id" };
        }

    }
}
