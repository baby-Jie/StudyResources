using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysqlCodeGenerator.Models
{
    public class TableModel
    {
        public string TableName { get; set; }

        public List<ColumnModel> ColumnModels { get; set; }

        public TableModel(string tableName, List<ColumnModel> columnModels)
        {
            this.TableName = tableName;
            this.ColumnModels = columnModels;
        }
    }
}
