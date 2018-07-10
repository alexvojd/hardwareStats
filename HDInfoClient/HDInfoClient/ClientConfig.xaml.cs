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

namespace HDInfoClient
{
    /// <summary>
    /// Логика взаимодействия для ClientConfig.xaml
    /// </summary>
    public partial class ClientConfig : Window
    {
        string serializedPacket;
        public ClientConfig(string serializedPacket)
        {
            InitializeComponent();
            string[] connStr = JSONConfigFile.GetClientConnectionStr();
            Ip_tb.Text = connStr[0];
            Port_tb.Text = connStr[1];
            Comp_tb.Text = connStr[2];
            this.serializedPacket = serializedPacket;
        }

        private void SendData_btn(object sender, RoutedEventArgs e)
        {
            ClientSocket socket = new ClientSocket();
            if (!socket.TryToSendDataToServer(JSONConfigFile.GetClientConnectionStr(),serializedPacket))
            {
                MessageBox.Show("Соединение с сервером не установлено");
            }
            else
            {
                MessageBox.Show("Данные отправлены");
            }
        }
        private void Back_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ChangeCfg_btn(object sender, RoutedEventArgs e)
        {
            string[] newConnection = new string[3];
            newConnection[0] = Ip_tb.Text;
            newConnection[1] = Port_tb.Text;
            newConnection[2] = Comp_tb.Text;
            if (Ip_tb.Text == "")
            {
                newConnection[0] = "localhost";
            }
            if (Port_tb.Text == "")
            {
                newConnection[1] = "11000";
            }
            if (Comp_tb.Text == "")
            {
                newConnection[2] = "";
            }
            JSONConfigFile.SetClientConnectionStr(newConnection);
            MessageBox.Show("Соединение успешно изменено");
        }
    }
}
