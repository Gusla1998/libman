using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Общий интерфейс объектов библиотеки.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    public interface ILibDataObject<TKey>: IKeyed<TKey>
        where TKey: IComparable<TKey>
    {

        /// <summary>
        /// Текстовое описание объекта.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Расширенное (включающее код) текстовое описание объекта.
        /// </summary>
        string ExtendedDescription { get; }

        /// <summary>
        /// Набор имён свойств и строковых представлений их значений.
        /// </summary>
        ValueSet AsValues { get; }

    }
}
