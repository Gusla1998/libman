using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace libman
{
    /// <summary>
    /// Коллекция данных о книгах библиотеки.
    /// </summary>
    public class Books: AVLTree<Book, string>, ILibDataCollection<Book, string>
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Создаёт пустой набор книг.
        /// </summary>
        public Books()
            : base()
        {
            LastNumbers = new Dictionary<uint, uint>();
        }

        #endregion

        #region Свойства (общедоступные)

        public Dictionary<uint, uint> LastNumbers;

        #endregion

        #region Методы (общедоступные)

        #region Нумерация

        /// <summary>
        /// Восстанавливает словарь последних номеров книг по секциям.
        /// </summary>
        public void RestoreNumeration()
        {
            LastNumbers = new Dictionary<uint, uint>();
            foreach (Book book in this)
            {
                book.ParseCode(out uint section, out uint regnumber);
                if (LastNumbers.ContainsKey(section))
                {
                    if (LastNumbers[section] < regnumber)
                        LastNumbers[section] = regnumber;
                }
                else
                    LastNumbers.Add(section, regnumber);
            }
        }

        /// <summary>
        /// Выдаёт номер новой книги в указанной секции.<br />
        /// При этом новый номер остаётся незанятым (и будет выдан снова при
        /// следующем обращении).
        /// </summary>
        /// <param name="section">Секция.</param>
        /// <returns>Номер книги в секции.</returns>
        public uint GetNewNumber(uint section)
        {
            if (!LastNumbers.ContainsKey(section))
                LastNumbers[section] = 0;
            return LastNumbers[section] + 1;
        }

        /// <summary>
        /// Выдаёт номер для новой книги в указанной секции.<br />
        /// Выданный номер "захватывается" и больше уже не выдаётся.
        /// </summary>
        /// <param name="section">Год регистрации.</param>
        /// <returns>Номер книги в секции.</returns>
        public uint SeizeNewNumber(uint section)
        {
            if (LastNumbers.ContainsKey(section))
                return ++LastNumbers[section];
            else
                return (LastNumbers[section] = 1);
        }

        #endregion

        #region ILibDataCollection<Book, string>

        /// <summary>
        /// Текстовое описание книги.
        /// </summary>
        /// <param name="data">Описываемая книга (возможноб null).</param>
        /// <returns>Текстовое описание.</returns>
        public string Description(Book data)
        {
            return data?.Description ?? string.Empty;
        }

        /// <summary>
        /// Расширенное (включающее шифр) текстовое описание книги.
        /// </summary>
        /// <param name="datа">Описываемая книга (возможноб null).</param>
        /// <returns>Расширенное екстовое описание.</returns>
        public string ExtendedDescription(Book datа)
        {
            return datа?.ExtendedDescription ?? string.Empty;
        }

        #endregion

        #region Реализация IDataCollection<Book, string>

        /// <summary>
        /// Очищает данные о книгах.
        /// </summary>
        public new void Clear()
        {
            base.Clear();
            LastNumbers.Clear();
        }

        #endregion

        #region Реализация IEditableCollection<Book, string>

        /// <summary>
        /// Открывает форму списка книг для просмотра и редактирования.
        /// </summary>
        public void EditList()
        {
            using (FormBooks form = new FormBooks())
            {
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Запрашивает в диалоге у пользователя выбрать книгу.
        /// </summary>
        /// <returns>Выбранная пользователем книга.<br />
        /// Если пользователь не выбрал книгу, то null</returns>
        public Book SelectItem()
        {
            using (FormBooks form = new FormBooks(FormPurpose.Select))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return form.SelectedItem;
                else
                    return null;
            }
        }

        /// <summary>
        /// Открывает форму для редактирования данных об указанной книге.
        /// </summary>
        /// <param name="item">Объект для редактирования.</param>
        public void EditItem(Book item)
        {
            using(FormBook form = new FormBook(item))
            {
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Открывает форму для создания данных о новой книге.
        /// </summary>
        public void NewItem()
        {
            using (FormBook form = new FormBook())
            {
                form.ShowDialog();
            }
        }

        #endregion

        #endregion

    }
}
