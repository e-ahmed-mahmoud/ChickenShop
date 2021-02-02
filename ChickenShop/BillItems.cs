using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop
{
    public class BillItems
    {
        public TbBill_Items Item { get; set; }
        private ShopContext _context = new ShopContext();
        public decimal ItemBillPrice { get; set; }
        private long _itemPK;

        public BillItems()
        {
                
        }

        public BillItems(long itemPk)
        {
            _itemPK = itemPk;
            Item = _context.TbBill_Items.Find(_itemPK);
        }

        public BillItems GetBillItems(decimal quantity)
        {
            Item.Quantity = quantity;
            return (new BillItems() { Item = Item, ItemBillPrice = Item.Price * quantity });
        }

    }
}
