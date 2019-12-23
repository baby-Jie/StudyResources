using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MysqlCodeGenerator.Utils
{
    public class MysqlUtil
    {
        public static MySqlConnection GetMySqlConnection(string connectStr)
        {
            return new MySqlConnection(connectStr);
        }

        public static MySqlCommand GetSqlCommand(string sql, MySqlConnection mySqlConnection)
        {
            return new MySqlCommand(sql, mySqlConnection);
        }

        /// <summary>
        /// 将数据库的表中的字段名更改格式 比如 stu_name -> sutName
        /// </summary>
        /// <param name="originalColumnName"></param>
        /// <returns></returns>
        public static string GetModelColumnName(string originalColumnName)
        {
            if (string.IsNullOrWhiteSpace(originalColumnName))
            {
                throw new Exception("传入的参数为空");
            }

            var splitStrings = originalColumnName.Split("_".ToCharArray());

            if (splitStrings.Length == 0)
            {
                return originalColumnName;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(splitStrings[0]);
                for (int i = 1; i < splitStrings.Length; i++)
                {
                    string word = splitStrings[i];

                    char firstCharacter = word[0];

                    if (firstCharacter >= 'a' && firstCharacter <= 'z')
                    {
                        firstCharacter = (char)(firstCharacter - 32);
                        word = firstCharacter + word.Substring(1);
                    }

                    sb.Append(word);
                }
                return sb.ToString();
            }
        }
    }
}
