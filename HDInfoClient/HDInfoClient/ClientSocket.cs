using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace HDInfoClient
{
    class ClientSocket
    {
        public void SendDataInJSON(string[] connStr, string serializedData)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry(connStr[0]);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, Int32.Parse(connStr[1]));

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);

            byte[] msg = Encoding.UTF8.GetBytes(serializedData);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
        public bool TryToSendDataToServer(string[] connStr,string serializedPacket)
        {
            try
            {
                SendDataInJSON(connStr, serializedPacket);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


    }
}
