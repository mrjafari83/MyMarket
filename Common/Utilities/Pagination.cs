using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public static class Pagination
    {
        public static IQueryable<TSource> ToPaged<TSource>(this IQueryable<TSource> sources
           , out int rowsCount, int pageNumber = 1, int pageSize = 10)
        {
            rowsCount = sources.Count() / pageSize + 1;
            return sources.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
