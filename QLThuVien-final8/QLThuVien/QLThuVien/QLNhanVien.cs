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
//using DTO;

namespace QLThuVien
{
    public partial class QLNhanVien : UserControl
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();

        public QLNhanVien()
        {
            InitializeComponent();
        }

        private void btDoiMK_QLNV_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            if (doiMatKhau.ShowDialog() == DialogResult.OK)
            {
                // Sau khi đổi mật khẩu thành công và form đóng, cập nhật lại danh sách
                HienThiDanhSachNhanVien();
            }
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();

        }

        private void HienThiDanhSachNhanVien()
        {
            dgvQLNhanVien.DataSource = nhanVienBLL.LayDanhSachNhanVien();

            dgvQLNhanVien.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvQLNhanVien.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            dgvQLNhanVien.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvQLNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";
        }

        private void btXoa_QLNV_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int row = dgvQLNhanVien.CurrentRow.Index;
                string maNV = dgvQLNhanVien.Rows[row].Cells[0].Value.ToString();
                if (nhanVienBLL.XoaNhanVien(maNV))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    HienThiDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thông báo");
                }
            }
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            DangKy dangky = new DangKy();
            if (dangky.ShowDialog() == DialogResult.OK)
            {
                // Sau khi đổi mật khẩu thành công và form đóng, cập nhật lại danh sách
                HienThiDanhSachNhanVien();
            }
        }
    }
}
