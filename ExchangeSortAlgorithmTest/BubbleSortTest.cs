using ExchangeSortAlgorithm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeSortAlgorithmTest
{
    class BubbleSortTest
    {
        public static void TestBubble()
        {
            IExchangeSortAlgorithm<int> isa = new BubbleSort<int>();
            isa.EndSortEvent += Isa_EndSortEvent;
            isa.ProcessSortEvent += Isa_ProcessSortEvent;
            //var list = new List<int>() { 2, 1, 4, 3, 5 };
            //var list = new List<int>() { 5, 5, 5, 5, 5};
            //var list = new List<int>() { 2, 1, 4, 5, 5};
            //var list = new List<string>() { "5", "1", "4", "3", "2"};
            //var list = new List<int>() { 5, 1, 4, 3, 2 };
            //var list = new List<string>() { "a", "c", "e", "d", "b"};
            var list = new int[]{ 2, 1, 2, 2};
            isa.ExchangeSort(list);
        }

        private static void Isa_ProcessSortEvent(SortEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("当前索引：" + args.CurrentSortIndex);
            Console.WriteLine("当前交换索引：" + args.CurrentExchangeElementIndex);
            Console.WriteLine("当前列表："  + string.Join(",", args.SortCompletedList.ToArray()));
            Console.WriteLine("--------------");
        }

        private static void Isa_EndSortEvent(SortEventArgs args)
        {
            Console.WriteLine("结束");
            Console.WriteLine("当前列表：" + string.Join(",", args.SortCompletedList.ToArray()));
        }
    }
}
