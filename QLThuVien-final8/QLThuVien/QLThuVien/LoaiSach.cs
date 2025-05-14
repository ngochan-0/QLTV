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
    public partial class LoaiSach : Form
    {
        LoaiSachBLL loaiSachBLL = new LoaiSachBLL();
        int bien = 0;

        public LoaiSach()
        {
            InitializeComponent();
        }

        private void btTrangChu_LoaiSach_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LoaiSach_Load(object sender, EventArgs e)
        {
            HienThiDanhSachLoaiSach();
            SetControls(false);
        }

        private void HienThiDanhSachLoaiSach()
        {
            dgvTimKiem_LoaiSach.DataSource = loaiSachBLL.LayDanhSachLoaiSach();

            dgvTimKiem_LoaiSach.Columns["MaLoai"].HeaderText = "Mã loại";
            dgvTimKiem_LoaiSach.Columns["TenLoaiSach"].HeaderText = "Tên loại sách";
            dgvTimKiem_LoaiSach.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        private void SetControls(bool edit)
        {
            txtMaLoai_LoaiSach.Enabled = edit;
            txtTenLoai_LoaiSach.Enabled = edit;
            txtGhiChu_LoaiSach.Enabled = edit;
            btThem_LoaiSach.Enabled = !edit;
            btSua_LoaiSach.Enabled = !edit;
            btXoa_LoaiSach.Enabled = !edit;
            btCapNhat_LoaiSach.Enabled = edit;
            btHuy_LoaiSach.Enabled = edit;
        }

        private void txtTimKiem_LoaiSach_KeyUp(object sender, KeyEventArgs e)
        {
            dgvTimKiem_LoaiSach.DataSource = loaiSachBLL.TimKiemLoaiSach(txtTimKiem_LoaiSach.Text.Trim());
        }

        private void dgvTimKiem_LoaiSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Đảm bảo rằng chỉ số hàng là hợp lệ (không phải hàng tiêu đề, không vượt quá số lượng hàng).
            int row = e.RowIndex;
            if (row >= 0 && row < dgvTimKiem_LoaiSach.Rows.Count)
            {
                txtMaLoai_LoaiSach.Text = dgvTimKiem_LoaiSach.Rows[row].Cells[0].Value.ToString();
                txtTenLoai_LoaiSach.Text = dgvTimKiem_LoaiSach.Rows[row].Cells[1].Value.ToString();
                txtGhiChu_LoaiSach.Text = dgvTimKiem_LoaiSach.Rows[row].Cells[2].Value.ToString();
            }
        }

        private void btThem_LoaiSach_Click(object sender, EventArgs e)
        {
            txtMaLoai_LoaiSach.Clear();
            txtTenLoai_LoaiSach.Clear();
            txtGhiChu_LoaiSach.Clear();
            txtMaLoai_LoaiSach.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btSua_LoaiSach_Click(object sender, EventArgs e)
        {
            txtMaLoai_LoaiSach.Enabled = false;
            txtTenLoai_LoaiSach.Focus();
            bien = 2;
            SetControls(true);
        }

        private void btXoa_LoaiSach_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maLoai = txtMaLoai_LoaiSach.Text;
                if (loaiSachBLL.XoaLoaiSach(maLoai))
                {
                    MessageBox.Show("Xóa thành công!");
                    HienThiDanhSachLoaiSach();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btCapNhat_LoaiSach_Click(object sender, EventArgs e)
        {
            LoaiSachDTO loai = new LoaiSachDTO
            {
                MaLoai = txtMaLoai_LoaiSach.Text.Trim(),
                TenLoaiSach = txtTenLoai_LoaiSach.Text.Trim(),
                GhiChu = txtGhiChu_LoaiSach.Text.Trim()
            };

            bool ketQua = false;
            if (bien == 1)
            {
                // Kiểm tra mã loại đã tồn tại chưa
                if (loaiSachBLL.KiemTraTrungMaLoai(loai.MaLoai))
                {
                    MessageBox.Show("Mã loại sách đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketQua = loaiSachBLL.ThemLoaiSach(loai);
            }
                
            else if (bien == 2)
                ketQua = loaiSachBLL.SuaLoaiSach(loai);

            if (ketQua)
            {
                MessageBox.Show("Cập nhật thành công!");
                HienThiDanhSachLoaiSach();
                SetControls(false);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btHuy_LoaiSach_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }
    }
}
