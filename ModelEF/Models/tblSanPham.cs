namespace ModelEF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSanPham")]
    public partial class tblSanPham
    {
        [Key]
        [StringLength(7)]
        [DisplayName("ID sản phẩm")]
        public string idSP { get; set; }

        [StringLength(100)]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Hãy nhập tên sản phẩm")]
        public string tenSP { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Hãy nhập số lượng")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng không hợp lệ!")]
        public int? soLuong { get; set; }

        [DisplayName("Giá bán")]
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue,ErrorMessage = "Giá bán không hợp lệ!")]
        [Required(ErrorMessage = "Hãy nhập giá bán")]
        public decimal? giaBan { get; set; }

        [DisplayName("Hình ảnh")]
        public string hinhAnh { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả")]
        public string mota { get; set; }

        [StringLength(1)]
        [DisplayName("Trạng thái")]
        public string trangThai { get; set; }

        [StringLength(7)]
        [DisplayName("Loại sản phẩm")]
        public string DMNo { get; set; }

        public virtual tblDanhMuc tblDanhMuc { get; set; }
    }
}
