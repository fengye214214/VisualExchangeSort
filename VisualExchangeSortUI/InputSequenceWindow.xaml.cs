using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace VisualExchangeSortUI
{
    /// <summary>
    /// InputSequenceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InputSequenceWindow : Window
    {
        public List<string> SortSequenceList { get; private set; }

        public InputSequenceWindow()
        {
            InitializeComponent();
            SortSequenceList = new List<string>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(rtb_inputSeq.Document.ContentStart, rtb_inputSeq.Document.ContentEnd);
            //获取输入的数据列表
            var resultList = textRange.Text.Split('\n');
            var tempList = resultList.ToList<string>();
            foreach (var item in tempList)
            {
                var num = item.Replace("\r", "");
                if (!string.IsNullOrEmpty(num))
                {
                    SortSequenceList.Add(num);
                }
            }
            //验证
            if (SortSequenceList.Count == 0)
            {
                MessageBox.Show("序列不能为空！");
                return;
            }
            if (SortSequenceList.Count == 1)
            {
                MessageBox.Show("请输入至少两个以上元素！");
                return;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
