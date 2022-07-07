using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovies_Demo_2.Utilities
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, int recordsToTake)
        {
            return source.Skip((page - 1) * recordsToTake).Take(recordsToTake);
        }
    }
}
