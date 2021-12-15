using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    public class Customer : ILibDataObject<string>, IEditableObject
    {
        #region Вспомогательные типы (общедоступные)

        /// <summary>
        /// Наборы прав читателя библиотеки.<br />
        /// Дополнительные функции-расширения для работы с наборами прав
        /// определены в статическом классе <see cref="CustomerExtensions"/>.
        /// </summary>
        public enum Rights : ushort
        {
            None = (ushort)'-',
            Abonement = (ushort)'А',
            ReadingRoom = (ushort)'Ч',
            All = (ushort)'В'
        }

        #endregion

        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию - создаёт пустой объект.
        /// </summary>
        public Customer()
        { }

        /// <summary>
        /// Создаёт объект, свойства которого задаются набором значений.<br />
        /// Значения с именами, не являющимися именами свойств, игнорируются.
        /// </summary>
        /// <param name="values">Набор значений свойств</param>
        public Customer(ValueSet values)
        {
            foreach (KeyValuePair<string, string> pair in values)
            {
                string key = pair.Key;
                string value = pair.Value;
                if (key == "CardId")
                    CardId = value;
                else if (key == "Name")
                    Name = value;
                else if (key == "BirthYear")
                    BirthYear = Convert.ToUInt16(value);
                else if (key == "Address")
                    Address = value;
                else if (key == "Job")
                    Job = value;
            }
        }

        #endregion

        #region Свойства (общедоступные)

        /// <summary>
        /// Номер читательского билета.
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Фамилия, имя, отчество.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Год рождения.
        /// </summary>
        public ushort BirthYear { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Место работы/учёбы.
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Набор прав читателя.
        /// </summary>
        public Rights CustomerRights
        {
            get
            {
                return CardId[0].AsRights();
            }
            set
            {
                if (CardId.Length > 0)
                    CardId = value.ToChar() + CardId.Substring(1);
            }
        }

        /// <summary>
        /// Проверяет наличие выданных книг на руках.
        /// </summary>
        public bool HasBooks
        {
            get
            {
                foreach (DeliveredBook delivered in Library.Data.DeliveredBooks.BooksForCustomers(this))
                    return true;
                return false;
            }
        }

        #region Реализация ILibDataObject

        public string Description => Name;

        public string ExtendedDescription => (Key + " " + Description).Trim();

        /// <summary>
        /// Набор имён свойств и строковых представлений их значений.
        /// </summary>
        public ValueSet AsValues =>
                new ValueSet
                {
                    ["CardId"] = CardId,
                    ["Name"] = Name,
                    ["BirthYear"] = BirthYear.ToString(),
                    ["Address"] = Address,
                    ["Job"] = Job
                };

        #region Реализация IKeyed

        public string Key => CardId;

        #endregion

        #endregion

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Разделяет номер читательского билета на состаляющие его части:<br />
        /// - набор прав читателя;<br />
        /// - регистрационный номер в пределах года;<br />
        /// - год регистрации (последние 2 цифры).
        /// </summary>
        /// <param name="cardid">Номер читательского билета.</param>
        /// <param name="rights">Переменная для набора прав.</param>
        /// <param name="regnumber">Переменная для регистрационного номера.</param>
        /// <param name="year">Переменная для года.</param>
        public void ParseCardId(out Rights rights, out uint regnumber, out int year)
        {
            ParseCardId(CardId, out rights, out regnumber, out year);
        }

        #region Реализация IEditable

        /// <summary>
        /// Открывает форму для редактирования в диалоге данных о читателе.
        /// </summary>
        public void Edit()
        {
            using (FormCustomer form = new FormCustomer(this))
            {
                form.ShowDialog();
            }
        }

        #endregion

        #endregion

        #region Статические свойства (общедоступные)

        public static string EmptyCardId => "     -  ";
        public static string EmptyCardId1 => "-    -  ";

        #endregion

        #region Статические методы (общедоступные)

        /// <summary>
        /// Составляет номер читательского билета из указаннх компонентов.
        /// </summary>
        /// <param name="rights">Набор прав читателя.</param>
        /// <param name="regnumber">Регистрационный номер (уникальный в течение года)</param>
        /// <param name="year">Год регистрации.</param>
        /// <returns></returns>
        public static string CreateCardId(Rights rights, uint regnumber, int year)
        {
            return $"{rights.ToChar()}{regnumber:0000}-{year % 100:00}";
        }

        /// <summary>
        /// Разделяет номер читательского билета на состаляющие его части:<br />
        /// - набор прав читателя;<br />
        /// - регистрационный номер в пределах года;<br />
        /// - год регистрации (последние 2 цифры).
        /// </summary>
        /// <param name="cardid">Номер читательского билета.</param>
        /// <param name="rights">Переменная для набора прав.</param>
        /// <param name="regnumber">Переменная для регистрационного номера.</param>
        /// <param name="year">Переменная для года.</param>
        public static void ParseCardId(string cardid, out Rights rights, out uint regnumber, out int year)
        {
            year = -1;
            rights = cardid[0].AsRights();
            regnumber = uint.Parse(cardid.Substring(1, 4));
            year = int.Parse(cardid.Substring(6, 2));
        }

        /// <summary>
        /// Проверка правильности строки номера читательского билета.
        /// </summary>
        /// <param name="cardid">Проверяемая строка номера.</param>
        /// <returns>true, если строка соответствует формату номера
        /// читательского билета;<br />
        /// false в противном случае.</returns>
        public static bool CardIdIsValid(string cardid)
        {
            if (cardid.Length != 8)
                return false;
            if (!cardid[0].IsValidForRights())
                return false;
            if (!(char.IsDigit(cardid[1]) && char.IsDigit(cardid[2]) && char.IsDigit(cardid[3]) && char.IsDigit(cardid[4])))
                return false;
            if (cardid[5] != '-')
                return false;
            if (!(char.IsDigit(cardid[6]) && char.IsDigit(cardid[7])))
                return false;
            return true;
        }

        #endregion

    }
}
