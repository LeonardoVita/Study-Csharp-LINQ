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
            //vm.OrderByTwoFields();
            //vm.WhereExpression();
            //vm.WhereExtensionExpression();
            //vm.First();
            //vm.FirstOrDefault();
            //vm.Last();
            //vm.LastOrDefault();
            //vm.Single();
            //vm.SingleOrDefault();
            //vm.ForEach();
            //vm.ForEachCallingMethod();
            //vm.Take();
            //vm.TakeWhile();
            //vm.Skip();
            //vm.SkipWhile();
            //vm.Distinct();
            //vm.All();
            //vm.Any();
            //vm.LINQContainsInt();
            //vm.LINQContains();
            //vm.SequenceEqualInteger();
            //vm.SequenceEqualProducts();
            //vm.ExceptIntegers();
            //vm.Except();
            //vm.Intersect();
            //vm.Union();
            //vm.Concat();
            vm.InnerJoin();


            foreach (var item in vm.products)
            {
                //Console.WriteLine($"productID: {item.productID} | name: {item.name} | color: {item.color}\n" +
                //    $"standardCost: {item.standardCost} | listPrice: {item.listPrice} | size: {item.size}");
                Console.WriteLine($"{item.name}\n{item.totalSales}");
            }

            Console.WriteLine(vm.ResultText);

        }
    }
}
