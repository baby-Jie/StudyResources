using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishPlans.CommonTool;
using EnglishPlans.Model;

namespace EnglishPlans.Service
{
    public class EnglishDataService : IDataService, IDisposable
    {
        public EnglishDataService(MyContext myContext)
        {
            _myContext = myContext;
        }

        private MyContext _myContext;

        /// <summary>
        /// 获取英语单词
        /// </summary>
        /// <returns></returns>
        public List<EnglishWordModel> GetEnglishWordModels()
        {
            DbSet<english> englishes = _myContext.Englishes;

            List<EnglishWordModel> englishWords = new List<EnglishWordModel>();

            foreach (var english in englishes)
            {
                EnglishWordModel englishWordModel = EnglishUtils.TranslateEnglish(english);

                if (englishWordModel != null)
                {
                    englishWords.Add(englishWordModel);
                }
            }

            return englishWords;
        }

        /// <summary>
        /// 获取要复习的英语单词
        /// </summary>
        /// <returns></returns>
        public List<EnglishWordModel> GetReviewEnglishWords()
        {
            var englishWords = GetEnglishWordModels();

            DateTime today = DateTime.Today;

            var reviewWords = from word in englishWords where word.ReviewTurn < ReviewTurn.OVER && word.NextReviewTime <= today select word;

            return new List<EnglishWordModel>(reviewWords);
        }

        public void Dispose()
        {
            _myContext?.Dispose();
        }

    }
}
