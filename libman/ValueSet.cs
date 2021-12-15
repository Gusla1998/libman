using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Множество атрибутов (пар [Имя=Значение]).
    /// </summary>
    [Serializable]
    public class ValueSet: Dictionary<string, string>
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Создаёт пустое множество атрибутов.
        /// </summary>
        public ValueSet()
            : base(DEFAULT_CAPACITY)
        { }

        /// <summary>
        /// Создаёт множество атрибутов из словаря.
        /// </summary>
        /// <param name="dictionary"></param>
        public ValueSet(Dictionary<string, string> dictionary)
            : base(dictionary)
        { }

        public ValueSet(IEnumerable<KeyValuePair<string, string>> seq)
            : base(seq.ToDictionary(pair => pair.Key, pair => pair.Value))
        { }

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Добавляет в набор свойств новый элемент из строки вида
        /// "имя=значение"
        /// </summary>
        /// <param name="pair">Строка вида "имя=значение"</param>
        /// <returns>Этот набор значений</returns>
        ValueSet Add(string pair)
        {

            return this;
        }

        #endregion

        #region Параметры по умолчанию

        /// <summary>
        /// Начальная ёмкость множества.
        /// </summary>
        const int DEFAULT_CAPACITY = 8;

        #endregion

    }
}
