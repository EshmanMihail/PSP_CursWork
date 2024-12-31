using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary
{
    /// <summary>
    /// Интерфейс объекта для сетевого взаимодействия
    /// </summary>
    public interface INetworkHandler
    {
        /// <summary>
        /// Событие получения данных по сети
        /// </summary>
        event Action<object> OnDataGot;

        /// <summary>
        /// Обновление данных
        /// </summary>
        /// <param name="obj">Объект для передачи по сети</param>
        /// <typeparam name="T">Тип объекта для передачи по сети</typeparam>
        void UpdateData<T>(T obj);

        /// <summary>
        /// Очистка случшителей событий
        /// </summary>
        void ClearListeners();
    }
}
