using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.servicesProvider
{
    public interface IItemDb : IDisposable
    {
        IEnumerable<BillItems> GetItems();

        bool Create(BillItems item);

        bool Delete(BillItems item);

        bool Update(BillItems item);

        IEnumerable<BillItems> SearcheItems(BillItems item);

    }
}
