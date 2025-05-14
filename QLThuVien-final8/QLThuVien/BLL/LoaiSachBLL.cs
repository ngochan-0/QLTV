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
    public class LoaiSachBLL
    {
        private LoaiSachDAL loaiSachDAL = new LoaiSachDAL();

        public DataTable LayDanhSachLoaiSach()
        {
            return loaiSachDAL.LayDanhSachLoaiSach();
        }

        public bool KiemTraTrungMaLoai(string maLoai)
        {
            return loaiSachDAL.KiemTraTrungMaLoai(maLoai);
        }

        public bool ThemLoaiSach(LoaiSachDTO loai)
        {
            return loaiSachDAL.ThemLoaiSach(loai);
        }

        public bool SuaLoaiSach(LoaiSachDTO loai)
        {
            return loaiSachDAL.SuaLoaiSach(loai);
        }

        public bool XoaLoaiSach(string maLoai)
        {
            return loaiSachDAL.XoaLoaiSach(maLoai);
        }

        public DataTable TimKiemLoaiSach(string tuKhoa)
        {
            return loaiSachDAL.TimKiemLoaiSach(tuKhoa);
        }
    }
}
