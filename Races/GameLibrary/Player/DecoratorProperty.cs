using EngineLibrary;
using GameLibrary.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class DecoratorProperty : PlayerProperities
    {
        protected PlayerProperities playerProperities;
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="playerProperities"></param>
        public DecoratorProperty(PlayerProperities playerProperities)
        {
            this.playerProperities = playerProperities;
        }

        public override float Fuel { get => playerProperities.Fuel; protected set => playerProperities.SetProperty(TypeProperty.Fuel, value); }

        public override bool Tires { get => playerProperities.Tires; set => playerProperities.Tires = value; }

        public override bool Slowing { get => playerProperities.Slowing; set => playerProperities.Slowing = value; }

        public override float Speed { get => playerProperities.Speed; protected set => playerProperities.SetProperty(TypeProperty.Speed, value); }

        public override float Consumption { get => playerProperities.Consumption; protected set => playerProperities.SetProperty(TypeProperty.Consumption, value); }

        protected override void DeactivateProperities(GameObject player)
        {
            (player.Script as Player).Property = new StandartProperities();
        }
    }
}
