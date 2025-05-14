using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class Login: Form
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;
        string TenNV;

        public Login()
        {
            InitializeComponent();
        }


        private void btDangKy_Click(object sender, EventArgs e)
        {
            DangKy dangky = new DangKy();
            dangky.Show();
            this.Hide();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            //string sSql = "select * from NhanVien where MaNhanVien='" + dn_user.Text + "' and MatKhau='" + dn_pass.Text + "'";
            //mySqlCommand = new SqlCommand(sSql, mySqlconnection);
            //mySqlCommand.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            //da.Fill(dt);
            //int count = Convert.ToInt32(dt.Rows.Count.ToString());
            //if (count == 0)
            //{
            //    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //else
            //{
            //    string sSql1 = "select TenNhanVien from NhanVien where MaNhanVien = '" + dn_user.Text + "'";
            //    mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            //    mySqlCommand.ExecuteNonQuery();
            //    DataTable dt1 = new DataTable();
            //    SqlDataAdapter da1 = new SqlDataAdapter(mySqlCommand);
            //    da1.Fill(dt1);
            //    foreach (DataRow dr in dt1.Rows)
            //    {
            //        TenNV = dr["TenNhanVien"].ToString();
            //    }
            //    this.Hide();
            //    TrangChu trangChu = new TrangChu(TenNV);
            //    trangChu.Show();
            //}

            using (SqlConnection mySqlconnection = new SqlConnection(Conn))
            {
                try
                {
                    mySqlconnection.Open(); // 🔹 Mở kết nối trước khi truy vấn

                    // 🔹 Sử dụng parameterized query để tránh SQL Injection
                    string sSql = "SELECT * FROM NhanVien WHERE MaNhanVien=@MaNV AND MatKhau=@MatKhau";
                    mySqlCommand = new SqlCommand(sSql, mySqlconnection);
                    mySqlCommand.Parameters.AddWithValue("@MaNV", dn_user.Text);
                    mySqlCommand.Parameters.AddWithValue("@MatKhau", dn_pass.Text);

                    SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // 🔹 Lấy Tên Nhân Viên bằng ExecuteScalar()
                        string sSql1 = "SELECT TenNhanVien FROM NhanVien WHERE MaNhanVien=@MaNV";
                        SqlCommand cmdTenNV = new SqlCommand(sSql1, mySqlconnection);
                        cmdTenNV.Parameters.AddWithValue("@MaNV", dn_user.Text);

                        object result = cmdTenNV.ExecuteScalar();
                        if (result != null)
                        {
                            TenNV = result.ToString();
                        }
                        else
                        {
                            TenNV = "Không xác định";
                        }

                        this.Hide();
                        TrangChu trangChu = new TrangChu(TenNV);
                        trangChu.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            } // 🔹 `using` đảm bảo tự động đóng kết nối sau khi xong
        }

        private void Login_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();
        }

        private void dn_showpass_CheckedChanged(object sender, EventArgs e)
        {
            dn_pass.PasswordChar = dn_showpass.Checked ? '\0' : '*';
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();   //nút X
        }
    }
}
