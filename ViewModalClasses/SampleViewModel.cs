using LINQ.EntityClasses;
using LINQ.RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ.ViewModalClasses
{
    public class SampleViewModel
    {
        public SampleViewModel()
        {
            products = ProductsRepository.GetAll(); 
            sales = SalesOrderDetailRepository.GetAll();
        }

        public bool UseQuerySyntax = true;
        public List<Product> products;
        public List<SalesOrderDetail> sales;
        public string ResultText;
        public void GetAll()
        {
            List<Product> products;

            if (UseQuerySyntax)
            {
                products = (from prod in this.products select prod).ToList();
            }
            else
            {
                products = this.products.Select(prod => prod).ToList();
            }

            ResultText = $"Total de produtos: {products.Count}";

        }
        public void GetAllLooping()
        {
            List<Product> products = new List<Product>();

            foreach (var prod in this.products)
            {
                products.Add(prod);
            }

            ResultText = $"Total de produtos: {products.Count}";
        }
        public void GetSingleColumn()
        {
            StringBuilder sb = new StringBuilder();
            List<string> products = new List<string>();

            if (UseQuerySyntax){
                products.AddRange(from prod in this.products select prod.name);
            }
            else{
                products.AddRange(this.products.Select(prod => prod.name));
            }

            foreach (var prod in products)
            {
                sb.AppendLine(prod);
            }

            ResultText = $"Total products: {products.Count}\n" + sb.ToString();
            this.products.Clear();
        }
        public void GetSpecificColumns()
        {
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 select new Product
                                 {
                                     productID = prod.productID,
                                     name = prod.name,
                                     size = prod.size,
                                 }).ToList();
            }
            else
            {
                this.products = this.products.Select(prod => new Product
                {
                    productID = prod.productID,
                    name = prod.name,
                    size = prod.size,
                }).ToList();
            }

            ResultText = $"Total products: {this.products.Count}";

        }
        public void AnonymousClass()
        {
            StringBuilder sb = new StringBuilder();

            if (UseQuerySyntax)
            {
                var products = (from prod in this.products
                                select new
                                {
                                    Identifier = prod.productID,
                                    ProductName = prod.name,
                                    ProductSize = prod.size
                                });

                foreach (var prod in products)
                {
                    sb.Append($"Produt ID: {prod.Identifier}");
                    sb.Append($" Product Name: {prod.ProductName}");
                    sb.AppendLine($" Product Size: {prod.ProductSize}");
                }
            }
            else
            {
                var products = this.products.Select(prod => new
                {
                    Identifier = prod.productID,
                    ProductName = prod.name,
                    ProductSize = prod.size
                });

                foreach (var prod in products)
                {
                    sb.Append($"Produt ID: {prod.Identifier}");
                    sb.Append($" Product Name: {prod.ProductName}");
                    sb.AppendLine($" Product Size: {prod.ProductSize}");
                }
            }

            ResultText = sb.ToString();
            this.products.Clear();

        }
        public void OrderBy()
        {
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                orderby prod.name
                                select prod).ToList();
            }
            else
            {
                this.products = this.products.OrderBy(prod => prod.name).ToList();
            }

            ResultText = $"Total Products {this.products.Count}";
        }
        public void DescendingOrderBy()
        {
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 orderby prod.name descending
                                 select prod).ToList();
            }
            else
            {
                this.products = this.products.OrderByDescending(prod => prod.name).ToList();
            }

            ResultText = $"Total Products {this.products.Count}";
        }
        public void OrderByTwoFields()
        {
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 orderby prod.name , prod.standardCost descending
                                 select prod).ToList();
            }
            else
            {
                this.products = this.products.OrderBy(prod => prod.name).ThenBy(prod => prod.standardCost).ToList();
            }

            ResultText = $"Total Products {this.products.Count}";
        }
        public void WhereExpression()
        {
            string search = "L";
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 where prod.name.StartsWith(search)
                                 && prod.standardCost > 40
                                 select new Product
                                 {
                                    name = prod.name
                                 }).ToList();
            }
            else
            {
                this.products = this.products.Where(prod => prod.name.StartsWith(search) && prod.standardCost > 40)
                    .Select(prod => new Product {
                        name = prod.name
                    }).ToList();
            }

            ResultText = $"Total Products {this.products.Count}";
        }
        public void WhereExtensionExpression()
        {
            string search = "L";
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 where prod.name.StartsWith(search)
                                 && prod.standardCost > 40
                                 select new Product
                                 {
                                     name = prod.name,
                                     color = prod.color
                                 }).ByColor("Black").ToList();
            }
            else
            {
                this.products = this.products.Where(prod => prod.name.StartsWith(search) && prod.standardCost > 40)
                    .Select(prod => new Product
                    {
                        name = prod.name,
                        color = prod.color
                    }).ByColor("Black").ToList();
            }

            ResultText = $"Total Products {this.products.Count}";
        }
        public void First()
        {
            string search = "Red";
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    value = (from prod in this.products
                             select prod)
                             .First(prod => prod.color == search);
                }
                else
                {
                    value = this.products.First(prod => prod.color == search);
                }

                ResultText = $"Valor: {value.name}";
            }
            catch 
            {
                ResultText = $"NOT FOUND";
            }

            this.products.Clear();
        }
        public void FirstOrDefault()
        {
            string search = "Red";
            Product value;

            
            if (UseQuerySyntax)
            {
                value = (from prod in this.products
                            select prod)
                            .FirstOrDefault(prod => prod.color == search);
            }
            else
            {
                value = this.products.FirstOrDefault(prod => prod.color == search);
            }

            if (value == null)
            {
                ResultText = $"NOT FOUND";
            }
            else
            {
                ResultText = $"Valor: {value.name}";
            }     

            this.products.Clear();
        }
        public void Last()
        {
            string search = "Reasdad";
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    value = (from prod in this.products
                             select prod)
                             .Last(prod => prod.color == search);
                }
                else
                {
                    value = this.products.Last(prod => prod.color == search);
                }

                ResultText = $"Valor: {value.name}";
            }
            catch
            {
                ResultText = $"NOT FOUND";
            }

            this.products.Clear();
        }
        public void LastOrDefault()
        {
            string search = "Red";
            Product value;


            if (UseQuerySyntax)
            {
                value = (from prod in this.products
                         select prod)
                            .LastOrDefault(prod => prod.color == search);
            }
            else
            {
                value = this.products.LastOrDefault(prod => prod.color == search);
            }

            if (value == null)
            {
                ResultText = $"NOT FOUND";
            }
            else
            {
                ResultText = $"Valor: {value.name}";
            }

            this.products.Clear();
        }
        public void Single()
        {
            int search = 706;
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    value = (from prod in this.products
                             select prod)
                             .Single(prod => prod.productID == search);
                }
                else
                {
                    value = this.products.Single(prod => prod.productID == search);
                }

                ResultText = $"Valor: {value.name}";
            }
            catch
            {
                ResultText = $"NOT FOUND";
            }

            this.products.Clear();
        }
        public void SingleOrDefault()
        {
            int search = 706;
            Product value;

            try
            {            
                if (UseQuerySyntax)
                {
                    value = (from prod in this.products
                             select prod)
                             .SingleOrDefault(prod => prod.productID == search);
                }
                else
                {
                    value = this.products.SingleOrDefault(prod => prod.productID == search);
                }

                if (value == null)
                {
                    ResultText = $"NOT FOUND";
                }
                else
                {
                    ResultText = $"Valor: {value.name}";
                }    

            }
            catch (Exception)
            {
                ResultText = $"NOT FOUND";
            }

            this.products.Clear();
        }
        public void ForEach()
        {
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 let temp = prod.nameLength = prod.name.Length
                                 select prod).ToList();
            }
            else
            {
                this.products.ForEach(prod => prod.nameLength = prod.name.Length);
            }

            ResultText = $"Total Products: {this.products.Count}";
        }
        public void ForEachCallingMethod()
        {
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 let tmp = prod.totalSales = prod.totalSales = SalesForProduct(prod)
                                 select prod).ToList();
            }else
            {
                this.products.ForEach(prod => prod.totalSales = SalesForProduct(prod));
            }
        }
        private decimal SalesForProduct(Product prod)
        {
            if (UseQuerySyntax)
            {
                var sales = (from sale in this.sales
                             where sale.productID == prod.productID
                             select sale).ToList();

                return sales.Aggregate(0M, (total, next) => total += next.lineTotal);
            }
            else
            {
                return sales.Where(sale => sale.productID == prod.productID).Sum(sale => sale.lineTotal);                    
            }
        }
        public void Take()
        {
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 orderby prod.name
                                 select prod).Take(5).ToList();
            }
            else
            {
                this.products = this.products.OrderBy(prod => prod.name).Take(5).ToList();
            }

            ResultText = $"Total Products: {products.Count}";
        }
        public void TakeWhile()
        {
            // para a execução da query quando a condição for falsa
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 select prod).TakeWhile(prod => prod.listPrice > 35).ToList();
            }
            else
            {
                this.products = this.products.TakeWhile(prod => prod.listPrice > 35).ToList();
            }

            ResultText = $"Total Products: {products.Count}";
        }
        public void Skip()
        {
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 orderby prod.name
                                 select prod).Skip(4).ToList();
            }
            else
            {
                this.products = this.products.OrderBy(prod => prod.name).Skip(4).ToList();
            }

            ResultText = $"Total Products: {products.Count}";
        }
        public void SkipWhile()
        {
            // começa apenas qunado a query retornar falso
            if (UseQuerySyntax)
            {
                this.products = (from prod in this.products
                                 select prod).SkipWhile(prod => prod.name.StartsWith("H")).ToList();
            }
            else
            {
                this.products = this.products.SkipWhile(prod => prod.name.StartsWith("H")).ToList();
            }

            ResultText = $"Total Products: {products.Count}";
        }

    }
}
