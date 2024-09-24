using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class AggregateCountViewModel
    {
        public string AGGREGATE { get; set; }

        public int Total_Active_BO_IP { get; set; }

        public int Active_Count_BO { get; set; }
        public int Active_Count_IP { get; set; }

        public int Count_Sourcing_Closure { get; set; }
        public int Count_ME_Closure { get; set; }
        public int Count_Designer_Remarks { get; set; }

        public int Total_Active_Inactive_BO_IP { get; set; }
        public int Total_Inactive_BO_IP { get; set; }
    }

}
