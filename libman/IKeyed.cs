using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    /// <summary>
    /// Интерфейс для типов объектов, имеющих встроенный ключ.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа</typeparam>
    public interface IKeyed<TKey>
        where TKey: IComparable<TKey>
    {
        TKey Key { get; }
    }
}
