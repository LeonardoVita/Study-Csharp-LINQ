using LINQ.EntityClasses;
using LINQ.RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ.RepositoryClasses;

namespace LINQ.ViewModalClasses
{
    public class SampleViewModel
    {
        public SampleViewModel()
        {
            products = ProductsRepository.GetAll(); 
        }

        public bool UseQuerySyntax = true;
        public List<Product> products;
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
    }
}
