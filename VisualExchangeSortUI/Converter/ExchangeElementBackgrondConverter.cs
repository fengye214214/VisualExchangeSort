using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace VisualExchangeSortUI
{
    /// <summary>
    /// 当前交换元素的背景色
    /// </summary>
    public class ExchangeElementBackgrondConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var CurrentExchangeElementIndex = values[0];
            var CurrentSortIndex = values[1];
            if(CurrentExchangeElementIndex == null || CurrentSortIndex == null)
            {
                return Brushes.Transparent;
            }
            int current = 0;
            int currentExchange = -1;
            bool isCurrent = int.TryParse(CurrentSortIndex.ToString(), out current);
            bool isCurrentExchange = int.TryParse(CurrentExchangeElementIndex.ToString(), out currentExchange);
            if(isCurrent == false || isCurrentExchange == false)
            {
                return Brushes.Transparent;
            }
            //冒泡排序
            if(current == currentExchange)
            {
                return Brushes.Red;
            }
            return Brushes.Transparent;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
