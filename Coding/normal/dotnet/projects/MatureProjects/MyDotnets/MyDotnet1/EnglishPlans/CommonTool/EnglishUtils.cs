using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishPlans.Model;

namespace EnglishPlans.CommonTool
{
    public class EnglishUtils
    {
        /// <summary>
        /// 将english 转换成 EnglishWordModel
        /// </summary>
        /// <param name="english"></param>
        /// <returns></returns>
        public static EnglishWordModel TranslateEnglish(english english)
        {
            if (english == null)
            {
                return null;
            }

            EnglishWordModel model = new EnglishWordModel();
            model.Id = english.id;
            model.Word = english.word;
            model.Commentary = english.commentary;
            model.Sentence = english.sentence;
            model.ReviewTurn = (ReviewTurn)english.review_turn; // 复习轮数
            model.CreateTime = english.create_time;
            model.LastReviewTime = english.last_review_time;
            model.NextReviewTime = english.next_review_time;
            model.English = english; // 元数据

            return model;
        }

        public static english TranslateEnglishWordModel(EnglishWordModel model)
        {
            english english = new english();

            english.id = model.Id;
            english.word = model.Word;
            english.commentary = model.Commentary;

            return english;
        }
    }
}
