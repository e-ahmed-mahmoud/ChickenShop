using ChickenShop.DbOperationsDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop
{

    public class BillData
    {
        private List<BillItems> ListItems = new List<BillItems>();
        private ShopContext context = new ShopContext();

        long? CustomerPk { get; set; }
        long? TreaderPk { get; set; }
        string WorkerPk { get; set; }

        public BillData()
        {

        }

        public void SetBillData(List<BillItems> listItems, string workerName, long? customerPk=null, long? treaderPk=null)
        {
            ListItems = listItems;
            CustomerPk = customerPk;
            TreaderPk = treaderPk;
            WorkerPk = workerName;
        }

        public List<string> GetCustomerData ()
        {
            if (CustomerPk.HasValue)
            {

                var customer = context.TbCustomers.Find(CustomerPk);

                return new List<string>() { customer.CustomerName, customer.CustomerMobileNumber, customer.CustomerAddress };

            }
            else
                return new List<string>();
        }

        public List<string> GetTreaderData()
        {
            if (TreaderPk.HasValue)
            {
                var teader = context.TbTreaders.Find(TreaderPk);

                return new List<string>() { teader.TreaderName, teader.TreaderMobileNumber, teader.TreaderAddress };
            }
            else
                return new List<string>();
        }

    }
}
