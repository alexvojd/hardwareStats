using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Management;


namespace HDInfoClient
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
        string serializedData;

        public MainWindow()
        {
            InitializeComponent();
            InitGridView();
            InitHardwareInfo();
            InitConfigFiles();
            //ComboDataBox.SelectedItem = "Операционная система";
            CheckConfigFiles();
            string[] connCfg = JSONConfigFile.GetClientConnectionStr();
            //connectionCFG
            // 0 - IP
            // 1 - PORT
            // 2 - computer_id
            serializedData = GetSerializedPacket(connCfg[2]);
            ClientSocket socket = new ClientSocket();
            if (!socket.TryToSendDataToServer(connCfg, serializedData))
            {
                MessageBox.Show("Соединение с сервером не установлено");
            }
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
                case "Win32_OperatingSystem":
                    operationSystem.ShowData();
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
                default:
                    return;
            }                        
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void InitGridView()
        {
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
            jsonConfigFile = new JSONConfigFile();

            processor = new Processor(ref ManufactureListView);
            processor.GetData();
 
            operationSystem = new OperationSystem(ref ManufactureListView);
            operationSystem.GetData();

            videoController = new VideoController(ref ManufactureListView);
            videoController.GetData();

            physicalMemory = new PhysicalMemory(ref ManufactureListView);
            physicalMemory.GetData();

            diskDrive = new DiskDrive(ref ManufactureListView);
            diskDrive.GetData();

            baseBoard = new BaseBoard(ref ManufactureListView);
            baseBoard.GetData();

            bios = new Bios(ref ManufactureListView);
            bios.GetData();

            networkAdapter = new NetworkAdapter(ref ManufactureListView);
            networkAdapter.GetData();
            networkAdapter.DeleteNoDataNetAdapters();

            //desktopMonitor = new DesktopMonitor(ref ManufactureListView);
            //desktopMonitor.GetData();
        }

        private void CheckConfigFiles()
        {
            List<string> alertMessages = new List<string>();

            alertMessages.AddRange(processor.CheckConfigData(jsonConfigFile));

            alertMessages.AddRange(operationSystem.CheckConfigData(jsonConfigFile));

            alertMessages.AddRange(videoController.CheckConfigData(jsonConfigFile));

            alertMessages.AddRange(physicalMemory.CheckConfigData(jsonConfigFile));

            alertMessages.AddRange(diskDrive.CheckConfigData(jsonConfigFile));

            alertMessages.AddRange(baseBoard.CheckConfigData(jsonConfigFile));

            alertMessages.AddRange(bios.CheckConfigData(jsonConfigFile));

            alertMessages.AddRange(networkAdapter.CheckConfigData(jsonConfigFile));

            //alertMessages.AddRange(desktopMonitor.CheckConfigData(jsonConfigFile));

            alertMessages.ForEach(delegate (string message)
            {
                MessageBox.Show(message);
            });
        }

        private void InitConfigFiles()
        {
            if (!jsonConfigFile.IsConfigFileExists(processor.className))
            {
                jsonConfigFile.SerializeAndSave(processor.className, processor.data);
            }

            if (!jsonConfigFile.IsConfigFileExists(operationSystem.className))
            {
                jsonConfigFile.SerializeAndSave(operationSystem.className, operationSystem.data);
            }

            if (!jsonConfigFile.IsConfigFileExists(videoController.className))
            {
                jsonConfigFile.SerializeAndSave(videoController.className, videoController.data);
            }

            if (!jsonConfigFile.IsConfigFileExists(physicalMemory.className))
            {
                jsonConfigFile.SerializeAndSave(physicalMemory.className, physicalMemory.data);
            }

            if (!jsonConfigFile.IsConfigFileExists(diskDrive.className))
            {
                jsonConfigFile.SerializeAndSave(diskDrive.className, diskDrive.data);
            }

            if (!jsonConfigFile.IsConfigFileExists(baseBoard.className))
            {
                jsonConfigFile.SerializeAndSave(baseBoard.className, baseBoard.data);
            }

            if (!jsonConfigFile.IsConfigFileExists(bios.className))
            {
                jsonConfigFile.SerializeAndSave(bios.className, bios.data);
            }

            if (!jsonConfigFile.IsConfigFileExists(networkAdapter.className))
            {
                jsonConfigFile.SerializeAndSave(networkAdapter.className, networkAdapter.data);
            }

           // if (!jsonConfigFile.IsConfigFileExists(desktopMonitor.className))
           // {
           //     jsonConfigFile.SerializeAndSave(desktopMonitor.className, desktopMonitor.data);
           // }
            
        }
        public string GetSerializedPacket(string computer_id)
        {
            DataPacket packet = new DataPacket();
            if(computer_id != "")
            {
                packet.computer_id = Int32.Parse(computer_id);
            }
            packet.processors = processor.GetDataForServer();
            packet.videoControllers = videoController.GetDataForServer();
            packet.diskDrives = diskDrive.GetDataForServer();
            packet.baseBoard = baseBoard.GetDataForServer();
            packet.networkAdapters = networkAdapter.GetDataForServer();
            packet.physicalMemories = physicalMemory.GetDataForServer();
            packet.bios = bios.GetDataForServer();
            return jsonConfigFile.SerializeData(packet);
        }

        public void ClientConfig_btn(object sender, RoutedEventArgs e)
        {
            AdminPass isAdm = new AdminPass("admin");
            if (isAdm.ShowDialog() == true)
            {
                ClientConfig cfg_w = new ClientConfig(serializedData);
                this.Hide();
                cfg_w.ShowDialog();
                this.Show();
                string[] connStr = JSONConfigFile.GetClientConnectionStr();
                ClientSocket socket = new ClientSocket();
                if (!socket.TryToSendDataToServer(connStr, GetSerializedPacket(connStr[2])))
                {
                    MessageBox.Show("Соединение с сервером не установлено");
                }
                else
                {
                    MessageBox.Show("Данные отправлены");
                }
            } 
        }
    }
}
