using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeSortAlgorithm
{   
    /// <summary>
    /// 交换排序算法
    /// </summary>
    public interface IExchangeSortAlgorithm<T>
    {
        /// <summary>
        /// 交换排序算法
        /// </summary>
        /// <param name="sortList">排序列表</param>
        /// <returns></returns>
        IEnumerable<T> ExchangeSort(IEnumerable<T> sortList);
        /// <summary>
        /// 排序开始时的事件
        /// </summary>
        event StartSortEventHandler StartSortEvent;
        /// <summary>
        /// 排序进行中事件
        /// </summary>
        event ProcessSortEventHandler ProcessSortEvent;
        /// <summary>
        /// 排序结束时事件
        /// </summary>
        event EndSortEventHandler EndSortEvent;
    }
}
