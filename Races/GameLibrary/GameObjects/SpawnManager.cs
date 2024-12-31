using EngineLibrary;
using GameLibrary.Factory;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameObjects
{
    /// <summary>
    /// Класс игрового менеджера
    /// </summary>
    public class SpawnManager : ObjectScript
    {
        private const float timeToSpawn = 2f;
        private float currentTimeToSpawn;

        private Game maze;
        private PrizeFactory[] spawnFactory;

        LevelScene levelScene;

        public SpawnManager(LevelScene levelScene)
        {
            this.levelScene = levelScene;
            spawnFactory = new[] {
                (PrizeFactory) new SpeedPrizeFactory(),
                new FuelPrizeFactory(),
                new SlowingPrizeFactory()
            };
        }

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start(GameObject gameObject)
        {
            maze = Game.instance;
            currentTimeToSpawn = Time.CurrentTime;
        }

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update(GameObject gameObject)
        {
            if (currentTimeToSpawn < Time.CurrentTime)
            {
                Random random = new Random();
                int chance = random.Next(0, 3);
                //chance = 2;

                if (levelScene.EmptyBlocks.Count == 0) return;

                Vector2 position = levelScene.GetRandomPosition();

                maze.AddObjectOnScene(spawnFactory[chance].CreatePrize(position));

                currentTimeToSpawn += timeToSpawn;
            }
        }
    }
}
