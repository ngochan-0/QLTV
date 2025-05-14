using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class BaoCaoDAL
    {
        public DataTable LayDanhSachDangMuon()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = @"SELECT MS.MaPhieuMuon, DG.MaDG, DG.TenDG, DG.SoDienThoai, DG.Email,
                            S.TenSach, MS.NgayMuon, MS.NgayTra, MS.GhiChu, MS.TrangThai 
                            FROM MuonTraSach MS 
                            JOIN Sach S ON S.MaSach = MS.MaSach 
                            JOIN DocGia DG ON DG.MaDG = MS.MaDG 
                            WHERE MS.TrangThai = N'Đang mượn'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LayDanhSachQuaHan()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = @"SELECT MS.MaPhieuMuon, DG.MaDG, DG.TenDG, DG.SoDienThoai, DG.Email,
                            S.TenSach, MS.NgayMuon, MS.NgayTra, MS.GhiChu, MS.TrangThai
                            FROM MuonTraSach MS 
                            JOIN Sach S ON S.MaSach = MS.MaSach 
                            JOIN DocGia DG ON DG.MaDG = MS.MaDG 
                            WHERE MS.TrangThai = N'Quá hạn'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Thêm cột phí phạt (phạt 50k/ngày trễ)
                DataColumn phiPhatCol = new DataColumn("PhiPhat", typeof(string));
                dt.Columns.Add(phiPhatCol);
                phiPhatCol.SetOrdinal(0); // Đưa lên đầu
                                          // Tính phí phạt và gán dữ liệu có định dạng + đơn vị
                foreach (DataRow row in dt.Rows)
                {
                    DateTime ngayTra = Convert.ToDateTime(row["NgayTra"]);
                    int soNgayTre = (DateTime.Now.Date - ngayTra.Date).Days;
                    if (soNgayTre < 0) soNgayTre = 0;

                    int tienPhat = soNgayTre * 50000;
                    row["PhiPhat"] = $"{tienPhat:N0} VND";
                }
                return dt;
            }
        }

        public DataTable LayDanhSachDaTra()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = @"SELECT MS.MaPhieuMuon, DG.MaDG, DG.TenDG, DG.SoDienThoai, DG.Email,
                            S.TenSach, MS.NgayMuon, MS.NgayTra, MS.GhiChu, MS.TrangThai
                            FROM MuonTraSach MS 
                            JOIN Sach S ON S.MaSach = MS.MaSach 
                            JOIN DocGia DG ON DG.MaDG = MS.MaDG 
                            WHERE MS.TrangThai = N'Đã trả'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int DemSoLuong(string tenBang)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = $"SELECT COUNT(*) FROM {tenBang}";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
