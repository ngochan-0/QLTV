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
    public class NhanVienDAL
    {
        public DataTable LayDanhSachNhanVien()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, MatKhau FROM NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool XoaNhanVien(string maNV)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public NhanVienDTO KiemTraDangNhap(string maNV, string matKhau)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT * FROM NhanVien WHERE MaNhanVien = @maNV AND MatKhau = @matKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maNV", maNV);
                cmd.Parameters.AddWithValue("@matKhau", matKhau);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new NhanVienDTO
                    {
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        TenNhanVien = reader["TenNhanVien"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        Quyen = reader["Quyen"].ToString()
                    };
                }
            }
            return null;
        }

        public bool KiemTraMaNV(string maNV)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                int count = (int)cmd.ExecuteScalar();
                return count >= 1; // Trả về true nếu mã nhân viên đã tồn tại
            }
        }

        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, SoDienThoai, MatKhau, Quyen) " +
                       "VALUES (@MaNhanVien, @TenNhanVien, @SoDienThoai, @MatKhau, @Quyen)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
                cmd.Parameters.AddWithValue("@TenNhanVien", nhanVien.TenNhanVien);
                cmd.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
                cmd.Parameters.AddWithValue("@MatKhau", nhanVien.MatKhau);
                cmd.Parameters.AddWithValue("@Quyen", nhanVien.Quyen);  // Thêm tham số quyền
                int result = cmd.ExecuteNonQuery();
                return result > 0; // Trả về true nếu thêm nhân viên thành công
            }
        }

        public bool KiemTraDangNhap(NhanVienDTO dto)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNV AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", dto.MaNhanVien);
                cmd.Parameters.AddWithValue("@MatKhau", dto.MatKhau);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool DoiMatKhau(NhanVienDTO dto)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "UPDATE NhanVien SET MatKhau = @MatKhauMoi WHERE MaNhanVien = @MaNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", dto.MaNhanVien);
                cmd.Parameters.AddWithValue("@MatKhauMoi", dto.MatKhau);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
