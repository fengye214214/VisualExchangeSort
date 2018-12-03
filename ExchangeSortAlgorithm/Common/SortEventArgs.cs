using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeSortAlgorithm
{   
    /// <summary>
    /// 用于开始排序时
    /// </summary>
    /// <param name="args"></param>
    public delegate void StartSortEventHandler(SortEventArgs args);
    /// <summary>
    /// 用于排序进行中
    /// </summary>
    /// <param name="args"></param>
    public delegate void ProcessSortEventHandler(SortEventArgs args);
    /// <summary>
    /// 用于排序结束时
    /// </summary>
    /// <param name="args"></param>
    public delegate void EndSortEventHandler(SortEventArgs args);


    /// <summary>
    /// 排序事件参数
    /// </summary>
    public class SortEventArgs : EventArgs
    {   
        /// <summary>
        /// 原始排序列表
        /// </summary>
        public IList<object> OriginalSortList { get; set; }
        /// <summary>
        /// 排序完成列表
        /// </summary>
        public IList<object> SortCompletedList { get; set; }
        /// <summary>
        /// 当前排序索引
        /// <para>默认值为-1</para>
        /// </summary>
        public int CurrentSortIndex { get; set; }
        /// <summary>
        /// 当前交换元素的索引
        /// <para>默认值为-1</para>
        /// </summary>
        public int CurrentExchangeElementIndex { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public SortEventArgs()
        {
        //    OriginalSortList = new List<Object>();
        //    SortCompletedList = new List<Object>();
            CurrentSortIndex = -1;
            CurrentExchangeElementIndex = -1;
        }
    }
}
