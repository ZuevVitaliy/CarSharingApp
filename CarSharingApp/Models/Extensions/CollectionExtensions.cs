using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.Models.Extensions
{
    public static class CollectionExtensions
    {
        public static void RemoveRange<TSource>(this ICollection<TSource> source, IEnumerable<TSource> deletingItems)
        {
            if (source == null || deletingItems == null)
                return;

            foreach (var item in deletingItems)
            {
                source.Remove(item);
            }
        }
    }
}
