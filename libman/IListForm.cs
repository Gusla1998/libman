using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{

    /// <summary>
    /// Назначение формы коллекции.
    /// </summary>
    public enum FormPurpose
    {
        /// <summary>
        /// Для просмотра и редактирования
        /// </summary>
        View,
        /// <summary>
        /// Для выбора элемента
        /// </summary>
        Select
    }
    
    /// <summary>
    /// Форма редактирования коллекции данных
    /// </summary>
    public interface IListForm<TItem, TKey>
        where TItem: ILibDataObject<TKey>
        where TKey: IComparable<TKey>
    {

        #region Свойства

        /// <summary>
        /// Назначение формы коллекции.
        /// </summary>
        FormPurpose Purpose { get; set; }

        /// <summary>
        /// Выбранный пользователем в диалоге объект.
        /// </summary>
        TItem SelectedItem { get; set; }

        #endregion

    }
}
