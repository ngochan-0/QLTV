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
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();

        public bool KiemTraDangNhap(NhanVienDTO dto)
        {
            return nhanVienDAL.KiemTraDangNhap(dto);
        }

        public bool DoiMatKhau(NhanVienDTO dto)
        {
            return nhanVienDAL.DoiMatKhau(dto);
        }

        public DataTable LayDanhSachNhanVien()
        {
            return nhanVienDAL.LayDanhSachNhanVien();
        }

        public bool XoaNhanVien(string maNV)
        {
            return nhanVienDAL.XoaNhanVien(maNV);
        }

        public NhanVienDTO KiemTraDangNhap(string maNV, string matKhau)
        {
            return nhanVienDAL.KiemTraDangNhap(maNV, matKhau);
        }

        public bool KiemTraMaNV(string maNV)
        {
            return nhanVienDAL.KiemTraMaNV(maNV);
        }

        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            // Kiểm tra xem quyền có được gán chưa, nếu không thì mặc định là "Admin"
            if (string.IsNullOrEmpty(nhanVien.Quyen))
            {
                nhanVien.Quyen = "Admin"; 
            }

            return nhanVienDAL.ThemNhanVien(nhanVien);
        }
    }
}
