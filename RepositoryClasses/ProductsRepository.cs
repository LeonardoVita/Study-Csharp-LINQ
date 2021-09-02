﻿using LINQ.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.RepositoryClasses
{
    public partial class ProductsRepository
    {
        #region GetAll Method
        public static List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product {
                  productID = 680,
                  name = "HL Road Frame - Black, 58",
                  color = "Black",
                  standardCost = 1059.31M,
                  listPrice = 1431.50M,
                  size = "58",
                },
                new Product {
                  productID = 706,
                  name = "HL Road Frame - Red, 58",
                  color = "Red",
                  standardCost = 1059.31M,
                  listPrice = 1431.50M,
                  size = "58",
                },
                new Product {
                  productID = 707,
                  name = "Sport-100 Helmet, Red",
                  color = "Red",
                  standardCost = 13.08M,
                  listPrice = 34.99M,
                  size = null,
                },
                new Product {
                  productID = 708,
                  name = "Sport-100 Helmet, Black",
                  color = "Black",
                  standardCost = 14.09M,
                  listPrice = 35.99M,
                  size = null,
                },
                new Product {
                  productID = 709,
                  name = "Mountain Bike Socks, M",
                  color = "White",
                  standardCost = 3.40M,
                  listPrice = 9.50M,
                  size = "M",
                },
                new Product {
                  productID = 710,
                  name = "Mountain Bike Socks, L",
                  color = "White",
                  standardCost = 3.40M,
                  listPrice = 9.50M,
                  size = "L",
                },
                new Product {
                  productID = 711,
                  name = "Sport-100 Helmet, Blue",
                  color = "Blue",
                  standardCost = 15.09M,
                  listPrice = 36.99M,
                  size = null,
                },
                new Product {
                  productID = 712,
                  name = "AWC Logo Cap",
                  color = "Multi",
                  standardCost = 6.92M,
                  listPrice = 8.99M,
                  size = null,
                },
                new Product {
                  productID = 713,
                  name = "Long-Sleeve Logo Jersey, S",
                  color = "Multi",
                  standardCost = 38.49M,
                  listPrice = 49.99M,
                  size = "S",
                },
                new Product {
                  productID = 714,
                  name = "Long-Sleeve Logo Jersey, M",
                  color = "Multi",
                  standardCost = 38.49M,
                  listPrice = 49.99M,
                  size = "M",
                },
                new Product {
                  productID = 715,
                  name = "Long-Sleeve Logo Jersey, L",
                  color = "Multi",
                  standardCost = 38.49M,
                  listPrice = 49.99M,
                  size = "L",
                },
                new Product {
                  productID = 716,
                  name = "Long-Sleeve Logo Jersey, XL",
                  color = "Multi",
                  standardCost = 38.49M,
                  listPrice = 49.99M,
                  size = "XL",
                },
                new Product {
                  productID = 717,
                  name = "HL Road Frame - Red, 62",
                  color = "Red",
                  standardCost = 868.63M,
                  listPrice = 1431.50M,
                  size = "62",
                },
                new Product {
                  productID = 718,
                  name = "HL Road Frame - Red, 44",
                  color = "Red",
                  standardCost = 868.63M,
                  listPrice = 1431.50M,
                  size = "44",
                },
                new Product {
                  productID = 719,
                  name = "HL Road Frame - Red, 48",
                  color = "Red",
                  standardCost = 868.63M,
                  listPrice = 1431.50M,
                  size = "48",
                },
                new Product {
                  productID = 720,
                  name = "HL Road Frame - Red, 52",
                  color = "Red",
                  standardCost = 868.63M,
                  listPrice = 1431.50M,
                  size = "52",
                },
                new Product {
                  productID = 721,
                  name = "HL Road Frame - Red, 56",
                  color = "Red",
                  standardCost = 868.63M,
                  listPrice = 1431.50M,
                  size = "56",
                },
                new Product {
                  productID = 722,
                  name = "LL Road Frame - Black, 58",
                  color = "Black",
                  standardCost = 204.63M,
                  listPrice = 337.22M,
                  size = "58",
                },
                new Product {
                  productID = 723,
                  name = "LL Road Frame - Black, 60",
                  color = "Black",
                  standardCost = 204.63M,
                  listPrice = 337.22M,
                  size = "60",
                },
                new Product {
                  productID = 724,
                  name = "LL Road Frame - Black, 62",
                  color = "Black",
                  standardCost = 204.63M,
                  listPrice = 337.22M,
                  size = "62",
                },
                new Product {
                  productID = 725,
                  name = "LL Road Frame - Red, 44",
                  color = "Red",
                  standardCost = 187.16M,
                  listPrice = 337.22M,
                  size = "44",
                },
                new Product {
                  productID = 726,
                  name = "LL Road Frame - Red, 48",
                  color = "Red",
                  standardCost = 187.16M,
                  listPrice = 337.22M,
                  size = "48",
                },
                new Product {
                  productID = 727,
                  name = "LL Road Frame - Red, 52",
                  color = "Red",
                  standardCost = 187.16M,
                  listPrice = 337.22M,
                  size = "52",
                },
                new Product {
                  productID = 728,
                  name = "LL Road Frame - Red, 58",
                  color = "Red",
                  standardCost = 187.16M,
                  listPrice = 337.22M,
                  size = "58",
                },
                new Product {
                  productID = 729,
                  name = "LL Road Frame - Red, 60",
                  color = "Red",
                  standardCost = 187.16M,
                  listPrice = 337.22M,
                  size = "60",
                },
                new Product {
                  productID = 730,
                  name = "LL Road Frame - Red, 62",
                  color = "Red",
                  standardCost = 187.16M,
                  listPrice = 337.22M,
                  size = "62",
                },
                new Product {
                  productID = 731,
                  name = "ML Road Frame - Red, 44",
                  color = "Red",
                  standardCost = 352.14M,
                  listPrice = 594.83M,
                  size = "44",
                },
                new Product {
                  productID = 732,
                  name = "ML Road Frame - Red, 48",
                  color = "Red",
                  standardCost = 352.14M,
                  listPrice = 594.83M,
                  size = "48",
                },
                new Product {
                  productID = 733,
                  name = "ML Road Frame - Red, 52",
                  color = "Red",
                  standardCost = 352.14M,
                  listPrice = 594.83M,
                  size = "52",
                },
                new Product {
                  productID = 734,
                  name = "ML Road Frame - Red, 58",
                  color = "Red",
                  standardCost = 352.14M,
                  listPrice = 594.83M,
                  size = "58",
                },
                new Product {
                  productID = 735,
                  name = "ML Road Frame - Red, 60",
                  color = "Red",
                  standardCost = 352.14M,
                  listPrice = 594.83M,
                  size = "60",
                },
                new Product {
                  productID = 736,
                  name = "LL Road Frame - Black, 44",
                  color = "Black",
                  standardCost = 204.63M,
                  listPrice = 337.22M,
                  size = "44",
                },
                new Product {
                  productID = 737,
                  name = "LL Road Frame - Black, 48",
                  color = "Black",
                  standardCost = 204.63M,
                  listPrice = 337.22M,
                  size = "48",
                },
                new Product {
                  productID = 738,
                  name = "LL Road Frame - Black, 52",
                  color = "Black",
                  standardCost = 204.63M,
                  listPrice = 337.22M,
                  size = "52",
                },
                new Product {
                  productID = 739,
                  name = "HL Mountain Frame - Silver, 42",
                  color = "Silver",
                  standardCost = 747.20M,
                  listPrice = 1364.50M,
                  size = "42",
                },
                new Product {
                  productID = 740,
                  name = "HL Mountain Frame - Silver, 44",
                  color = "Silver",
                  standardCost = 706.81M,
                  listPrice = 1364.50M,
                  size = "44",
                },
                new Product {
                  productID = 741,
                  name = "HL Mountain Frame - Silver, 48",
                  color = "Silver",
                  standardCost = 706.81M,
                  listPrice = 1364.50M,
                  size = "48",
                },
                new Product {
                  productID = 742,
                  name = "HL Mountain Frame - Silver, 46",
                  color = "Silver",
                  standardCost = 747.20M,
                  listPrice = 1364.50M,
                  size = "46",
                },
                new Product {
                  productID = 743,
                  name = "HL Mountain Frame - Black, 42",
                  color = "Black",
                  standardCost = 739.04M,
                  listPrice = 1349.60M,
                  size = "42",
                },
                new Product {
                  productID = 744,
                  name = "HL Mountain Frame - Black, 44",
                  color = "Black",
                  standardCost = 699.09M,
                  listPrice = 1349.60M,
                  size = "44",
                }
            };
        }
        #endregion
    }
}
