using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysqlCodeGenerator.Models
{
    public class ColumnModel
    {
        /// <summary>
        /// 数据库中的字段名
        /// </summary>
        public string OriginalColumnName { get; set; }

        /// <summary>
        /// 修改后的字段名
        /// </summary>
        public string NewColumnName { get; set; }

        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string DataType { get; set; }

        public ColumnModel(string originalColumnName, string newColumnName): this(originalColumnName, newColumnName, string.Empty)
        {
        }

        public ColumnModel(string originalColumnName, string newColumnName, string dataType)
        {
            this.OriginalColumnName = originalColumnName;
            this.NewColumnName = newColumnName;
            this.DataType = dataType;
        }


    }
}
