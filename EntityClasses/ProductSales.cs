using System.Collections.Generic;

namespace LINQ.EntityClasses
{
    class ProductSales
    {
        public Product product { get; set; }
        public IEnumerable<SalesOrderDetail> sales { get; set; }
    }
}
