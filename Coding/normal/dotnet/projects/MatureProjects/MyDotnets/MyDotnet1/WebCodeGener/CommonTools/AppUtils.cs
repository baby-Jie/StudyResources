using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCodeGener.Models;

namespace WebCodeGener.CommonTools
{
    public class AppUtils
    {
        public static string GenerateModelCode(ModelCondition modelCondition)
        {
            return ModelObjectCodeUtil.GenerateModelCode(modelCondition);
        }
        
    }
}
