using EngineLibrary;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Network
{
    public class NetworkData
    {
        /// <summary>
        /// Позиция игрока
        /// </summary>
        public float[] PlayerPosition { get; set; }

        public float Angle { get; set; }

        public PrizeNetworkData PrizeData { get; set; }

        public override string ToString()
        {
            return "x: " + PlayerPosition[0] + " y: " + PlayerPosition[1];
        }
    }
}
