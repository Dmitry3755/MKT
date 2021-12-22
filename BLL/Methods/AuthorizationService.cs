using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using DAL.Repository;
using BLL;

namespace BLL.Methods
{
    public class AuthorizationService : IAuthorizationService
    {
        IDatabaseRepository db;
        public AuthorizationService(IDatabaseRepository database)
        {
            db = database;
        }

        public void AddAccount(UsersModel usersModel)
        {
            db.AuthorizationRepository.AddAccount(new Users()
            {
                user_id = usersModel.user_id,
                user_login = usersModel.user_login,
                user_password = usersModel.user_password
            });
            Save();

        }

        public List<UsersModel> GetUsersList()
        {
            return db.AuthorizationRepository.GetList().Select(i => new UsersModel(i)).ToList();
        }

        public void Save()
        {
            db.Save();
        }
    }
}
