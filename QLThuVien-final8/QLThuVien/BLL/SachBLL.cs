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
    public class SachBLL
    {
        private SachDAL sachDAL = new SachDAL();

        public DataTable LayDanhSachSach()
        {
            return sachDAL.LayDanhSachSach();
        }

        public DataTable LayDanhSachMaTacGia()
        {
            return sachDAL.LayDanhSachMaTacGia();
        }

        public DataTable LayDanhSachMaNXB()
        {
            return sachDAL.LayDanhSachMaNXB();
        }

        public DataTable LayDanhSachMaLoai()
        {
            return sachDAL.LayDanhSachMaLoai();
        }

        public bool ThemSach(SachDTO sach)
        {
            // kiểm tra dữ liệu nếu cần
            return sachDAL.ThemSach(sach);
        }

        public bool KiemTraTrungMaSach(string maSach)
        {
            return sachDAL.KiemTraTrungMaSach(maSach);
        }

        public bool XoaSach(string maSach)
        {
            return sachDAL.XoaSach(maSach);
        }

        public DataTable TimKiemTheoTen(string ten)
        {
            return sachDAL.TimKiemTheoTen(ten);
        }

        public bool SuaSach(SachDTO sach)
        {
            // Gọi phương thức của SachDAL để thực hiện việc cập nhật
            return sachDAL.SuaSach(sach);
        }


        //phần của QLSach
        public DataTable TimKiemSach(string tuKhoa, string loaiTimKiem)
        {
            string cot = "";
            switch (loaiTimKiem)
            {
                case "Tên Sách":
                    cot = "S.TenSach"; break;
                case "Loại Sách":
                    cot = "LS.TenLoaiSach"; break;
                case "Tác Giả":
                    cot = "TG.TacGia"; break;
                case "NXB":
                    cot = "XB.NhaXuatBan"; break;
            }

            return sachDAL.TimKiemSach(tuKhoa, cot);
        }

        public DataTable LayTatCaSach()
        {
            return sachDAL.LayTatCaSach();
        }
    }
}
