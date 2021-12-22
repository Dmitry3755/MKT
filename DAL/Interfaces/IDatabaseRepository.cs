using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDatabaseRepository
    {
        IRepository<Information_about_sales> InformationAboutSales { get; }
        IRepository<Сategory> CategoryRepository { get; }
        IProductRepository ProductsRepository { get; }
        IChequeRepository Cheques { get; }
        IAuthorizationRepository AuthorizationRepository { get; }
        int Save();
    }
}
