using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Интерфейс форм редактирования объектов данных.
    /// </summary>
    /// <typeparam name="TData">Тип редактируемого объекта данных.</typeparam>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    public interface IDataForm<TData, TKey>
        where TData: IKeyed<TKey>
        where TKey: IComparable<TKey>
    {
        #region Свойства

        /// <summary>
        /// Признак модифицированности данных формы.
        /// </summary>
        bool Modified { get; set; }

        /// <summary>
        /// Редактируемый объект данных.
        /// </summary>
        TData Source { get; set; }

        #endregion
    }
}
