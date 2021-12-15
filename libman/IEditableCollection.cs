using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Интерфейс для редактируемых в диалоге объектов и коллекций данных.
    /// </summary>
    public interface IEditableCollection<TItem, TKey>
        where TItem: ILibDataObject<TKey>
        where TKey: IComparable<TKey>
    {
        #region Свойства

        bool Modified { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Открывает форму списка для просмотра и редактирования в диалоге.
        /// </summary>
        void EditList();

        /// <summary>
        /// Открывает форму для выбора объекта данных в диалоге.
        /// </summary>
        /// <returns>Выбранный объект.<br />
        /// Если пользователь не выбрал объект, то null</returns>
        TItem SelectItem();

        /// <summary>
        /// Открывает форму для редактирования указанного объекта данных.
        /// </summary>
        /// <param name="item">Объект для редактирования.</param>
        void EditItem(TItem item);

        /// <summary>
        /// Открывает форму для создания нового объекта данных в диалоге.
        /// </summary>
        void NewItem();

        #endregion
    }
}
