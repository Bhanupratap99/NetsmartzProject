using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAccountRepository
    {
        dynamic LoginRepository(LoginModel loginModel, bool aldapValidated, string Token);

        dynamic LogoutRepository(string username);


    }

    
}
