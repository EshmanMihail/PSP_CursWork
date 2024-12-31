using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary
{
    public class Server : INetworkHandler, IDisposable
    {
        private IPAddress _ip = IPAddress.Any;
        private const int port = 8080;

        private UdpClient _udpServer;
        private IPEndPoint _endPoint;

        public event Action<object> OnDataGot;

        public Server()
        {
            _endPoint = new IPEndPoint(_ip, port);
            _udpServer = new UdpClient(port);
        }

        public void ClearListeners()
        {
            OnDataGot = null;
        }

        public void Dispose()
        {
            _udpServer.Dispose();
        }

        public void UpdateData<T>(T obj)
        {
            try
            {
                byte[] bytes = _udpServer.Receive(ref _endPoint);

                string message = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                T clientData = JsonConvert.DeserializeObject<T>(message);

                SendResponse<T>(obj, _endPoint);

                Console.WriteLine("Получено1-" + clientData.ToString());

                OnDataGot?.Invoke(clientData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void SendResponse<T>(T obj, IPEndPoint iP)
        {
            string message = JsonConvert.SerializeObject(obj);
            byte[] bytes = Encoding.UTF8.GetBytes(message);

            var result = _udpServer.Send(bytes, bytes.Length, iP);
            Console.WriteLine("Отправлено1-" + obj.ToString());
        }
    }
}
