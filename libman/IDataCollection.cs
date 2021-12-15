using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Общий интерфейс коллекций данных.
    /// </summary>
    /// <typeparam name="TData">Тип объекта данных.</typeparam>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    public interface IDataCollection<TData, TKey>: IEnumerable<TData>
        where TKey : IComparable<TKey>
        where TData : IKeyed<TKey>
    {

        #region Свойства

        /// <summary>
        /// Признак модифицированности данных коллекции.
        /// </summary>
        bool Modified { get; set; }

        /// <summary>
        /// Признак отсутствия данных в коллекции.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Признак заполненности таблицы (невозможности добавления новых
        /// данных в таблицу).
        /// </summary>
        bool IsFull { get; }

        /// <summary>
        /// Проверка наличия в коллекции данных с указанным ключом.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <returns>true, если ключ присутствует в коллекции;<br />
        /// false в противном случае.</returns>
        bool ContainsKey(TKey key);

        #endregion

        #region Методы

        /// <summary>
        /// Удаляет все данные из набора.
        /// </summary>
        void Clear();

        /// <summary>
        /// Добавляет элемент в коллекцию.<br />
        /// Если в коллекции уже присутствует элемент с таким же ключом,
        /// обновляет данные существующего элемента.
        /// </summary>
        /// <param name="item">Вставляемый элемент.</param>
        void Insert(TData item);

        /// <summary>
        /// Удаляет элемент из коллекции.
        /// </summary>
        /// <param name="item">Удаляемый элемент.</param>
        void Remove(TData item);

        /// <summary>
        /// Удаляет из коллекции элемент с указанным ключом.
        /// </summary>
        /// <param name="key">Удаляемый элемент.</param>
        void Remove(TKey key);

        /// <summary>
        /// Ищет в коллекции данные с указанным ключом.<br />
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <param name="data">Переменная для записи найденных данных.</param>
        /// <returns>true, если данные найдены;<br />
        /// false в противном случае.</returns>
        bool Lookup(TKey key, out TData data);

        /// <summary>
        /// Ищет в коллекции данные с указанным ключом.<br />
        /// Если указанный ключ в коллекции отсутствует, выдаёт исключение.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Найденные данные.</returns>
        TData Lookup(TKey key);

        #endregion

    }
}
