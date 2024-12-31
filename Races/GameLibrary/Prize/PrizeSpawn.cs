using EngineLibrary;
using GameLibrary.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Prize
{
    public class PrizeSpawn : ObjectScript
    {
        private Game maze;
        private PlayerProperities dropOutPrize;
        private TypeProperty typeProperty;
        private float cuurentTimeToDisappear;
        private int value;
        private bool valueBool;

        public void InitializePrizeSpawn(PlayerProperities playerProperities, float disappearTime)
        {
            dropOutPrize = playerProperities;
            cuurentTimeToDisappear = Time.CurrentTime + disappearTime;
        }

        public void InitializePrizeSpawn(TypeProperty typeProperty, int value, float disappearTime)
        {
            this.typeProperty = typeProperty;
            this.value = value;
            cuurentTimeToDisappear = Time.CurrentTime + disappearTime;
        }

        public void InitializePrizeSpawn(TypeProperty typeProperty, bool value, float disappearTime)
        {
            this.typeProperty = typeProperty;
            valueBool = value;
            cuurentTimeToDisappear = Time.CurrentTime + disappearTime;
        }

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start(GameObject gameObject = null)
        {
            maze = Game.instance;
        }

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update(GameObject gameObject)
        {
            if (cuurentTimeToDisappear < Time.CurrentTime)
            {
                maze.AddObjectsToRemove(gameObject);
            }

            if (gameObject.Collider.CheckGameObjectIntersection(out GameObject player, "PlayerOne", "PlayerTwo"))
            {
                if (dropOutPrize == null)
                {
                    if (typeProperty == TypeProperty.Tires)
                    {
                        (player.Script as BasePlayer).Property.Tires = valueBool;
                        PlayerInteractionSpeedUp(player);
                    }
                    else if (typeProperty == TypeProperty.Slowing)
                    {
                        (player.Script as BasePlayer).Property.Slowing = valueBool;
                        PlayerInteractionSlowing(player);
                    }
                    else
                        (player.Script as BasePlayer).Property.SetProperty(typeProperty, value);
                }
                else
                    (player.Script as BasePlayer).Property = dropOutPrize;

                maze.AddObjectsToRemove(gameObject);
            }
        }

        public void PlayerInteractionSpeedUp(GameObject playerGameObject)
        {
            (playerGameObject.Script as BasePlayer).Property.Tires = true;
            (playerGameObject.Script as BasePlayer).Property = new SpeedDecorator((playerGameObject.Script as BasePlayer).Property);
            (playerGameObject.Script as BasePlayer).ChangeStatsValue(playerGameObject, true);
        }

        public void PlayerInteractionSlowing(GameObject playerGameObject)
        {
            (playerGameObject.Script as BasePlayer).Property.Slowing = true;
            (playerGameObject.Script as BasePlayer).Property = new SlowDecorator((playerGameObject.Script as BasePlayer).Property);
            (playerGameObject.Script as BasePlayer).ChangeStatsValue(playerGameObject, 11, true);
        }
    }
}
