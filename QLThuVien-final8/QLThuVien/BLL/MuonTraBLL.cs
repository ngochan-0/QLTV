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
    public class MuonTraBLL
    {
        private MuonTraDAL muonTradal = new MuonTraDAL();

        public bool KiemTraDocGiaDangMuonSach(string maDG, string maSach)
        {
            return muonTradal.KiemTraDocGiaDangMuonSach(maDG, maSach);
        }

        public void CapNhatTrangThaiQuaHan()
        {
            muonTradal.CapNhatTrangThaiQuaHan();
        }

        public DataTable InDanhSachMuonTra()
        {
            return muonTradal.InDanhSachMuonTra();
        }

        public DataTable LayDanhSachMuonTra()
        {
            return muonTradal.LayDanhSachMuonTra();
        }

        // Lấy danh sách sách đang mượn của người dùng
        public DataTable LaySachDangMuonUser(string maDG)
        {
            return muonTradal.LaySachDangMuonUser(maDG);
        }

        // Lấy danh sách sách quá hạn của người dùng
        public DataTable LaySachQuaHanUser(string maDG)
        {
            return muonTradal.LaySachQuaHanUser(maDG);
        }

        public DataTable TimSachDangMuonTheoTen(string maDG, string tenSach)
        {
            return muonTradal.TimSachDangMuonTheoTen(maDG, tenSach);
        }

        public DataTable LayDanhSachMaDocGia()
        {
            return muonTradal.LayDanhSachMaDocGia();
        }

        public DataTable LayDanhSachTenSach()
        {
            return muonTradal.LayDanhSachTenSach();
        }

        public DataTable LayThongTinSachTheoTen(string tenSach)
        {
            return muonTradal.TimThongTinSachTheoTen(tenSach);
        }

        public DataTable LayThongTinSachTheoMa(string maSach)
        {
            return muonTradal.TimThongTinSachTheoMa(maSach);
        }

        public DataTable LayThongTinDocGiaTheoMa(string maDG)
        {
            return muonTradal.TimDocGiaTheoMa(maDG);
        }

        public bool MuonSach(MuonTraDTO muon)
        {
            return muonTradal.MuonSach(muon);
        }

        public bool GiaHan(int maPhieuMuon, DateTime ngayTraMoi)
        {
            return muonTradal.GiaHan(maPhieuMuon, ngayTraMoi);
        }

        public bool TraSach(int maPhieuMuon)
        {
            return muonTradal.TraSach(maPhieuMuon);
        }

        public int DemSoLuongSachDangMuon(string maDG)
        {
            return muonTradal.DemSoLuongSachDangMuon(maDG);
        }

        public void SoLuongSauMuon(string maSach)
        {
            muonTradal.TruSoLuongSach(maSach);
        }

        public void SoLuongSauTra(string maSach)
        {
            muonTradal.CongSoLuongSach(maSach);
        }
    }
}
