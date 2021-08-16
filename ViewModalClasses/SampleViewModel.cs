using LINQ.EntityClasses;
using LINQ.RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            else
            {

            }
        }
    }
}
