//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChickenShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TbBill()
        {
            this.TbBillsItemsBridges = new HashSet<TbBillsItemsBridge>();
        }
    
        public long BilI_ID { get; set; }
        public decimal TotalPrice { get; set; }
        public Nullable<long> CustomerID { get; set; }
        public Nullable<long> TreaderID { get; set; }
        public int WorkerID { get; set; }
    
        public virtual TbCustomer TbCustomer { get; set; }
        public virtual TbWorker TbWorker { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TbBillsItemsBridge> TbBillsItemsBridges { get; set; }
        public virtual TbTreader TbTreader { get; set; }
    }
}
