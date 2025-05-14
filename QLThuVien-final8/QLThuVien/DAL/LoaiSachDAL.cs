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
    public class LoaiSachDAL
    {
        public DataTable LayDanhSachLoaiSach()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM LoaiSach";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool KiemTraTrungMaLoai(string maLoai)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT COUNT(*) FROM LoaiSach WHERE MaLoai = @MaLoai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count >= 1;  //có nghĩa là đã có ít nhất 1 bản ghi tồn tại.
            }
        }

        public bool ThemLoaiSach(LoaiSachDTO loai)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "INSERT INTO LoaiSach VALUES (@MaLoai, @TenLoaiSach, @GhiChu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoai", loai.MaLoai);
                cmd.Parameters.AddWithValue("@TenLoaiSach", loai.TenLoaiSach);
                cmd.Parameters.AddWithValue("@GhiChu", loai.GhiChu);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        public bool SuaLoaiSach(LoaiSachDTO loai)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE LoaiSach SET TenLoaiSach = @TenLoaiSach, GhiChu = @GhiChu WHERE MaLoai = @MaLoai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenLoaiSach", loai.TenLoaiSach);
                cmd.Parameters.AddWithValue("@GhiChu", loai.GhiChu);
                cmd.Parameters.AddWithValue("@MaLoai", loai.MaLoai);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        public bool XoaLoaiSach(string maLoai)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "DELETE FROM LoaiSach WHERE MaLoai = @MaLoai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        public DataTable TimKiemLoaiSach(string tuKhoa)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM LoaiSach WHERE TenLoaiSach LIKE @TuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

    }
}
