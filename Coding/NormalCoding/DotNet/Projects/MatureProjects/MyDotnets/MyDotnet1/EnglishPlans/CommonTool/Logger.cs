using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPlans.CommonTool
{
    /// <summary>
    /// 日志助手
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// 日志形式
        /// </summary>
        public static  LogEnum LogEnum { get; set; }


        public static void Info(string message, params object[] parameters)
        {
            switch (LogEnum)
            {
                case LogEnum.CONSOLE:
                    Console.WriteLine(message, parameters);
                    break;
                case LogEnum.FILE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum LogEnum
    {
        CONSOLE = 0,
        FILE,
    }
}
