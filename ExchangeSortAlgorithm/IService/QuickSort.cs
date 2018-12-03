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
    internal class QuickSort<T> : IExchangeSortAlgorithm<T>
    {
        public event StartSortEventHandler StartSortEvent;
        public event ProcessSortEventHandler ProcessSortEvent;
        public event EndSortEventHandler EndSortEvent;

        public IEnumerable<T> ExchangeSort(IEnumerable<T> sortList)
        {   
            throw new NotImplementedException();
        }
    }
}
