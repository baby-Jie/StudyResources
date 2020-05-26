using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using Point = System.Drawing.Point;

//using Point = System.Windows.Point;

namespace HookTest
{
    /// <summary>
    /// ThroughWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ThroughWindow : Window
    {
        public ThroughWindow()
        {
            InitializeComponent();
        }

        const int WM_MOUSEMOVE = 0x0200;

        private const int WM_NCHITTEST = 0x0084;

        private const int HTTRANSPARENT = -1;

        [DllImport("user32.dll", EntryPoint = "SendMessage")]

        private static extern int SendMessage(

            IntPtr hWnd,　　　// handle to destination window

            int Msg,　　　 // message

            IntPtr wParam,　// first message parameter

            IntPtr lParam // second message parameter

        );

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            Handle = source.Handle;
            Penetrate(Handle);
            //source.AddHook(WndProc);
        }

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);

        private const int WS_EX_LAYERED     = 0x80000;
        private const int  WS_EX_TRANSPARENT = 0x20;
        private const int  GWL_STYLE         = (-16);
        private const int  GWL_EXSTYLE       = (-20);
        private const int LWA_ALPHA = 0;

        /// <summary>
        /// 鼠标穿透.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <author>YangSen</author>
        public static void Penetrate(IntPtr hWnd)
        {
            int style = GetWindowLong(hWnd, GWL_EXSTYLE);
            SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
            //SetLayeredWindowAttributes(hWnd, 0, 100, LWA_ALPHA);
        }

        public static IntPtr Handle { get; set; } = IntPtr.Zero;


        private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            Point cursorPosition = new Point();
            switch (msg)
            {
                case WM_MOUSEMOVE:
                    //Console.WriteLine("Mouse Move");
                    break;
                case WM_NCHITTEST:

                    //return 
                    //cursorPosition = new Point();
                    //GetCursorPos(ref cursorPosition);
                    break;
                default:
                    break;
            }

            //if (cursorPosition.X == 0 && cursorPosition.Y == 0)
            //{
            //    return new IntPtr(HTTRANSPARENT);
            //}

            // 根据鼠标位置获取窗口句柄
            IntPtr sendPtr = WindowFromPoint(cursorPosition);

            if (Handle != IntPtr.Zero && Handle == sendPtr)
            {

            }

            // 发送消息给指定窗口
            SendMessage(sendPtr, msg, wParam, lParam);

            ////handled = true;
            return new IntPtr(HTTRANSPARENT);
            //return IntPtr.Zero;
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern Int32 SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point point);
    }
}
