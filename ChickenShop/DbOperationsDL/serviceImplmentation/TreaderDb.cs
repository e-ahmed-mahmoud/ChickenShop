using ChickenShop.DbOperationsDL.servicesProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.serviceImplmentation
{
    public class TreaderDb : ITreaderDb
    {
        private readonly ShopContext _context = new ShopContext();

        public long TreaderPK { get; private set; }

        public bool Create(TbTreader treaderModel)
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbTreader> GetAllTreadera()
        {
            throw new NotImplementedException();
        }

        #region treader methods
        private void AddNewTreader(string name, string mobile, string address)
        {
            var treader = new TbTreader()
            {
                TreaderName = name,
                TreaderAddress = address,
                TreaderMobileNumber = mobile,
            };
            _context.TbTreaders.Add(treader);
            TreaderPK = treader.TreaderID;
            _context.SaveChanges();
        }

        public bool CheckOnTreader(string name, string mobile, string address)
        {
            try
            {
                var treader = _context.TbTreaders.SingleOrDefault(t => t.TreaderName == name && t.TreaderMobileNumber == mobile);
                if (treader == null)
                {
                    AddNewTreader(name, mobile, address);
                    return true;
                }
                else
                {
                    treader.TreaderName = name;
                    treader.TreaderMobileNumber = mobile;
                    treader.TreaderAddress = address;
                    TreaderPK = treader.TreaderID;
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TbTreader LoadTreader(string name, string mobile)
        {
            return (_context.TbTreaders.SingleOrDefault(t => t.TreaderName == name && t.TreaderMobileNumber == mobile));
        }

        public IEnumerable<TbTreader> GetAllTreaders()
        {
            throw new NotImplementedException();
        }

        public bool Delete(TbTreader treader)
        {
            throw new NotImplementedException();
        }

        public bool Update(TbTreader treader)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbTreader> SearcheItems(TbTreader treader)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
