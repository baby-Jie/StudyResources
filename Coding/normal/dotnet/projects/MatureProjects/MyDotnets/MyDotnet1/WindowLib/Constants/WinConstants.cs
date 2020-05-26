using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowLib.Constants
{
    public class WinConstants
    {

        #region SetWindowPos Flags

        public const int SWP_NOSIZE = 0x0001; // 维持当前尺寸（忽略cx和Cy参数）

        public const int SWP_NOMOVE = 0x0002; // 维持当前位置（忽略X和Y参数）

        public const int SWP_NOZORDER = 0x0004; // 维持当前Z序（忽略hWndlnsertAfter参数）。

        public const int SWP_NOREDRAW = 0x0008; // 不重画改变的内容。如果设置了这个标志，则不发生任何重画动作。适用于客户区和非客户区（包括标题栏和滚动条）和任何由于窗回移动而露出的父窗口的所有部分。如果设置了这个标志，应用程序必须明确地使窗口无效并区重画窗口的任何部分和父窗口需要重画的部分。

        public const int SWP_NOACTIVATE = 0x0010; // 不激活窗口。如果未设置标志，则窗口被激活，并被设置到其他最高级窗口或非最高级组的顶部（根据参数hWndlnsertAfter设置）

        public const int SWP_FRAMECHANGED = 0x0020; // The frame changed: send WM_NCCALCSIZE 给窗口发送WM_NCCALCSIZE消息，即使窗口尺寸没有改变也会发送该消息。如果未指定这个标志，只有在改变了窗口尺寸时才发送WM_NCCALCSIZE。

        public const int SWP_SHOWWINDOW = 0x0040; // 显示窗口。

        public const int SWP_HIDEWINDOW = 0x0080; // 隐藏窗口

        public const int SWP_NOCOPYBITS = 0x0100; // 清除客户区的所有内容。如果未设置该标志，客户区的有效内容被保存并且在窗口尺寸更新和重定位后拷贝回客户区。

        public const int SWP_NOOWNERZORDER = 0x0200; // Don't do owner Z ordering 不改变z序中的所有者窗口的位置

        public const int SWP_NOSENDCHANGING = 0x0400; // Don't send WM_WINDOWPOSCHANGING 防止窗口接收WM_WINDOWPOSCHANGING消息

        public const int SWP_DEFERERASE = 0x2000; // 防止产生WM_SYNCPAINT消息

        public const int SWP_ASYNCWINDOWPOS = 0x4000; // 如果调用进程不拥有窗口，系统会向拥有窗口的线程发出需求。这就防止调用线程在其他线程处理需求的时候发生死锁。

        #endregion SetWindowPos Flags

        #region Window field offsets for GetWindowLong()

        public const int GWL_WNDPROC = -4; // 获取窗口过程地址或句柄。必须使用CallWindowProc函数调用获取的窗口过程。

        public const int GWL_HINSTANCE = -6; // 获取应用实例句柄

        public const int GWL_HWNDPARENT = -8; // 获取所有者窗口句柄

        public const int GWL_STYLE = -16; // 	获得窗口样式

        public const int GWL_EXSTYLE = -20; // 获取扩展窗口样式

        public const int GWL_USERDATA = -21; // 获得窗口样式

        public const int GWL_ID = -12; // 	获取窗口ID

        #endregion Window field offsets for GetWindowLong()

        #region Extended Window Styles

        public const long WS_EX_TOOLWINDOW = 0x00000080L;

        #endregion Extended Window Styles

    }
}
