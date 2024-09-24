using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PartCategory
    {
        public string Category { get; set; }
        public int ActivePartsCount { get; set; }
        public int released { get; set; }
        public int inReleaseProcess { get; set; }
        public int pendingForRelease { get; set; }
        public int InactivePartsCount { get; set; }
        public int TotalCount { get; set; }
    }

}

