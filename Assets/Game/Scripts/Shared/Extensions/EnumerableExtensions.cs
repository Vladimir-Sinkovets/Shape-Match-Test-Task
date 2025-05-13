using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Game.Scripts.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var list = source.ToList();

            for (var i = list.Count - 1; i > 0; i--)
            {
                var j = Random.Range(0, i + 1);

                (list[i], list[j]) = (list[j], list[i]);

                yield return list[i];
            }

            yield return list[0];
        }
    }
}
