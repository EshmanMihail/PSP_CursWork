using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Map
{
    /// <summary>
    /// Статический класс событий игры
    /// </summary>
    public static class GameEvents
    {
        /// <summary>
        /// Делегат события изменения количества топлива
        /// </summary>
        /// <param name="tagPlayer">Тег игрового объекта игрока</param>
        /// <param name="value">Значение собранных монет</param>
        public delegate void FuelDelegate(string tagPlayer, float value);

        /// <summary>
        /// Событие изменения количества топлива
        /// </summary>
        public static FuelDelegate ChangeFuel { get; set; }

        /// <summary>
        /// Делегат события изменения количества скорости
        /// </summary>
        /// <param name="tagPlayer">Тег игрового объекта игрока</param>
        /// <param name="value">Значение собранных монет</param>
        public delegate void TiresDelegate(string tagPlayer, bool value);

        /// <summary>
        /// Событие изменения количества скорости
        /// </summary>
        public static TiresDelegate ChangeTires { get; set; }

        /// <summary>
        /// Делегат события изменения количества кругов
        /// </summary>
        /// <param name="tagPlayer">Тег игрового объекта игрока</param>
        /// <param name="value">Значение собранных монет</param>
        public delegate void LapsDelegate(string tagPlayer, int value);


        public static SlowingDelegate ChangeSlowing { get; set; }

        /// <summary>
        /// Делегат события изменения количества кругов
        /// </summary>
        /// <param name="tagPlayer">Тег игрового объекта игрока</param>
        /// <param name="value">Значение собранных монет</param>
        public delegate void SlowingDelegate(string tagPlayer, int count, bool value);


        /// <summary>
        /// Событие изменения количества кругов
        /// </summary>
        /// 
        public static LapsDelegate ChangeLaps { get; set; }

        /// <summary>
        /// Делегат события окончания игры
        /// </summary>
        public delegate void EndGameDelegate(string winPlayer);

        /// <summary>
        /// Событие окончания игры
        /// </summary>
        public static EndGameDelegate EndGame { get; set; }
    }
}
