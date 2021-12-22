using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class CategoryRepositorySQL : IRepository<Сategory>
    {
        private PcShopContext db;
        public CategoryRepositorySQL(PcShopContext database)
        {
            this.db = database;
        }
        public List<Сategory> GetList()
        {
            return db.Сategory.ToList();
        }
        public Сategory GetItem(int id)
        {
            return db.Сategory.Find(id);
        }

        public void Create(Сategory сategory)
        {
            db.Сategory.Add(сategory);
        }

        public void Update(Сategory сategory)
        {
            db.Entry(сategory).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Сategory сategory = db.Сategory.Find(id);
            if (сategory != null)
                db.Сategory.Remove(сategory);
        }
    }
}
