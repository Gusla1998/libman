using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Поиск методом Кнута-Морриса-Пратта.
    /// </summary>
    class KMPSearch
    {
        #region Исключения (общедоступные)

        /// <summary>
        /// Тип исключения - неинициализированный образец.
        /// </summary>
        public class NoPattern : Exception
        {
            public NoPattern()
                : base("Образец для поиска не задан")
            { }
        }

        #endregion

        #region Конструкторы (общедоступные)

        /// <summary>
        /// Создаёт пустой (без заданного образца) поисковик по алгоритму
        /// Кнута-Морриса-Пратта.
        /// </summary>
        public KMPSearch()
        {
            pattern = "";
            pi = null;
        }

        /// <summary>
        /// Создаёт новый поисковик по алгоритму Кнута-Морриса-Пратта для
        /// указанного образца.
        /// </summary>
        /// <param name="pattern">Образец для поиска.</param>
        public KMPSearch(string pattern)
        {
            Pattern = pattern;
        }

        #endregion

        #region Свойства (общедоступные)

        /// <summary>
        /// Образец для поиска.<br />
        /// При присваивании свойству нового образца строится префиксная
        /// функция для поиска.
        /// </summary>
        public string Pattern
        {
            get
            {
                return pattern;
            }
            set
            {
                pattern = value;
                pi = PrefixFunction(pattern);
            }
        }

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Находит первое вхождение в текст подготовленного образца.
        /// </summary>
        /// <param name="text">Текст, в котором производится поиск.</param>
        /// <returns>Позиция первого вхождения образца в текст.<br />
        /// -1, если образец не найден.</returns>
        public int FindFirstIn(string text)
        {
            int k = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while ((k > 0) && (text[i] != pattern[k]))
                    k = pi[k - 1];
                if (text[i] == pattern[k])
                {
                    k++;
                    if (k == pattern.Length)
                        return i - k + 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Находит все вхождения в текст подготовленного образца.
        /// </summary>
        /// <param name="text">Текст, в котором производится поиск.</param>
        /// <returns>Массив позиций вхождений образца в текст.</returns>
        public int[] FindAllIn(string text)
        {
            List<int> result = new List<int>();
            int k = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while ((k > 0) && (text[i] != pattern[k]))
                    k = pi[k - 1];
                if (text[i] == pattern[k])
                {
                    k++;
                    if (k == pattern.Length)
                    {
                        result.Add(i - k + 1);
                        k = pi[k - 1];
                    }
                }
            }
            return result.ToArray();
        }

        #endregion

        #region Поля

        /// <summary>
        /// Строка-образец.
        /// </summary>
        string pattern;

        /// <summary>
        /// Префиксная функция для строки-образца.
        /// </summary>
        int[] pi;

        #endregion

        #region Статические методы (общедоступные)

        /// <summary>
        /// Построение префикс-функции для указанного образца.
        /// </summary>
        /// <param name="word">Образец.</param>
        /// <returns>Массив значений префикс-функции.</returns>
        public static int[] PrefixFunction(string word)
        {
            int[] result = new int[word.Length];
            for (int i = 1; i < word.Length; i++)
            {
                int k = result[i - 1];
                while ((k > 0) && (word[k] != word[i]))
                    k = result[k - 1];
                if (word[k] == word[i])
                    k++;
                result[i] = k;
            }
            return result;
        }

        /// <summary>
        /// Построение z-функции для указанного образца.
        /// </summary>
        /// <param name="word">Образец.</param>
        /// <returns>Массив значений z-функции.</returns>
        public static int[] ZFunction(string word)
        {
            int[] result = new int[word.Length];
            int left = 0;
            int right = 0;
            for (int i = 1; i < word.Length; i++)
            {
                result[i] = result[i - left];
                if (result[i] > right - i)
                    result[i] = right - i;
                if (result[i] < 0)
                    result[i] = 0;
                while ((i + result[i] < word.Length) && (word[result[i]] == word[i + result[i]]))
                    result[i]++;
                if (i + result[i] > right)
                {
                    left = i;
                    right = i + result[i];
                }
            }
            return result;
        }

        #endregion

    }
}
