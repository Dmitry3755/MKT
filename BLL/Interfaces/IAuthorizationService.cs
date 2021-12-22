using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthorizationService
    {
       void AddAccount(UsersModel usersModel);
       List<UsersModel> GetUsersList();
       void Save();
    }
}
