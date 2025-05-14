using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MuonTraDTO
    {
        public int MaPhieuMuon { get; set; }
        public string MaDG { get; set; }
        public string TenDG { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public string GhiChu { get; set; }
        public string TrangThai { get; set; }
    }
}
