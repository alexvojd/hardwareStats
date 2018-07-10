using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HDInfoServer
{
    class DataBase
    {
        MySqlConnection connector;
 
        public DataBase()
        {
            string connString = "server=localhost;user=root;database=HardwareDB";
            connector = new MySqlConnection(connString);
            connector.Open();

        }

        public string CheckConnection()
        {
            string result = "Connection Successful!";
            try
            {
                connector.Open();
            }
            catch(Exception e)
            {
                result = "Connection failed";
            }
            return result;
        }

        public List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();

            string sql = "Select * from Rooms";

            MySqlCommand cmd = new MySqlCommand(sql, connector);
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.id = Convert.ToInt32(reader.GetValue(0));
                        int nameIndex = reader.GetOrdinal("name");
                        room.name = reader.GetString(nameIndex);
                        rooms.Add(room);
                    }
                }
            }

            return rooms;
        }

        public List<Computer> GetAllComps()
        {
            List<Computer> comps = new List<Computer>();

            string sql = "Select * from Computers";

            MySqlCommand cmd = new MySqlCommand(sql, connector);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Computer comp = new Computer();
                        comp.id = Convert.ToInt32(reader.GetValue(0));
                        int nameIndex = reader.GetOrdinal("name");
                        comp.name = reader.GetString(nameIndex);
                        comps.Add(comp);
                    }
                }
            }

            return comps;
        }

        public List<ChangeHistoryItem> GetHistory(int computer_id)
        {
            List<ChangeHistoryItem> history = new List<ChangeHistoryItem>();

            string sql = "Select * from ChangesHistory where computer_id='"+computer_id+"'";

            MySqlCommand cmd = new MySqlCommand(sql, connector);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ChangeHistoryItem historyItem = new ChangeHistoryItem();

                        historyItem.id = Convert.ToInt32(reader.GetValue(0));

                        int deviceType = reader.GetOrdinal("deviceType");
                        historyItem.deviceType = reader.GetString(deviceType);

                        int deviceID = reader.GetOrdinal("deviceID");
                        historyItem.deviceID = Convert.ToInt32(reader.GetValue(deviceID));

                        int header = reader.GetOrdinal("header");
                        historyItem.header = reader.GetString(header);

                        int valueBefore = reader.GetOrdinal("valueBefore");
                        historyItem.valueBefore = reader.GetString(valueBefore);

                        int valueAfter = reader.GetOrdinal("valueAfter");
                        historyItem.valueAfter = reader.GetString(valueAfter);

                        int changeSubmit = reader.GetOrdinal("changeSubmit");
                        historyItem.changeSubmit = reader.GetString(changeSubmit);

                        int updatedAt = reader.GetOrdinal("updatedAt");
                        historyItem.updatedAt = reader.GetString(updatedAt);

                        historyItem.computer_id = computer_id;

                        history.Add(historyItem);
                    }
                }
            }

            return history;
        }

        public List<Computer> GetComputersByRoom(string room)
        {
            List<Computer> computers = new List<Computer>();

            string sql = "Select comp.id, comp.name, comp.status, comp.updatedAt, comp.room_id " +
                "from Computers comp join Rooms room on " +
                "comp.room_id=room.id " +
                "where room.name='"+room+"'";

            MySqlCommand cmd = new MySqlCommand(sql, connector);
            
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Computer computer = new Computer();
                        computer.id = Convert.ToInt32(reader.GetValue(0));

                        int nameIndex = reader.GetOrdinal("name");
                        computer.name = reader.GetString(nameIndex);

                        int statusIndex = reader.GetOrdinal("status");
                        computer.status = reader.GetString(statusIndex);

                        int updatedAtIndex = reader.GetOrdinal("updatedAt");
                        computer.updatedAt = reader.GetString(updatedAtIndex);

                        computer.room_id = Convert.ToInt32(reader.GetValue(4));

                        computers.Add(computer);
                    }
                }
            }

            return computers;
        }

        public void updateDevice(ChangeHistoryItem item)
        {
            string sql = "update "+ item.deviceType +" set "+ item.header + " = '" + item.valueBefore + "' where id = '" + item.deviceID + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();

        }

        public void accept_change(int item_id)
        {
            string sql = "update ChangesHistory set changeSubmit = 'Подтверждено' where id = '" + item_id + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();
        }

        public void accept_Allchanges(int computer_id)
        {
            string sql = "update ChangesHistory set changeSubmit = 'Подтверждено' where computer_id = '" + computer_id + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();
        }

        public void insertChange(ChangeHistoryItem item)
        {
            string sql = "insert into ChangesHistory(deviceType, deviceID, header, valueBefore, valueAfter, changeSubmit, updatedAt, computer_id) " +
                "values('" + item.deviceType + "', '" + item.deviceID + "', '" + item.header + "', '" + item.valueBefore + "', '" + item.valueAfter + 
                "', '" + item.changeSubmit + "', '" + 
                DateNowParsed() + "', '" + item.computer_id + "')";

            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();
        }

        public void insertRoom(string name)
        {
            string sql = "insert into Rooms(name) " + "values('" + name + "')";

            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();
        }


        public bool checkComputer(int computer_id)
        {
            bool result = false;
            string sql = "Select * from Computers where id = " + computer_id;

            MySqlCommand cmd = new MySqlCommand(sql, connector);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    result = true;
                }
            }
            return result;
        }

        public void checkCompState(int computer_id)
        {
            bool result = false;
            string sql = "Select * from ChangesHistory where computer_id = '" + computer_id + "' and changeSubmit = 'Не подтверждено'";

            MySqlCommand cmd = new MySqlCommand(sql, connector);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return;
                }
            }
            string sql_upd = "update Computers set status = 'Подтвержден' where id = '" + computer_id + "'";
            MySqlCommand cmd_upd = new MySqlCommand(sql_upd, connector);
            cmd_upd.ExecuteNonQuery();
        }

        public bool checkCompData(int computer_id)
        {
            bool result = false;
            string sql = "Select * from Processors where computer_id = " + computer_id;

            MySqlCommand cmd = new MySqlCommand(sql, connector);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    result = true;
                }
            }
            return result;
        }

        public void insertComp(Computer computer) { 

            string sql = "insert into Computers(name,status,room_id) values('" + computer.name + "', '"
                + computer.status +  "', '" + computer.room_id + "')";
            
            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();
        }

        public void DelComp(int comp_id)
        {
            string sql = "delete from Computers where id = '" + comp_id + "'";

            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();
        }

        public void DelRoom(int room_id)
        {
            string sql = "delete from Rooms where id = '" + room_id + "'";

            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();
        }

        public void insertDevices<T>(T device, int comp_id)
        {
            dynamic d_device = device;

            StringBuilder sqlHeaders = new StringBuilder();
            foreach (string header in d_device.DBHeaders)
            {
                sqlHeaders.Append(header + ", ");
            }
            sqlHeaders.Length = sqlHeaders.Length - 2;

            string sql_template = "insert into " + d_device.tableName + " (" + sqlHeaders + ") values ('"; 

            List<Dictionary<string,string>> d_data = d_device.data;

            d_data.ForEach(delegate (Dictionary<string, string> device_in_data)
            {
                StringBuilder sql = new StringBuilder(sql_template);
                foreach(KeyValuePair<string,string> node in device_in_data)
                {
                    sql.Append(node.Value+"', '");
                }
                sql.Length = sql.Length - 1;
                sql.Append(comp_id.ToString() + ")");
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), connector);
                cmd.ExecuteNonQuery();

            });
        }

        public List<Dictionary<string, string>> getDeviceData<T>(T device, int computer_id)
        {
            dynamic d_device = device;

            string sql = "select * from " + d_device.tableName + " where computer_id = '" + computer_id + "'";

            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            MySqlCommand cmd = new MySqlCommand(sql, connector);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    d_device.ids = new List<int>();
                    while (reader.Read())
                    {
                        int iter = 0;

                        Dictionary<string, string> device_in_data = new Dictionary<string, string>();

                        int id = Convert.ToInt32(reader.GetValue(0));
                        d_device.ids.Add(id);

                        foreach(string header in d_device.DBHeaders)
                        {
                            if (d_device.headers.Length == iter) break;
                            int headerIndex = reader.GetOrdinal(header);
                            string headerValue = reader.GetString(headerIndex);
                            device_in_data.Add(d_device.headers[iter], headerValue);
                            iter++;
                        }

                        data.Add(device_in_data);
                    }
                }
                else
                {
                    return null;
                }

            }

            return data;
        }

        public List<int> getIdDevice(string table, int computer_id)
        {
            List<int> id = new List<int>();

            string sql = "Select id from " + table + " where computer_id=" + computer_id;

            MySqlCommand cmd = new MySqlCommand(sql, connector);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id.Add(Convert.ToInt32(reader.GetValue(0)));
                    }
                }
            }

            return id;
        }

        public string DateNowParsed()
        {
            DateTime now = DateTime.Now;
            string month = (now.Month >= 10) ? now.Month.ToString() : "0" + now.Month.ToString();
            string year = now.Year.ToString();
            string day = (now.Day >= 10) ? now.Day.ToString() : "0" + now.Day.ToString();
            string hours = (now.Hour >= 10) ? now.Hour.ToString() : "0"+ now.Hour.ToString();
            string minutes = (now.Minute >= 10) ? now.Minute.ToString() : "0" + now.Minute.ToString();
            string seconds = (now.Second >= 10) ? now.Second.ToString() : "0" + now.Second.ToString();
            string date = year + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds;
            return date;
        }

        public void updateCompState(int computer_id, string status)
        {
            string sql = "update Computers set updatedAt = '" + DateNowParsed() + "', status = '" + status + "' where id=" + computer_id;
            MySqlCommand cmd = new MySqlCommand(sql, connector);
            cmd.ExecuteNonQuery();
        }
    }
}
