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
    
    public partial class tbl_Designation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Designation()
        {
            this.tbl_Employee = new HashSet<tbl_Employee>();
        }
    
        public int DesignationID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public string Scale { get; set; }
    
        public virtual tbl_Users tbl_Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Employee> tbl_Employee { get; set; }
    }
}
