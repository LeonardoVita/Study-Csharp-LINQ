using System;
using System.Linq;
using LINQ.ViewModalClasses;
using System.Collections.Generic;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleViewModel vm = new SampleViewModel()
            {
                //UseQuerySyntax = false
            };

            //vm.GetAll();
            //vm.GetAllLooping();
            //vm.GetSingleColumn();
            //vm.GetSpecificColumns();
            //vm.AnonymousClass();
            //vm.OrderBy();
            //vm.DescendingOrderBy();
            vm.OrderByTwoFields();

            foreach (var item in vm.products)
            {
                Console.WriteLine($"productID: {item.productID} | name: {item.name} | color: {item.color}\n" +
                    $"standardCost: {item.standardCost} | listPrice: {item.listPrice} | size: {item.size}");
            }

            Console.WriteLine(vm.ResultText);

        }
    }
}
