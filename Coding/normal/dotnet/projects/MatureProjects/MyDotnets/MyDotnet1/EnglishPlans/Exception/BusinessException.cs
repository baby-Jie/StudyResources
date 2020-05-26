using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPlans.Exception
{
    /// <summary>
    /// 业务异常
    /// </summary>
    public class BusinessException:System.Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
