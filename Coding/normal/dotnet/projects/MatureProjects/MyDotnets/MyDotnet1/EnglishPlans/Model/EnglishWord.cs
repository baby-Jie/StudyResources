using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace EnglishPlans.Model
{
    public class EnglishWordModel : ViewModelBase
    {
        /// <summary>
        /// 单词id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 单词
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// 中文
        /// </summary>
        public string Commentary { get; set; }

        /// <summary>
        /// 句子
        /// </summary>
        public string Sentence { get; set; }

        /// <summary>
        /// 当前复习轮数
        /// </summary>
        public ReviewTurn ReviewTurn { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 上次复习时间
        /// </summary>
        public DateTime LastReviewTime { get; set; }

        /// <summary>
        /// 下次复习时间
        /// </summary>
        public DateTime NextReviewTime { get; set; }

        #region Business 以下为业务所需

        /// <summary>
        /// 数据库的Model
        /// </summary>
        public english English { get; set; }

        private bool _isExapanded;

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool IsExpanded
        {
            get => _isExapanded;
            set { Set("IsExpanded", ref _isExapanded, value); }
        }

        #region MVVMProperty IsReviewed 是否复习过

        private bool _isReviewed;

        public bool IsReviewed
        {
            get { return _isReviewed; }
            set { Set(ref _isReviewed, value); }
        }

        #endregion	MVVMProperty IsReviewed

        #endregion Business	



        public override string ToString()
        {
            return this.Word;
        }
    }
}
