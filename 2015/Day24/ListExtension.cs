using System.Collections.Generic;
using System.Linq;

namespace Day24
{
    internal static class ListExtension
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> list, int k)
        {
            var array = list.ToArray();

            var result = new int[k];
            var stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();

                while (value <= array.Count())
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == k)
                    {
                        yield return result.Select(x => array[x - 1]);
                        break;
                    }
                }
            }
        }
    }
}