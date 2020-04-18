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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFTest1.Views
{
    /// <summary>
    /// TaskTest.xaml 的交互逻辑
    /// </summary>
    public partial class TaskTest : Window
    {
        CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _token;

        private int _recordNum = 0;

        ManualResetEvent resetEvent = new ManualResetEvent(true);

        private Task _task;
        public TaskTest()
        {
            InitializeComponent();
            _token = _tokenSource.Token;
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            _task = Task.Run(() =>
            {
                Thread.CurrentThread.IsBackground = false;
                for (int i = 0; i < 100000; i++)
                {
                    Console.WriteLine("Thread.CurrentThread.IsBackground=" + Thread.CurrentThread.IsBackground);
                    //_recordNum++;
                    //NumTxtBlk.Dispatcher.Invoke(() => { NumTxtBlk.Text = _recordNum.ToString(); });
                    Thread.Sleep(1000);
                }
            });

            //Thread thread = new Thread(() =>
            //{
            //    for (int i = 0; i < 100000; i++)
            //    {
            //        Console.WriteLine("Thread.CurrentThread.IsBackground=" + Thread.CurrentThread.IsBackground);
            //        _recordNum++;
            //        NumTxtBlk.Dispatcher.Invoke(() => { NumTxtBlk.Text = _recordNum.ToString(); });
            //        Thread.Sleep(1000);
            //    }
            //});
            //thread.Start();
        }

        private void PauseButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ResumeButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void TestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //this.Close();
            //Window win = new Window();
            //win.Show();
            //this.Owner = win;
            //Form1 form1 = new Form1();
            //form1.Show();

            var args = Environment.GetCommandLineArgs();

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }
    }
}
