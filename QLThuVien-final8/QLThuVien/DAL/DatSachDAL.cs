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
    public class DatSachDAL
    {
        public bool KiemTraTrung(string maDG, string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT COUNT(*) FROM PhieuDatSach WHERE MaDG = @MaDG AND MaSach = @MaSach AND TrangThai = N'Chờ duyệt'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        
        public bool ThemPhieuDatSach(string maDG, string maSach)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "INSERT INTO PhieuDatSach (MaDG, MaSach, NgayDat, TrangThai) VALUES (@MaDG, @MaSach, GETDATE(), N'Chờ duyệt')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                return rows > 0;
            }
        }

        public DataTable LayDanhSachDatSach()
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT * FROM PhieuDatSach";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool CapNhatTrangThai(int maDat, string trangThai)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "UPDATE PhieuDatSach SET TrangThai = @TrangThai WHERE MaPhieuDat = @MaDat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@MaDat", maDat);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DatSachDTO LayPhieuDat(int maPhieuDat)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT * FROM PhieuDatSach WHERE MaPhieuDat = @MaPhieuDat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuDat", maPhieuDat);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new DatSachDTO
                    {
                        MaPhieuDat = Convert.ToInt32(reader["MaPhieuDat"]),
                        MaDG = reader["MaDG"].ToString(),
                        MaSach = reader["MaSach"].ToString(),
                        NgayDat = Convert.ToDateTime(reader["NgayDat"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                }
                return null;
            }
        }

        //USachDaDat
        public DataTable LayPhieuDatTheoMaDocGia(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                conn.Open();
                string query = "SELECT * FROM PhieuDatSach WHERE MaDG = @ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ma", maDG);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool XoaPhieuDat(int maPhieuDat)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "DELETE FROM PhieuDatSach WHERE MaPhieuDat = @MaPhieuDat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuDat", maPhieuDat);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public int DemSoLuongSachDaDat(string maDG)
        {
            using (SqlConnection conn = KetNoiChung.TaoKetNoi())
            {
                string query = "SELECT COUNT(*) FROM PhieuDatSach WHERE MaDG = @MaDG AND TrangThai = N'Chờ duyệt'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDG", maDG);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                return count;
            }
        }
    }
}
