using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DocGiaBLL
    {
        private DocGiaDAL docGiaDAL = new DocGiaDAL();

        public DataTable LayDanhSachDocGia()
        {
            return docGiaDAL.LayDanhSachDocGia();
        }

        public bool KiemTraTrungMaDocGia(string maDG)
        {
            return docGiaDAL.KiemTraTrungMaDocGia(maDG);
        }

        public bool ThemDocGia(DocGiaDTO dg)
        {
            return docGiaDAL.ThemDocGia(dg);
        }

        public bool SuaDocGia(DocGiaDTO dg)
        {
            return docGiaDAL.SuaDocGia(dg);
        }

        public bool XoaDocGia(string maDG)
        {
            return docGiaDAL.XoaDocGia(maDG);
        }

        public DataTable TimKiemDocGiaTheoMa(string tuKhoa)
        {
            return docGiaDAL.TimKiemDocGiaTheoMa(tuKhoa);
        }

        public DataTable TimKiemDocGiaTheoTen(string tuKhoa)
        {
            return docGiaDAL.TimKiemDocGiaTheoTen(tuKhoa);
        }

        public DocGiaDTO DangNhap(string maDG, string matKhau)
        {
            return docGiaDAL.KiemTraDangNhap(maDG, matKhau);
        }

        public DocGiaDTO LayThongTinDocGia(string maDG)
        {
            return docGiaDAL.LayThongTinDocGia(maDG);
        }
    }
}
