using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace HDInfoClient
{
    class JSONConfigFile
    {
        string fileDir;

        public JSONConfigFile(string fileDir = "")
        {
            this.fileDir = fileDir;
        }

        public void SerializeAndSave(string fileName, List<Dictionary<string, string>> data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            string filePath = fileDir + fileName + ".json";
            File.WriteAllText(filePath, serializedData);
        }

        public List<Dictionary<string, string>> DeserialezeAndLoad(string fileName)
        {
            string filePath = fileDir + fileName + ".json";
            string serializedData = File.ReadAllText(filePath);
            List<Dictionary<string, string>> data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(serializedData);
            return data;
        }

        public string SerializeData<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }


        public bool IsConfigFileExists(string fileName)
        {
            string filePath = fileDir + fileName + ".json";
            return File.Exists(filePath);
        }

        public static DataPacket DeserializePacket(string serializedPacket)
        {
            return JsonConvert.DeserializeObject<DataPacket>(serializedPacket);
        }

        public static string[] GetClientConnectionStr()
        {
            string[] connection = new string[3];
            try
            {
                connection = JsonConvert.DeserializeObject<string[]>(File.ReadAllText("clientcfg.json"));
            }
            catch (Exception e)
            {
                connection[0] = "localhost";
                connection[1] = "11000";
                connection[2] = "";
            }


            return connection;
        }

        public static void SetClientConnectionStr(string[] newConnection)
        {

            File.WriteAllText("clientcfg.json", JsonConvert.SerializeObject(newConnection));
        }

    }
}
