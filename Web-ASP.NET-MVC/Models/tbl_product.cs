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
    
    public partial class tbl_product
    {
        public int pro_id { get; set; }
        public string pro_name { get; set; }
        public int pro_price { get; set; }
        public string pro_des { get; set; }
        public string pro_image { get; set; }
        public int pro_slton { get; set; }
        public Nullable<int> pro_fk_cat { get; set; }
        public Nullable<int> pro_fk_user { get; set; }
        public Nullable<int> pro_fk_ad { get; set; }
        public Nullable<int> pro_fk_cty { get; set; }
        public Nullable<int> pro_day_update { get; set; }

        public virtual tbl_admin tbl_admin { get; set; }
        public virtual tbl_category tbl_category { get; set; }
        public virtual tbl_company tbl_company { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}