using System;
using System.Collections.Generic;
using System.Linq;

namespace libman
{
    /// <summary>
    /// Сведения о книге.
    /// </summary>
    public class Book: ILibDataObject<string>, IEditableObject
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Book()
        { }

        /// <summary>
        /// Создаёт объект, свойства которого задаются набором значений.<br />
        /// Значения с именами, не являющимися именами свойств, игнорируются.<br />
        /// Используется при считывании из файла.
        /// </summary>
        /// <param name="values">Набор значений свойств.</param>
        public Book(ValueSet values)
        {
            foreach (KeyValuePair<string, string> pair in values)
            {
                string key = pair.Key;
                string value = pair.Value;
                if (key == "Code")
                    Code = value;
                else if (key == "Authors")
                    Authors = value;
                else if (key == "Title")
                    Title = value;
                else if (key == "Year")
                    Year = Convert.ToUInt16(value);
                else if (key == "Publisher")
                    Publisher = value;
                else if (key == "Total")
                    Total = Convert.ToUInt16(value);
            }
        }

        #endregion

        #region Свойства (общедоступные)

        /// <summary>
        /// Шифр книги.<br />
        /// Имеет вид XXX.YYY, где XXX - номер раздела, YYY - номер книги в разделе.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Авторы книги.
        /// </summary>
        public string Authors { get; set; }

        /// <summary>
        /// Название (заголовок) книги.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Издатель.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Год издания.
        /// </summary>
        public uint Year { get; set; }

        /// <summary>
        /// Общее количество экземпляров.
        /// </summary>
        public uint Total { get; set; }

        /// <summary>
        /// Количество выданных экземпляров книги.
        /// </summary>
        public int Delivered =>
            Library.Data.DeliveredBooks
            .Count(delivery => (delivery.BookCode == Code) && ((delivery?.ReturnDate ?? DateTime.MaxValue) > DateTime.Now));

        /// <summary>
        /// Количество экземпляров в наличии.
        /// </summary>
        public long Ready => Total - Delivered;

        #region Реализация ILibObject<>

        public string Description => (Authors + " " + Title).Trim();

        public string ExtendedDescription => (Key + " " + Description).Trim();

        public ValueSet AsValues =>
            new ValueSet
            {
                ["Code"] = Code,
                ["Authors"] = Authors,
                ["Title"] = Title,
                ["Publisher"] = Publisher,
                ["Year"] = Year.ToString(),
                ["Total"] = Total.ToString()
            };

        #region Реализация IKeyed<string>

        public string Key => Code;

        #endregion

        #endregion

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Разбирает шифр книги на секцию и номер книги в секции.
        /// </summary>
        /// <param name="section">Переменная для номера секции.</param>
        /// <param name="regnumber">Переменная для номера книги в секции.</param>
        public void ParseCode(out uint section, out uint regnumber)
        {
            ParseCode(Code, out section, out regnumber);
        }

        #region ILibDataObject<string>

        #endregion

        #region Реализация IEditableObject

        /// <summary>
        /// Открывает форму для редактирования данных о книге в диалоге.
        /// </summary>
        public void Edit()
        {
            using(FormBook form = new FormBook(this))
            {
                form.ShowDialog();
            }
        }

        #endregion

        #endregion

        #region Статические свойства (общедоступные)

        public static string EmptyCode => "   .   ";

        #endregion

        #region Статические методы (общедоступные)

        /// <summary>
        /// Составляет шифр книги из кода раздела и номера книги в разделе.
        /// </summary>
        /// <param name="section">Код раздела.</param>
        /// <param name="regnumber">Номер книги в разделе.</param>
        /// <returns>Шифр книги.</returns>
        public string CreateCode(uint section, uint regnumber)
        {
            return $"{section:000}.{regnumber:000}";
        }

        /// <summary>
        /// Разбирает шифр книги на секцию и номер книги в секции.
        /// </summary>
        /// <param name="code">Шифр книги.</param>
        /// <param name="section">Переменная для номера секции.</param>
        /// <param name="regnumber">Переменная для номера книги в секции.</param>
        public void ParseCode(string code, out uint section, out uint regnumber)
        {
            section = uint.Parse(code.Substring(0, 3));
            regnumber = uint.Parse(code.Substring(4, 3));
        }

        /// <summary>
        /// Проверка корректности шифра книги.
        /// </summary>
        /// <param name="code">Проверяемая строка.</param>
        /// <returns>true, если строка соответствует правилам для шифра
        /// книги<br />
        /// false в противном случае.</returns>
        public static bool CodeIsValid(string code)
        {
            return
                (code.Length == 7) &&
                char.IsDigit(code[0]) && char.IsDigit(code[1]) && char.IsDigit(code[2]) &&
                (code[3] == '.') &&
                char.IsDigit(code[4]) && char.IsDigit(code[5]) && char.IsDigit(code[6])
                ;
        }

        #endregion
    }
}
