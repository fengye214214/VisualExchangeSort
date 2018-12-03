using ExchangeSortAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeSortAlgorithmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ////var list = new List<int>() { 2,1,4,3,5};
            //var list = new List<int>() { 5, 1, 4, 3, 2 };
            ////var list = new List<int>() { 1, 1, 1, 1, 1 };
            ////Sort1(ref list);
            //Sort(ref list);
            ////bubbleSort2(ref list);
            //Console.WriteLine("--------------");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //var sdsd = list.ToArray();
            //sdsd[0] = 100;
            //foreach (var item in sdsd)
            //{
            //    Console.WriteLine(item);
            //}

            //IExchangeSortAlgorithm<int> isa = new BubbleSort<int>();
            //var res = isa.ExchangeSort(list);
            //Console.WriteLine("++++++++++++");
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            //TestSort<int>(list);
            //int[] arr = new int[] { 1, 2, 3, 4};
            //TestSort<int>(arr);

            BubbleSortTest.TestBubble();
            Console.WriteLine("c".CompareTo("b"));

        }
        static void TestSort<T>(IEnumerable<T> cs)
        {

        }

        static void Sort1(ref List<int> list)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        Console.WriteLine("b:" + i.ToString());
                    }
                    count = count + 1;
                }
            }
            Console.WriteLine("count" + count);
        }

        private static void bubbleSort2(ref List<int> ints)
        {
            int len = ints.Count;
            int flag = len;
            while (flag > 0)
            {//如果flag>0则排序结束
                flag = 0;
                for (int i = 1; i < len; i++)
                {
                    if (ints[i - 1] > ints[i])
                    { //前面大于后面则交换数据
                        int temp = ints[i];
                        ints[i] = ints[i - 1];
                        ints[i - 1] = temp;
                        flag = i; //设置最新边界
                    }
                }
                len = flag;//记录遍历的边界
            }
        }

        static void Sort(ref List<int> list)
        {
            int count = 0;
            int bound = list.Count - 1;
            int exchange = bound;

            while (exchange > 0)
            {
                exchange = 0;
                for (int i = 0; i < bound; i++)
                {
                    if(list[i] > list[i + 1])
                    {
                        Console.WriteLine(i.ToString());
                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        exchange = i;
                    }
                    count = count + 1;
                }
                bound = exchange;

            }
            Console.WriteLine("count" + count);
        }
    }
}
