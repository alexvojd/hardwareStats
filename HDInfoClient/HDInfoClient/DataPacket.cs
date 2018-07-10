using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDInfoClient
{
    class DataPacket
    {
        public int computer_id;
        public List<Dictionary<string, string>> processors;
        public List<Dictionary<string, string>> bios;
        public List<Dictionary<string, string>> baseBoard;
        public List<Dictionary<string, string>> diskDrives;
        public List<Dictionary<string, string>> physicalMemories;
        public List<Dictionary<string, string>> networkAdapters;
        public List<Dictionary<string, string>> videoControllers;

    }
}
