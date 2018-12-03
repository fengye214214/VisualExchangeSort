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
        public event StartSortEventHandler StartSortEvent;
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
            //开始排序事件
            SetStartSortEvent(cacheList);
            //开始排序
            var resultList = PureBubbleSort(sortList);
            //排序结束事件
            SetEndSortEvent(resultList, cacheList);
            return resultList;
        }


        private IEnumerable<T> PureBubbleSort(IEnumerable<T> sortList)
        {
            int bound = sortList.Count() - 1;
            int exchange = bound;
            var tempList = sortList.ToArray<T>();
            var args = new SortEventArgs{ OriginalSortList = sortList.ToList<T>().ConvertAll<object>(s => (object)s) };
            while (exchange > 0)
            {
                exchange = 0;
                for (int i = 0; i < bound; i++)
                {
                    args.CurrentSortIndex = i;
                    args.CurrentExchangeElementIndex = -1;
                    if (tempList[i].CompareTo(tempList[i + 1]) > 0)
                    {
                        var temp = tempList[i];
                        tempList[i] = tempList[i + 1];
                        tempList[i + 1] = temp;
                        exchange = i;
                        args.CurrentExchangeElementIndex = i;
                    }
                    args.SortCompletedList = tempList.ToList<T>().ConvertAll<object>(s => (object)s);
                    ProcessSortEvent?.Invoke(args);
                }
                bound = exchange;
            }
            return tempList;
        }

        private void SetEndSortEvent(IEnumerable<T> sortList, List<T> cacheList)
        {
            if (EndSortEvent != null)
            {
                var args = new SortEventArgs
                {
                    OriginalSortList = cacheList.ToList<T>().ConvertAll<object>(s => (object)s),
                    SortCompletedList = sortList.ToList<T>().ConvertAll<object>(s => (object)s)
                };
                EndSortEvent(args);
            }
        }

        private void SetStartSortEvent(List<T> cacheList)
        {
            if (StartSortEvent != null)
            {
                var args = new SortEventArgs
                {
                    OriginalSortList = cacheList.ToList<T>().ConvertAll<object>(s => (object)s)
                };
                StartSortEvent(args);
            }
        }
    }
}
