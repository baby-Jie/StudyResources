using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCodeGener.Models
{
    /// <summary>
    /// 用于生成Model的条件类
    /// </summary>
    public class ModelCondition
    {
        public string Text { get; set; }

        //public string Comment { get; set; }

        /// <summary>
        /// 是否要添加ApiModelProperty
        /// </summary>

        public bool AddApiModelPropertyAttribute { get; set; }
    }
}
