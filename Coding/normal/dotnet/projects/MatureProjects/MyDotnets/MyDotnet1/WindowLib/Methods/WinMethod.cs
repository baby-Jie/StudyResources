using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowLib.Methods
{
    public static class WinMethod
    {
        #region Window Relations

        #region GetWindowLong 获取指定窗口的有关信息

        /// <summary>
        /// 该函数可获取指定窗口的有关信息，也可用于获取窗口内存中指定偏移的32位度整型值。
        /// </summary>
        /// <param name="handle">目标窗口句柄，间接指向其窗口类</param>
        /// <param name="index">若指定值大于0，返回窗口内存中指定偏移量的32位值。</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowLong(IntPtr handle, int index);

        #endregion GetWindowLong	

        #region SetWindowLong 设置指定窗口的有关信息

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowLong(IntPtr handle, int index, int style);

        #endregion SetWindowLong

        #region SetWindowPos 改变一个子窗口，弹出式窗口或顶层窗口的尺寸，位置和Z序。

        /// <summary>
        /// 子窗口，弹出式窗口，及顶层窗口根据它们在屏幕上出现的顺序排序、顶层窗口设置的级别最高，并且被设置为Z序的第一个窗口
        /// </summary>
        /// <param name="hWnd">在z序中的位于被置位的窗口前的窗口句柄。该参数必须为一个窗口句柄</param>
        /// <param name="hWndInsertAfter">用于标识在z-顺序的此 CWnd 对象之前的 CWnd 对象。如果uFlags参数中设置了SWP_NOZORDER标记则本参数将被忽略。可为下列值之一：
        /// HWND_BOTTOM：值为1，将窗口置于Z序的底部。如果参数hWnd标识了一个顶层窗口，则窗口失去顶级位置，并且被置在其他窗口的底部。
        /// HWND_NOTOPMOST：值为-2，将窗口置于所有非顶层窗口之上（即在所有顶层窗口之后）。如果窗口已经是非顶层窗口则该标志不起作用。
        /// HWND_TOP：值为0，将窗口置于Z序的顶部
        /// HWND_TOPMOST：值为-1，将窗口置于所有非顶层窗口之上。即使窗口未被激活窗口也将保持顶级位置
        /// </param>
        /// <param name="x">以客户坐标指定窗口新位置的左边界。</param>
        /// <param name="y">以客户坐标指定窗口新位置的顶边界。</param>
        /// <param name="cx">以像素指定窗口的新的宽度。</param>
        /// <param name="cy">以像素指定窗口的新的高度。</param>
        /// <param name="uFlags">见WinConstants</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy,
            uint uFlags);

        #endregion SetWindowPos	

        #region ShowWindow 显示或者隐藏窗口

        /// <summary>
        /// 显示Window
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion 显示或者隐藏窗口	

        #region FindWindow 查找window

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 查找window
        /// </summary>
        /// <param name="hwndParent"></param>
        /// <param name="hwndChildAfter"></param>
        /// <param name="lpszClass"></param>
        /// <param name="lpszWindow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        #endregion FindWindow	

        #region EnumWindows 列举窗口

        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        //EnumWindows函数，EnumWindowsProc 为处理函数
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        #endregion EnumWindows	

        #region GetParent 获取窗口的父窗口

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr handle);

        #endregion 获取窗口的父窗口	

        #endregion Window Relations	
    }
}
