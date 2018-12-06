using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeSortAlgorithm
{
    /// <summary>
    /// 冒泡排序算法
    /// </summary>
    public class BubbleSort<T> : IExchangeSortAlgorithm<T> where T : IComparable<T>
    {
        public event ProcessSortEventHandler ProcessSortEvent;
        public event EndSortEventHandler EndSortEvent;

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="sortList"></param>
        public IEnumerable<T> ExchangeSort(IEnumerable<T> sortList)
        {
            if (sortList == null)
            {
                throw new NullReferenceException("sortList为null");
            }
            if (sortList.Count() == 0)
            {
                throw new Exception("sortList元素个数不能为0");
            }
            var cacheList = sortList.ToList<T>();
            //开始排序
            var resultList = PureBubbleSort(sortList);
            //排序结束事件
            SetEndSortEvent(resultList, cacheList);
            return resultList;
        }

        private IEnumerable<T> PureBubbleSort(IEnumerable<T> sortList)
        {
            int exchange = sortList.Count() - 1;
            var tempList = sortList.ToArray<T>();
            var args = new SortEventArgs();
            while (exchange > 0)
            {
                int bound = exchange;
                exchange = 0;
                for (int i = 0; i < bound; i++)
                {
                    args.CurrentSortIndex = i;
                    args.CurrentExchangeElementIndex = -1;
                    if (tempList[i].CompareTo(tempList[i + 1]) > 0)
                    {
                        Swap(ref tempList[i], ref tempList[i + 1]);
                        exchange = i;
                        args.CurrentExchangeElementIndex = i;
                    }
                    //调用处理中事件
                    args.ExecuteCount += 1;
                    args.SortCompletedList = tempList.ToList<T>().ConvertAll<object>(s => (object)s);
                    ProcessSortEvent?.Invoke(args);
                }
            }
            return tempList;
        }

        private static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private void SetEndSortEvent(IEnumerable<T> sortList, List<T> cacheList)
        {
            if (EndSortEvent != null)
            {
                var args = new SortEventArgs
                {
                    SortCompletedList = sortList.ToList<T>().ConvertAll<object>(s => (object)s)
                };
                EndSortEvent(args);
            }
        }
    }
}
