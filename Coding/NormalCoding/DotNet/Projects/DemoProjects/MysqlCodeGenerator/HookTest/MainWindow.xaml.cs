using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HookTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            //string path = "%AppData%/test.txt";
            //using (FileStream fs = File.OpenWrite(path))
            //{
            //    using (StreamWriter sw = new StreamWriter(fs))
            //    {
            //       sw.WriteLine("test");
            //    }
            //}
            PenetrateWindow win = new PenetrateWindow();
            win.Show();
            //int original = 0x90000;
            //int newStyle = original | 0x80000 | 0x20;
            //int other = newStyle & (~(0x80000 | 0x20));
        }
    }
}
