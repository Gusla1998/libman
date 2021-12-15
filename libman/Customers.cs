using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace libman
{
    public class Customers : KeyedHashTable<Customer, string>, ILibDataCollection<Customer, string>
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Создаёт пустой набор читателей.
        /// </summary>
        public Customers()
        {
            customers = new KeyedHashTable<Customer, string>();
            LastNumbers = new Dictionary<int, uint>();
        }

        #endregion

        #region Свойства (общедоступные)

        /// <summary>
        /// Последние номера читательских билетов по годам выдачи.
        /// </summary>
        public Dictionary<int, uint> LastNumbers { get; set; }

        #endregion

        #region Методы (общедоступные)

        #region Нумерация

        /// <summary>
        /// Восстанавливает словарь последних номеров читательских билетов
        /// по годам выдачи.
        /// </summary>
        public void RestoreNumeration()
        {
            LastNumbers = new Dictionary<int, uint>();
            foreach(Customer customer in this)
            {
                customer.ParseCardId(out Customer.Rights rights, out uint regnumber, out int year);
                if (LastNumbers.ContainsKey(year))
                {
                    if (LastNumbers[year] < regnumber)
                        LastNumbers[year] = regnumber;
                }
                else
                    LastNumbers.Add(year, regnumber);
            }
        }

        /// <summary>
        /// Выдаёт номер регистрации нового читателя в указанном году.<br />
        /// При этом новый номер остаётся незанятым (и будет выдан снова при
        /// следующем обращении).
        /// </summary>
        /// <param name="year">Год.</param>
        /// <returns>Номер регистрации.</returns>
        public uint GetNewNumber(int year)
        {
            if (!LastNumbers.ContainsKey(year % 100))
                LastNumbers[year % 100] = 0;
            return LastNumbers[year % 100] + 1;
        }

        /// <summary>
        /// Выдаёт номер регистрации нового читателя в указанную дату.<br />
        /// При этом новый номер остаётся незанятым (и будет выдан снова при
        /// следующем обращении).
        /// </summary>
        /// <param name="date">Дата.</param>
        /// <returns>Номер регистрации.</returns>
        public uint GetNewNumber(DateTime date)
        {
            return GetNewNumber(date.Year);
        }

        /// <summary>
        /// Выдаёт номер сегодняшней (в момент вызова) регистрации нового
        /// читателя.<br />
        /// При этом новый номер остаётся незанятым (и будет выдан снова при
        /// следующем обращении).
        /// </summary>
        /// <returns>Номер регистрации.</returns>
        public uint GetNewNumber()
        {
            return GetNewNumber(DateTime.Now.Year);
        }

        /// <summary>
        /// Выдаёт номер регистрации нового читателя в указанном году.<br />
        /// Выданный номер "захватывается" и больше уже не выдаётся.
        /// </summary>
        /// <param name="year">Год регистрации.</param>
        /// <returns>Номер читательского билета.</returns>
        public uint SeizeNewNumber(int year)
        {
            int shortyear = year % 100;
            if (LastNumbers.ContainsKey(shortyear))
                return ++LastNumbers[shortyear];
            else
                return (LastNumbers[shortyear] = 1);
        }

        /// <summary>
        /// Выдаёт номер регистрации нового читателя в указанную дату.<br />
        /// Выданный номер "захватывается" и больше уже не выдаётся.
        /// </summary>
        /// <param name="date">Дата регистрации.</param>
        /// <returns>Номер регистрации.</returns>
        public uint SeizeNewNumber(DateTime date)
        {
            return SeizeNewNumber(date.Year);
        }

        /// <summary>
        /// Выдаёт номер сегодняшней (в момент вызова) регистрации нового
        /// читателя.<br />
        /// Выданный номер "захватывается" и больше уже не выдаётся.
        /// </summary>
        /// </summary>
        /// <returns>Номер регистрации.</returns>
        public uint SeizeNewNumber(uint number)
        {
            return SeizeNewNumber(DateTime.Now.Year);
        }

        #endregion

        #region Реализация ILibDataCollection<Customer, string>

        /// <summary>
        /// Текстовое описание читателя.
        /// </summary>
        /// <param name="datа">Описываемый читатель (возможно. null).</param>
        /// <returns>Текстовое описание.</returns>
        public string Description(Customer datа)
        {
            return datа?.Description ?? string.Empty;
        }

        /// <summary>
        /// Расширенное (с номером читательского билета) описание читателя.
        /// </summary>
        /// <param name="datа">Описываемый читатель (возможно. null).</param>
        /// <returns>Расширенное описание.</returns>
        public string ExtendedDescription(Customer datа)
        {
            return datа?.ExtendedDescription ?? string.Empty;
        }

        #region Реализация IDataCollection<Customer, string>

        /// <summary>
        /// Очищает данные о читателях.
        /// </summary>
        public new void Clear()
        {
            base.Clear();
            LastNumbers.Clear();
        }

        #endregion

        #region Реализация IEditableCollection<Customer, string>

        /// <summary>
        /// Открывает список пользователей для просмотра и редактирования.
        /// </summary>
        public void EditList()
        {
            using (FormCustomers form = new FormCustomers())
            {
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Открывает форму списка читателей для выбора.
        /// </summary>
        /// <returns>Выбранный пользователем читатель.<br />
        /// Если читатель не был выбран, то null.</returns>
        public Customer SelectItem()
        {
            using (FormCustomers form = new FormCustomers(FormPurpose.Select))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return form.SelectedItem;
                else
                    return null;
            }
        }

        /// <summary>
        /// Открывает форму для редактирования данных об указанном читателе.
        /// </summary>
        /// <param name="item">Читатель.</param>
        public void EditItem(Customer item)
        {
            using (FormCustomer form = new FormCustomer(item))
            {
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Открывает форму для создания данных о новом читателе.
        /// </summary>
        public void NewItem()
        {
            using (FormCustomer form = new FormCustomer())
            {
                form.ShowDialog();
            }
        }

        #endregion

        #endregion

        #endregion

        #region Поля

        readonly KeyedHashTable<Customer, string> customers;

        #endregion

    }
}
