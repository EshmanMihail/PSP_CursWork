using EngineLibrary;
using GameLibrary.GameObjects;
using GameLibrary.Network;
using GameLibrary.Prize;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Factory
{
    public class SpeedPrizeFactory : PrizeFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">Позиция появления</param>
        /// <returns>Игровой объект</returns>
        public override GameObject CreatePrize(Vector2 position)
        {
            LevelScene.instance?.UpdatePrize(new PrizeNetworkData() { Id = (int)TypePrize.Speed, Position = new[] { position.X, position.Y } });

            GameObject gameObject = new GameObject();
            gameObject.SetComponent(new TransformComponent(position, new Vector2(0.15f, 0.15f), new Vector2(1f, 1f), 0));
            gameObject.SetComponent(new TexturesBox(ContentPipe.LoadTexture("MazeElements/Prize/tire.png")));
            gameObject.SetComponent(new ColliderComponent(gameObject, 0.5f, new Vector2(10, 5)));
            gameObject.GameObjectTag = "Spawn";

            PrizeSpawn speedPrize = new PrizeSpawn();
            speedPrize.InitializePrizeSpawn(TypeProperty.Tires, true, 10);

            speedPrize.Start(gameObject);

            gameObject.SetComponent(speedPrize);

            return gameObject;
        }
    }
}
