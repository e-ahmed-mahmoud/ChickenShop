//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChickenShop.DbOperationsDL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbBillsItemsBridge
    {
        public long ItemsInBillID { get; set; }
        public Nullable<long> BillFkID { get; set; }
        public Nullable<long> ItemsFkID { get; set; }
    
        public virtual TbBill_Items TbBill_Items { get; set; }
        public virtual TbBill TbBill { get; set; }
    }
}
