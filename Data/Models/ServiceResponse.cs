using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ServiceResponse
    {
        public bool? isError { get; set; } = false;
        public string Error { get; set; }
        public object result { get; set; }

        public string Message { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public int TotalCount { get; set; }

    }

}

