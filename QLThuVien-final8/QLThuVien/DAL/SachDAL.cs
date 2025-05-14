using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;
using System.Text.RegularExpressions;

namespace DAL
{
    public class SachDAL
    {
        public DataTable LayDanhSachSach()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM Sach";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LayDanhSachMaTacGia()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MaTacGia FROM TacGia";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LayDanhSachMaNXB()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MaXB FROM NhaXuatBan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LayDanhSachMaLoai()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MaLoai FROM LoaiSach";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool KiemTraTrungMaSach(string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT COUNT(*) FROM Sach WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count >= 1;  //có nghĩa là đã có ít nhất 1 bản ghi tồn tại.
            }
        }

        public bool ThemSach(SachDTO sach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "INSERT INTO Sach VALUES (@MaSach, @TenSach, @MaTacGia, @MaXB, @MaLoai, @SoTrang, @GiaBan, @SoLuong)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
                cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
                cmd.Parameters.AddWithValue("@MaTacGia", sach.MaTacGia);
                cmd.Parameters.AddWithValue("@MaXB", sach.MaXB);
                cmd.Parameters.AddWithValue("@MaLoai", sach.MaLoai);
                cmd.Parameters.AddWithValue("@SoTrang", sach.SoTrang);
                cmd.Parameters.AddWithValue("@GiaBan", sach.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuong", sach.SoLuong);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }                
        }

        public bool XoaSach(string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        public bool SuaSach(SachDTO sach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE Sach SET TenSach = @TenSach, MaTacGia = @MaTacGia, MaXB = @MaNXB, MaLoai = @MaLoai, SoTrang = @SoTrang, GiaBan = @GiaBan, SoLuong = @SoLuong WHERE MaSach = @MaSach";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
                cmd.Parameters.AddWithValue("@TenSach", sach.TenSach);
                cmd.Parameters.AddWithValue("@MaTacGia", sach.MaTacGia);
                cmd.Parameters.AddWithValue("@MaNXB", sach.MaXB);
                cmd.Parameters.AddWithValue("@MaLoai", sach.MaLoai);
                cmd.Parameters.AddWithValue("@SoTrang", sach.SoTrang);
                cmd.Parameters.AddWithValue("@GiaBan", sach.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuong", sach.SoLuong);

                int result = cmd.ExecuteNonQuery();
                return result > 0; // Trả về true nếu cập nhật thành công
            }
        }

        public DataTable TimKiemTheoTen(string tenSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM Sach WHERE TenSach LIKE N'%' + @TenSach + '%'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@TenSach", tenSach);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int LaySoLuongCon(string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT SoLuong FROM Sach WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                conn.Open();
                int soLuong = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return soLuong;
            }
        }


        //phần của QLSach
        public DataTable TimKiemSach(string tuKhoa, string tieuChi)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT S.MaSach, S.TenSach, LS.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, 
                             S.SoTrang, S.GiaBan, S.SoLuong
                             FROM Sach S
                             JOIN LoaiSach LS ON S.MaLoai = LS.MaLoai
                             JOIN NhaXuatBan XB ON S.MaXB = XB.MaXB
                             JOIN TacGia TG ON S.MaTacGia = TG.MaTacGia
                             WHERE " + tieuChi + " LIKE @TuKhoa";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LayTatCaSach()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = @"SELECT S.MaSach, S.TenSach, LS.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, 
                             S.SoTrang, S.GiaBan, S.SoLuong
                             FROM Sach S
                             JOIN LoaiSach LS ON S.MaLoai = LS.MaLoai
                             JOIN NhaXuatBan XB ON S.MaXB = XB.MaXB
                             JOIN TacGia TG ON S.MaTacGia = TG.MaTacGia";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
