using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DocGiaDTO
    {
        public string MaDG { get; set; }
        public string TenDG { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string MatKhau { get; set; }   // Mới thêm để đăng nhập
        public string Quyen { get; set; }     // "User"
        public string Email { get; set; }
    }
}
