//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kutabkhana_DBLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_PurchaseDetails
    {
        public int PurchaseDetailID { get; set; }
        public int BookID { get; set; }
        public int PurchaseID { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
    
        public virtual tbl_Book tbl_Book { get; set; }
        public virtual tbl_Purchase tbl_Purchase { get; set; }
    }
}
