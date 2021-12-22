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

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
