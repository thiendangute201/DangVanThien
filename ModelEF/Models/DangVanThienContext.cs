using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ModelEF.Models
{
    public partial class DangVanThienContext : DbContext
    {
        public DangVanThienContext()
            : base("name=DangVanThienContext")
        {
        }

        public virtual DbSet<tblDanhMuc> tblDanhMucs { get; set; }
        public virtual DbSet<tblSanPham> tblSanPhams { get; set; }
        public virtual DbSet<tblUserAccount> tblUserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblDanhMuc>()
                .Property(e => e.idDM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblDanhMuc>()
                .HasMany(e => e.tblSanPhams)
                .WithOptional(e => e.tblDanhMuc)
                .HasForeignKey(e => e.DMNo);

            modelBuilder.Entity<tblSanPham>()
                .Property(e => e.idSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblSanPham>()
                .Property(e => e.giaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblSanPham>()
                .Property(e => e.hinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<tblSanPham>()
                .Property(e => e.mota)
                .IsUnicode(false);

            modelBuilder.Entity<tblSanPham>()
                .Property(e => e.trangThai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblSanPham>()
                .Property(e => e.DMNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblUserAccount>()
                .Property(e => e.idUser)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblUserAccount>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUserAccount>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUserAccount>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
