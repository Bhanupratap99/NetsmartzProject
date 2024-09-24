using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class DesignReleaseRequest
    {
        public List<string> Platform_Code { get; set; }
        public List<string>? Project_Code { get; set; }
        public string? Date { get; set; }
        public string Report_Status { get; set; }

        public string Aggregate { get; set; }


    }
}
