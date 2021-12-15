using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// АВЛ-дерево.
    /// </summary>
    /// <typeparam name="TData">Тип хранимых данных.</typeparam>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    public class AVLTree<TData, TKey> : IDataCollection<TData, TKey>
        where TData: IKeyed<TKey>
        where TKey : IComparable<TKey>
    {
        #region  Исключения (общедоступные)

        public class OutOfRange: Exception
        {
            public OutOfRange(TKey key)
                :base("Ключ " + key.ToString() + "не найден в дереве")
            { }
        }

        #endregion

        #region Вспомогательные типы (закрытые)

        private class Node: IEnumerable<TData>
        {
            #region Конструкторы (общедоступные)

            /// <summary>
            /// Создаёт узел по ключу и информационной части с пустыми
            /// поддеревьями.
            /// </summary>
            /// <param name="key">Ключ нового узла</param>
            /// <param name="info">Информационная часть нового узла</param>
            public Node(TData info)
            {
                Info = info;
                Left = null;
                Right = null;
                Height = 0;
            }

            /// <summary>
            /// Создаёт узел по ключу и информационной части с указанными
            /// поддеревьями.<br />
            /// При создании узла предполагается, что поддеревья правильно
            /// соответствуют порядку ключей и сбалансированы.
            /// </summary>
            /// <param name="key">Ключ нового узла.</param>
            /// <param name="info">Информационная часть нового узла.</param>
            /// <param name="left">Левое поддерево.</param>
            /// <param name="right">Правое поддерево.</param>
            public Node(TData info, Node left, Node right)
            {
                Info = info;
                Left = left;
                Right = right;
                Height = (byte)(1 + (left.Height > right.Height ? left.Height : right.Height));
            }

            #endregion

            #region Свойства (общедоступные)

            /// <summary>
            /// Ключ узла дерева
            /// </summary>
            public TKey Key => Info.Key;

            /// <summary>
            /// Информационная часть узла дерева
            /// </summary>
            public TData Info { get; }

            /// <summary>
            /// Левое поддерево (может быть null)
            /// </summary>
            public Node Left { get; private set; }

            /// <summary>
            /// Правое поддерево (может быть null)
            /// </summary>
            public Node Right { get; private set; }

            /// <summary>
            /// Высота узла дерева.
            /// </summary>
            public byte Height;

            /// <summary>
            /// Показатель балансировки.<br />
            /// (Lля сбалансированного дерева от -1 до +1, значения -2 и +2
            /// соответствуют несбалансированным деревьям).
            /// </summary>
            public sbyte BalanceFactor => GetBalanceFactor(this);

            #endregion

            #region Статические методы (общедоступные)

            // Операции поиска, вставки и удаления и другие объявлены
            // статическими чтобы учесть случай пустого дерева.

            /// <summary>
            /// Поиск в дереве узла с заданным ключом.
            /// </summary>
            /// <param name="key">Искомый ключ</param>
            /// <returns>Найденный узел. Если узел не найден, то null.</returns>
            public static Node Lookup(Node root, TKey key)
            {
                if ((root == null) || (key == null))
                    return null;
                int compare = key.CompareTo(root.Key);
                if (compare == 0)
                    return root;
                else if (compare < 0)
                    return Lookup(root.Left, key);
                else if (compare > 0)
                    return Lookup(root.Right, key);
                else
                    return null;
            }

            /// <summary>
            /// Вставляет в дерево узел с заданными ключом и информационной
            /// частью.
            /// </summary>
            /// <param name="key">Вставляемый ключ</param>
            /// <param name="info">Вставляемая информация</param>
            /// <returns>Корень дерева со вставленным ключом</returns>
            public static Node Insert(Node root, TData info)
            {
                if (root == null)
                    return new Node(info);
                int compare = info.Key.CompareTo(root.Key);
                if (compare < 0)
                {
                    if (root.Left == null)
                        root.Left = new Node(info);
                    else
                        root.Left = Insert(root.Left, info);
                }
                else if (compare > 0)
                {
                    if (root.Right == null)
                        root.Right = new Node(info);
                    else
                        root.Right = Insert(root.Right, info);
                }
                return Balance(root);
            }

            /// <summary>
            /// Удаляет из дерева узел с указанным ключом.<br />
            /// Если такой ключ в дереве отсутствует (в том числе если дерево
            /// пустое), ничего не делает.
            /// </summary>
            /// <param name="root">Корень дерева.</param>
            /// <param name="key">Удаляемый ключ.</param>
            /// <returns></returns>
            public static Node Remove(Node root, TKey key)
            {
                if (root == null)
                    return null;
                else
                {
                    int compare = key.CompareTo(root.Key);
                    if (compare < 0)
                    {
                        root.Left = Remove(root.Left, key);
                        return Balance(root);
                    }
                    else if (compare > 0)
                    {
                        root.Right = Remove(root.Right, key);
                        return Balance(root);
                    }
                    else // удаляемый ключ совпадает с ключом корневого узла
                    {
                        if (root.Right == null)
                            return root.Left;
                        Node min = FindMin(root.Right);
                        min.Left = root.Left;
                        min.Right = RemoveMin(root.Right);
                        return Balance(min);
                    }
                }
            }

            /// <summary>
            /// Высота дерева с указанным корнем.
            /// </summary>
            /// <param name="p">Корневой узел дерева.</param>
            /// <returns>Высота дерева (для пустого дерева = 0).</returns>
            public static byte GetHeight(Node p)
            {
                return (p == null) ? (byte)0 : p.Height;
            }

            /// <summary>
            /// Баланс дерева может принимать значения от -2 до +2
            /// (для сбалансированного дерева от -1 до +1, значения -2 и +2
            /// соответствуют несбалансированным деревьям).
            /// Для пустого дерева = 0.
            /// </summary>
            /// <param name="p"></param>
            /// <returns>Баланс дерева. Для пустого дерева = 0.</returns>
            public static sbyte GetBalanceFactor(Node p)
            {
                return (sbyte)((p == null) ? 0 : GetHeight(p.Right) - GetHeight(p.Left));
            }

            #endregion

            #region Методы (закрытые)

            // "Левый поворот" АВЛ-дерева
            Node RotateLeft()
            {
                if (Right == null)
                    return this;
                else
                {
                    Node p = Right;
                    Right = p.Left;
                    p.Left = this;
                    FixHeight(this);
                    FixHeight(p);
                    return p;
                }
            }

            // "Правый поворот" АВЛ-дерева
            Node RotateRight()
            {
                if (Left == null)
                    return this;
                else
                {
                    Node p = Left;
                    Left = p.Right;
                    p.Right = this;
                    FixHeight(this);
                    FixHeight(p);
                    return p;
                }
            }

            // "Большой левый поворот" АВЛ-дерева
            Node RotateLeftLong()
            {
                if (Right == null)
                    return this;
                else
                {
                    Node p = Right;
                    if (p.Left == null)
                        return this;
                    Node q = p.Left;
                    Right = q.Left;
                    p.Left = q.Right;
                    q.Left = this;
                    q.Right = p;
                    FixHeight(this);
                    FixHeight(p);
                    FixHeight(q);
                    return q;
                }
            }

            /// <summary>
            /// "Большой правый поворот" АВЛ-дерева
            /// </summary>
            /// <returns>Корневой узел дерева после поворота.</returns>
            Node RotateRightLong()
            {
                if (Left == null)
                    return this;
                else
                {
                    Node p = Left;
                    if (p.Right == null)
                        return this;
                    Node q = p.Right;
                    p.Right = q.Left;
                    Left = q.Right;
                    q.Left = p;
                    q.Right = this;
                    FixHeight(this);
                    FixHeight(p);
                    FixHeight(q);
                    return q;
                }
            }

            #endregion

            #region Статические методы (закрытые)

            // Эти методы объявлены статическими, чтобы учесть случай пустого
            // дерева.

            /// <summary>
            /// Пересчитывает высоту узла в предположении, что высоты дочерних
            /// узлов корректны.
            /// <param name="node">Обрабатываемый узел.</param>
            /// </summary>
            static void FixHeight(Node node)
            {
                if (node == null)
                    return;
                byte hl = GetHeight(node.Left);
                byte hr = GetHeight(node.Right);
                node.Height = (byte)(1 + (hl > hr ? hl : hl));
            }

            /// <summary>
            /// Восстанавливает баланс дерева, если он был утрачен.<br />
            /// (Сбалансированное дерево не изменяется).
            /// </summary>
            /// <param name="root">Корень дерева</param>
            /// <returns>Корень сбалансированного дерева</returns>
            static Node Balance(Node root)
            {
                FixHeight(root);
                sbyte balance = GetBalanceFactor(root);
                switch (balance)
                {
                    case -2:
                        if (GetBalanceFactor(root.Left) > 0)
                            root.Left = root.Left.RotateLeft();
                        return root.Left.RotateRight();
                    case 2:
                        if (GetBalanceFactor(root.Right) > 0)
                            root.Right = root.Right.RotateRight();
                        return root.Right.RotateLeft();
                    default:
                        return root;
                }
            }

            /// <summary>
            /// Поиск узла дерева с минимальным ключом.
            /// </summary>
            /// <param name="root">Корень дерева.</param>
            /// <returns>Узел дерева с минимальным ключом.<br />
            /// Для пустого поддерева - null.</returns>
            static Node FindMin(Node root)
            {
                if (root == null)
                    return null;
                while (root.Left != null)
                    root = root.Left;
                return root;
            }

            /// <summary>
            /// Удаляет из дерева элемент с минимальным ключом.
            /// </summary>
            /// <param name="root">Корень дерева</param>
            /// <returns>Дерево после удаления элемента с минимальным ключом.</returns>
            static Node RemoveMin(Node root)
            {
                if (root == null)
                    return null;
                else if (root.Left == null)
                    return root.Right;
                else
                {
                    root.Left = RemoveMin(root.Left);
                    return Balance(root);
                }
            }

            #endregion

            #region Реализация IEnumerable

            /// <summary>
            /// Обход дерева в симметричном порядке.
            /// </summary>
            /// <returns>Итератор для АВЛ-дерева.</returns>
            public IEnumerator<TData> GetEnumerator()
            {
                if (Left != null)
                {
                    foreach (TData info in Left)
                        yield return info;
                }
                yield return Info;
                if (Right != null)
                {
                    foreach (TData info in Right)
                        yield return info;
                }
            }

            /// <summary>
            /// Обход дерева в симметричном порядке.
            /// </summary>
            /// <returns>Итератор для АВЛ-дерева.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                if (Left != null)
                {
                    foreach (TData info in Left)
                        yield return info;
                }
                yield return Info;
                if (Right != null)
                {
                    foreach (TData info in Right)
                        yield return info;
                }
            }

            #endregion

        }

        #endregion

        #region Конструкторы (общедоступные)

        public AVLTree()
        {
            root = null;
            Modified = false;
        }

        #endregion

        #region Свойства и индексаторы (общедоступные)

        /// <summary>
        /// Признак отсутствия данных в дереве.
        /// </summary>
        public bool IsEmpty => root == null;

        /// <summary>
        /// Признак заполненности (невозможности добавления).
        /// </summary>
        public bool IsFull => false;

        /// <summary>
        /// Признак модифицированности набора данных.
        /// </summary>
        public bool Modified { get; set; }

        /// <summary>
        /// Фактор сбалансированности АВЛ-дерева.
        /// </summary>
        public sbyte BalanceFactor => Node.GetBalanceFactor(root);

        /// <summary>
        /// Высота АВЛ-дерева.
        /// </summary>
        public byte Height => Node.GetHeight(root);

        /// <summary>
        /// Индексатор обеспечивает наглядный синтаксис для операций поиска в
        /// АВЛ-дереве.
        /// </summary>
        /// <param name="index">Искомый ключ.</param>
        /// <returns>Информация, соответствующая ключу.</returns>
        public TData this[TKey index] => Lookup(index);

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Очищает АВЛ-дерево (удаляет все его узлы).
        /// </summary>
        public void Clear()
        {
            root = null;
            Modified = false;
        }

        /// <summary>
        /// Поиск в дереве по ключу.
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
                throw new OutOfRange(key);
        }

        /// <summary>
        /// Поиск в дереве по ключу.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <param name="info">Переменная для записи найденной информации.</param>
        /// <returns>true, если ключ найден в дереве;<br />
        /// false, если не найден.</returns>
        public bool Lookup(TKey key, out TData info)
        {
            Node found = Node.Lookup(root, key);
            if (found == null)
            {
                info = default(TData);
                return false;
            }
            else
            {
                info = found.Info;
                return true;
            }
        }

        /// <summary>
        /// Вставляет в дерево элемент с указанными ключом и информационной
        /// частью.<br />
        /// Если в дереве уже присутствует элемент с указанным ключом,
        /// информационная часть замещается новой.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="info">Вставляемая информационная часть.</param>
        public void Insert(TData info)
        {
            if (info == null)
                return;
            root = Node.Insert(root, info);
            Modified = true;
        }

        /// <summary>
        /// Удаляет из дерева элемент с указанным ключом.<br />
        /// Если такого элемента нет, ничего не делает.
        /// </summary>
        /// <param name="key">Удаляемый ключ.</param>
        public void Remove(TKey key)
        {
            root = Node.Remove(root, key);
            Modified = true;
        }

        /// <summary>
        /// Удаляет из дерева указанный элемент.<br />
        /// Если такого элемента в дереве нет, ничего не делает.
        /// </summary>
        /// <param name="item">Удаляемый элемент.</param>
        public void Remove(TData item)
        {
            if (item == null)
                return;
            Remove(item.Key);
        }

        /// <summary>
        /// Проверка наличия в дереве данных с указанным ключом.
        /// </summary>
        /// <param name="key">Искомый ключ.</param>
        /// <returns>true, если ключ присутствует в дереве;<br />
        /// false в противном случае.</returns>
        public bool ContainsKey(TKey key)
        {
            return Lookup(key, out TData data);
        }

        #endregion

        #region Реализация IEnumerable<TData>

        /// <summary>
        /// Обход дерева в симметричном порядке.
        /// </summary>
        /// <returns>Итератор для АВЛ-дерева.</returns>
        public IEnumerator<TData> GetEnumerator()
        {
            if (root == null)
                yield break;
            else
            {
                foreach (TData info in root)
                    yield return info;
            }
        }

        /// <summary>
        /// Обход дерева в симметричном порядке.
        /// </summary>
        /// <returns>Итератор для АВЛ-дерева.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (root == null)
                yield break;
            else
            {
                foreach (TData info in root)
                    yield return info;
            }
        }

        #endregion

        #region Поля 

        /// <summary>
        /// Корень дерева.
        /// </summary>
        Node root;

        #endregion
    }
}
