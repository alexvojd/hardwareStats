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
    /// Логика взаимодействия для AdminPass.xaml
    /// </summary>
    public partial class AdminPass : Window
    {
        string adminPass;

        public AdminPass(string adminPass)
        {
            InitializeComponent();
            this.adminPass = adminPass;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if( Password.Text == adminPass)
            {
                this.DialogResult = true;
            }
            this.Close();
        }
    }
}
