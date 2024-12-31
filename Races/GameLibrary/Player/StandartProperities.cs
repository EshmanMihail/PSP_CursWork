using EngineLibrary;
using GameLibrary.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    /// <summary>
    /// Класс с характеристиками игрока
    /// </summary>
    public class StandartProperities : PlayerProperities
    {
        public StandartProperities() { }

        public StandartProperities(float currentFuel)
        {
            Fuel = currentFuel;
        }


        public override bool Slowing { get; set; } = false;

        public override float Speed { get; protected set; } = 400;

        public override float Fuel { get; protected set; }

        public override bool Tires { get; set; } = false;

        public override float Consumption { get; protected set; } = 0.1f;

        protected override void DeactivateProperities(GameObject player)
        {

        }
    }
}
