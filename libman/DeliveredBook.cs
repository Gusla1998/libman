using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Сведения о выдаче книги
    /// </summary>
    public class DeliveredBook: ILibDataObject<string>, IEditableObject
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public DeliveredBook()
        { }

        public DeliveredBook(ValueSet values)
        {
            BookCode = values["BookCode"];
            CustomerCardId = values["CustomerCardId"];
            DeliveryDate = DateTime.Parse(values["DeliveryDate"]);
            ReturnDate = null;
            if (values.ContainsKey("ReturnDate"))
            {
                string strReturnDate = values["ReturnDate"];
                if (string.IsNullOrEmpty(strReturnDate))
                    ReturnDate = null;
                else
                    ReturnDate = DateTime.Parse(strReturnDate);
            }
        }

        #endregion

        #region Свойства (общедоступные)

        /// <summary>
        /// Шифр книги.
        /// </summary>
        public string BookCode { get; set; }

        /// <summary>
        /// Номер читательского билета.
        /// </summary>
        public string CustomerCardId { get; set; }

        /// <summary>
        /// Дата выдачи книги.
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Дата возврата книги, если книга возвращена.<br />
        /// null, если книга ещё не возвращена.
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// Книга ещё не возвращена.
        /// </summary>
        public bool Active => !ReturnDate.HasValue || (ReturnDate.Value > DateTime.Now);

        #region Реализация ILibObject<string>

        /// <summary>
        /// Описание выдачи книги.
        /// </summary>
        public string Description => BookCode + "->" + CustomerCardId;

        /// <summary>
        /// Расширенное (включая ключ) описание выдачи книги.
        /// </summary>
        public string ExtendedDescription => Description;

        /// <summary>
        /// Набор имён свойств и строковых представлений их значений.
        /// </summary>
        public ValueSet AsValues =>
            ReturnDate.HasValue ?
            new ValueSet()
            {
                ["BookCode"] = BookCode,
                ["CustomerCardId"] = CustomerCardId,
                ["DeliveryDate"] = DeliveryDate.ToString("dd'.'MM'.'yyyy"),
                ["ReturnDate"] = ReturnDate.Value.ToString("dd'.'MM'.'yyyy")
            } :
            new ValueSet()
            {
                ["BookCode"] = BookCode,
                ["CustomerCardId"] = CustomerCardId,
                ["DeliveryDate"] = DeliveryDate.ToString("dd'.'MM'.'yyyy")
            };

        #region IKeyed<string>

        /// <summary>
        /// Ключевое (индексное) свойство.
        /// </summary>
        public string Key => CreateKey(BookCode, CustomerCardId);

        #endregion

        #endregion

        #endregion

        #region Методы (общедоступные)

        #region Реализация IEditableObject

        /// <summary>
        /// Открывает форму для редактирования в диалоге.
        /// </summary>
        public void Edit()
        {
            using (FormDeliveredBook form = new FormDeliveredBook(this))
            {
                form.ShowDialog();
            }
        }

        #endregion

        #endregion

        #region Статические методы (общедоступные)

        public static string CreateKey(string book, string customer) => book + "->" + customer;

        public static string CreateKey(Book book, Customer customer)
        {
            return (book == null) || (customer == null) ? string.Empty : CreateKey(book.Key, customer.Key);
        }

        #endregion
    }
}
