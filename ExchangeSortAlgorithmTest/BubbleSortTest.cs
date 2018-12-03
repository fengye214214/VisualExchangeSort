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
            IExchangeSortAlgorithm<string> isa = new BubbleSort<string>();
            isa.StartSortEvent += Isa_StartSortEvent;
            isa.EndSortEvent += Isa_EndSortEvent;
            isa.ProcessSortEvent += Isa_ProcessSortEvent;
            //var list = new List<int>() { 2, 1, 4, 3, 5 };
            //var list = new List<int>() { 5, 5, 5, 5, 5};
            //var list = new List<int>() { 2, 1, 4, 5, 5};
            //var list = new List<string>() { "5", "1", "4", "3", "2"};
            //var list = new List<int>() { 5, 1, 4, 3, 2 };
            var list = new List<string>() { "a", "c", "e", "d", "b"};
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
            Console.WriteLine();
            ObservableCollection<int> oc = new ObservableCollection<int>();
            oc.CollectionChanged += Oc_CollectionChanged;
        }

        private static void Oc_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void Isa_EndSortEvent(SortEventArgs args)
        {
            Console.WriteLine("结束");
            Console.WriteLine("当前列表：" + string.Join(",", args.SortCompletedList.ToArray()));
        }

        private static void Isa_StartSortEvent(SortEventArgs args)
        {
            Console.WriteLine("开始");
        }
    }
}
