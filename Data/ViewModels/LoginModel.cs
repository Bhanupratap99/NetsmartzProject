using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class LoginModel
    {
       
         public string username { get; set; }
         public string password { get; set; }

         public string IpAddress { get; set; }
         public string BrowserName { get; set; }
         public string BrowserVersion { get; set; }
         public string reCaptcha { get; set; }

        // public bool mahindraUser { get; set; }
        // public string? Token { get; set; }
        // public bool? loggedIn { get; set; }
    }
}
