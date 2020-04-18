using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLib.WCommonTools
{
    public class CommonUtil
    {
        #region IsAbleToDrag 判断两个点是否满足拖动的条件

        /// <summary>
        /// 判断两个点是否满足拖动的条件
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static bool IsAbleToDrag(System.Windows.Point point1, System.Windows.Point point2)
        {
            var flag = false;
            var offsetX = Math.Abs(point1.X - point2.X);
            var offsetY = Math.Abs(point1.Y - point2.Y);

            if (offsetX > SystemParameters.MinimumHorizontalDragDistance ||
                offsetY > SystemParameters.MinimumVerticalDragDistance)
            {
                flag = true;
            }

            return flag;
        }

        #endregion IsAbleToDrag	
    }
}
