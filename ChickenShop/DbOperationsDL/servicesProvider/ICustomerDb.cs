using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.servicesProvider
{
    public interface ICustomerDb : IDisposable
    {
        IEnumerable<TbCustomer> GetCustomers();

        bool Create(TbCustomer customer);

        bool Delete(TbCustomer customer);

        bool Update(TbCustomer customer);

        IEnumerable<TbCustomer> SearcheCustomers(TbCustomer customer);


    }
}
