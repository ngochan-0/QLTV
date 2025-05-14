using BLL;
using DTO;
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
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();

        public DangKy()
        {
            InitializeComponent();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void dk_showpass_CheckedChanged(object sender, EventArgs e)
        {
            dk_MatKhau.PasswordChar = dk_showpass.Checked ? '\0' : '*';
        }

        private void btDangKy_2_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = dk_MaNV.Text.Trim();
                string tenNV = dk_TenNV.Text.Trim();
                string soDienThoai = dk_SoDienThoai.Text.Trim();
                string matKhau = dk_MatKhau.Text.Trim();

                // Kiểm tra thông tin không được để trống
                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra mã nhân viên đã tồn tại
                if (nhanVienBLL.KiemTraMaNV(maNV))
                {
                    MessageBox.Show(maNV + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Mặc định quyền là Admin
                    string quyen = "Admin"; // Tất cả tài khoản đăng ký đều có quyền Admin

                    // Tạo đối tượng DTO với quyền mặc định là Admin
                    NhanVienDTO nhanVien = new NhanVienDTO
                    {
                        MaNhanVien = maNV,
                        TenNhanVien = tenNV,
                        SoDienThoai = soDienThoai,
                        MatKhau = matKhau,
                        Quyen = quyen // Gán quyền Admin mặc định
                    };

                    // Kiểm tra sdt đủ 10 chữ số 0-9
                    if (nhanVien.SoDienThoai.Length != 10 || !nhanVien.SoDienThoai.All(char.IsDigit))
                    {
                        MessageBox.Show("Số điện thoại phải đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra mật khẩu >= 3
                    if (nhanVien.MatKhau.Length < 3)
                    {
                        MessageBox.Show("Mật khẩu phải có ít nhất 3 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Gọi lớp BLL để thêm nhân viên
                    if (nhanVienBLL.ThemNhanVien(nhanVien))
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Xoa();
                        this.DialogResult = DialogResult.OK;
                        
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Xoa()
        {
            dk_MaNV.Clear();
            dk_TenNV.Clear();
            dk_SoDienThoai.Clear();
            dk_MatKhau.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();  //nut X
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            dk_MaNV.Focus();
        }
    }
}
