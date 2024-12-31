using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    public class GameObject : IDisposable
    {
        /// <summary>
        /// Свойство, хранящее текстуру объекта
        /// </summary>
        public virtual TexturesBox Texture { get; protected set; }

        /// <summary>
        /// Класс, хранящее позицию объекта
        /// </summary>
        public virtual TransformComponent Transform { get; protected set; }

        /// <summary>
        /// Сценарий выполения
        /// </summary>
        public virtual ObjectScript Script { get; protected set; }

        public virtual ColliderComponent Collider { get; protected set; }

        /// <summary>
        /// Тэг игрового объекта
        /// </summary>
        public string GameObjectTag { get; set; }

        /// <summary>
        /// Активность игрового объекта
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Конструктор игрового объекта.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="scale"></param>
        /// <param name="position"></param>
        public GameObject()
        {
            //Texture = null;
            //Script = null;
            //Collider = null;
            //Transform = null;
        }

        public virtual void SetComponent(object component)
        {
            switch (component)
            {
                case TexturesBox textureBox:
                    Texture = textureBox;
                    break;
                case ObjectScript objectScript:
                    Script = objectScript;
                    break;
                case ColliderComponent systemCollider:
                    Collider = systemCollider;
                    break;
                case TransformComponent transform:
                    Transform = transform;
                    break;
            }
        }

        public void Update()
        {
            if (Collider != null)
                Collider.SetIsInactive(!IsActive);

            if (Script != null)
                Script.Update(this);

            //if (!IsActive || (ParentGameObject != null && !ParentGameObject.IsActive)) return;
        }

        public void Dispose()
        {

        }
    }
}
