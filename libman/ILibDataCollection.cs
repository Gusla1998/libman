using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Интерфейс коллекций данных для хранения данных о библиотеке.
    /// </summary>
    /// <typeparam name="TData">Тип объекта данных.</typeparam>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    public interface ILibDataCollection<TData, TKey> : IDataCollection<TData, TKey>, IEditableCollection<TData, TKey>
        where TKey : IComparable<TKey>
        where TData : ILibDataObject<TKey>
    {
        #region Методы

        /// <summary>
        /// Текстовое описание объекта коллекции.
        /// </summary>
        /// <param name="datа">Описываемый объект (возможно, null).</param>
        /// <returns>Текстовое описание.</returns>
        string Description(TData datа);

        /// <summary>
        /// Расширенное (включающее ключ) текстовое описание объекта коллекции.
        /// </summary>
        /// <param name="datа">Описываемый объект (возможно, null).</param>
        /// <returns>Расширеннное описание.</returns>
        string ExtendedDescription(TData datа);

        #endregion

    }
}
