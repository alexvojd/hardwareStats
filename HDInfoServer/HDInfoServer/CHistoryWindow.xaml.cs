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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class CHistoryWindow : Window
    {
        DataBase hardwareDB;
        List<ChangeHistoryItem> history;
        string adminPass = "admin";
        int computer_id;
        public CHistoryWindow(int computer_id, string computer_name, string room_name)
        {
            InitializeComponent();
            InitGridView(computer_name, room_name);
            this.computer_id = computer_id;
            FillListView();
        }

        private void InitGridView(string computer_name, string room_name)
        {
                CompNameLabel.Content = computer_name;
                CompRoomLabel.Content = room_name;
                CompNameLabel.Visibility = Visibility.Visible;
                CompRoomLabel.Visibility = Visibility.Visible;
            var gridView = new GridView();
            HistoryListView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "DeviceID",
                Width = 70,
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Устройство",
                Width = 120,
                DisplayMemberBinding = new Binding("DeviceType")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 120,
                Header = "Параметр",
                DisplayMemberBinding = new Binding("Header")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 120,
                Header = "Значение до",
                DisplayMemberBinding = new Binding("ValueBefore")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 120,
                Header = "Значение после",
                DisplayMemberBinding = new Binding("ValueAfter")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 130,
                Header = "Состояние",
                DisplayMemberBinding = new Binding("ChangeSubmit")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Дата обновления",
                DisplayMemberBinding = new Binding("UpdatedAt")
            });
           
        }

        public void FillListView()
        {
            hardwareDB = new DataBase();
            history = hardwareDB.GetHistory(computer_id);
            HistoryListView.Items.Clear();
            history.ForEach(delegate (ChangeHistoryItem historyItem)
            {
                HistoryListView.Items.Add(
                    new
                    {
                        Id = historyItem.deviceID,
                        DeviceType = historyItem.deviceType,
                        Header = historyItem.header,
                        ValueBefore = historyItem.valueBefore,
                        ValueAfter = historyItem.valueAfter,
                        ChangeSubmit = historyItem.changeSubmit,
                        UpdatedAt = historyItem.updatedAt,
                    });
            });
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ChangeSelected(object sender, RoutedEventArgs e)
        {

            int historyItemIndex = HistoryListView.SelectedIndex;
            if (historyItemIndex == -1)
            {
                return;
            }
            AdminPass passW = new AdminPass(adminPass);
            if (passW.ShowDialog() == true)
            {
                hardwareDB.accept_change(history[historyItemIndex].id);
                hardwareDB.checkCompState(computer_id);
            }
            FillListView();
        }
        public void AcceptAll_btn(object sender, RoutedEventArgs e)
        {
            AdminPass passW = new AdminPass(adminPass);
            if (passW.ShowDialog() == true)
            {
                hardwareDB.accept_Allchanges(history[0].computer_id);
            }
            FillListView();
            hardwareDB.checkCompState(computer_id);
        }
    }
}
