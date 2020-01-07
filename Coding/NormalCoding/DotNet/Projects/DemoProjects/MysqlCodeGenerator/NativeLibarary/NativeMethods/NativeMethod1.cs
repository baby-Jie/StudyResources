using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NativeLibrary.NativeStructs;

namespace NativeLibrary.NativeMethods
{
    public class NativeMethod1
    {
        /// <summary>
        /// 获取鼠标位置(相对于屏幕 全局)
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        /// <summary>
        /// 获取鼠标位置的窗口句柄(最上面那个)
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point point);

        /// <summary>
        /// 设置window的样式
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// 获取window的样式
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// 设置窗口透明
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="crKey"></param>
        /// <param name="bAlpha"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);


    }
}
