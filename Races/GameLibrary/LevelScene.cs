using EngineLibrary;
using NetworkLibrary;
using OpenTK;
using System;
using System.Collections.Generic;
using GameLibrary.GameObjects;
using GameLibrary.Map;
using GameLibrary.Network;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class LevelScene : Scene
    {
        public static LevelScene instance;

        private NetworkManager networkManager;

        public List<Vector2> EmptyBlocks { get; private set; } = new List<Vector2>();

        /// <summary>
        /// Конструктор первого игрока
        /// </summary>
        public PlayerConstructor PlayerOneFactory { get; set; }
        /// <summary>
        /// Конструктор второго игрока
        /// </summary>
        public PlayerConstructor PlayerTwoFactory { get; set; }

        private GameObject playerOne;
        private GameObject playerTwo;

        private GameObject[] map;

        private GameObject spawnManager;

        public LevelScene(INetworkHandler handler, string hostPlayer, string networkPlayer)
        {
            instance = this;

            var playerScript = new Player();
            var networkPlayerScript = new NetworkPlayer();

            if (hostPlayer == "PlayerOne")
            {
                PlayerOneFactory = new PlayerConstructor(playerScript);
                PlayerTwoFactory = new PlayerConstructor(networkPlayerScript);

                Maps track = new Maps(this);
                //maze.CreateGameObjectsOnScene();
                map = track.CreateMap();

                EmptyBlocks = track.EmptyBlocks;

                playerOne = PlayerOneFactory.CreatePlayer("PlayerOne");
                playerTwo = PlayerTwoFactory.CreatePlayer("PlayerTwo");

                var gameObject3 = new GameObject();
                gameObject3.SetComponent(new TransformComponent(new Vector2(0f, 0f), new Vector2(1, 1), new Vector2(1, 1), 0));
                gameObject3.GameObjectTag = "GameManager";

                var script3 = new SpawnManager(this);
                script3.Start(gameObject3);

                gameObject3.SetComponent(script3);

                spawnManager = gameObject3;
            }
            else
            {
                PlayerTwoFactory = new PlayerConstructor(playerScript);
                PlayerOneFactory = new PlayerConstructor(networkPlayerScript);

                Maps track = new Maps(this);
                //maze.CreateGameObjectsOnScene();
                map = track.CreateMap();

                EmptyBlocks = track.EmptyBlocks;

                playerTwo = PlayerOneFactory.CreatePlayer("PlayerOne");
                playerOne = PlayerTwoFactory.CreatePlayer("PlayerTwo");
            }

            networkManager = new NetworkManager(handler, playerOne, playerTwo);
            networkManager.OnWriteData += playerScript.WriteNetworkData;
            networkManager.OnUpdateData += networkPlayerScript.UpdateNetworkData;
            game.OnSceneDrawed += networkManager.UpdateData;
        }

        public override void Init()
        {
            game.AddObjectOnScene(map);
            game.AddObjectOnScene(playerOne);
            game.AddObjectOnScene(playerTwo);

            if (spawnManager != null)
                game.AddObjectOnScene(spawnManager);
        }

        public void UpdatePrize(PrizeNetworkData data)
        {
            networkManager.CurrentPlayerNetworkData.PrizeData = data;
        }

        protected override void EndScene(string end)
        {
            string winPlayer;

            if (Player.BPLaps < Player.RPLaps)
                winPlayer = PlayerTwoFactory.PlayerTag;
            else
                winPlayer = PlayerOneFactory.PlayerTag;

            GameEvents.EndGame?.Invoke(winPlayer);
        }

        /// <summary>
        /// Рандомное место на карте
        /// </summary>
        /// <returns>Позицию</returns>
        public Vector2 GetRandomPosition()
        {
            Random random = new Random();

            int index = random.Next(0, EmptyBlocks.Count);

            Vector2 position = EmptyBlocks[index];

            EmptyBlocks.Remove(position);

            return position * game.HeightOfApplication / 15;
        }
    }
}
