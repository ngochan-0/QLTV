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
    public partial class NhaXuatBan : Form
    {
        NhaXuatBanBLL NXBbll = new NhaXuatBanBLL();
        int bien = 1;

        public NhaXuatBan()
        {
            InitializeComponent();
        }

        private void btTrangChu_NXB_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NhaXuatBan_Load(object sender, EventArgs e)
        {
            HienThi();
            SetControls(false);
        }

        private void HienThi()
        {
            dgvTimKiem_NXB.DataSource = NXBbll.LayDanhSachNXB();

            dgvTimKiem_NXB.Columns["MaXB"].HeaderText = "Mã nhà xuất bản";
            dgvTimKiem_NXB.Columns["NhaXuatBan"].HeaderText = "Nhà xuất bản";
            dgvTimKiem_NXB.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        private void SetControls(bool edit)
        {
            txtMaNXB_NXB.Enabled = edit;
            txtTenNXB_NXB.Enabled = edit;
            txtGhiChu_NXB.Enabled = edit;
            btThem_NXB.Enabled = !edit;
            btSua_NXB.Enabled = !edit;
            btXoa_NXB.Enabled = !edit;
            btCapNhat_NXB.Enabled = edit;
            btHuy_NXB.Enabled = edit;
        }

        private void txtTimKiem_NXB_KeyUp(object sender, KeyEventArgs e)
        {
            dgvTimKiem_NXB.DataSource = NXBbll.TimKiemNXB(txtTimKiem_NXB.Text);
        }

        private void dgvTimKiem_NXB_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0 && row < dgvTimKiem_NXB.Rows.Count)
            {
                txtMaNXB_NXB.Text = dgvTimKiem_NXB.Rows[row].Cells[0].Value.ToString();
                txtTenNXB_NXB.Text = dgvTimKiem_NXB.Rows[row].Cells[1].Value.ToString();
                txtGhiChu_NXB.Text = dgvTimKiem_NXB.Rows[row].Cells[2].Value.ToString();
            }
        }

        private void btThem_NXB_Click(object sender, EventArgs e)
        {
            txtMaNXB_NXB.Clear();
            txtTenNXB_NXB.Clear();
            txtGhiChu_NXB.Clear();
            txtMaNXB_NXB.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btSua_NXB_Click(object sender, EventArgs e)
        {
            txtMaNXB_NXB.Enabled = false;
            txtTenNXB_NXB.Focus();
            bien = 2;
            SetControls(true);
        }

        private void btXoa_NXB_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (NXBbll.XoaNXB(txtMaNXB_NXB.Text))
                    MessageBox.Show("Xoá thành công");
                else
                    MessageBox.Show("Xoá thất bại");
                HienThi();
            }
        }

        private void btCapNhat_NXB_Click(object sender, EventArgs e)
        {
            NhaXuatBanDTO nxb = new NhaXuatBanDTO
            {
                MaXB = txtMaNXB_NXB.Text.Trim(),
                NhaXuatBan = txtTenNXB_NXB.Text.Trim(),
                GhiChu = txtGhiChu_NXB.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(nxb.MaXB) || string.IsNullOrWhiteSpace(nxb.NhaXuatBan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (bien == 1) // Thêm mới
            {
                // Kiểm tra mã NXB đã tồn tại chưa
                if (NXBbll.KiemTraTrungMaNXB(nxb.MaXB))
                {
                    MessageBox.Show("Mã nhà xuất bản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (NXBbll.ThemNXB(nxb))
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm thất bại");
            }
            else // Cập nhật
            {
                if (NXBbll.CapNhatNXB(nxb))
                    MessageBox.Show("Cập nhật thành công");
                else
                    MessageBox.Show("Cập nhật thất bại");
            }

            HienThi();
            SetControls(false);
        }

        private void btHuy_NXB_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }
    }
}
