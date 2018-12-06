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
            //BubbleSortTest.TestBubble();
            QuickSortTest.TestPrint();
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
    }
}
