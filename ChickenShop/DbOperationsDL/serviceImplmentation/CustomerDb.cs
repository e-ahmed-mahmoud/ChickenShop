using ChickenShop.DbOperationsDL.servicesProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.serviceImplmentation
{
    public class CustomerDb : ICustomerDb
    {
        private readonly ShopContext _context = new ShopContext();

        public long TreaderPK { get; private set; }
        public long CustomerPk { get; private set; }

        #region Customer methods
        private void AddNewCustomer(string name, string mobile, string address)
        {
            var customer = new TbCustomer()
            {
                CustomerName = name,
                CustomerAddress = address,
                CustomerMobileNumber = mobile,
                CustomerPoints = 5
            };
            _context.TbCustomers.Add(customer);
            CustomerPk = customer.Customer_ID;
            _context.SaveChanges();
        }

        public bool CheckOnCustomer(string name, string mobile, string address)
        {
            try
            {
                var customer = _context.TbCustomers.SingleOrDefault(c => c.CustomerName == name && c.CustomerMobileNumber == mobile);
                if (customer == null)
                {
                    AddNewCustomer(name, mobile, address);
                    return true;
                }
                else
                {
                    customer.CustomerName = name;
                    customer.CustomerMobileNumber = mobile;
                    customer.CustomerAddress = address;
                    TreaderPK = customer.Customer_ID;
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public TbCustomer LoadCustomer(string name, string mobile)
        {
            return (_context.TbCustomers.SingleOrDefault(c => c.CustomerName == name && c.CustomerMobileNumber == mobile));
        }

        public IEnumerable<TbCustomer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public bool Create(TbCustomer customer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TbCustomer customer)
        {
            throw new NotImplementedException();
        }

        public bool Update(TbCustomer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbCustomer> SearcheCustomers(TbCustomer customer)
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
