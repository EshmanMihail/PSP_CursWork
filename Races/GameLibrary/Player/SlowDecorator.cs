using EngineLibrary;
using GameLibrary.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class SlowDecorator : DecoratorProperty
    {
        public SlowDecorator(PlayerProperities playerProperities) : base(playerProperities)
        {

        }

        public override float Speed { get => playerProperities.Speed / 30; }

        protected override void DeactivateProperities(GameObject player)
        {
            if ((player.Script as Player).Property.Slowing)
            {
                (player.Script as Player).ChangeStatsValue(player, 11, false);
                (player.Script as Player).Property = new StandartProperities(Fuel);
            }
        }
    }
}
