using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HDInfoServer
{
    /// <summary>
    /// Логика взаимодействия для ServerConfig.xaml
    /// </summary>
    public partial class ServerConfig : Window
    {
        DataBase hardwareDB;
        List<Room> rooms;
        List<Computer> comps;
        public ServerConfig()
        {
            InitializeComponent();
            hardwareDB = new DataBase();
            ComboCompBoxFilling();
            ComboRoomBoxFilling();
            comps = hardwareDB.GetAllComps();
            rooms = hardwareDB.GetRooms();
            connectFill();
        }

        private void DelRoom_btn(object sender, RoutedEventArgs e)
        {
            int room_id = rooms[rooms_cb2.SelectedIndex].id;
            hardwareDB.DelRoom(room_id);
            ComboRoomBoxFilling();
            MessageBox.Show("Аудитория успешно удалена");
        }
        private void AddComp_btn(object sender, RoutedEventArgs e)
        {
            Computer comp = new Computer();
            comp.name = computerName.Text;
            comp.status = "Подтвержден";
            int room_index = rooms_cb1.SelectedIndex;
            comp.room_id = rooms[room_index].id;
            hardwareDB.insertComp(comp);
            ComboCompBoxFilling();
            MessageBox.Show("Компьютер успешно добавлен");
        }
        private void DelComp_btn(object sender, RoutedEventArgs e)
        {
            int comp_id =  comps[comps_cb.SelectedIndex].id;
            hardwareDB.DelComp(comp_id);
            ComboCompBoxFilling();
            MessageBox.Show("Компьютер успешно удален");
        }
        private void AddRoom_btn(object sender, RoutedEventArgs e)
        {
            string roomname = roomName.Text;
            hardwareDB.insertRoom(roomname);
            ComboRoomBoxFilling();
            MessageBox.Show("Аудитория успешно добавлена");
        }
        private void Back_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ComboRoomBoxFilling()
        {
            rooms_cb1.Items.Clear();
            rooms_cb2.Items.Clear();
            if (rooms != null) rooms.Clear();
            rooms = hardwareDB.GetRooms();
            rooms.ForEach(delegate (Room room)
            {
                var textBlock1 = new TextBlock();
                var textBlock2 = new TextBlock();
                textBlock1.Text = room.name;
                textBlock2.Text = room.name;
                rooms_cb1.Items.Add(textBlock1);
                rooms_cb2.Items.Add(textBlock2);
            });
        }

        private void ComboCompBoxFilling()
        {
            comps_cb.Items.Clear();
            if(comps != null) comps.Clear();
            comps = hardwareDB.GetAllComps();
            comps.ForEach(delegate (Computer comp)
            {
                var textBlock = new TextBlock();
                textBlock.Text = comp.name;
                comps_cb.Items.Add(textBlock);

            }); 
        }
        private void changeConn_btn(object sender, RoutedEventArgs e)
        {
            string[] newConnection = new string[2];
            newConnection[0] = serverIP_tb.Text;
            newConnection[1] = serverPort_tb.Text;
            if (serverIP_tb.Text == "")
            {
                newConnection[0] = "localhost";
            }
            if (serverPort_tb.Text == "")
            {
                newConnection[1] = "11000";
            }
            JSONConfigFile.SetServerConnectionStr(newConnection);
            MessageBox.Show("Соединение успешно изменено");
        }

        private void connectFill()
        {
            JSONConfigFile file = new JSONConfigFile();
            string[] currentConn = JSONConfigFile.GetServerConnectionStr();
            serverIP_tb.Text = currentConn[0];
            serverPort_tb.Text = currentConn[1];
        }
    }
}
