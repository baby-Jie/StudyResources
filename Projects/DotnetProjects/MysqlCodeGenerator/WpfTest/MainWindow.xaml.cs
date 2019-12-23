using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WpfTest
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

        private void TestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            TestAdminPrivilege();
        }

        #region Test

        /// <summary>
        /// 测试非管理员权限是否能够在某些目录下读取和写入文件
        /// </summary>
        private void TestAdminPrivilege()
        {
            string path = PathTxtBox.Text.Trim();
            path = Path.Combine(path, "test.txt");
            using (FileStream fs = File.OpenWrite(path))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("hello this is test ");
                }
            }
        }

        #endregion Test	
    }
}
