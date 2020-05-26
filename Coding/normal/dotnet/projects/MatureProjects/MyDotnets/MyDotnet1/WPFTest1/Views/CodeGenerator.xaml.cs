using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace WPFTest1.Views
{
    /// <summary>
    /// CodeGenerator.xaml 的交互逻辑
    /// </summary>
    public partial class CodeGenerator : Window
    {

        public HashSet<string> _clazzSet = new HashSet<string>();

        public List<Tuple<string, JObject>> _clazzList = new List<Tuple<string, JObject>>();
        
        public CodeGenerator()
        {
            InitializeComponent();
        }

        private void TestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string json = TestTBox.Text.Trim();
            JObject jObject = JObject.Parse(json);

            // 准备层级遍历第一个数据
            if (jObject != null)
            {
                _clazzList.Add(new Tuple<string, JObject>("Root", jObject));
            }

            string clazzStrs = LevelOrder();

            Console.WriteLine(clazzStrs);
        }

        /// <summary>
        /// 层级遍历
        /// </summary>
        /// <returns></returns>
        private string LevelOrder()
        {
            StringBuilder sb = new StringBuilder();
            while (_clazzList.Count > 0)
            {
                // 取出一个数据
                var tuple = _clazzList[0];
                _clazzList.RemoveAt(0);

                string name = tuple.Item1;
                JObject jObject = tuple.Item2;

                string clazzStr = GetJavaJObjectClazzString(name, jObject);

                sb.AppendLine(clazzStr);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 生成java类代码
        /// </summary>
        /// <param name="objName"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        private string GetJavaJObjectClazzString(string objName, JObject jObject)
        {
            if (jObject == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public class {objName} {{");

            string formatStr = "\tprivate {0} {1};";

            JToken token = jObject;

            var properties = jObject.Properties();

            foreach (var property in properties)
            {
                string name = property.Name;
                if (property.Value.Type == JTokenType.String)
                {
                    sb.AppendLine(string.Format(formatStr, "String", name));
                }
                else if (property.Value.Type == JTokenType.Integer)
                {
                    sb.AppendLine(string.Format(formatStr, "int", name));
                }
                else if (property.Value.Type == JTokenType.Boolean)
                {
                    sb.AppendLine(string.Format(formatStr, "boolean", name));
                }
                else if (property.Value.Type == JTokenType.Date)
                {
                    sb.AppendLine(string.Format(formatStr, "DateTime", name));
                }
                else if (property.Value.Type == JTokenType.Float)
                {
                    sb.AppendLine(string.Format(formatStr, "float", name));
                }
                else if (property.Value.Type == JTokenType.Object)
                {
                    sb.AppendLine(string.Format(formatStr, name, name));
                    JObject val = property.Value.ToObject<JObject>();
                    if (!_clazzSet.Contains(name))
                    {
                        _clazzSet.Add(name);
                        _clazzList.Add(new Tuple<string, JObject>(name, val));
                    }
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    sb.AppendLine(string.Format(formatStr, $"List<{name}>", name));
                    JArray jArray = property.Value.ToObject<JArray>();
                    if (jArray.Count > 0)
                    {
                        var jO = (JObject)jArray[0];
                        if (!_clazzSet.Contains(name))
                        {
                            _clazzSet.Add(name);
                            _clazzList.Add(new Tuple<string, JObject>(name, jO));
                        }
                    }
                }
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// 生成dotnet类代码
        /// </summary>
        /// <param name="objName"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        private string GetDotnetJObjectClazzString(string objName, JObject jObject)
        {
            if (jObject == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public class {objName}");
            sb.AppendLine("{");

            string formatStr = "\tpublic {0} {1} {{get; set;}}";

            JToken token = jObject;

            var properties = jObject.Properties();

            foreach (var property in properties)
            {
                string name = property.Name;
                if (property.Value.Type == JTokenType.String)
                {
                    //string val = property.Value.ToString();
                    sb.AppendLine(string.Format(formatStr, "string", name));
                }
                else if (property.Value.Type == JTokenType.Integer)
                {
                    //int val = property.Value.ToObject<int>();
                    sb.AppendLine(string.Format(formatStr, "int", name));
                }
                else if (property.Value.Type == JTokenType.Boolean)
                {
                    //bool val = property.Value.ToObject<bool>();
                    sb.AppendLine(string.Format(formatStr, "bool", name));
                }
                else if (property.Value.Type == JTokenType.Date)
                {
                    //DateTime val = property.Value.ToObject<DateTime>();
                    sb.AppendLine(string.Format(formatStr, "DateTime", name));
                }
                else if (property.Value.Type == JTokenType.Float)
                {
                    //float val = property.Value.ToObject<float>();
                    sb.AppendLine(string.Format(formatStr, "float", name));
                }
                else if (property.Value.Type == JTokenType.Object)
                {
                    sb.AppendLine(string.Format(formatStr, name, name));
                    JObject val = property.Value.ToObject<JObject>();
                    if (!_clazzSet.Contains(name))
                    {
                        _clazzSet.Add(name);
                        _clazzList.Add(new Tuple<string, JObject>(name, val));
                    }
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    sb.AppendLine(string.Format(formatStr, $"List<{name}>", name));
                    JArray jArray = property.Value.ToObject<JArray>();
                    //jArray.

                    if (jArray.Count > 0)
                    {
                        var jO = (JObject)jArray[0];
                        if (!_clazzSet.Contains(name))
                        {
                            _clazzSet.Add(name);
                            _clazzList.Add(new Tuple<string, JObject>(name, jO));
                        }
                    }
                }
                
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
