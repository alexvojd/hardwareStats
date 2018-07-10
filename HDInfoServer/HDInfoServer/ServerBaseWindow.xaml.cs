using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для ServerBaseWindow.xaml
    /// </summary>
    public partial class ServerBaseWindow : Window
    {
        DataBase hardwareDB;
        List<Computer> computers;
        JSONConfigFile jsonConfigFile;
        Thread myThread;

        public ServerBaseWindow()
        {
            InitializeComponent();
            hardwareDB = new DataBase();
            ComboBoxFilling();
            InitGridView();
            myThread = new Thread(new ThreadStart(StartServer));
            myThread.Start();
            //AsyncServerSocket.AsynchronousSocketListener.StartListening();
        }

        public void StartServer()
        {
            AsyncServerSocket.AsynchronousSocketListener.StartListening();
        }

        private void InitGridView()
        {
            var gridView = new GridView();
            ComputersListView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "ID",
                Width = 30  ,
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Компьютер",
                Width = 80,
                DisplayMemberBinding = new Binding("CompName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 120,
                Header = "Статус",
                DisplayMemberBinding = new Binding("Status")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Дата последнего обновления",
                DisplayMemberBinding = new Binding("UpdDate")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "room_id",
                Width = 50,
                DisplayMemberBinding = new Binding("RoomId")
            });
        }

        private void ComboBoxFilling()
        {
            List<Room> rooms = hardwareDB.GetRooms();
            rooms.ForEach(delegate (Room room)
            {
                var textBox = new TextBlock();
                textBox.Text = room.name;
                ComboRoomBox.Items.Add(textBox);
            });
        }

        private void ComboRoomBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock textBox = (TextBlock)comboBox.SelectedItem;
            computers = hardwareDB.GetComputersByRoom(textBox.Text);
            ComputersListView.Items.Clear();
            computers.ForEach(delegate (Computer computer)
            {
                ComputersListView.Items.Add(
                    new
                    {
                        Id = computer.id,
                        CompName = computer.name,
                        Status = computer.status,
                        UpdDate = computer.updatedAt,
                        RoomId = computer.room_id
                    });
            });
        }

        private void ComputerSelected(object sender, SelectionChangedEventArgs e)
        {
            int compIndex = ComputersListView.SelectedIndex;
            if(compIndex == -1)
            {
                return;
            }
            Computer computer = computers[compIndex];
            TextBlock room = (TextBlock)ComboRoomBox.SelectedItem;
            MainWindow mainW = new MainWindow(computer, room.Text);
            if (hardwareDB.checkCompData(computer.id))
            {
                this.Hide();
                mainW.ShowDialog();
                this.ShowDialog();
            }
            else
            {
                MessageBox.Show("Данный компьютер еще не подключался к серверу.");
            }
            
            
        }

        private void Exit_Btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void App_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myThread.Abort();
            System.Windows.Application.Current.Shutdown();
        }

        private void ServerConfig_btn(object sender, RoutedEventArgs e)
        {
            AdminPass admPass = new AdminPass("admin");
            if(admPass.ShowDialog() == true)
            {
                ServerConfig windowCfg = new ServerConfig();
                this.Hide();
                windowCfg.ShowDialog();
                ComboRoomBox.Items.Refresh();
                ComputersListView.Items.Refresh();
                this.ShowDialog();
            }
        }
    }

}
