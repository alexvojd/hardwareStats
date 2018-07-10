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
    class HardwareInfo
    {
        public List<int> ids;
        public ListView listView;
        public string[] DBHeaders;
        public string[] headers;
        public string className;
        public Dictionary<string, string> device;
        public List<Dictionary<string, string>> data;
        public string tableName;

  

        public List<string> CheckDataDB(List<Dictionary<string, string>> db_data, int computer_id, DataBase db)
        {
            
            List<string> alertMessages = new List<string>();
            if (!db.checkComputer(computer_id))
            {
                return alertMessages;
            }
            ChangeHistoryItem historyItem;
            int iterCount = headers.Length;
            int currentDeviceNumber = 0;
            List<int> devices_id = new List<int>();
            Dictionary<string, string>[] configDataArray = null;
            Dictionary<string, string> device_in_config = null;
            string deviceName = "";
            if (db_data == null)
            {
                db.insertDevices(this, computer_id);
                devices_id = db.getIdDevice(tableName, computer_id);
            }
            else
            {
                configDataArray = db_data.ToArray<Dictionary<string, string>>();
            }
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
                    catch (Exception e1)
                    {
                        try
                        {
                            deviceName = device_in_data.First(kvp => kvp.Key == "Description").Value;
                        }
                        catch (Exception e2)
                        {
                            deviceName = device_in_data.First(kvp => kvp.Key == "Product").Value;
                        }
                    }
                }
                try
                {
                    if (!configDataArray[currentDeviceNumber].Equals(device_in_data))
                    {
                        device_in_config = configDataArray[currentDeviceNumber];
                    }
                }
                catch (Exception e)
                {

                }
                //Если устройство в базе данных не найдено
                if (device_in_config == null)
                {
                    for (; iter < iterCount; iter++)
                    {
                        // Получаем очередную запись [Header => Value], параметр -> значение для очередного устройства
                        KeyValuePair<string, string> deviceNote = device_in_data.First(kvp => kvp.Key == headers[iter]);

                        alertMessages.Add("Данное устройство в базе данных не найдено" + deviceName);
                        // Добавляем новое устройство в базу данных
                        
                        // Создаем запись в таблице изменений о добавлении нового устройства
                        historyItem = new ChangeHistoryItem();
                        historyItem.deviceType = tableName;
                        historyItem.header = deviceNote.Key;
                        historyItem.valueAfter = deviceNote.Value;
                        historyItem.valueBefore = " ";
                        historyItem.changeSubmit = "Не подтверждено";
                        historyItem.computer_id = computer_id;
                        historyItem.deviceID = devices_id[currentDeviceNumber];
                        db.insertChange(historyItem);
                    }
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
                        historyItem = new ChangeHistoryItem();
                        historyItem.deviceType = tableName;
                        List<int> device_id = db.getIdDevice(tableName,computer_id); 
                        historyItem.header = configDeviceNote.Key;
                        historyItem.valueAfter = deviceNote.Value;
                        historyItem.valueBefore = configDeviceNote.Value;
                        historyItem.changeSubmit = "Не подтверждено";
                        historyItem.computer_id = computer_id;
                        historyItem.deviceID = device_id[currentDeviceNumber];
                        db.insertChange(historyItem);
                        db.updateDevice(historyItem);
                        alertMessages.Add("Параметр устройства " + deviceName + " был изменен! Параметр: " + deviceNote.Key + " бывшее значение: " + deviceNote.Value + " текущее значение: " + configDeviceNote.Value);
                    }
                }
                currentDeviceNumber++;

            });
            return alertMessages;
        }

        public void ShowData(string[] headers = null)
        {
            if (headers == null)
            {
                headers = this.headers;
            }
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
    }
}
