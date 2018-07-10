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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;


namespace HDInfoServer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Processor processor;
        OperationSystem operationSystem;
        VideoController videoController;
        PhysicalMemory physicalMemory;
        DiskDrive diskDrive;
        BaseBoard baseBoard;
        Bios bios;
        NetworkAdapter networkAdapter;
        JSONConfigFile jsonConfigFile;
        Computer computer;
        string roomName;
        DataBase hardwareDB;

        public MainWindow()
        {
            InitializeComponent();
        }        
        //Используется конструктор находящийся ниже
        public MainWindow(object computer, string roomName)
        {
            this.computer = (Computer)computer;
            hardwareDB = new DataBase();
            this.roomName = roomName;
            InitializeComponent();
            InitGridView();
            InitHardwareInfo();

        }
        private void ComboBoxSelected(object sender, RoutedEventArgs e)
        {
            if (processor == null) return;
            ComboBox comboBox = (ComboBox)sender;
            TextBlock textBox = (TextBlock)comboBox.SelectedItem;
            ManufactureListView.Items.Clear();
            JSONConfigFile jsonConfigFile = new JSONConfigFile();
            switch (textBox.Name)
            {
                case "Win32_Processor":
                    processor.ShowData();
                    break;
                case "Win32_VideoController":
                    videoController.ShowData();
                    break;
                case "Win32_PhysicalMemory":
                    physicalMemory.ShowData();
                    break;
                case "Win32_DiskDrive":
                    diskDrive.ShowData();
                    break;
                case "Win32_BaseBoard":
                    baseBoard.ShowData();
                    break;
                case "Win32_BIOS":
                    bios.ShowData();
                    break;
                case "Win32_NetworkAdapterConfiguration":
                    networkAdapter.ShowData();
                    break;
            }                        
        }

        private void Back_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InitGridView()
        {
            if (roomName != null)
            {
                CompNameLabel.Content = computer.name;
                CompRoomLabel.Content = roomName;
                CompNameLabel.Visibility = Visibility.Visible;
                CompRoomLabel.Visibility = Visibility.Visible;
            }
            var gridView = new GridView();
            ManufactureListView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Заголовок",
                DisplayMemberBinding = new Binding("Header")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Сведения",
                DisplayMemberBinding = new Binding("Data")
            });
        }
        private void InitHardwareInfo()
        {
            
                processor = new Processor(ref ManufactureListView);
                processor.data = hardwareDB.getDeviceData(processor, computer.id);

                videoController = new VideoController(ref ManufactureListView);
                videoController.data = hardwareDB.getDeviceData(videoController, computer.id); ;

                physicalMemory = new PhysicalMemory(ref ManufactureListView);
                physicalMemory.data = hardwareDB.getDeviceData(physicalMemory, computer.id);

                diskDrive = new DiskDrive(ref ManufactureListView);
                diskDrive.data = hardwareDB.getDeviceData(diskDrive, computer.id);

                baseBoard = new BaseBoard(ref ManufactureListView);
                baseBoard.data = hardwareDB.getDeviceData(baseBoard, computer.id);

                bios = new Bios(ref ManufactureListView);
                bios.data = hardwareDB.getDeviceData(bios, computer.id);

                networkAdapter = new NetworkAdapter(ref ManufactureListView);
                networkAdapter.data = hardwareDB.getDeviceData(networkAdapter, computer.id);

            
        }


        public void BtnOpenHistoryPK_Click(object sender, RoutedEventArgs e)
        {
            CHistoryWindow historyWindow = new CHistoryWindow(this.computer.id, this.computer.name, this.roomName);
            this.Hide();
            historyWindow.ShowDialog();
            this.ShowDialog();
        }

    }
}
