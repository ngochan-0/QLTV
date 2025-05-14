using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class UTTCaNhan : UserControl
    {
        DocGiaBLL docGiaBLL = new DocGiaBLL();
        private string maDocGia;

        // Phương thức để gán mã độc giả vào UserControl
        public void SetMaDocGia(string ma)
        {
            maDocGia = ma;
            LoadThongTinCaNhan(); // Gọi ở đây cho chắc chắn là có maDocGia
        }

        public void LoadThongTinCaNhan()
        {
            if (!string.IsNullOrEmpty(maDocGia))
            {
                DocGiaDTO docGia = docGiaBLL.LayThongTinDocGia(maDocGia);
                if (docGia != null)
                {
                    txtMaDG_TTCN.Text = docGia.MaDG;
                    txtTenDG_TTCN.Text = docGia.TenDG;
                    txtDiaChi_TTCN.Text = docGia.DiaChi;
                    cbGioiTinh_TTCN.Text = docGia.GioiTinh;
                    txtSDT_TTCN.Text = docGia.SoDienThoai;
                    txtMatKhau_TTCN.Text = docGia.MatKhau;
                    txtEmail_TTCN.Text = docGia.Email;

                    // Không cho chỉnh sửa các ô               
                    SetControls(true);
                }
            }
        }

        private void SetControls(bool edit)
        {
            // Không cho chỉnh sửa các ô
            txtMaDG_TTCN.ReadOnly = edit;
            txtTenDG_TTCN.ReadOnly = edit;
            txtDiaChi_TTCN.ReadOnly = edit;
            cbGioiTinh_TTCN.Enabled = !edit;
            txtSDT_TTCN.ReadOnly = edit;
            txtMatKhau_TTCN.ReadOnly = edit;
            txtEmail_TTCN.ReadOnly = edit;
        }

        public UTTCaNhan()
        {
            InitializeComponent();
        }

        private void UTTCaNhan_Load(object sender, EventArgs e)
        {
            LoadThongTinCaNhan();
        }

        private void btDoiMK_TTCN_Click(object sender, EventArgs e)
        {
            // Cho phép chỉnh sửa tất cả trừ mã độc giả
            SetControls(false);
            txtMaDG_TTCN.ReadOnly = true;

            txtTenDG_TTCN.Focus(); // Focus vào tên độc giả đầu tiên
        }

        private void btCapNhat_TTCN_Click(object sender, EventArgs e)
        {
            DocGiaDTO docGia = new DocGiaDTO
            {
                MaDG = txtMaDG_TTCN.Text,
                TenDG = txtTenDG_TTCN.Text,
                DiaChi = txtDiaChi_TTCN.Text,
                GioiTinh = cbGioiTinh_TTCN.Text,
                SoDienThoai = txtSDT_TTCN.Text,
                MatKhau = txtMatKhau_TTCN.Text,
                Email = txtEmail_TTCN.Text,
            };

            // Kiểm tra sdt đủ 10 chữ số 0-9
            if (docGia.SoDienThoai.Length != 10 || !docGia.SoDienThoai.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (docGia.MatKhau.Length < 3)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 3 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool kq = docGiaBLL.SuaDocGia(docGia);
            if (kq)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetControls(true);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btHuy_TTCN_Click(object sender, EventArgs e)
        {
            SetControls(true);
        }
    }
}
