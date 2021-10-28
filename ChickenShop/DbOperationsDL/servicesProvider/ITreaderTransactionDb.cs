using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.servicesProvider
{
    public interface ITreaderTransactionDb : IDisposable
    {
        IEnumerable<TbTreaderTransaction> GetAllTreaderTransactions();

        bool Create(TbTreaderTransaction treader);


        bool Delete(TbTreaderTransaction treader);


        bool Update(TbTreaderTransaction treader);


        IEnumerable<TbTreaderTransaction> SearcheItems(TbTreaderTransaction treader);

    }
}
