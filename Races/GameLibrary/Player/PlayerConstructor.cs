using EngineLibrary;
using GameLibrary.GameObjects;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class PlayerConstructor
    {
        /// <summary>
        /// Тег плеера
        /// </summary>
        public string PlayerTag { get; private set; }

        public Vector2 StartPosition { get; set; }

        private BasePlayer script;

        public PlayerConstructor(BasePlayer script)
        {
            this.script = script;
        }

        /// <summary>
        /// Создание игрового объекта персонажа
        /// </summary>
        /// <returns>Игровой объект</returns>
        public GameObject CreatePlayer(string path)
        {
            PlayerTag = path;

            var gameObject = new GameObject();
            gameObject.GameObjectTag = path;

            TexturesBox texture1;
            texture1 = new TexturesBox(ContentPipe.LoadTexture(path + "Car.png"));

            var script = this.script;
            script.Start(gameObject);

            gameObject.SetComponent(texture1);
            gameObject.SetComponent(script);
            gameObject.SetComponent(new TransformComponent(StartPosition, new Vector2(0.1f, 0.1f), new Vector2(0.3f, 0.5f), 0));
            gameObject.SetComponent(new ColliderComponent(gameObject, 0.5f, new Vector2(0, 0)));

            return gameObject;
        }
    }
}
