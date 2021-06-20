using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Models;
using PagedList;

namespace ModelEF.DAO
{
    public class SanPhamDAO
    {
        DangVanThienContext db;
        public SanPhamDAO()
        {
            db = new DangVanThienContext();
        }

        public tblSanPham GetSanPham(string id)
        {
            return db.tblSanPhams.Find(id);
        }

        public tblDanhMuc GetDanhMuc(string id)
        {
            return db.tblDanhMucs.Find(id);
        }

        public IEnumerable<tblDanhMuc> GetAllDanhMuc()
        {
            return db.tblDanhMucs;
        }

        public IEnumerable<tblSanPham> GetAllSanPham(string idDM, int page, int pageSize)
        {
            if (String.IsNullOrEmpty(idDM))
                return db.tblSanPhams.OrderBy(sp => sp.soLuong).
                    ThenByDescending(sp => sp.giaBan).ToPagedList(page, pageSize);
            return db.tblSanPhams.Where(sp => sp.DMNo.Equals(idDM)).OrderBy(sp => sp.soLuong).
                ThenByDescending(sp => sp.giaBan).ToPagedList(page, pageSize);
        }

        public string newIDSP()
        {
            string newID = db.tblSanPhams.Max(sp => sp.idSP);
            newID = "00000" + (int.Parse(newID.Substring(newID.Length - 5)) + 1);
            newID = "SP" + newID.Substring(newID.Length - 5);
            return newID;
        }

        public bool InsertSanPham(tblSanPham sp)
        {
            sp.idSP = newIDSP();
            if (sp.soLuong == 0)
                sp.trangThai = "d";
            else
                sp.trangThai = "e";
            db.tblSanPhams.Add(sp);
            db.SaveChanges();
            return true;
        }
    }
}
