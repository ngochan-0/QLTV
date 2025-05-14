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
using BLL;
using DTO;

namespace QLThuVien
{
    public partial class QLDocGia : UserControl
    {
        DocGiaBLL docGiaBLL = new DocGiaBLL();
        int bien = 0;

        public QLDocGia()
        {
            InitializeComponent();
        }

        private void QLDocGia_Load(object sender, EventArgs e)
        {
            HienThiDanhSachDocGia();
            SetControls(false);
        }

        private void HienThiDanhSachDocGia()
        {
            dgvDocGia.DataSource = docGiaBLL.LayDanhSachDocGia();

            dgvDocGia.Columns["MaDG"].HeaderText = "Mã độc giả";
            dgvDocGia.Columns["TenDG"].HeaderText = "Tên độc giả";
            dgvDocGia.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDocGia.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDocGia.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvDocGia.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dgvDocGia.Columns["Quyen"].HeaderText = "Quyền";

        }

        private void SetControls(bool edit)
        {
            txtMaDG_QLDG.Enabled = edit;
            txtMatKhau_QLDG.Enabled = edit;
            txtEmail_QLDG.Enabled = edit;
            txtTenDG_QLDG.Enabled = edit;
            cbGioiTinh_QLDG.Enabled = edit;
            txtDiaChi_QLDG.Enabled = edit;
            txtSDT_QLDG.Enabled = edit;
            btThem_QLDG.Enabled = !edit;
            btXoa_QLDG.Enabled = !edit;
            btCapNhat_QLDG.Enabled = edit;
            btHuy_QLDG.Enabled = edit;       
        }

        private void btThem_QLDG_Click(object sender, EventArgs e)
        {
            txtMaDG_QLDG.Clear();
            txtMatKhau_QLDG.Clear();
            txtEmail_QLDG.Clear();
            txtTenDG_QLDG.Clear();
            txtDiaChi_QLDG.Clear();
            txtSDT_QLDG.Clear();
            cbGioiTinh_QLDG.SelectedIndex = -1;
            //txtMaDG_QLDG.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btXoa_QLDG_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.CurrentRow != null)
            {
                string maDG = dgvDocGia.CurrentRow.Cells["MaDG"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (docGiaBLL.XoaDocGia(maDG))
                        MessageBox.Show("Xóa thành công!");
                    else
                        MessageBox.Show("Không thể xóa độc giả này!");

                    HienThiDanhSachDocGia();
                }
            }
        }

        private void btCapNhat_QLDG_Click(object sender, EventArgs e)
        {
            DocGiaDTO dg = new DocGiaDTO
            {
                MaDG = txtMaDG_QLDG.Text.Trim(),
                TenDG = txtTenDG_QLDG.Text.Trim(),
                GioiTinh = cbGioiTinh_QLDG.Text,
                DiaChi = txtDiaChi_QLDG.Text.Trim(),
                MatKhau = txtMatKhau_QLDG.Text.Trim(),
                Email = txtEmail_QLDG.Text.Trim(),
                SoDienThoai = txtSDT_QLDG.Text.Trim(),
                Quyen = "User" // nếu bạn có phân quyền
            };

            if (string.IsNullOrWhiteSpace(dg.MaDG) || string.IsNullOrWhiteSpace(dg.TenDG))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            bool thanhCong = false;

            if (bien == 1)
            {
                // Kiểm tra mã độc giả đã tồn tại chưa
                if (docGiaBLL.KiemTraTrungMaDocGia(dg.MaDG))
                {
                    MessageBox.Show("Mã độc giả đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra sdt đủ 10 chữ số 0-9
                if (dg.SoDienThoai.Length != 10 || !dg.SoDienThoai.All(char.IsDigit))
                {                    
                    MessageBox.Show("Số điện thoại phải đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra mật khẩu >= 3
                if (dg.MatKhau.Length < 3)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 3 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                thanhCong = docGiaBLL.ThemDocGia(dg);
            }


            if (thanhCong)
                MessageBox.Show("Cập nhật thành công!");
            else
                MessageBox.Show("Cập nhật thất bại!");

            HienThiDanhSachDocGia();
            SetControls(false);
        }

        private void btHuy_QLDG_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        private void dgvDocGia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0 && dgvDocGia.Rows[r].Cells["MaDG"].Value != null)
            {
                txtMaDG_QLDG.Text = dgvDocGia.Rows[r].Cells["MaDG"].Value.ToString();
                txtTenDG_QLDG.Text = dgvDocGia.Rows[r].Cells["TenDG"].Value.ToString();
                cbGioiTinh_QLDG.Text = dgvDocGia.Rows[r].Cells["GioiTinh"].Value.ToString();
                txtDiaChi_QLDG.Text = dgvDocGia.Rows[r].Cells["DiaChi"].Value.ToString();
                txtSDT_QLDG.Text = dgvDocGia.Rows[r].Cells["SoDienThoai"].Value.ToString();
                txtMatKhau_QLDG.Text = dgvDocGia.Rows[r].Cells["MatKhau"].Value.ToString();
                txtEmail_QLDG.Text = dgvDocGia.Rows[r].Cells["Email"].Value.ToString();
            }
        }

        private void txtTimKiemDocGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (rbMaDG_QLDG.Checked)
                dgvDocGia.DataSource = docGiaBLL.TimKiemDocGiaTheoMa(txtTimKiemDocGia.Text);
            else if (rbTenDG_QLDG.Checked)
                dgvDocGia.DataSource = docGiaBLL.TimKiemDocGiaTheoTen(txtTimKiemDocGia.Text);
        }
    }
}
