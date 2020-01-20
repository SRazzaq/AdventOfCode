using System.Collections.Generic;

namespace Day13
{
    internal static class ListExtension
    {
        internal static IEnumerable<IList<T>> Permutate<T>(this IList<T> sequence, int count = -1)
        {
            if (count == -1) count = sequence.Count;

            if (count == 1) yield return sequence;

            for (int i = 0; i < count; i++)
            {
                foreach (var perm in sequence.Permutate(count - 1))
                    yield return perm;

                sequence.Insert(0, sequence[count - 1]);
                sequence.RemoveAt(count);
            }
        }
    }
}