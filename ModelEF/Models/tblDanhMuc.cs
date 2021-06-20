namespace ModelEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDanhMuc")]
    public partial class tblDanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDanhMuc()
        {
            tblSanPhams = new HashSet<tblSanPham>();
        }

        [Key]
        [StringLength(7)]
        [DisplayName("ID loại sản phẩm")]
        public string idDM { get; set; }

        [StringLength(100)]
        [DisplayName("Loại sản phẩm")]
        public string tenDM { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả")]
        public string moTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSanPham> tblSanPhams { get; set; }

        public override string ToString()
        {
            return tenDM;
        }
    }
}
