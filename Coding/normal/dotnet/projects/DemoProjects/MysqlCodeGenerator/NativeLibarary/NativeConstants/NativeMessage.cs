using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeLibrary.NativeConstants
{
    public class NativeMessage
    {
        public const int GWL_EXSTYLE = -20; // 设定一个新的扩展风格。

        public const int GWL_STYLE = -16; // 设定一个新的窗口风格。

        public const int WS_EX_TRANSPARENT = 0x20; // 设置窗口透明

        public const int WS_EX_LAYERED = 0x80000; // 设置为Layer窗口
    }
}
