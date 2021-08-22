﻿using LINQ.EntityClasses;
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
        public void Distinct()
        {
            List<string> colors;

            if (UseQuerySyntax)
            {
                colors = (from prod in this.products
                          select prod.color).Distinct().ToList();
            }else
            {
                colors = this.products.Select(prod => prod.color).Distinct().ToList();
            }

            foreach (var color in colors)
            {
                Console.WriteLine($"Color: {color}");
            }

            ResultText = $"Total Products: {products.Count}";
            this.products.Clear();
        }
        public void All()
        {
            string search = " ";
            bool value;

            if (UseQuerySyntax)
            {
                value = (from prod in this.products
                         select prod).All(prod => prod.name.Contains(search));
            }
            else
            {
                value = this.products.All(prod => prod.name.Contains(search));
            }

            ResultText = $"Value: {value}";
        }
        public void Any()
        {
            string search = "L";
            bool value;

            if (UseQuerySyntax)
            {
                value = (from prod in this.products
                         select prod).Any(prod => prod.name.Contains(search));
            }else
            {
                value = this.products.Any(prod => prod.name.Contains(search));
            }

            ResultText = $"Value: {value}";
        }
        public void LINQContainsInt()
        {
            bool value;
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            if (UseQuerySyntax)
            {
                value = (from num in numbers
                         select num).Contains(30);
            }else
            {
                value = numbers.Contains(30);
            }

            ResultText = $"Value: {value}";
            this.products.Clear();
        }
        public void LINQContains()
        {
            int search = 744;
            bool value;
            ProductIdComparer pc = new ProductIdComparer();
            Product prodToFind = new Product { productID = search };

            if (UseQuerySyntax)
            {
                value = (from prod in this.products
                         select prod).Contains(prodToFind, pc);
            }
            else
            {
                value = this.products.Contains(prodToFind, pc);
            }

            ResultText = $"Value: {value}";
            this.products.Clear();
        }
        public void SequenceEqualInteger()
        {
            bool value;
            List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> list2 = new List<int> { 1, 2, 3, 4, 5 };

            if (UseQuerySyntax)
            {
                value = (from item in list1
                         select item).SequenceEqual(list2);
            }else
            {
                value = list1.SequenceEqual(list2); 
            }

            ResultText = $"Value: {value}";
            this.products.Clear();
        }
        public void SequenceEqualProducts()
        {
            bool value;
            ProductComparer pc = new ProductComparer();
            List<Product> list1 = new List<Product> 
            { 
                new Product {productID = 1,name = "Product 1"},
                new Product {productID = 2,name = "Product 2"},
            };
            List<Product> list2 = new List<Product> 
            {
                new Product {productID = 1,name = "Product 1"},
                new Product {productID = 2,name = "Product 2"},
            };

            if (UseQuerySyntax)
            {
                value = (from item in list1
                         select item).SequenceEqual(list2, pc);
            }
            else
            {
                value = list1.SequenceEqual(list2, pc);
            }

            ResultText = $"Value: {value}";
            this.products.Clear();
        }
        public void ExceptIntegers()
        {
            List<int> exceptions;
            List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> list2 = new List<int> { 3, 4 };

            if (UseQuerySyntax)
            {
                exceptions = (from item in list1
                              select item).Except(list2).ToList();
            }
            else
            {
                exceptions = list1.Except(list2).ToList();
            }

            ResultText = string.Empty;
            this.products.Clear();

            foreach (var item in exceptions)
            {
                Console.WriteLine(item);
            }
        }
        public void Except()
        {
            ProductComparer pc = new ProductComparer();
            List<Product> list1 = ProductsRepository.GetAll();
            List<Product> list2 = ProductsRepository.GetAll();

            list2.RemoveAll(prod => prod.color == "Black");

            if (UseQuerySyntax)
            {
                list1 = (from prod in list1
                         select prod)
                         .Except(list2, pc).ToList();
            }
            else
            {
                list1 = list1.Except(list2, pc).ToList();
            }

            ResultText = string.Empty;
            this.products.Clear();

            foreach (var item in list1)
            {
                Console.WriteLine($"{item.name}");
            }

        }
    }
}
