using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.servicesProvider
{
    public interface IWorker : IDisposable
    {
        IEnumerable<TbWorker> GetAllWorkers();

        bool Create(TbWorker worker);


        bool Delete(TbWorker worker);


        bool Update(TbWorker worker);


        IEnumerable<TbWorker> SearcheItems(TbWorker worker );
    }
}
