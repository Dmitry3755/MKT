using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL;

namespace DAL.Repository
{
    public class ChequeRepositorySQL : IChequeRepository
    {
        private PcShopContext db;
        private class chequeResult
        {
            public string nameProduct { get; set; }
            public int salesCount { get; set; }

            public decimal salesPrice { get; set; }

            public DateTime salesDate { get; set; }

        }
        public ChequeRepositorySQL(PcShopContext pcshopContext)
        {
            this.db = pcshopContext;
        }

        public List<Information_about_sales> informationAboutSalesByMonth(int informationAboutSalesId)
        {
            var request = db.Information_about_sales
             .Join(db.Products, ph => ph.product_FK, m => m.product_id, (ph, m) => ph)
             .Where(i => i.Information_about_sales_id == informationAboutSalesId)
             .Select(i => new Information_about_sales() { sales_count = i.sales_count, sales_price = i.sales_price, sales_date = i.sales_date, product_FK = i.product_FK })
             .ToList();
            return request;
        }
    }
}
