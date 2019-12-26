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

namespace HookTest
{
    /// <summary>
    /// PenetrateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PenetrateWindow : Window
    {

        private const int WS_EX_LAYERED     = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_STYLE         = (-16);
        private const int GWL_EXSTYLE       = (-20);
        private const int LWA_ALPHA         = 0;
        public PenetrateWindow()
        {
            InitializeComponent();
        }

        private void PenetrateWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            Penetrate(source.Handle);
        }

        /// <summary>
        /// 鼠标穿透.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <author>YangSen</author>
        public static void Penetrate(IntPtr hWnd)
        {
            int style = GetWindowLong(hWnd, GWL_EXSTYLE);
            int newStyle = style | WS_EX_TRANSPARENT | WS_EX_LAYERED;
            SetWindowLong(hWnd, GWL_EXSTYLE, style | WS_EX_TRANSPARENT | WS_EX_LAYERED);
        }


        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern Int32 SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);
    }
}
