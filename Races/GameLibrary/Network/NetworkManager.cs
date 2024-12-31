using GameLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkLibrary;
using EngineLibrary;
using GameLibrary.Prize;

namespace GameLibrary.Network
{
    public class NetworkManager
    {
        /// <summary>
        /// Событие записи данных
        /// </summary>
        public event Action<NetworkManager> OnWriteData;
        /// <summary>
        /// Событие обновления данных
        /// </summary>
        public event Action<NetworkManager> OnUpdateData;

        private INetworkHandler networkHandler;
        /// <summary>
        /// Данные текущего игрока
        /// </summary>
        public NetworkData CurrentPlayerNetworkData { get; private set; }
        /// <summary>
        /// Данные игрока по сети
        /// </summary>
        public NetworkData NetworkPlayerNetworkData { get; private set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="networkHandler">Обработчик сетевого взаимодействия</param>
        public NetworkManager(INetworkHandler networkHandler, GameObject host, GameObject network)
        {
            this.networkHandler = networkHandler;
            CurrentPlayerNetworkData = new NetworkData()
            {
                PlayerPosition = new[] { host.Transform.Position.X, host.Transform.Position.Y }
            };

            NetworkPlayerNetworkData = new NetworkData()
            {
                PlayerPosition = new[] { network.Transform.Position.X, network.Transform.Position.Y }
            };
            networkHandler.OnDataGot += OnDataGot;
        }

        /// <summary>
        /// Обновление данных
        /// </summary>
        public void UpdateData()
        {
            OnWriteData?.Invoke(this);
            networkHandler.UpdateData(CurrentPlayerNetworkData);
        }

        /// <summary>
        /// Событие, когда данные по сети получены
        /// </summary>
        /// <param name="data">Данные</param>
        private void OnDataGot(object data)
        {
            NetworkPlayerNetworkData = (NetworkData)data;
            var prizeData = NetworkPlayerNetworkData.PrizeData;

            if (prizeData != null)
            {
                PrizeFactory spawnFactory;
                TypePrize id = (TypePrize)prizeData.Id;

                if (TypePrize.Speed == id)
                {
                    spawnFactory = new SpeedPrizeFactory();
                }
                else if (TypePrize.Fuel == id)
                {
                    spawnFactory = new FuelPrizeFactory();
                }
                else
                {
                    spawnFactory = new SlowingPrizeFactory();
                }

                Game.instance.AddObjectOnScene(spawnFactory.CreatePrize(new OpenTK.Vector2(prizeData.Position[0], prizeData.Position[1])));
            }

            CurrentPlayerNetworkData.PrizeData = null;
            NetworkPlayerNetworkData.PrizeData = null;

            OnUpdateData?.Invoke(this);
        }
    }
}
