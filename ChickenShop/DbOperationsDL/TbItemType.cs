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
    
    public partial class TbItemType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TbItemType()
        {
            this.TbBill_Items = new HashSet<TbBill_Items>();
        }
    
        public int ItemID { get; set; }
        public string ItemName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TbBill_Items> TbBill_Items { get; set; }
    }
}