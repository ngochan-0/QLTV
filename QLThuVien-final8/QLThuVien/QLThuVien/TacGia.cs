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
    public partial class TacGia : Form
    {
        private TacGiaBLL tacGiaBLL = new TacGiaBLL();
        int bien = 0;

        public TacGia()
        {
            InitializeComponent();
        }

        private void btTrangChu_TacGia_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            TaiDanhSachTacGia();
            SetControls(false);
        }

        private void TaiDanhSachTacGia()
        {
            dgvTimKiem_TacGia.DataSource = tacGiaBLL.LayDanhSachTacGia();

            dgvTimKiem_TacGia.Columns["MaTacGia"].HeaderText = "Mã tác giả";
            dgvTimKiem_TacGia.Columns["TacGia"].HeaderText = "Tác giả";
            dgvTimKiem_TacGia.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        private void SetControls(bool edit)
        {
            txtMaTG_TacGia.Enabled = edit;
            txtTenTG_TacGia.Enabled = edit;
            txtGhiChu_TacGia.Enabled = edit;
            btThem_TacGia.Enabled = !edit;
            btSua_TacGia.Enabled = !edit;
            btXoa_TacGia.Enabled = !edit;
            btCapNhat_TacGia.Enabled = edit;
            btHuy_TacGia.Enabled = edit;
        }

        private void dgvTimKiem_TacGia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Đảm bảo rằng chỉ số hàng là hợp lệ (không phải hàng tiêu đề, không vượt quá số lượng hàng).
            //?.ToString() ?? "" nghĩa là: nếu .Value là null, thì dùng "" thay thế.
            int row = e.RowIndex;
            if (row >= 0 && row < dgvTimKiem_TacGia.Rows.Count)
            {
                txtMaTG_TacGia.Text = dgvTimKiem_TacGia.Rows[row].Cells[0].Value?.ToString() ?? "";
                txtTenTG_TacGia.Text = dgvTimKiem_TacGia.Rows[row].Cells[1].Value?.ToString() ?? "";
                txtGhiChu_TacGia.Text = dgvTimKiem_TacGia.Rows[row].Cells[2].Value?.ToString() ?? "";
            }
        }

        private void txtTimKiem_TacGia_KeyUp(object sender, KeyEventArgs e)
        {
            string tuKhoa = txtTimKiem_TacGia.Text.Trim();
            dgvTimKiem_TacGia.DataSource = tacGiaBLL.TimKiemTacGia(tuKhoa);
        }

        private void btThem_TacGia_Click(object sender, EventArgs e)
        {
            txtMaTG_TacGia.Clear();
            txtTenTG_TacGia.Clear();
            txtGhiChu_TacGia.Clear();
            txtMaTG_TacGia.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btSua_TacGia_Click(object sender, EventArgs e)
        {
            txtMaTG_TacGia.Enabled = false;
            txtTenTG_TacGia.Focus();
            bien = 2;
            SetControls(true);
        }

        private void btXoa_TacGia_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                string ma = txtMaTG_TacGia.Text;
                if (tacGiaBLL.XoaTacGia(ma))
                {
                    MessageBox.Show("Xóa thành công");
                    TaiDanhSachTacGia();
                }
                else
                {
                    MessageBox.Show("Không thể xóa");
                }
            }
        }

        private void btCapNhat_TacGia_Click(object sender, EventArgs e)
        {
            TacGiaDTO tg = new TacGiaDTO
            {
                MaTacGia = txtMaTG_TacGia.Text,
                TacGia = txtTenTG_TacGia.Text,
                GhiChu = txtGhiChu_TacGia.Text
            };

            if (string.IsNullOrWhiteSpace(tg.MaTacGia) || string.IsNullOrWhiteSpace(tg.TacGia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (bien == 1) // Thêm
            {
                // Kiểm tra mã tác giả đã tồn tại chưa
                if (tacGiaBLL.KiemTraTrungMaTG(tg.MaTacGia))
                {
                    MessageBox.Show("Mã tác giả đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tacGiaBLL.ThemTacGia(tg))
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm thất bại");
            }
            else if (bien == 2) // Sửa
            {
                if (tacGiaBLL.SuaTacGia(tg))
                    MessageBox.Show("Cập nhật thành công");
                else
                    MessageBox.Show("Cập nhật thất bại");
            }

            TaiDanhSachTacGia();
            SetControls(false);
        }

        private void btHuy_TacGia_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }
    }
}
