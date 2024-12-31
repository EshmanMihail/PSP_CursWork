using EngineLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameObjects
{
    public abstract class PlayerProperities
    {
        protected Player player;

        protected float timeDeactivate = 2;
        protected float timer = 0;

        public abstract float Fuel { get; protected set; }

        public abstract bool Tires { get; set; }

        public abstract bool Slowing { get; set; }

        public abstract float Speed { get; protected set; }

        public abstract float Consumption { get; protected set; }

        public virtual void SetProperty(TypeProperty type, float value)
        {
            switch (type)
            {
                case TypeProperty.Fuel:
                    Fuel = value;
                    break;
                case TypeProperty.Consumption:
                    Consumption = value;
                    break;
            }
        }

        public virtual void UpdateTime(GameObject player)
        {
            timer += Time.DeltaTime;

            if (timer >= timeDeactivate)
            {
                timer = 0;
                DeactivateProperities(player);
            }
        }

        protected abstract void DeactivateProperities(GameObject player);
    }
}
