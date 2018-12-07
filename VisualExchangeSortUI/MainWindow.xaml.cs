using ExchangeSortAlgorithm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualExchangeSortUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 变量定义
        private IExchangeSortAlgorithm<string> _exchangeSort;
        private IExchangeSortAlgorithm<int> _exchangeSortInt;
        private int singleCount = 0;
        #endregion

        #region 属性定义
        /// <summary>
        /// 输入待排序的序列
        /// </summary>
        public List<string> InputSortList { get; set; }
        /// <summary>
        /// 冒泡排序正在排序的序列
        /// </summary>
        public ObservableCollection<SortListSummaryViewModel> BubbleSortedList { get; set; }
        /// <summary>
        /// 冒泡排序单步模式正在排序的序列
        /// </summary>
        public ObservableCollection<SortListSummaryViewModel> SinglePatternSortedList { get; set; }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            InputSortList = new List<string>();
            BubbleSortedList = new ObservableCollection<SortListSummaryViewModel>();
            SinglePatternSortedList = new ObservableCollection<SortListSummaryViewModel>();
        }

        #region 输入排序序列
        private void btn_inputSequence_Click(object sender, RoutedEventArgs e)
        {
            var input = new InputSequenceWindow();
            input.ShowDialog();
            if (input.DialogResult == true)
            {
                InitStates();
                btn_startSort.IsEnabled = true;
                //把输入数据显示到界面上
                com_inputSequence.Items.Add(string.Join(",", input.SortSequenceList.ToArray()));
                com_inputSequence.SelectedIndex = com_inputSequence.Items.Count - 1;
                InputSortList = input.SortSequenceList;
            }
        }

        private void com_inputSequence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(com_inputSequence.SelectedValue.ToString()) || com_inputSequence.Items.Count <= 0)
            {
                return;
            }
            InitStates();
            InputSortList.Clear();
            InputSortList = com_inputSequence.SelectedValue.ToString().Split(',').ToList<string>();
        }
        #endregion

        #region 开始排序
        private void btn_startSort_Click(object sender, RoutedEventArgs e)
        {
            InitStates();
            if (rad_isSingle.IsChecked == true)
            {
                //单步骤模式
                ls_sortSequence.ItemsSource = SinglePatternSortedList;
            }
            else
            {
                //非单步模式
                ls_sortSequence.ItemsSource = BubbleSortedList;
            }
            btn_inputSequence.IsEnabled = false;
            btn_startSort.IsEnabled = false;
            txt_info.Visibility = Visibility.Visible;
            StartBuble();
        }

        private void InitStates()
        {
            singleCount = 0;
            SinglePatternSortedList.Clear();
            BubbleSortedList.Clear();
            btn_Next.IsEnabled = false;
            btn_Preview.IsEnabled = false;
        }

        private void StartBuble()
        {
            bool isAllNum = true;
            foreach (var item in InputSortList)
            {
                int num = 0;
                if (!int.TryParse(item, out num))
                {
                    isAllNum = false;
                    break;
                }
            }
            if (isAllNum)
            {
                if (rad_BubbleSort.IsChecked == true)
                {
                    _exchangeSortInt = new BubbleSort<int>();
                }
                if (rad_QuickSort.IsChecked == true)
                {
                    _exchangeSortInt = new QuickSort<int>();
                }
                //添加事件
                _exchangeSortInt.ProcessSortEvent += _bubbleSort_ProcessSortEvent;
                _exchangeSortInt.EndSortEvent += _bubbleSortInt_EndSortEvent;
                //如果全是数字
                Task.Factory.StartNew(new Action(() =>
                {
                    _exchangeSortInt.ExchangeSort(InputSortList.ConvertAll(x => Convert.ToInt32(x)));

                }));
            }
            else
            {
                if (rad_BubbleSort.IsChecked == true)
                {
                    _exchangeSort = new BubbleSort<string>();
                }
                if (rad_QuickSort.IsChecked == true)
                {
                    _exchangeSort = new QuickSort<string>();
                }
                _exchangeSort.ProcessSortEvent += _bubbleSort_ProcessSortEvent;
                _exchangeSort.EndSortEvent += _bubbleSortInt_EndSortEvent;
                Task.Factory.StartNew(new Action(() =>
                {
                        //如果里面有非数字
                        _exchangeSort.ExchangeSort(InputSortList);
                }));
            }
        }

        private void _bubbleSortInt_EndSortEvent(SortEventArgs args)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (rad_isSingle.IsChecked == true)
                {
                    //单步骤模式
                    btn_Next.IsEnabled = true;
                    btn_Preview.IsEnabled = false;
                }
                btn_inputSequence.IsEnabled = true;
                btn_startSort.IsEnabled = true;
                txt_info.Visibility = Visibility.Hidden;
            }));
        }
        #endregion

        #region 排序处理事件
        private void _bubbleSort_ProcessSortEvent(SortEventArgs args)
        {
            var resultArr = args.SortCompletedList.ToArray();
            if (resultArr == null)
            {
                return;
            }
            SortListSummaryViewModel model = SortListSummaryViewModel.SortEventArgsToSortListSummaryViewModel(args);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                BubbleSortedList.Add(model);
            }));
        }
        #endregion

        #region 单步模式

        private void btn_Next_Click(object sender, RoutedEventArgs e)
        {
            SinglePatternSortedList.Add(BubbleSortedList[singleCount]);
            btn_Preview.IsEnabled = true;
            singleCount++;
            if (singleCount == BubbleSortedList.Count)
            {
                btn_Next.IsEnabled = false;
            }
        }

        private void btn_Preview_Click(object sender, RoutedEventArgs e)
        {
            int index = SinglePatternSortedList.Count == singleCount ? singleCount - 1 : singleCount;
            SinglePatternSortedList.RemoveAt(index);
            singleCount--;
            if (singleCount == 0)
            {
                btn_Preview.IsEnabled = false;
            }
            btn_Next.IsEnabled = true;
        }

        private void rad_isSingle_Click(object sender, RoutedEventArgs e)
        {
            InitStates();
            if (rad_isSingle.IsChecked == true)
            {
                btn_Next.Visibility = Visibility.Visible;
                btn_Preview.Visibility = Visibility.Visible;
            }
            else
            {
                btn_Next.Visibility = Visibility.Collapsed;
                btn_Preview.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region 算法选择类型
        private void rad_BubbleSort_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
            {
                return;
            }
            if (rb.IsChecked == true)
            {
                InitStates();
            }
        }
        #endregion
    }
}
