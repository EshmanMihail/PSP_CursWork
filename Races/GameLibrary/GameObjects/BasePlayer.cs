using EngineLibrary;
using GameLibrary.Factory;
using GameLibrary.Map;
using OpenTK.Input;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EngineLibrary.Input;
using GameLibrary.Network;

namespace GameLibrary.GameObjects
{
    public enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }

    public class BasePlayer : ObjectScript
    {
        /// <summary>
        /// Возможность двигаться у игрока
        /// </summary>
        public bool IsCanMove { get; set; } = true;

        /// <summary>
        /// Проеханные круги
        /// </summary>
        public static int RPLaps { get; private set; } = 0;
        public static int BPLaps { get; private set; } = 0;

        public PlayerProperities Property { get; set; }

        protected float currSpeed = 0;
        protected float maxSpeed;
        protected Vector2 direction = new Vector2();

        public bool IsCheckPoint { get; set; } = false;

        protected float currentReloadTime;
        protected Vector2 view = new Vector2(0, 1);

        public override void Start(GameObject gameObject = null)
        {
            Property = new StandartProperities();
            Property.SetProperty(TypeProperty.Fuel, 30);
            Property.SetProperty(TypeProperty.Consumption, 0.1f);

            maxSpeed = Property.Speed;

            this.gameObject = gameObject;
        }

        public override void Update(GameObject gameObject)
        {
            Move(gameObject);
        }

        /// <summary>
        /// Запись сетевых данных об игроке
        /// </summary>
        /// <param name="manager">Менеджер сетевого взаимодействия</param>
        public void WriteNetworkData(NetworkManager manager)
        {
            manager.CurrentPlayerNetworkData.PlayerPosition[0] = gameObject.Transform.Position.X;
            manager.CurrentPlayerNetworkData.PlayerPosition[1] = gameObject.Transform.Position.Y;
            manager.CurrentPlayerNetworkData.Angle = gameObject.Transform.Angle;

            //Console.WriteLine("Отправил игрок: " + gameObject.GameObjectTag + " Data: ");
        }

        /// <summary>
        /// Обновление данные сетевого игрока
        /// </summary>
        /// <param name="manager">Менеджер сетевого взаимодействия</param>
        public void UpdateNetworkData(NetworkManager manager)
        {
            Vector2 pos = new Vector2(manager.NetworkPlayerNetworkData.PlayerPosition[0], manager.NetworkPlayerNetworkData.PlayerPosition[1]);

            gameObject.Transform.Position = pos;
            gameObject.Transform.Angle = manager.NetworkPlayerNetworkData.Angle;
            //Console.WriteLine("Получил игрок: " + gameObject.GameObjectTag + pos.ToString());
        }

        /// <summary>
        /// Метод движения игрока
        /// </summary>
        protected virtual void Move(GameObject gameObject)
        {
            DetectCollision(gameObject);
        }

        /// <summary>
        /// Изменение значения характеристик игрока
        /// </summary>
        public void ChangeStatsValue(GameObject gameObject, float value)
        {
            Property.SetProperty(TypeProperty.Fuel, Property.Fuel - value);
            GameEvents.ChangeFuel?.Invoke(gameObject.GameObjectTag, Property.Fuel);
        }

        /// <summary>
        /// Изменение значения характеристик игрока
        /// </summary>
        public void ChangeStatsValue(GameObject gameObject, bool value)
        {
            GameEvents.ChangeTires?.Invoke(gameObject.GameObjectTag, value);
        }

        public void ChangeStatsValue(GameObject gameObject, int count, bool value)
        {
            GameEvents.ChangeSlowing?.Invoke(gameObject.GameObjectTag, count, value);
        }

        public static void SetLaps(string tag, int value)
        {
            if (tag == "PlayerOne")
            {
                RPLaps += value;
                GameEvents.ChangeLaps?.Invoke(tag, RPLaps);
            }
            else
            {
                BPLaps += value;
                GameEvents.ChangeLaps?.Invoke(tag, BPLaps);
            }

            if (RPLaps == 5)
            {
                GameEvents.EndGame?.Invoke(tag);
            }
            else if (BPLaps == 5)
            {
                GameEvents.EndGame?.Invoke(tag);
            }
        }

        /// <summary>
        /// Распознавание столкновений и реакция на них
        /// </summary>
        protected void DetectCollision(GameObject gameObject)
        {
            if (gameObject.Collider.CheckGameObjectIntersection(out GameObject player, "PlayerOne", "PlayerTwo"))
            {
                player.Transform.SetMovement(view);
                gameObject.Transform.ResetMovement();
            }

            if (gameObject.Collider.CheckGameObjectIntersection(out GameObject wall, "Wall"))
            {
                maxSpeed = Property.Speed / 50;
            }
            else
                maxSpeed = Property.Speed;

            if (gameObject.Collider.CheckGameObjectIntersection(out GameObject checkPoint, "CheckPoint"))
            {
                IsCheckPoint = true;
            }

            if (gameObject.Collider.CheckGameObjectIntersection(out GameObject start, "Start") && IsCheckPoint)
            {
                SetLaps(gameObject.GameObjectTag, 1);

                IsCheckPoint = false;
            }
        }
    }
}
