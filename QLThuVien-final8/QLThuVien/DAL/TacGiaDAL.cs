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
    public class TacGiaDAL
    {
        public DataTable LayDanhSachTacGia()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM TacGia";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool KiemTraTrungMaTG(string maTG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT COUNT(*) FROM TacGia WHERE MaTacGia = @MaTacGia";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTacGia", maTG);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count >= 1;  //có nghĩa là đã có ít nhất 1 bản ghi tồn tại.
            }
        }

        public bool ThemTacGia(TacGiaDTO tg)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "INSERT INTO TacGia VALUES (@MaTacGia, @TacGia, @GhiChu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTacGia", tg.MaTacGia);
                cmd.Parameters.AddWithValue("@TacGia", tg.TacGia);
                cmd.Parameters.AddWithValue("@GhiChu", tg.GhiChu);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        public bool SuaTacGia(TacGiaDTO tg)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE TacGia SET TacGia = @TacGia, GhiChu = @GhiChu WHERE MaTacGia = @MaTacGia";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TacGia", tg.TacGia);
                cmd.Parameters.AddWithValue("@GhiChu", tg.GhiChu);
                cmd.Parameters.AddWithValue("@MaTacGia", tg.MaTacGia);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        public bool XoaTacGia(string maTacGia)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "DELETE FROM TacGia WHERE MaTacGia = @MaTacGia";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        public DataTable TimKiemTacGia(string tuKhoa)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM TacGia WHERE TacGia LIKE @TuKhoa";
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
