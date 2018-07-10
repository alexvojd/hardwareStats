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

namespace NikitaServer
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();
        }

        private void InitGridView()
        {
            var gridView = new GridView();
            HistoryListView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Устройство",
                DisplayMemberBinding = new Binding("device")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Параметр",
                DisplayMemberBinding = new Binding("header")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Значение было",
                DisplayMemberBinding = new Binding("valueBefore")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Значение стало",
                DisplayMemberBinding = new Binding("valueAfter")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Состояние изменения",
                DisplayMemberBinding = new Binding("changeSubmit")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Дата изменения",
                DisplayMemberBinding = new Binding("updatedAt")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Действие",
                DisplayMemberBinding = new Binding("btnSumbit")
            });
        }
    }
}
