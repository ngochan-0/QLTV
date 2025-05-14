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
    public class DocGiaDAL
    {
        public DataTable LayDanhSachDocGia()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM DocGia";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool KiemTraTrungMaDocGia(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT COUNT(*) FROM DocGia WHERE MaDG = @MaDG";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count >= 1;  //có nghĩa là đã có ít nhất 1 bản ghi tồn tại.
            }
        }

        public bool ThemDocGia(DocGiaDTO dg)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "INSERT INTO DocGia VALUES (@MaDG, @TenDG, @GioiTinh, @DiaChi, @SoDienThoai, @MatKhau, @Quyen, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", dg.MaDG);
                cmd.Parameters.AddWithValue("@TenDG", dg.TenDG);
                cmd.Parameters.AddWithValue("@GioiTinh", dg.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", dg.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", dg.SoDienThoai);
                //
                cmd.Parameters.AddWithValue("@MatKhau", dg.MatKhau);
                cmd.Parameters.AddWithValue("@Quyen", dg.Quyen);
                cmd.Parameters.AddWithValue("@Email", dg.Email);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public bool SuaDocGia(DocGiaDTO dg)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE DocGia SET TenDG = @TenDG, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email WHERE MaDG = @MaDG";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDG", dg.TenDG);
                cmd.Parameters.AddWithValue("@GioiTinh", dg.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", dg.DiaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", dg.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", dg.Email);
                cmd.Parameters.AddWithValue("@MaDG", dg.MaDG);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public bool XoaDocGia(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "DELETE FROM DocGia WHERE MaDG = @MaDG";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public DataTable TimKiemDocGiaTheoMa(string tuKhoa)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM DocGia WHERE MaDG LIKE @TuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable TimKiemDocGiaTheoTen(string tuKhoa)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM DocGia WHERE TenDG LIKE @TuKhoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DocGiaDTO KiemTraDangNhap(string maDG, string matKhau)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT * FROM DocGia WHERE MaDG = @maDG AND MatKhau = @matKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maDG", maDG);
                cmd.Parameters.AddWithValue("@matKhau", matKhau);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DocGiaDTO
                    {
                        MaDG = reader["MaDG"].ToString(),
                        TenDG = reader["TenDG"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        Quyen = reader["Quyen"].ToString()                      
                    };
                }
            }
            return null;
        }

        public DocGiaDTO LayThongTinDocGia(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT * FROM DocGia WHERE MaDG = @MaDG";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DocGiaDTO
                    {
                        MaDG = reader["MaDG"].ToString(),
                        TenDG = reader["TenDG"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
                return null;
            }
        }
    }
}
