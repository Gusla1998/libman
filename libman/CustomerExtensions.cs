using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Расширения для типов, определённых в <see cref="Customer"/>.
    /// </summary>
    public static class CustomerExtensions
    {

        /// <summary>
        /// Представление набора прав читателя для вывода.
        /// </summary>
        /// <param name="rights">Набор прав читателя.</param>
        /// <returns>Представление набора прав читателя.</returns>
        public static string PrettyString(this Customer.Rights rights)
        {
            switch (rights)
            {
                case Customer.Rights.None:
                    return "-";
                case Customer.Rights.Abonement:
                    return "только абонемент";
                case Customer.Rights.ReadingRoom:
                    return "только читальный зал";
                case Customer.Rights.All:
                    return "абонемент и читальный зал";
                default:
                    return "(не определены)";
            }
        }

        /// <summary>
        /// Преобразует набор прав в первый символ номера читательского билета.
        /// </summary>
        /// <param name="rights">Набор прав читателя.</param>
        /// <returns>Символ для номера читательского билета.</returns>
        public static char ToChar(this Customer.Rights rights)
        {
            switch (rights)
            {
                case Customer.Rights.Abonement:
                case Customer.Rights.ReadingRoom:
                case Customer.Rights.All:
                    return (char)rights;
                default:
                    return '-';
            }
        }

        /// <summary>
        /// Определяет права по первому символу номера читательского билета.
        /// </summary>
        /// <param name="ch">Первый символ номера читательского билета.</param>
        /// <returns>Права читателя, соответствующие номеру его читательского
        /// билета</returns>
        public static Customer.Rights AsRights(this char ch)
        {
            switch(ch)
            {
                case 'А':
                case 'Ч':
                case 'В':
                case '-':
                    return (Customer.Rights)ch;
                default:
                    return Customer.Rights.None;
            }
        }

        /// <summary>
        /// Проверяет, является ли символ пригодным для обозначения набора прав
        /// в читательском билете.
        /// </summary>
        /// <param name="ch">Проверяемый символ.</param>
        /// <returns>true, если символ обозначает набор прав читателя;<br />
        /// false в противном случае.</returns>
        public static bool IsValidForRights(this char ch)
        {
            switch(ch)
            {
                case 'А':
                case 'Ч':
                case 'В':
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Порядковый номер набора прав в перечислении (начинается с 0).
        /// </summary>
        /// <param name="rights">Набор прав</param>
        /// <returns>Порядковый номер.</returns>
        public static int Ord(this Customer.Rights rights)
        {
            switch (rights)
            {
                case Customer.Rights.None:
                    return 0;
                case Customer.Rights.Abonement:
                    return 1;
                case Customer.Rights.ReadingRoom:
                    return 2;
                case Customer.Rights.All:
                    return 3;
                default:
                    return 0;

            }
        }

    }
}
