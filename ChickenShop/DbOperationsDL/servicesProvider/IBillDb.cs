using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.servicesProvider
{
    public interface IBillDb : IDisposable
    {
        IEnumerable<TbBill> GetBills();

        bool Create(TbBill bill);

        bool Delete(TbBill bill);

        bool Update(TbBill bill);

        IEnumerable<TbBill> SearcheBills( TbBill bill);

    }
}
