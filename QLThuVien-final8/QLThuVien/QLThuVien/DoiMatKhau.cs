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
    public partial class DoiMatKhau : Form
    {
        NhanVienBLL doiMKBLL = new NhanVienBLL();

        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMaNV_DoiMatKhau.Focus();
        }

        private void btCapNhat_DoiMatKhau_Click(object sender, EventArgs e)
        {
            NhanVienDTO thongTinDangNhap = new NhanVienDTO
            {
                MaNhanVien = txtMaNV_DoiMatKhau.Text.Trim(),
                MatKhau = txtMKCu_DoiMatKhau.Text.Trim()
            };

            NhanVienDTO thongTinMoi = new NhanVienDTO
            {
                MaNhanVien = txtMaNV_DoiMatKhau.Text.Trim(),
                MatKhau = txtMKMoi_DoiMatKhau.Text.Trim()
            };

            if (!doiMKBLL.KiemTraDangNhap(thongTinDangNhap))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (thongTinMoi.MatKhau.Length < 3)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 3 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool doiMK = doiMKBLL.DoiMatKhau(thongTinMoi);
            if (doiMK)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Xoa();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Xoa()
        {
            txtMaNV_DoiMatKhau.Clear();
            txtMKCu_DoiMatKhau.Clear();
            txtMKMoi_DoiMatKhau.Clear();
        }

        private void btHuy_DoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
