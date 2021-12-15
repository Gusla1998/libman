using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libman
{
    public static class Sorting<TData, TKey>
        where TKey: IComparable<TKey>
    {
        public static IEnumerable<TData> Coctail(IEnumerable<TData> source, Func<TData, TKey> key)
        {
            TData[] data = source.ToArray();
            int start = 0;
            int end = data.Length - 1;
            while (start < end)
            {
                for (int i = start; i < end; i++)
                {
                    if (key(data[i]).CompareTo(key(data[i + 1])) > 0)
                    {
                        TData tmp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = tmp;
                    }
                }
                for (int i = end; i > start; i--)
                {
                    if (key(data[i]).CompareTo(key(data[i - 1])) < 0)
                    {
                        TData tmp = data[i];
                        data[i] = data[i - 1];
                        data[i - 1] = tmp;
                    }
                }
                start++;
                end--;
            }
            return data;
        }
    }
}
