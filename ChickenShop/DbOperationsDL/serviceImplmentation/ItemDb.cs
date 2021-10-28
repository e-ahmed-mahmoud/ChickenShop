using ChickenShop.DbOperationsDL.servicesProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenShop.DbOperationsDL.serviceImplmentation
{
    public class ItemDb : IItemDb 
    {
        private readonly ShopContext _context = new ShopContext();

        public bool Create(BillItems item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BillItems item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BillItems> GetItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BillItems> SearcheItems(BillItems item)
        {
            throw new NotImplementedException();
        }

        public bool Update(BillItems item)
        {
            throw new NotImplementedException();
        }
        #region items methods

        //internal void AddingNewItems(string name, decimal price, decimal quantity)
        //{
        //    var item = _context.TbItemTypes.SingleOrDefault(n => n.ItemName == name);
        //    if (item != null)
        //    {
        //        UpdateExitingItem(name, price, quantity);
        //    }
        //    else
        //    {
        //        var newItem = new TbItemType() { ItemName = name };
        //        var data2 = new TbBill_Items()
        //        { TodayItem = DateTime.Now, TbItemType = newItem, Price = price, Quantity = quantity };
        //        _context.TbBill_Items.Add(data2);
        //        _context.SaveChanges();
        //    }
        //}

        //internal void UpdateExitingItem(string name, decimal price, decimal quantity)
        //{
        //    var item = _context.TbItemTypes.SingleOrDefault(n => n.ItemName == name);

        //    var todayItem = new TbBill_Items() { TodayItem = DateTime.Now, TbItemType = item, Price = price, Quantity = quantity };
        //    _context.TbBill_Items.Add(todayItem);
        //    _context.SaveChanges();
        //}

        //internal bool DeleteItemFromTbItems(long id)
        //{
        //    var item = _context.TbBill_Items.SingleOrDefault(c => c.ItemIDPK == id);
        //    if (item != null)
        //    {
        //        _context.TbBill_Items.Remove(item);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //internal bool EditItemInTBItems(long id, decimal price, decimal quantity, string name)
        //{
        //    try
        //    {
        //        var item = _context.TbBill_Items.Find(id);
        //        if (item != null)
        //        {
        //            item.TbItemType.ItemName = name;
        //            item.Price = price;
        //            item.Quantity = quantity;
        //            item.TodayItem = DateTime.Now;
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

        //public List<string> SetItemsList(decimal quantity = 0)
        //{
        //    var itemsList = _context.TbBill_Items.Where(c => c.Quantity != 0).OrderByDescending(d => d.TodayItem).
        //        Select(d => String.Concat(d.TbItemType.ItemName + "\t\t\t" + (d.Quantity - quantity) + "ك" + "\t" + "$" + d.Price + "\t" + d.TodayItem.Day + "-" + d.TodayItem.Month + "-" + d.TodayItem.Year)).ToList();
        //    return itemsList;
        //}

        //public void GetItemsList(string selectedItem)
        //{
        //    var strItem = selectedItem.Split('\t');
        //    var strName = strItem[0].ToString();
        //    var strQuanity = strItem[3].Split('ك').ElementAt(0);
        //    var strPrice = strItem[4].Split('$').ElementAt(1);

        //    decimal quantity;
        //    decimal price;
        //    DateTime date;


        //    var date2 = strItem[5].Split('-');

        //    date = DateTime.Parse(date2[2] + "-" + date2[1] + "-" + date2[0]);

        //    if (decimal.TryParse(strQuanity, out quantity) && decimal.TryParse(strPrice, out price))
        //    {
        //        var item = _context.TbBill_Items.SingleOrDefault(c => c.TbItemType.ItemName == strName && c.Quantity == quantity && c.Price == price &&
        //                        c.TodayItem.Day == date.Day && c.TodayItem.Month == date.Month && c.TodayItem.Year == date.Year);

        //        Date = date;

        //        if (item == null)
        //        {
        //            throw new NullReferenceException();
        //        }
        //        else
        //            ItemPk = item.ItemIDPK;
        //    }
        //    else
        //        throw new Exception("not convert types");
        //}


        //public bool UpdateItemQuantityAfterPrinting(decimal quantity)
        //{
        //    try
        //    {
        //        if (quantity <= _context.TbBill_Items.Find(ItemPk).Quantity)
        //        {
        //            _context.TbBill_Items.Find(ItemPk).Quantity -= quantity;
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateItemsBeforePrinting(decimal quantity)
        //{
        //    try
        //    {
        //        if (quantity <= _context.TbBill_Items.Find(ItemPk).Quantity)
        //        {
        //            _context.TbBill_Items.Find(ItemPk).Quantity -= quantity;
        //            SetItemsList();
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

        //public decimal GetItemPrice() { return _context.TbBill_Items.Find(ItemPk).Price; }

        //public void SaveTheChangingItems() { _context.SaveChanges(); }

        //internal bool CheckOnItemQuantity(decimal quantity)
        //{
        //    decimal itemQuantity = _context.TbBill_Items.Find(ItemPk).Quantity;
        //    if (quantity <= itemQuantity)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public List<object> GetItem(decimal quantity)
        //{
        //    //var item = _context.TbBill_Items.Where(c => c.ItemIDPK == _itemPk).Select(d => new List<string> { d.TbItemType.ItemName, d.Quantity.ToString(), d.Price.ToString(), (d.Price * quantity).ToString() });
        //    var item = _context.TbBill_Items.Where(c => c.ItemIDPK == ItemPk).Select(d => new List<object>
        //    {
        //        d.Price , d.Quantity , d.TbItemType.ItemName
        //    });
        //    return item as List<object>;
        //}

        //public bool SetBillItems(List<BillItems> billItems)
        //{
        //    if (billItems == null)
        //    {
        //        throw new NullReferenceException();
        //    }
        //    if (billItems.Count == 0)
        //    {
        //        return false;
        //    }
        //    TbBill bill = new TbBill();
        //    bill.CustomerID.GetValueOrDefault();
        //    bill.TreaderID.GetValueOrDefault();

        //    foreach (var item in billItems)
        //    {

        //    }

        //    return true;
        //}

        //public IEnumerable<BillItems> GetItems()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Create(BillItems item)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(BillItems item)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Update(BillItems item)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<BillItems> SearcheItems(BillItems item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        #endregion


    }
}
