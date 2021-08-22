using System.Collections.Generic;

namespace LINQ.EntityClasses
{
    public class ProductIdComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product x, Product y)
        {
            return (x.productID == y.productID);
        }

        public override int GetHashCode(Product obj)
        {
            return obj.productID.GetHashCode();
        }
    }
}
