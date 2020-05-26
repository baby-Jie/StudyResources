using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPlans.Model
{
    public class MyContext:DbContext
    {
        public MyContext() : base("mainEntities") { }

        public DbSet<english> Englishes { get; set; }
    }
}
