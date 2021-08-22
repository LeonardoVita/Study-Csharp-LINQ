using System.Collections.Generic;

namespace LINQ.EntityClasses
{
    public class ProductComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product x, Product y)
        {
            return (x.productID == y.productID &&
                    x.name == y.name &&
                    x.color == y.color &&
                    x.size == y.size &&
                    x.listPrice == y.listPrice &&
                    x.standardCost == y.standardCost);
        }

        public override int GetHashCode(Product obj)
        {
            return obj.productID.GetHashCode();
        }
    }
}
