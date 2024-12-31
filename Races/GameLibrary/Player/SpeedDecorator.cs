using EngineLibrary;
using GameLibrary.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class SpeedDecorator : DecoratorProperty
    {
        public SpeedDecorator(PlayerProperities playerProperities) : base(playerProperities)
        {

        }

        /// <summary>
        /// Скорость
        /// </summary>
        public override float Speed { get => playerProperities.Speed * 1.5f; }

        protected override void DeactivateProperities(GameObject player)
        {
            if ((player.Script as Player).Property.Tires)
            {
                (player.Script as Player).ChangeStatsValue(player, false);
                (player.Script as Player).Property = new StandartProperities(Fuel);
            }
        }
    }
}
