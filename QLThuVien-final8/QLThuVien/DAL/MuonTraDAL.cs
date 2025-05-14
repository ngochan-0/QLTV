using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAL
{
    public class MuonTraDAL
    {
        //in
        public DataTable InDanhSachMuonTra()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM MuonTraSach";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool KiemTraDocGiaDangMuonSach(string maDG, string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM MuonTraSach WHERE MaDG = @MaDG AND MaSach = @MaSach AND TrangThai IN (N'Đang mượn', N'Quá hạn')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public void CapNhatTrangThaiQuaHan()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE MuonTraSach SET TrangThai = N'Quá hạn' WHERE TrangThai = N'Đang mượn' AND NgayTra <= GETDATE()";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //cho dgv
        public DataTable LayDanhSachMuonTra()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MS.MaPhieuMuon, DG.MaDG, DG.TenDG, S.MaSach, S.TenSach, MS.NgayMuon, MS.NgayTra, MS.GhiChu, MS.TrangThai " +
                       "FROM MuonTraSach MS " +
                       "JOIN Sach S ON S.MaSach = MS.MaSach " +
                       "JOIN DocGia DG ON DG.MaDG = MS.MaDG";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LaySachDangMuonUser(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MS.MaPhieuMuon, S.MaSach, S.TenSach, MS.NgayMuon, MS.NgayTra, MS.GhiChu, MS.TrangThai " +
                               "FROM MuonTraSach MS " +
                               "JOIN Sach S ON S.MaSach = MS.MaSach " +
                               "WHERE MS.MaDG = @MaDG AND MS.TrangThai = N'Đang mượn'"; // Chỉ lấy sách đang mượn
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LaySachQuaHanUser(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"
            SELECT 
                MS.MaPhieuMuon, 
                S.MaSach, 
                S.TenSach, 
                MS.NgayMuon, 
                MS.NgayTra, 
                MS.GhiChu, MS.TrangThai
            FROM MuonTraSach MS
            JOIN Sach S ON S.MaSach = MS.MaSach
            WHERE MS.MaDG = @MaDG 
              AND MS.TrangThai = N'Quá hạn'"; // Chỉ lấy sách quá hạn

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDG", maDG);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable TimSachDangMuonTheoTen(string maDG, string tenSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MS.MaPhieuMuon, S.MaSach, S.TenSach, MS.NgayMuon, MS.NgayTra, MS.GhiChu, MS.TrangThai " +
                               "FROM MuonTraSach MS " +
                               "JOIN Sach S ON S.MaSach = MS.MaSach " +
                               "WHERE MS.MaDG = @MaDG AND MS.TrangThai = N'Đang mượn' AND S.TenSach LIKE @TenSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                cmd.Parameters.AddWithValue("@TenSach", "%" + tenSach + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //cho cbMaDocGia
        public DataTable LayDanhSachMaDocGia()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT MaDG FROM DocGia";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //cho cbTenSach
        public DataTable LayDanhSachTenSach()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT TenSach FROM Sach";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //cho groupbox TTS
        public DataTable TimThongTinSachTheoTen(string tenSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "select s.MaSach, s.TenSach, tg.TacGia, s.SoLuong from Sach s join TacGia tg on s.MaTacGia = tg.MaTacGia WHERE s.TenSach = @TenSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSach", tenSach); 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //cho tim kiem raMaSach
        public DataTable TimThongTinSachTheoMa(string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MS.MaPhieuMuon, DG.MaDG, DG.TenDG, S.MaSach, S.TenSach, MS.NgayMuon, MS.NgayTra, MS.GhiChu, MS.TrangThai " +
                       "FROM MuonTraSach MS " +
                       "JOIN Sach S ON S.MaSach = MS.MaSach " +
                       "JOIN DocGia DG ON DG.MaDG = MS.MaDG WHERE S.MaSach LIKE @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", "%" + maSach + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //cho tim kiem raMaDG
        public DataTable TimDocGiaTheoMa(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MS.MaPhieuMuon, DG.MaDG, DG.TenDG, S.MaSach, S.TenSach, MS.NgayMuon, MS.NgayTra, MS.GhiChu, MS.TrangThai " +
                       "FROM MuonTraSach MS " +
                       "JOIN Sach S ON S.MaSach = MS.MaSach " +
                       "JOIN DocGia DG ON DG.MaDG = MS.MaDG WHERE DG.MaDG LIKE @MaDG";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", "%" + maDG + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool MuonSach(MuonTraDTO muon)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "INSERT INTO MuonTraSach (MaDG, MaSach, NgayMuon, NgayTra, GhiChu, TrangThai) " +
                          "VALUES (@MaDG, @MaSach, GETDATE(), @NgayTra, @GhiChu, @TrangThai)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", muon.MaDG);
                cmd.Parameters.AddWithValue("@MaSach", muon.MaSach);
                cmd.Parameters.AddWithValue("@NgayTra", muon.NgayTra);
                cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(muon.GhiChu) ? DBNull.Value : (object)muon.GhiChu);
                cmd.Parameters.AddWithValue("@TrangThai", muon.TrangThai);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0; // Trả về true nếu ít nhất 1 dòng được ảnh hưởng, tức là mượn sách thành công
            }
        }

        public bool GiaHan(int maPhieuMuon, DateTime ngayTraMoi)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "UPDATE MuonTraSach SET NgayTra = @NgayTra WHERE MaPhieuMuon = @MaPhieuMuon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NgayTra", ngayTraMoi);
                cmd.Parameters.AddWithValue("@MaPhieuMuon", maPhieuMuon);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0; // Trả về true nếu ít nhất 1 dòng được ảnh hưởng, tức là gia hạn thành công
            }
        }

        public bool TraSach(int maPhieuMuon)
        {

            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE MuonTraSach SET TrangThai = N'Đã trả', NgayTra = GETDATE() WHERE MaPhieuMuon = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieuMuon);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Đếm số lượng sách đang mượn
        public int DemSoLuongSachDangMuon(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                //NgayTra > GETDATE(): Điều này sẽ tính số sách mà sinh viên đang mượn (tức là sách có ngày trả trong tương lai).
                string query = "SELECT COUNT(*) FROM MuonTraSach WHERE MaDG = @MaDG AND TrangThai IN (N'Đang mượn', N'Quá hạn')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return count;
            }
        }

        // Giảm số lượng sách khi mượn
        public void TruSoLuongSach(string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "UPDATE Sach SET SoLuong = SoLuong - 1 WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // Tăng số lượng sách khi trả
        public void CongSoLuongSach(string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "UPDATE Sach SET SoLuong = SoLuong + 1 WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

    }
}
