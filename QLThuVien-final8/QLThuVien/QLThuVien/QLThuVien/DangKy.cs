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
    public partial class DangKy: Form
    {
        SqlConnection connect = new SqlConnection("Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False");
        public DangKy()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btDangNhap_2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }


        private void dk_showpass_CheckedChanged(object sender, EventArgs e)
        {
            dk_MatKhau.PasswordChar = dk_showpass.Checked ? '\0' : '*';
        }

        private void btDangKy_2_Click(object sender, EventArgs e)
        {
            if (dk_MaNV.Text.Trim() == "" || dk_TenNV.Text.Trim() == "" || dk_SoDienThoai.Text.Trim() == "" || dk_MatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        String ktMaNV = "select count(*) from NhanVien where MaNhanVien = @MaNV";
                        using(SqlCommand ktCMD = new SqlCommand(ktMaNV, connect))
                        {
                            ktCMD.Parameters.AddWithValue("@MaNV", dk_MaNV.Text.Trim());
                            int dem = (int)ktCMD.ExecuteScalar(); 
                            if(dem >= 1)
                            {
                                MessageBox.Show(dk_MaNV.Text.Trim()
                                    + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else
                            {
                                String themDulieu = "insert into NhanVien(MaNhanVien, TenNhanVien, SoDienThoai, MatKhau) " +
                                    "values(@MaNV, @TenNV, @SDT, @MatKhau)";
                                using (SqlCommand themCMD = new SqlCommand(themDulieu, connect))
                                {
                                    themCMD.Parameters.AddWithValue("@MaNV", dk_MaNV.Text.Trim());
                                    themCMD.Parameters.AddWithValue("@TenNV", dk_TenNV.Text.Trim());
                                    themCMD.Parameters.AddWithValue("@SDT", dk_SoDienThoai.Text.Trim());
                                    themCMD.Parameters.AddWithValue("@MatKhau", dk_MatKhau.Text.Trim());

                                    themCMD.ExecuteNonQuery();
                                    MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Login login = new Login();
                                    login.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }

                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();  //nut X
        }
    }
}
