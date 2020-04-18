using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using Newtonsoft.Json;

namespace WpfTest2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomInitialization();
        }

        #region LoadAndDispose

        private void CustomInitialization()
        {
            this.Loaded += Window_OnLoaded;
            this.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Dispose();
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadInitialization();
        }

        private void Dispose()
        {

        }

        private void LoadInitialization()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Task.Run(() =>
            {
                string message;
                while (true)
                {
                    message = Console.ReadLine();
                    MessageBox.Show($"message:{message}");
                }
            });
        }

        #endregion LoadAndDispose

        private void TestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //ProcessStartInfo processStartInfo = new ProcessStartInfo("");
            //processStartInfo.RedirectStandardInput

            //string message = Console.ReadLine();
            //Console.WriteLine($"message:{message}");
            //MessageBox.Show($"message:{message}");
            //string message = "王杰是大傻逼";

            MsgObj obj = new MsgObj();
            obj.Message = "王杰是大傻逼\n是的";
            obj.Age = 1;

            string json = JsonConvert.SerializeObject(obj);

            Console.WriteLine(json);

        }

    }

    public class MsgObj
    {
        public string Message { get; set; }

        public int Age { get; set; }
    }
}
