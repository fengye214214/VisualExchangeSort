using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeSortAlgorithm
{
    /// <summary>
    /// 快速排序
    /// </summary>
    public class QuickSort<T> : IExchangeSortAlgorithm<T> where T : IComparable<T>
    {
        public event ProcessSortEventHandler ProcessSortEvent;
        public event EndSortEventHandler EndSortEvent;
        private int _executeCount = 0;

        /// <summary>
        /// 快速排序算法
        /// </summary>
        /// <param name="sortList"></param>
        /// <returns></returns>
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
            var result = sortList.ToArray();
            PuerQuickSort(result, 0, sortList.Count());
            SetEndSortEvent(sortList, result.ToList<T>());
            return result;
        }

        private void PuerQuickSort(T[] items, int left, int right)
        {
            if (left == right) return;
            int pivot = Partition(items, left, right);
            PuerQuickSort(items, left, pivot);
            PuerQuickSort(items, pivot + 1, right);
        }

        private int Partition(T[] items, int left, int right)
        {
            int i = left, j = right - 1;
            while (i < j)
            {
                while(i < j && items[i].CompareTo(items[j]) <= 0)
                {
                    RaiseProcessNoCrrentExchangeIndex(items, j);
                    //右侧扫描
                    j--;
                }
                if (i < j)
                {
                    //将较小的记录交换到前面
                    Swap(ref items[i], ref items[j]);
                    RaiseProcessEvent(items, j);
                    i++;
                }
                while (i < j && items[i].CompareTo(items[j]) <= 0)
                {
                    RaiseProcessNoCrrentExchangeIndex(items, i);
                    //左侧扫描
                    i++;
                }
                if(i < j)
                {
                    //将较大记录交换到后面
                    Swap(ref items[j], ref items[i]);
                    RaiseProcessEvent(items, i);
                    j--;
                }
            }
            return i;
        }

        private void RaiseProcessEvent(T[] items, int j)
        {
            _executeCount++;
            var args = new SortEventArgs();
            args.CurrentSortIndex = j;
            args.CurrentExchangeElementIndex = j;
            args.SortCompletedList = items.ToList<T>().ConvertAll<object>(s => (object)s);
            args.ExecuteCount = _executeCount;
            ProcessSortEvent?.Invoke(args);
        }

        private void RaiseProcessNoCrrentExchangeIndex(T[] items, int j)
        {
            _executeCount++;
            var args = new SortEventArgs();
            args.CurrentSortIndex = j;
            args.SortCompletedList = items.ToList<T>().ConvertAll<object>(s => (object)s);
            args.ExecuteCount = _executeCount;
            ProcessSortEvent?.Invoke(args);
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

        private static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
