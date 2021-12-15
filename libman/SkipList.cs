using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Слоёный список (список с пропусками).
    /// </summary>
    /// <typeparam name="TData">Тип данных элементов списка.</typeparam>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    public class SkipList<TData, TKey>: IDataCollection<TData, TKey>
        where TData: IKeyed<TKey>
        where TKey: IComparable<TKey>
    {

        #region Типы исключений (общедоступные)

        /// <summary>
        /// Возникает при попытке доступа к таблице по отсутствующему в ней
        /// ключу.
        /// </summary>
        public class OutOfRangeException : Exception
        {
            /// <summary>
            /// Создаёт исключение при не найденном ключе.
            /// </summary>
            /// <param name="key">Не найденный ключ.</param>
            public OutOfRangeException(TKey key)
                : base("Ключ " + key.ToString() + "не найден в списке")
            { }
        }

        #endregion

        #region Вспомогательные типы (закрытые)

        /// <summary>
        /// Элемент слоёного списка.<br />
        /// Голова списка также имеет этот тип.
        /// </summary>
        class Node
        {
            /// <summary>
            /// Создаёт узел с указанными данными, без связей.
            /// </summary>
            /// <param name="info">Данные нового узла.</param>
            public Node(TData info)
            {
                Info = info;
                Next = new Node[MAX_LEVEL];
                for (int i = 0; i < MAX_LEVEL; i++)
                    Next[i] = null;
            }

            /// <summary>
            /// Конструктор по умолчанию создаёт пустой узел, без данных
            /// и связей.
            /// </summary>
            public Node()
                : this(default(TData))
            { }

            #region Свойства (общедоступные)

            /// <summary>
            /// Ключ данных элемента списка.
            /// </summary>
            public TKey Key => Info.Key;

            /// <summary>
            /// Данные элемента списка.
            /// </summary>
            public TData Info { get; set; }

            /// <summary>
            /// Следующие элементы списка по уровням, отсчёт начинается от 0.
            /// </summary>
            public Node[] Next { get; private set; }

            #endregion
        }

        #endregion

        #region Конструкторы (общедоступные)
        public SkipList()
        {
            Head = new Node();
            Level = 1;
            random = new Random();
        }

        #endregion

        #region Свойства (общедоступные)

        public bool Modified { get; set; }

        public bool IsEmpty => Head.Next[0] == null;

        /// <summary>
        /// Признак заполненности списка (невозможности добавлять новые
        /// элементы).<br />
        /// Всегда равен false, поскольку свыше 60 элементов вряд ли
        /// будет когда-либо использоваться в этом списке.
        /// </summary>
        public bool IsFull => false;

        #endregion

        #region Свойства (закрытые)

        /// <summary>
        /// Фактический уровень списка.
        /// </summary>
        private int Level { get; set; }

        /// <summary>
        /// Голова списка.
        /// </summary>
        private Node Head { get; set; }

        private Random random;

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Добавляет в список новый элемент.
        /// </summary>
        /// <param name="info">Добавляемый элемент.</param>
        public void Insert(TData info)
        {
            TKey key = info.Key;
            Node[] Update = new Node[MAX_LEVEL];
            Node p = Head;
            for (int i = Level - 1; i >= 0; i--)
            {
                while ((p.Next[i] != null) && (p.Next[i].Key.CompareTo(key) < 0))
                {
                    p = p.Next[i];
                }
                Update[i] = p;
            }
            p = p.Next[0];
            if ((p != null) && (p.Key.CompareTo(key) == 0))
            {
                p.Info = info;
            }
            else
            {
                int newlevel = randomLevel();
                if (newlevel > Level)
                {
                    for (int i = Level; i < newlevel; i++)
                        Update[i] = Head;
                    Level = newlevel;
                }
                Node newnode = new Node(info);
                for(int i = 0; i < newlevel; i++)
                {
                    newnode.Next[i] = Update[i].Next[i];
                    Update[i].Next[i] = newnode;
                }
            }
        }

        /// <summary>
        /// Поиск в списке по ключу.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <param name="info">Переменная для записи найденной информации.</param>
        /// <returns>true, если ключ найден в дереве;<br />
        /// false, если не найден.</returns>
        public bool Lookup(TKey key, out TData info)
        {
            if (key== null)
            {
                info = default(TData);
                return false;
            }
            Node p = Head;
            for (int i = Level-1; i >= 0; i--)
            {
                while ((p.Next[i] != null) && (key.CompareTo(p.Next[i].Key) > 0))
                {
                    p = p.Next[i];
                }
            }
            p = p.Next[0];
            if ((p != null) && (p.Key.CompareTo(key) == 0))
            {
                info = p.Info;
                return true;
            }
            else
            {
                info = default(TData);
                return false;
            }
        }

        /// <summary>
        /// Поиск в списке по ключу.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <returns>Информация, соответствующая указанному ключу.<br />
        /// Если ключ не найден, возникает исключение AVLTree.OutOfRange.
        /// </returns>
        public TData Lookup(TKey key)
        {
            if (Lookup(key, out TData result))
                return result;
            else
                throw new OutOfRangeException(key);
        }

        /// <summary>
        /// Удаляет из списка элемент с указанным ключом.
        /// </summary>
        /// <param name="key">Удаляемый ключ.</param>
        public void Remove(TKey key)
        {
            Node[] Update = new Node[Level];
            Node p = Head;
            for (int i = Level - 1; i >= 0; i--)
            {
                while ((p.Next[i] != null) && (p.Next[i].Key.CompareTo(key) < 0))
                {
                    p = p.Next[i];
                }
                Update[i] = p;
            }
            p = p.Next[0];
            if ((p != null) && (p.Key.CompareTo(key) == 0))
            {
                for(int i = 0; i < Level; i++)
                {
                    if (Update[i].Next[i] != p)
                        break;
                    Update[i].Next[i] = p.Next[i];
                }
                while ((Level >= 1) && (Head.Next[Level - 1] == null))
                    Level--;
            }
        }

        /// <summary>
        /// Удаляет из списка указанный элемент.
        /// </summary>
        /// <param name="item">Удаляемый элемент.</param>
        public void Remove(TData item)
        {
            if (item != null)
                Remove(item.Key);
        }

        /// <summary>
        /// Проверка наличия в списек данных с указанным ключом.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <returns>true, если ключ присутствует в списке;<br />
        /// false в противном случае.</returns>
        public bool ContainsKey(TKey key)
        {
            return Lookup(key, out TData data);
        }

        /// <summary>
        /// Удаляет все элементы из списка.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < MAX_LEVEL; i++)
                Head.Next[i] = null;
            Modified = false;
        }

        #region Реализация IEnumerable<TData>

        public IEnumerator<TData> GetEnumerator()
        {
            if (Level > 0)
            {
                for (Node p = Head.Next[0]; p != null; p = p.Next[0])
                    yield return p.Info;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #endregion

        #region Методы (закрытые)

        /// <summary>
        /// Случайный выбор следующего уровня.
        /// </summary>
        /// <returns>Новый уровень списка.</returns>
        int randomLevel()
        {
            int level;
            for(level = 1; ((P > random.NextDouble()) && (level < MAX_LEVEL)); level++)
            { }
            return level;
        }

        #endregion

        #region Параметры слоёного списка по умолчанию

        /// <summary>
        /// Максимальный уровень списка (достаточен для хранения до 65536
        /// элементов).
        /// </summary>
        const int MAX_LEVEL = 16;

        /// <summary>
        /// "Монета" - вероятность выпадения следующего уровня.
        /// </summary>
        const double P = 0.5;

        #endregion

    }
}
