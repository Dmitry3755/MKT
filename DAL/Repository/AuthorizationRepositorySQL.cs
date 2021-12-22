using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class AuthorizationRepositorySQL : IAuthorizationRepository
    {
        private PcShopContext db;
        public AuthorizationRepositorySQL(PcShopContext database)
        {
            this.db = database;
        }

        public void AddAccount(Users users)
        {

            db.Users.Add(users);

        }
        public List<Users> GetList()
        {
            return db.Users.ToList();
        }

        public bool isUserEmailExists(string userEmail)
        {

            //if (db.Users.Select(i => i.user_login.Equals(userEmail)).ToList().Count == 0)
            try
            {
                db.Users.First(i => i.user_login.Equals(userEmail));
                return true;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
        }

        public bool isLoginDataValid(string userPassword, string userEmail)
        {

            if (db.Users.Single(i => i.user_login == userEmail).user_password == userPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
