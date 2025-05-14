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
    public partial class DoiMatKhau : Form
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;

        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();
            txtMaNV_DoiMatKhau.Focus();
        }

        private void btCapNhat_DoiMatKhau_Click(object sender, EventArgs e)
        {
            string sSql = "select * from NhanVien where MaNhanVien='" + txtMaNV_DoiMatKhau.Text + "' and MatKhau='" + txtMKCu_DoiMatKhau.Text + "'";
            mySqlCommand = new SqlCommand(sSql, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            int count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (Convert.ToInt32(txtMKMoi_DoiMatKhau.Text.Trim().Length) != Convert.ToInt32(txtMKMoi_DoiMatKhau.Text.Length))
                {
                    MessageBox.Show("Mật khẩu mới có ký tự không hợp lệ. Vui lòng nhập lại", "Thông Báo");
                    return;
                }
                if (Convert.ToInt32(txtMKMoi_DoiMatKhau.Text.Trim().Length) < 3)
                {
                    MessageBox.Show("Mật khẩu mới phải ít nhất có 3 ký tự", "Thông Báo");
                    return;
                }
                else
                {
                    string query2 = "update NhanVien set MatKhau = '" + txtMKMoi_DoiMatKhau.Text + "' where MaNhanVien = '" + txtMaNV_DoiMatKhau.Text + "'";
                    mySqlCommand = new SqlCommand(query2, mySqlconnection);
                    mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Xoa();
                }
            }
        }

        public void Xoa()
        {
            txtMaNV_DoiMatKhau.Text = "";
            txtMKMoi_DoiMatKhau.Text = "";
            txtMKCu_DoiMatKhau.Text = "";
        }

        private void btHuy_DoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
