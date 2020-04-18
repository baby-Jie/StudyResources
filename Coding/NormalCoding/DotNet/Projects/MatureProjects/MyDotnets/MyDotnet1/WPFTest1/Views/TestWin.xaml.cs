using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Shapes;

namespace WPFTest1.Views
{
    /// <summary>
    /// TestWin.xaml 的交互逻辑
    /// </summary>
    public partial class TestWin : Window
    {
        public TestWin()
        {
            InitializeComponent();


            this.Left = 0;
            this.Top = 0;
            this.Width = SystemParameters.FullPrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;

            VideoPlayer.UnloadedBehavior = MediaState.Manual;

            VideoPlayer.IsMuted = true;
            VideoPlayer.MediaEnded += (sender, args) =>
            {
                VideoPlayer.Position = new TimeSpan(0, 0, 0);
                VideoPlayer.Play();
            };
        }

        private void TestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Test1();
        }

        private void Test1()
        {
            // 根据名称找到一个window
            IntPtr windowPtr = FindWindow(null, "Program Manager");
            if (windowPtr != IntPtr.Zero)
            {
                SetParent(new WindowInteropHelper(this).Handle, windowPtr);
            }
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
            string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetParent")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void TestWin_OnLoaded(object sender, RoutedEventArgs e)
        {
            Test1();
        }

    }
}
