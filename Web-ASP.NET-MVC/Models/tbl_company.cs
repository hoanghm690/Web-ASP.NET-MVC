//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_ASP.NET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_company()
        {
            this.tbl_product = new HashSet<tbl_product>();
        }
    
        public int cty_id { get; set; }
        public string cty_name { get; set; }
        public string cty_email { get; set; }
        public string cty_contact { get; set; }
        public string cty_phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_product> tbl_product { get; set; }
    }
}