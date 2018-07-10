using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDInfoServer
{
    class ChangeHistoryItem 
    {
        public int id;
        public string deviceType;
        public int deviceID;
        public string header;
        public string valueBefore;
        public string valueAfter;
        public string changeSubmit;
        public string updatedAt;
        public int computer_id;

    }
}
