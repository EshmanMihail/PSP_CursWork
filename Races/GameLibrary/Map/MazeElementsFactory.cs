using EngineLibrary;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Map
{
    /// <summary>
    /// Класс фабрики создания элементов лабиринта 
    /// </summary>
    public class MazeElementsFactory
    {
        /// <summary>
        /// Создает элемент лабиринта
        /// </summary>
        /// <param name="position">Позиция объекта на сцене</param>
        /// <param name="TagName">Тег игрового объекта</param>
        /// <returns>Созданный игровой объект</returns>
        public GameObject CreateMazeElement(Vector2 position, string TagName)
        {
            float worldScale = Game.instance.HeightOfApplication / 15;

            GameObject gameObject = new GameObject();
            gameObject.SetComponent(new TexturesBox(ContentPipe.LoadTexture(@"MazeElements\" + TagName + ".png")));
            gameObject.SetComponent(new TransformComponent(new Vector2(position.X, position.Y), new Vector2(1, 1) * worldScale / gameObject.Texture.Texture.Width, new Vector2(0, 0), 0));

            gameObject.SetComponent(new ColliderComponent(gameObject, 1));

            gameObject.GameObjectTag = TagName;

            return gameObject;
        }

        /// <summary>
        /// Создает элемент лабиринта
        /// </summary>
        /// <param name="position">Позиция объекта на сцене</param>
        /// <param name="TagName">Тег игрового объекта</param>
        /// <returns>Созданный игровой объект</returns>
        public GameObject CreateFinish(Vector2 position, string TagName)
        {
            float worldScale = Game.instance.HeightOfApplication / 15;

            GameObject gameObject = new GameObject();
            gameObject.SetComponent(new TexturesBox(ContentPipe.LoadTexture(@"MazeElements\" + TagName + ".png")));
            gameObject.SetComponent(new TransformComponent(new Vector2(position.X, position.Y), new Vector2(1.25f, 1.25f) * worldScale / gameObject.Texture.Texture.Width, new Vector2(0, 0), 0));

            gameObject.SetComponent(new ColliderComponent(gameObject, 1));

            gameObject.GameObjectTag = TagName;

            return gameObject;
        }
    }
}
