using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    /// <summary>
    /// Абстрактный класс сценария поведения игрового объекта
    /// </summary>
    public abstract class ObjectScript
    {
        protected GameObject gameObject;

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public abstract void Start(GameObject gameObject = null);

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public abstract void Update(GameObject gameObject);
    }
}
