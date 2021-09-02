using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.EntityClasses
{
    public partial class SaleProducts
    {
        public int salesOrderID { get; set; }
        public List<Product> products { get; set; }

    }
}
