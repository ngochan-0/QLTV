using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class NhaXuatBanDAL
    {
        public DataTable LayDanhSachNXB()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT * FROM NhaXuatBan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool KiemTraTrungMaNXB(string maNXB)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT COUNT(*) FROM NhaXuatBan WHERE MaXB = @MaXB";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaXB", maNXB);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count >= 1;  //có nghĩa là đã có ít nhất 1 bản ghi tồn tại.
            }
        }

        public bool ThemNXB(NhaXuatBanDTO nxb)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "INSERT INTO NhaXuatBan VALUES (@MaXB, @NhaXuatBan, @GhiChu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaXB", nxb.MaXB);
                cmd.Parameters.AddWithValue("@NhaXuatBan", nxb.NhaXuatBan);
                cmd.Parameters.AddWithValue("@GhiChu", nxb.GhiChu);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //NhaXuatBanDTO nxb: Cần đầy đủ thông tin để cập nhật:
        public bool CapNhatNXB(NhaXuatBanDTO nxb)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "UPDATE NhaXuatBan SET NhaXuatBan = @NhaXuatBan, GhiChu = @GhiChu WHERE MaXB = @MaXB";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaXB", nxb.MaXB);
                cmd.Parameters.AddWithValue("@NhaXuatBan", nxb.NhaXuatBan);
                cmd.Parameters.AddWithValue("@GhiChu", nxb.GhiChu);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //string maXB: Chỉ cần biết mã để xóa dòng tương ứng, không cần các thông tin khác.
        public bool XoaNXB(string maXB)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "DELETE FROM NhaXuatBan WHERE MaXB = @MaXB";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaXB", maXB);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable TimKiemNXB(string tuKhoa)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT * FROM NhaXuatBan WHERE NhaXuatBan LIKE @TuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
