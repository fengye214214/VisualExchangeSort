using ExchangeSortAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeSortAlgorithmTest
{
    public class QuickSortTest
    {
        public static void TestPrint()
        {
            //var list = new List<int>() { 1, 3, 2, 5, 4};
            //var list = new List<int> { 3, 7, 8, 5, 2, 1, 9, 5, 4};
            //var list = new List<int> { 23, 13, 49, 6, 31, 19, 28};
            var list = new List<int> { 1, 3, 2, 1};
            IExchangeSortAlgorithm<int> isa = new QuickSort<int>();
            isa.ProcessSortEvent += Isa_ProcessSortEvent;
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("---------------------------");
            var result = isa.ExchangeSort(list);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }

        private static void Isa_ProcessSortEvent(SortEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("次数：" + args.ExecuteCount);
            Console.WriteLine("当前索引：" + args.CurrentSortIndex);
            Console.WriteLine("当前交换索引：" + args.CurrentExchangeElementIndex);
            Console.WriteLine("当前列表：" + string.Join(",", args.SortCompletedList.ToArray()));
            Console.WriteLine("--------------");
        }
    }
}
