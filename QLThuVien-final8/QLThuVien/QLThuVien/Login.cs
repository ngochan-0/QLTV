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
using DTO;
using BLL;

namespace QLThuVien
{
    public partial class Login: Form
    {
        NhanVienBLL NVbll = new NhanVienBLL();
        DocGiaBLL docGiaBLL = new DocGiaBLL(); // thêm dòng này

        public Login()
        {
            InitializeComponent();
        }


        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string maTK = dn_user.Text.Trim();
            string matKhau = dn_pass.Text.Trim();


            // Thử đăng nhập bằng nhân viên (Admin)
            NhanVienDTO nhanVien = NVbll.KiemTraDangNhap(maTK, matKhau);

            if (nhanVien != null && nhanVien.Quyen == "Admin")
            {
                MessageBox.Show("Đăng nhập thành công với quyền Admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                TrangChu trangChu = new TrangChu(nhanVien.TenNhanVien); // Giao diện Admin
                trangChu.ShowDialog();
                //this.Show();
                return;
            }

            // Thử đăng nhập bằng độc giả (User)
            DocGiaDTO docGia = docGiaBLL.DangNhap(maTK, matKhau);

            if (docGia != null && docGia.Quyen == "User")
            {
                MessageBox.Show("Đăng nhập thành công với quyền User!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                TrangChuUser trangUser = new TrangChuUser(docGia.MaDG); // Giao diện User (form bạn cần tạo)
                trangUser.ShowDialog();
                //this.Show();
                return;
            }

            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
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
