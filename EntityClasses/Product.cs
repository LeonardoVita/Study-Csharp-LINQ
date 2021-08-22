using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.EntityClasses
{
    public partial class Product
    {
        public int productID;
        public string name;
        public string color;
        public decimal standardCost;
        public decimal listPrice;
        public string size;

        //calculated properties
        public int? nameLength;
        public decimal? totalSales;
    }
}
