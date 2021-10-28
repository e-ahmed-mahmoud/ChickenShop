using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.servicesProvider
{
    public interface ITreaderDb : IDisposable
    {
        IEnumerable<TbTreader> GetAllTreaders();

        bool Create(TbTreader treader);


        bool Delete(TbTreader treader);


        bool Update(TbTreader treader);


        IEnumerable<TbTreader> SearcheItems(TbTreader treader);


    }
}
