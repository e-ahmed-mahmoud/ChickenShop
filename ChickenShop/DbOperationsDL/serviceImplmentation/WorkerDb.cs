using ChickenShop.DbOperationsDL.servicesProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.serviceImplmentation
{
    class WorkerDb : IWorker
    {

        //#region worker region 

        //public List<String> GetWorkersNames()
        //{
        //    var list = (_context.TbWorkers.Where(w => !string.IsNullOrEmpty(w.WorkerName))
        //        .Select(c => String.Concat(" ", c.WorkerName)).ToList());
        //    return list;
        //}

        //public bool DeleteWorker(string workerName)
        //{
        //    var worker = _context.TbWorkers.SingleOrDefault(w => w.WorkerName == workerName.Trim());
        //    if (worker != null)
        //    {
        //        _context.TbWorkers.Remove(worker);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    else
        //        return false;
        //}
        //#endregion
        public bool Create(TbWorker worker)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TbWorker worker)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbWorker> GetAllWorkers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbWorker> SearcheItems(TbWorker worker)
        {
            throw new NotImplementedException();
        }

        public bool Update(TbWorker worker)
        {
            throw new NotImplementedException();
        }
    }
}
