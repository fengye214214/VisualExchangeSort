using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualExchangeSortUI
{   
    /// <summary>
    /// 当前排序数字信息
    /// </summary>
    public class SortNumsViewModel : BaseViewModel
    {
        private string sortNum;
        /// <summary>
        /// 排序数列的元素
        /// </summary>
        public string SortNum
        {
            get { return sortNum; }
            set
            {
                if (value != this.sortNum)
                {
                    sortNum = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int currentExchangeElementIndex;
        /// <summary>
        /// 当前交换元素的索引
        /// <para>默认值为-1</para>
        /// </summary>
        public int CurrentExchangeElementIndex
        {
            get { return currentExchangeElementIndex; }
            set
            {
                if (value != this.currentExchangeElementIndex)
                {
                    currentExchangeElementIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int currentIndex;
        /// <summary>
        /// 当前索引
        /// </summary>
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (value != this.currentIndex)
                {
                    currentIndex = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool isIndexVisibile;
        /// <summary>
        /// 是否显示当前下标
        /// </summary>
        public bool IsIndexVisibile
        {
            get
            {
                return isIndexVisibile;
            }
            set
            {
                if (value != this.isIndexVisibile)
                {
                    isIndexVisibile = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public SortNumsViewModel()
        {
            currentExchangeElementIndex = -1;
        }
    }
}
