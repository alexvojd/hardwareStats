using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDInfoServer
{
    class DataPacket
    {
        public int computer_id;
        public List<Dictionary<string, string>> processors;
        public List<Dictionary<string, string>> bios;
        public List<Dictionary<string, string>> baseBoard;
        public List<Dictionary<string, string>> diskDrives;
        public List<Dictionary<string, string>> physicalMemories;
        public List<Dictionary<string, string>> networkAdapters;
        public List<Dictionary<string, string>> videoControllers;

        public static void CheckDataPacket(string serializedPacket)
        {
            DataBase hardwareDB = new DataBase();
            DataPacket packet = JSONConfigFile.DeserializePacket(serializedPacket);
            List<Dictionary<string, string>> db_data;
            if (hardwareDB.checkComputer(packet.computer_id))
            {
                List<string> alertMessages = new List<string>();
                hardwareDB.updateCompState(packet.computer_id, "Не подтвержден");

                Processor processor = new Processor();
                processor.data = packet.processors;
                db_data = hardwareDB.getDeviceData(processor, packet.computer_id);
                //CheckDataDB записывает устройства в базу если их нет и сообщает о том, есть ли изменения в существующих устройствах в AlertMessages
                //с записью в базу данных изменений
                alertMessages.AddRange(processor.CheckDataDB(db_data, packet.computer_id, hardwareDB));

                VideoController videoController = new VideoController();
                videoController.data = packet.videoControllers;
                db_data = hardwareDB.getDeviceData(videoController, packet.computer_id);
                alertMessages.AddRange(videoController.CheckDataDB(db_data, packet.computer_id, hardwareDB));

                PhysicalMemory physicalMemory = new PhysicalMemory();
                physicalMemory.data = packet.physicalMemories;
                db_data = hardwareDB.getDeviceData(physicalMemory, packet.computer_id);
                alertMessages.AddRange(physicalMemory.CheckDataDB(db_data, packet.computer_id, hardwareDB));

                DiskDrive diskDrive = new DiskDrive();
                diskDrive.data = packet.diskDrives;
                db_data = hardwareDB.getDeviceData(diskDrive, packet.computer_id);
                alertMessages.AddRange(diskDrive.CheckDataDB(db_data, packet.computer_id, hardwareDB));

                BaseBoard baseBoard = new BaseBoard();
                baseBoard.data = packet.baseBoard;
                db_data = hardwareDB.getDeviceData(baseBoard, packet.computer_id);
                alertMessages.AddRange(baseBoard.CheckDataDB(db_data, packet.computer_id, hardwareDB));

                Bios bios = new Bios();
                bios.data = packet.bios;
                db_data = hardwareDB.getDeviceData(bios, packet.computer_id);
                alertMessages.AddRange(bios.CheckDataDB(db_data, packet.computer_id, hardwareDB));

                NetworkAdapter networkAdapter = new NetworkAdapter();
                networkAdapter.data = packet.networkAdapters;
                db_data = hardwareDB.getDeviceData(networkAdapter, packet.computer_id);
                alertMessages.AddRange(networkAdapter.CheckDataDB(db_data, packet.computer_id, hardwareDB));

            }

        }

    }
}
