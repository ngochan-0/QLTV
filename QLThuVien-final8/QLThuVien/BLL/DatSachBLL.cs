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
    public class DatSachBLL
    {
        MuonTraDAL muonTraDAL = new MuonTraDAL();
        SachDAL sachDAL = new SachDAL();
        DatSachDAL datSachDAL = new DatSachDAL();

        public string DatSach(string maDG, string maSach)
        {
            int soLuongDangMuon = muonTraDAL.DemSoLuongSachDangMuon(maDG); // Sách đang mượn
            int soLuongDaDat = datSachDAL.DemSoLuongSachDaDat(maDG);       // Sách đã đặt

            if (soLuongDangMuon + soLuongDaDat >= 5)
                return "Bạn đã mượn và đặt đủ 5 sách, không thể đặt thêm.";

            int soLuongCon = sachDAL.LaySoLuongCon(maSach);
            if (soLuongCon <= 0)
                return "Sách này hiện đã hết.";

            // Đã đặt sách này rồi
            bool daDat = datSachDAL.KiemTraTrung(maDG, maSach);
            if (daDat)
                return "Bạn đã đặt sách này rồi.";

            // Đã mượn (chưa trả) sách này rồi
            if (muonTraDAL.KiemTraDocGiaDangMuonSach(maDG, maSach))
                return "Bạn đã mượn cuốn sách này rồi và chưa trả, không thể đặt tiếp.";

            bool kq = datSachDAL.ThemPhieuDatSach(maDG, maSach);
            return kq ? "Đặt sách thành công!" : "Đặt sách thất bại!";
        }

        public DataTable LayTatCaPhieuDat()
        {
            return datSachDAL.LayDanhSachDatSach();
        }

        public DataTable LayPhieuDatTheoMaDocGia(string maDG)
        {
            return datSachDAL.LayPhieuDatTheoMaDocGia(maDG);
        }

        public bool CapNhatTrangThai(int maDat, string trangThai)
        {
            return datSachDAL.CapNhatTrangThai(maDat, trangThai);
        }

        public DatSachDTO DuyetPhieuDat(int maDat)
        {
            DatSachDTO dat = datSachDAL.LayPhieuDat(maDat);
            if (dat == null || dat.TrangThai != "Chờ duyệt")
                return null;

            // Cập nhật trạng thái
            bool capNhat = datSachDAL.CapNhatTrangThai(maDat, "Đã duyệt");

            if (capNhat)
            {
                // TRỪ SỐ LƯỢNG
                MuonTraDAL muonTraDAL = new MuonTraDAL();
                muonTraDAL.TruSoLuongSach(dat.MaSach);
            }

            return dat;
        }

        public bool XoaPhieuDat(int maPhieuDat)
        {
            return datSachDAL.XoaPhieuDat(maPhieuDat);
        }
    }
}
