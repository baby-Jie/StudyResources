using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebCodeGener.Models;

namespace WebCodeGener.CommonTools
{
    public class ModelObjectCodeUtil
    {
        public static string GenerateModelCode(ModelCondition modelCondition)
        {
            try
            {
                if (modelCondition == null || string.IsNullOrWhiteSpace(modelCondition.Text))
                {
                    return string.Empty;
                }

                StringBuilder sb = new StringBuilder();

                bool isAddClass = false;

                // 0. 将文本分割成多行
                var lines = modelCondition.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


                // 1. 查看第一行是否带有类的信息
                isAddClass = IsClass(lines[0], out string clazzName, out string clazzComment);
                if (isAddClass)
                {
                    if (modelCondition.AddApiModelPropertyAttribute)
                    {
                        sb.AppendLine($"@ApiModel(\"{clazzComment}\")");
                    }

                    sb.AppendLine("@Data");
                    sb.AppendLine($"public class {clazzName}" + '{');
                }

                // 2. 分析每一行 获取 所得列表
                int startIndex = isAddClass ? 1 : 0; // 如果是带了类信息，那么第一行描述的是类的信息，从第二行开始描述的才是filed信息
                for (int i = startIndex; i < lines.Length; i++)
                {
                    string line = lines[i];

                    if (GetField(line, out string fieldName, out string typeName, out string comment))
                    {
                        sb.AppendLine(); // 添加一个空行

                        string fieldCode = $"\tprivate {typeName} {fieldName}; // {comment}";
                        if (modelCondition.AddApiModelPropertyAttribute)
                        {
                            string apiComment = $"\t@ApiModelProperty(\"{comment}\")";
                            sb.AppendLine(apiComment);
                        }

                        sb.AppendLine(fieldCode);
                    }
                }

                // 3. 添加括号 返回代码
                if (isAddClass)
                {
                    sb.AppendLine("}");
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return string.Empty;
        }

        /// <summary>
        /// 判断是否带有Class
        /// </summary>
        /// <param name="text"></param>
        /// <param name="clazzName"></param>
        /// <returns></returns>
        private static bool IsClass(string text, out string clazzName, out string comment)
        {
            bool flag = false;
            clazzName = string.Empty;
            comment = string.Empty;

            if (!string.IsNullOrWhiteSpace(text))
            {
                string[] words = text.Split(':');
                if (words.Length > 2 && "class".Equals(words[1], StringComparison.OrdinalIgnoreCase))
                {
                    clazzName = words[0];
                    comment = words[2];
                    flag = true;
                }
            }

            return flag;
        }

        /// <summary>
        /// 从一行文本中获取 字段名 类型名 注释
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fieldName"></param>
        /// <param name="typeName"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        private static bool GetField(string text, out string fieldName, out string typeName, out string comment)
        {
            bool flag = false;

            fieldName = string.Empty;
            typeName = string.Empty;
            comment = string.Empty;

            if (string.IsNullOrWhiteSpace(text))
            {
                return flag;
            }

            string pattern = @"([a-zA-Z_]+):([a-zA-Z<>]+):([\w]+)";

            var match = Regex.Match(text, pattern);

            if (match.Success)
            {
                var groups = match.Groups;
                if (groups.Count > 3)
                {
                    fieldName = groups[1].Value;
                    typeName = groups[2].Value;
                    comment = groups[3].Value;
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }

            return flag;
        }
    }

}
