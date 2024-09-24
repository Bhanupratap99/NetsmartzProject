using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        ServiceResponse LoginService(LoginModel loginModel);
        ServiceResponse LogOutService(string username);
    }
}
