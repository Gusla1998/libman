using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libman
{
    public class DeliveredBooks : SkipList<DeliveredBook, string>, ILibDataCollection<DeliveredBook, string>
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public DeliveredBooks()
        { }

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Перечисляет читателей, которым была выдана указанная книга.
        /// </summary>
        /// <param name="book">Выданная книга.</param>
        /// <returns>Последовательность читателей.</returns>
        public IEnumerable<DeliveredBook> BooksForCustomers(Book book)
        {
            string code = book.Code;
            return
                from delivery in this where delivery.BookCode == code select delivery;
        }

        /// <summary>
        /// Перечисляет книги, выданные указанному читателю.
        /// </summary>
        /// <param name="customer">Читатель.</param>
        /// <returns>Выданные читателю книги.</returns>
        public IEnumerable<DeliveredBook> BooksForCustomers(Customer customer)
        {
            string cardid = customer.CardId;
            return
                from delivery in this where delivery.CustomerCardId == cardid select delivery;
        }

        #region ILibDataCollection<DeliveredBook, string>

        /// <summary>
        /// Текстовое описание выдачи книги.
        /// </summary>
        /// <param name="datа">Описываемая выдача книги (возможно, null).</param>
        /// <returns>Текстовое описание.</returns>
        public string Description(DeliveredBook datа) => datа?.Description ?? string.Empty;

        /// <summary>
        /// Расширенное (включающее ключ) текстовое описание выдачи книги.
        /// </summary>
        /// <param name="datа">Описываемая выдача книги (возможно, null).</param>
        /// <returns>Расширеннное описание.</returns>
        public string ExtendedDescription(DeliveredBook datа) => datа?.ExtendedDescription ?? string.Empty;

        #region IEditableCollection<DeliveredBook>

        public void EditItem(DeliveredBook item)
        {
            using (FormDeliveredBook form = new FormDeliveredBook(item))
            {
                form.ShowDialog();
            }
        }

        public void EditList()
        {
            using (FormDeliveredBooks form = new FormDeliveredBooks())
            {
                form.ShowDialog();
            }
        }

        public void NewItem()
        {
            using (FormDeliveredBook form = new FormDeliveredBook())
            {
                form.ShowDialog();
            }
        }

        public DeliveredBook SelectItem()
        {
            using (FormDeliveredBooks form = new FormDeliveredBooks(FormPurpose.Select))
            {
                return (form.ShowDialog() == DialogResult.OK) ? form.SelectedItem : null;
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
