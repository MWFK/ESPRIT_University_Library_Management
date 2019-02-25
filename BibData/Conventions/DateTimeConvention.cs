using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibData.Conventions
{
   public class DateTimeConvention:Convention
    {
        public DateTimeConvention()
        {
            Properties<DateTime>().Configure(t => t.HasColumnType("datetime2"));
        }
    }
}
