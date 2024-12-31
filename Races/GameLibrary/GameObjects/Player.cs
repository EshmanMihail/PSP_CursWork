using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineLibrary;
using GameLibrary;
using GameLibrary.Factory;
using GameLibrary.Map;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using static EngineLibrary.Input;
using static GameLibrary.GameObjects.BasePlayer;

namespace GameLibrary.GameObjects
{
    public class Player : BasePlayer
    {
        /// <summary>
        /// Управление игроком
        /// </summary>
        public PlayerControl Control { get; private set; }

        public override void Start(GameObject gameObject = null)
        {
            base.Start(gameObject);

            if (gameObject.GameObjectTag == "PlayerOne")
                Control = new PlayerControl(AxisOfInput.Horizontal, AxisOfInput.Vertical);
            else if (gameObject.GameObjectTag == "PlayerTwo")
                Control = new PlayerControl(AxisOfInput.AlternativeHorizontal, AxisOfInput.AlternativeVertical);
        }

        public override void Update(GameObject gameObject)
        {
            Console.WriteLine("Klaw: " + gameObject.GameObjectTag);

            if (gameObject.IsActive && IsCanMove)
                Move(gameObject);

            if (Property != null)
                Property.UpdateTime(gameObject);

            //base.Update(gameObject);
        }

        protected override void Move(GameObject gameObject)
        {
            int directionX, directionY;

            directionX = Input.GetAxis(Control.HorizontalAxis);
            directionY = Input.GetAxis(Control.VerticalAxis);

            if (directionY == 0)
            {
                SpeedDown(100);
                ChangeStatsValue(gameObject, Property.Consumption * Time.DeltaTime);
            }
            else
                ChangeStatsValue(gameObject, Property.Consumption * Time.DeltaTime * 4);

            if (Property.Fuel > 0)
            {
                if (directionX > 0 && currSpeed > 0)
                {
                    //gameObject.Texture.Set("Right");
                    gameObject.Transform.SetAngle(0.01f * currSpeed * Time.DeltaTime);
                }
                else if (directionX < 0 && currSpeed > 0)
                {
                    gameObject.Transform.SetAngle(-0.01f * currSpeed * Time.DeltaTime);
                    //gameObject.Texture.Set("Left");
                }

                if (directionY > 0)
                {
                    //gameObject.Texture.Set("Down");
                    if (direction == new Vector2(1, 1) && currSpeed > 0)
                        SpeedDown(300);
                    else
                    {
                        direction = new Vector2(-1, -1);
                        SpeedUp(100);
                    }
                }
                else if (directionY < 0)
                {
                    //gameObject.Texture.Set("Up");

                    if (direction == new Vector2(-1, -1) && currSpeed > 0)
                        SpeedDown(200);
                    else
                    {
                        direction = new Vector2(1, 1);
                        SpeedUp(100);
                    }
                }
            }

            view = direction;

            view.X *= (float)Math.Cos(gameObject.Transform.Angle);
            view.Y *= (float)Math.Sin(gameObject.Transform.Angle);

            gameObject.Transform.SetMovement(view * currSpeed * Time.DeltaTime);

            base.Move(gameObject);
        }

        private void SpeedUp(float value)
        {
            if (currSpeed < maxSpeed)
            {
                currSpeed += value * Time.DeltaTime;
            }
            else if (currSpeed > maxSpeed)
                SpeedDown(value);
        }

        private void SpeedDown(float value)
        {
            if (currSpeed > 0)
            {
                currSpeed -= value * Time.DeltaTime;
            }
            else if (currSpeed < 0)
            {
                currSpeed = 0;
            }
        }

        /// <summary>
        /// Структура игрового управления персонажа
        /// </summary>
        public struct PlayerControl
        {
            /// <summary>
            /// Горизонтальная ось передвижения
            /// </summary>
            public AxisOfInput HorizontalAxis { get; private set; }
            /// <summary>
            /// Вертикальная ось передвижения
            /// </summary>
            public AxisOfInput VerticalAxis { get; private set; }

            /// <summary>
            /// Конструктор структуры
            /// </summary>
            /// <param name="horizontalAxis">Горизонтальная ось передвижения</param>
            /// <param name="verticalAxis"> Вертикальная ось передвижения</param>
            public PlayerControl(AxisOfInput horizontalAxis, AxisOfInput verticalAxis)
            {
                HorizontalAxis = horizontalAxis;
                VerticalAxis = verticalAxis;
            }
        }
    }
}
