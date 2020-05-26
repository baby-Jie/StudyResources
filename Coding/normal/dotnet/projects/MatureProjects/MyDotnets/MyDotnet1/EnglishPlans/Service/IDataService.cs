using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishPlans.Model;

namespace EnglishPlans.Service
{
    public interface IDataService
    {
        List<EnglishWordModel> GetEnglishWordModels();

        List<EnglishWordModel> GetReviewEnglishWords();
    }
}
