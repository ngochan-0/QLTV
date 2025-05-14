using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SachDTO
    {
        //public string MaSach { get; set; }
        //public string TenSach { get; set; }
        //public string MaTacGia { get; set; }
        //public string MaXB { get; set; }
        //public string MaLoai { get; set; }
        //public int SoTrang { get; set; }
        //public int GiaBan { get; set; }
        //public int SoLuong { get; set; }

        // Mã
        public string MaSach { get; set; }
        public string MaTacGia { get; set; }
        public string MaXB { get; set; }
        public string MaLoai { get; set; }

        // Tên
        public string TenSach { get; set; }
        public string TenLoaiSach { get; set; }
        public string NhaXuatBan { get; set; }
        public string TacGia { get; set; }

        // Thông tin khác
        public int SoTrang { get; set; }
        public int GiaBan { get; set; }
        public int SoLuong { get; set; }
    }
}
