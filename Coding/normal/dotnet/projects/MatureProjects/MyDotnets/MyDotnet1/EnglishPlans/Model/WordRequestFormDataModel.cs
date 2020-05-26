using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPlans.Model
{
    public class WordRequestFormDataModel
    {
        public string from { get; set; } = "en";

        public string to { get; set; } = "zh";

        public string query { get; set; }

        public string simple_means_flag { get; set; }

        public string sign { get; set; }

        public string token { get; set; }

        public string domain { get; set; }
    }
}
