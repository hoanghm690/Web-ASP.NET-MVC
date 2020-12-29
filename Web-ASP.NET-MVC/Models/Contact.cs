namespace Web_ASP.NET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int ContactCode { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public bool? ContactStatus { get; set; }
    }
}
