using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Management;

namespace HDInfoClient
{
    class HardwareInfo
    {
        public ListView listView;
        public string[] headers;
        public string[] DBHeaders;
        public string className;
        public Dictionary<string, string> device;
        public List<Dictionary<string, string>> data;

        public void GetData()
        {
            data = new List<Dictionary<string, string>>();
            StringBuilder sqlHeaders = new StringBuilder();
            foreach (string header in headers)
            {
                sqlHeaders.Append(header + ", ");
            }
            sqlHeaders.Length = sqlHeaders.Length - 2;
            string sql = "select " + sqlHeaders + " from " + className;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(sql);
            foreach (ManagementObject share in searcher.Get())
            {
                device = new Dictionary<string, string>();
                string value;
                bool ignoreDevice = false;
                foreach (string header in headers)
                {
                                      
                    if (share[header] == null)
                    {

                        value = "Данные устройством не передаются";

                    }else
                    {

                        value = share[header].ToString();
                        switch (value)
                        {
                            case "System.String[]":
                                string[] undefinedString = (string[])share[header];

                                string stringValue = "";
                                foreach (string str in undefinedString)
                                    stringValue += str + " ";

                                value = stringValue;

                                break;
                            case "System.UInt16[]":
                                ushort[] undefinedInt = (ushort[])share[header];


                                string intValue = "";
                                foreach (ushort ush in undefinedInt)
                                    intValue += ush.ToString() + " ";

                                value = intValue;

                                break;

                            default:
                                
                                break;
                        }
                    }
                    if (value.Contains("USB"))
                    {
                        ignoreDevice = true;
                        break;
                    }
                    device.Add(header, value);
                }
                if (!ignoreDevice)
                {
                    data.Add(device);
                }
            }

        }

        protected List<string> CheckConfigData(List<Dictionary<string, string>> configData)
        {
            List<string> alertMessages = new List<string>();
            int iterCount = headers.Length;
            int currentDeviceNumber = 0;
            Dictionary<string,string>[] configDataArray = configData.ToArray<Dictionary<string, string>>();
            Dictionary<string, string> device_in_config = null;
            string deviceName = "";
            data.ForEach(delegate (Dictionary<string, string> device_in_data)
            {
                int iter = 0;
                try
                {
                    deviceName = device_in_data.First(kvp => kvp.Key == "Name").Value;
                }
                catch (Exception e)
                {
                    try
                    {
                        deviceName = device_in_data.First(kvp => kvp.Key == "Caption").Value;
                    }
                    catch(Exception e1)
                    {
                        deviceName = device_in_data.First(kvp => kvp.Key == "Description").Value;
                    }
                }
                try
                {
                    if (!configDataArray[currentDeviceNumber].Equals(device_in_data))
                    {
                        device_in_config = configDataArray[currentDeviceNumber];
                    }
                }
                catch(Exception e)
                {
                    
                }

                if (device_in_config.Count < device_in_data.Count)
                {
                    alertMessages.Add("Данное устройство в config-файле не найдено " + deviceName);
                    iter = iterCount;
                }

                for (; iter < iterCount; iter++)
                {
                    // Получаем очередную запись [Header => Value], параметр -> значение для очередного устройства
                    KeyValuePair<string, string> deviceNote = device_in_data.First(kvp => kvp.Key == headers[iter]);
                    KeyValuePair<string, string> configDeviceNote = device_in_config.First(kvp => kvp.Key == headers[iter]);
                    try
                    {
                        // Пытаемся найти такую же пару [ключ,значение] в девайсах из конфига
                        // Если такой записи нет, или она изменена выбрасывается исключение и мы летим в catch
                        device_in_config.First(kvp => kvp.Equals(deviceNote));

                    }
                    catch (Exception e)
                    {
                        alertMessages.Add("Параметр устройства " + deviceName + " был изменен! Параметр: " + deviceNote.Key + " бывшее значение: "+ deviceNote.Value + " текущее значение: " + configDeviceNote.Value);
                    }
                }
                currentDeviceNumber++;

            });
            return alertMessages;
        }

        public void ShowData()
        {
            int iterCount = headers.Length;
            data.ForEach(delegate (Dictionary<string, string> device_in_data)
            {
                for (int iter = 0; iter < iterCount; iter++)
                {
                    string header = headers[iter];
                    listView.Items.Add(new { Header = header, Data = device_in_data[header] });
                }
            });
        }

        public List<Dictionary<string, string>> GetDataForServer()
        {
            List<Dictionary<string, string>> DBData = new List<Dictionary<string, string>>();

            data.ForEach(delegate (Dictionary<string, string> device_in_data)
            {
                Dictionary<string, string> device_to_db = new Dictionary<string, string>();
                foreach (string header in DBHeaders)
                {
                    string value = device_in_data.First(kvp => kvp.Key == header).Value;
                    device_to_db.Add(header, value);
                }

                DBData.Add(device_to_db);

            });

            return DBData;
        }
    }
}
