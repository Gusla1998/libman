using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Хеш-таблица с ключами (хеш-функция вычисляется только для
    /// свойства-ключа).
    /// </summary>
    /// <typeparam name="TData">Тип хранимых данных.</typeparam>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    public class KeyedHashTable<TData, TKey> : IDataCollection<TData, TKey>
        where TData: IKeyed<TKey>
        where TKey : IComparable<TKey>
    {
        #region Типы исключений (общедоступные)

        /// <summary>
        /// Возникает при попытке доступа к таблице по отсутствующему в ней
        /// ключу.
        /// </summary>
        public class OutOfRangeException: Exception
        {
            /// <summary>
            /// Создаёт исключение при не найденном ключе.
            /// </summary>
            /// <param name="key">Не найденный ключ.</param>
            public OutOfRangeException(TKey key)
                : base("Ключ " + key.ToString() + "не найден в таблице")
            { }
        }

        /// <summary>
        /// Возникает при переполнении хеш-таблицы.
        /// </summary>
        public class TableOverflowException: Exception
        {
            /// <summary>
            /// Создаёт исключение переполнения таблицы.
            /// </summary>
            /// <param name="capacity">Ёмкость таблицы</param>
            public TableOverflowException(int capacity)
                : base ("Таблица переполнена ("+ capacity.ToString() + "элементов")
            { }
        }

        #endregion

        #region Вспомогательные типы (закрытые)

        /// <summary>
        /// Статус узла хеш-таблицы
        /// </summary>
        enum NodeState : byte
        {
            /// <summary>
            /// Свободен
            /// </summary>
            Free = 0,
            /// <summary>
            /// Используется (занят)
            /// </summary>
            Used = 1,
            /// <summary>
            /// Использовался, но элемент был удалён из таблицы
            /// </summary>
            Deleted = 2
        }

        /// <summary>
        /// Элемент хеш-таблицы.
        /// </summary>
        class Node
        {
            #region Конструкторы (общедоступные)

            /// <summary>
            /// Создаёт пустую ячейку
            /// </summary>
            public Node()
            {
                Info = default(TData);
                State = NodeState.Free;
            }

            #endregion

            #region Свойства (общедоступные)

            /// <summary>
            /// Ключ узда таблицы.
            /// </summary>
            public TKey Key => Info.Key;

            /// <summary>
            /// Данные узла таблицы.
            /// </summary>
            public TData Info { get; set; }

            /// <summary>
            /// Статус узла таблицы.
            /// </summary>
            public NodeState State { get; set; }

            #endregion

            #region Методы (общедоступные)

            /// <summary>
            /// Очищает узел.
            /// </summary>
            public void Clear()
            {
                Info = default(TData);
                State = NodeState.Free;
            }

            #endregion
        }

        #endregion

        #region Конструкторы (общедоступные)

        /// <summary>
        /// Создаёт пустую хеш-таблицу с параметрами по умолчанию.
        /// </summary>
        public KeyedHashTable()
            : this(DEFAULT_CAPACITY, DEFAULT_C, DEFAULT_D)
        { }

        /// <summary>
        /// Создаёт хеш-таблицу с явно заданными параметрами.
        /// </summary>
        /// <param name="capacity">Ёмкость (максимальное количество элементов)
        /// таблицы</param>
        /// <param name="c">коэффициент при линейном члене</param>
        /// <param name="d">коэффициент при квадратичном члене</param>
        public KeyedHashTable(int capacity, int c, int d)
        {
            this.capacity = capacity;
            this.table = new Node[capacity];
            this.c = c;
            this.d = d;
            for (int i = 0; i < capacity; i++)
                table[i] = new Node();
            this.Count = 0;
            Modified = false;
        }

        #endregion

        #region Свойства и индексаторы (общедоступные)

        /// <summary>
        /// Признак модифицированности таблицы.
        /// </summary>
        public bool Modified { get; set; }

        /// <summary>
        /// Количество элементов в хеш-таблице.<br />
        /// (Удалённые элементы не считаются).
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Признак отсутствия данных в коллекции.
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Признак заполненности таблицы (невозможности добавленияданных).
        /// </summary>
        public bool IsFull => Count == capacity;

        /// <summary>
        /// Индексатор обеспечивает наглядный синтаксис для операций поиска.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <returns>Данные, соответствующие искомому ключу.</returns>
        public TData this[TKey key] => Lookup(key);

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Очищает таблицу (полностью удаляя все данные из таблицы).
        /// </summary>
        /// <returns>Очищенная таблица.</returns>
        public void Clear()
        {
            for (int i = 0; i < capacity; i++)
                table[i].Clear();
            Count = 0;
            Modified = false;
        }

        /// <summary>
        /// Вставляет в таблицу новые данные с указанным ключом.<br />
        /// Если ключ уже присутствует в таблице, заменяет связанные с ключом
        /// данные новыми.
        /// </summary>
        /// <param name="key">Ключ вставляемых данных.</param>
        /// <param name="data">Вставляемые данные.</param>
        /// <returns>Эта хеш-таблица.</returns>
        public void Insert(TData data)
        {
            if (Count == capacity)
                throw new TableOverflowException(capacity);
            int h = data.Key.GetHashCode() % capacity;
            int step;
            for (step = 0;
                (table[h].State == NodeState.Used) && (table[h].Key.CompareTo(data.Key) != 0);
                ++step, h = (h + (c + d * step) * step) % capacity) ;
            table[h].Info = data;
            table[h].State = NodeState.Used;
            Count++;
            Modified = true;
        }

        /// <summary>
        /// Удаляет указанный объект из хеш-таблицы.
        /// </summary>
        /// <param name="data">Удаляемый объект.</param>
        /// <returns>Эта хеш-таблица.</returns>
        public void Remove(TData data)
        {
            Remove(data.Key);
            Modified = true;
        }

        /// <summary>
        /// Удаляет из хеш-таблицы объект с указанным ключом.
        /// </summary>
        /// <param name="key">Ключ удаляемого объекта</param>
        /// <returns>Эта хеш-таблица.</returns>
        public void Remove (TKey key)
        {
            int h = key.GetHashCode() % capacity;
            int step;
            for
                (step = 0;
                (table[h].State != NodeState.Free) && (table[h].Key.CompareTo(key) != 0) && (step < capacity);
                ++step, h = (h + (c + d * step) * step) % capacity) ;
            if (table[h].Key.CompareTo(key) == 0)
            {
                table[h].State = NodeState.Deleted;
                Count--;
                Modified = true;
            }
        }

        /// <summary>
        /// Поиск в таблице данных для указанного ключа.<br />
        /// Если искомый ключ не найден в таблице, возникает исключение.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <returns>Данные, соответствующие искомому ключу.</returns>
        public TData Lookup(TKey key)
        {
            if (Lookup(key, out TData info))
                return info;
            else
                throw new OutOfRangeException(key);
        }

        /// <summary>
        /// Поиск в таблице данных для указанного ключа.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <param name="info">Переменная для записи данных, соответствующих
        /// искомому ключу.</param>
        /// <returns>true, если ключ найден в таблице,<br />
        /// false, если не найден.</returns>
        public bool Lookup(TKey key, out TData info)
        {
            if (key == null)
            {
                info = default(TData);
                return false;
            }
            int h = key.GetHashCode() % capacity;
            int step;
            for
                (step = 0;
                (table[h].State != NodeState.Free) && (key.CompareTo(table[h].Key) != 0) && (step < capacity);
                ++step, h = (h + (c + d * step) * step) % capacity) ;
            switch (table[h].State)
            {
                case NodeState.Free:
                case NodeState.Deleted:
                    info = default(TData);
                    return false;
                default:
                    if (key.CompareTo(table[h].Key) == 0)
                    {
                        info = table[h].Info;
                        return true;
                    }
                    else
                    {
                        info = default(TData);
                        return false;
                    }
            }
        }

        /// <summary>
        /// Проверяет наличие в таблице данных с указанным ключом.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <returns>true, если ключ присутствует в таблице;<br />
        /// false в противном случае.</returns>
        public bool ContainsKey(TKey key)
        {
            return Lookup(key, out TData data);
        }

        #region Реализация IEnumerable<>

        /// <summary>
        /// Используемые (внесённые и не удалённые) элементы таблицы.
        /// </summary>
        /// <returns>Перечислитель элементов данных таблицы.</returns>
        public IEnumerator<TData> GetEnumerator()
        {
            foreach(var item in table)
                if (item.State == NodeState.Used)
                    yield return item.Info;
        }

        /// <summary>
        /// Используемые (внесённые и не удалённые) элементы таблицы.
        /// </summary>
        /// <returns>Динамически типизированный перечислитель элеменов таблицы.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Параметры хеш-таблицы по умолчанию

        /// <summary>
        /// Ёмкость по умолчанию.
        /// (на всякий случай - простое число)
        /// </summary>
        const int DEFAULT_CAPACITY = 7351;

        /// <summary>
        /// Коэффициент при линейном члене рехеширования по умоланию.
        /// </summary>
        const int DEFAULT_C = 1;

        /// <summary>
        /// Коэффициент при квадратичном члене рехеширования по умолчанию.
        /// </summary>
        const int DEFAULT_D = 2;

        #endregion

        #region Поля

        readonly int capacity;
        readonly Node[] table;
        readonly int c;
        readonly int d;

        #endregion

        #endregion

    }
}
