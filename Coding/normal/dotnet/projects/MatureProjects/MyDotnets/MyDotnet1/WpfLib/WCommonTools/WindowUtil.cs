using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using WindowLib.Constants;
using WindowLib.Methods;

namespace WpfLib.WCommonTools
{
    public static class WindowUtil
    {
        #region GetWindowHandle 获取窗口句柄

        public static IntPtr GetWindowHandle(this Window window)
        {
            IntPtr rtn = IntPtr.Zero;
            if (window != null)
            {
                WindowInteropHelper helper = new WindowInteropHelper(window);
                return helper.Handle;
            }
            return rtn;
        }

        #endregion GetWindowHandle


        #region HiddenFromTab 在 Alt + tab 中隐藏

        public static void HiddenFromTab(this Window window)
        {
            if (window == null)
            {
                return;
            }
            var handle = window.GetWindowHandle();

            IntPtr exStyle = WinMethod.GetWindowLong(handle, WinConstants.GWL_EXSTYLE);
            int style = (int)exStyle | (int)WinConstants.WS_EX_TOOLWINDOW;
            WinMethod.SetWindowLong(handle, WinConstants.GWL_EXSTYLE, style);
        }

        #endregion HiddenFromTab	

    }
}
