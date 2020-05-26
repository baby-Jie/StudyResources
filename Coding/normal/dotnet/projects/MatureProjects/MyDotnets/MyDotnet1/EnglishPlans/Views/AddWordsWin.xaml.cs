using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EnglishPlans.CommonTool;
using EnglishPlans.Model;

namespace EnglishPlans.Views
{
    /// <summary>
    /// AddWordsWin.xaml 的交互逻辑
    /// </summary>
    public partial class AddWordsWin : Window
    {
        public AddWordsWin()
        {
            InitializeComponent();
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string text = AddWordTBox.Text.Trim();
            AddWords(text);
            this.DialogResult = true;
            this.Close();
        }

        private void AddWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            List<english> englishes = new List<english>();

            try
            {
                string[] lines = text.Split("\n".ToCharArray());

                string regexStr = @"(\d{0,4})\s*年\s*(\d{0,2})\s*月\s*(\d{0,2})\s*日"; // 正则表达式
                DateTime date = DateTime.Now.Date;

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    Regex regex = new Regex(regexStr);
                    var match = regex.Match(line);

                    // 如果时候时间行
                    if (match.Success)
                    {
                        var groups = match.Groups;

                        if (groups.Count == 4)
                        {
                            string year = groups[1].Value;
                            string month = groups[2].Value;
                            string day = groups[3].Value;

                            string datestr = $"{year}/{month}/{day}";

                            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();

                            dtFormat.ShortDatePattern = "yyyy/MM/dd";

                            date = Convert.ToDateTime(datestr, dtFormat); // 修改时间
                        }
                    }
                    // 如果是单词行
                    else
                    {
                        // hello 你好 --- Hello, how are you today?
                        try
                        {
                            string[] words = line.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
                            string firstword = words[0].Substring(1).Trim();
                            int index = firstword.IndexOf(" ");
                            string word = firstword.Substring(0, index).Trim();
                            string comment = firstword.Substring(index + 1).Trim();
                            string sentence = words[1].Trim();

                            english english = new english()
                            {
                                word = word,
                                commentary = comment,
                                sentence = sentence,
                                create_time = date,
                                last_review_time = date, // 默认一天后开始复习
                                next_review_time = date.AddDays(1),
                                review_turn = 0,
                                delete_flag = 0,
                            };

                            englishes.Add(english);
                        }
                        catch (System.Exception ex)
                        {
                            Logger.Info(ex.Message);
                        }
                    }
                }


                if (englishes.Count > 0)
                {
                    using (MyContext context = new MyContext())
                    {
                        var ret = context.Englishes;
                        ret.AddRange(englishes);
                        context.SaveChanges();
                    }
                }
            }
            catch (System.Exception e)
            {
                Logger.Info(e.Message);
            }
        }
    }
}
