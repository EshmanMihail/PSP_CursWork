using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace NetworkLibrary
{
    public class Client : INetworkHandler, IDisposable
    {
        private string ip = "192.168.148.1";
        private const int port = 8080;

        public event Action OnStartGame;

        private Socket _udpClientScoket;
        private IPEndPoint _endPoint;

        public event Action<object> OnDataGot;

        public Client(string ip)
        {
            this.ip = ip;
            _endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            _udpClientScoket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public void ClearListeners()
        {
            OnDataGot = null;
        }

        public void Dispose()
        {
            _udpClientScoket.Dispose();
        }

        public void UpdateData<T>(T obj)
        {
            try
            {
                string message = JsonConvert.SerializeObject(obj);
                byte[] bytes = Encoding.UTF8.GetBytes(message);

                var result = _udpClientScoket.SendTo(bytes, _endPoint);

                //Console.Clear();
                //Console.WriteLine("Отправлено0-" + obj.ToString());

                GetData<T>();

                //OnDataGot?.Invoke(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Получение данных
        /// </summary>
        /// <typeparam name="T">Тип получаемых данных</typeparam>
        public void GetData<T>()
        {
            try
            {
                byte[] bytes = new byte[512];
                _udpClientScoket.Connect(_endPoint);
                int length = _udpClientScoket.Receive(bytes);
                string message = Encoding.UTF8.GetString(bytes, 0, length);

                T serverData = JsonConvert.DeserializeObject<T>(message);

                OnDataGot?.Invoke(serverData);
                Console.WriteLine("Получено0-" + serverData.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
