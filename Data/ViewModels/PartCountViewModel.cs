using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class PartCountViewModel
    {
        public string Platform_Code { get; set; }
        public string Part_Category { get; set; }

        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }

    }
}


