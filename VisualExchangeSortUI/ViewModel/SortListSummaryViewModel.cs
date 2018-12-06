using ExchangeSortAlgorithm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualExchangeSortUI
{   
    /// <summary>
    /// 排序序列摘要ViewModel
    /// </summary>
    public class SortListSummaryViewModel : BaseViewModel
    {
        private int executeCount;
        /// <summary>
        /// 函数执行次数
        /// </summary>
        public int ExecuteCount
        {
            get { return executeCount; }
            set
            {
                if(value != this.executeCount)
                {
                    executeCount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// 正在排序中的序列
        /// </summary>
        public ObservableCollection<SortNumsViewModel> SortingList { get; set; }

        public SortListSummaryViewModel()
        {
            executeCount = 0;
            SortingList = new ObservableCollection<SortNumsViewModel>();
        }
        /// <summary>
        /// SortEventArgs转换为SortListSummaryViewModel
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static SortListSummaryViewModel SortEventArgsToSortListSummaryViewModel(SortEventArgs args)
        {
            var resultArr = args.SortCompletedList.ToArray();
            var model = new SortListSummaryViewModel()
            {
                ExecuteCount = args.ExecuteCount
            };
            for (int i = 0; i < resultArr.Length; i++)
            {
                var numModel = new SortNumsViewModel()
                {
                    SortNum = resultArr[i].ToString(),
                    CurrentIndex = args.CurrentSortIndex
                };
                //如果当前交换元素的索引存在，并且当前元素索引等于正在交换的元素的索引
                if (args.CurrentExchangeElementIndex != -1 &&
                    i == args.CurrentExchangeElementIndex)
                {
                    numModel.CurrentExchangeElementIndex = args.CurrentExchangeElementIndex;
                }
                //如果当前元素的下标等于回调中的当前元素的下标
                if (i == args.CurrentSortIndex)
                {
                    numModel.IsIndexVisibile = true;
                }
                model.SortingList.Add(numModel);
            }
            return model;
        }
    }
}
