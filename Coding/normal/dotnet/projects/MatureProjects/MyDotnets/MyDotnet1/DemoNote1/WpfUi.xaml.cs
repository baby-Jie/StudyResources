using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace DemoNote1
{
    /// <summary>
    /// WpfUi.xaml 的交互逻辑
    /// </summary>
    public partial class WpfUi : Window
    {
        public WpfUi()
        {
            InitializeComponent();
        }

        private void StartBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //Task.Run(() =>
            //{
            //    IncreaseNumProc(100);
            //});

            IncreaseNumProc(100);
        }

        private void IncreaseNumProc(int num)
        {
            for (int i = 0; i < num; i++)
            {
                NumBlk.Dispatcher.Invoke(() =>
                {
                    NumBlk.Text = i.ToString();
                });
                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(10);
                System.Windows.Forms.Application.DoEvents();

            }
        }
    }
}
