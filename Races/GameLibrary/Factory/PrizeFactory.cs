using EngineLibrary;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Factory
{
    public abstract class PrizeFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position">Позиция появления</param>
        /// <returns>Игровой объект</returns>
        public abstract GameObject CreatePrize(Vector2 position);
    }
}
