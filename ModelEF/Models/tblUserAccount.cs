namespace ModelEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUserAccount")]
    public partial class tblUserAccount
    {
        [Key]
        [StringLength(7)]
        public string idUser { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        public string password { get; set; }

        [StringLength(1)]
        public string status { get; set; }
    }
}
