using LINQ.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.RepositoryClasses
{
    public static class ProductHelper
    {
        public static IEnumerable<Product> ByColor(this IEnumerable<Product> query, string color)
        {
            return query.Where(prod => prod.color == color);
        }
    }
}
