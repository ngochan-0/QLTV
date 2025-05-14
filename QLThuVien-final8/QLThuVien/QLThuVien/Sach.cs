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
    public partial class Sach : Form
    {
        private SachBLL sachBLL = new SachBLL();
        int bien = 0;

        public Sach()
        {
            InitializeComponent();
        }

        private void btTrangChu_Sach_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Sach_Load(object sender, EventArgs e)
        {
            dgvTimKiem_Sach.DataSource = sachBLL.LayDanhSachSach();

            dgvTimKiem_Sach.Columns["MaSach"].HeaderText = "Mã sách";
            dgvTimKiem_Sach.Columns["TenSach"].HeaderText = "Tên sách";
            dgvTimKiem_Sach.Columns["MaTacGia"].HeaderText = "Mã tác giả";
            dgvTimKiem_Sach.Columns["MaXB"].HeaderText = "Mã nhà xuất bản";
            dgvTimKiem_Sach.Columns["MaLoai"].HeaderText = "Mã loại";
            dgvTimKiem_Sach.Columns["SoTrang"].HeaderText = "Số trang";
            dgvTimKiem_Sach.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvTimKiem_Sach.Columns["SoLuong"].HeaderText = "Số lượng";

            SetControls(false);
            loadComboBox();
        }

        public void loadComboBox()
        {
            cbTacGia_Sach.Items.Clear();
            cbNXB_Sach.Items.Clear();
            cbLoaiSach_Sach.Items.Clear();

            cbTacGia_Sach.DataSource = sachBLL.LayDanhSachMaTacGia();
            cbTacGia_Sach.DisplayMember = "MaTacGia";
            cbTacGia_Sach.ValueMember = "MaTacGia";

            cbNXB_Sach.DataSource = sachBLL.LayDanhSachMaNXB();
            cbNXB_Sach.DisplayMember = "MaXB";
            cbNXB_Sach.ValueMember = "MaXB";

            cbLoaiSach_Sach.DataSource = sachBLL.LayDanhSachMaLoai();
            cbLoaiSach_Sach.DisplayMember = "MaLoai";
            cbLoaiSach_Sach.ValueMember = "MaLoai";
        }

        private void SetControls(bool edit)
        {
            txtMaSach_Sach.Enabled = edit;
            txtTenSach_Sach.Enabled = edit;
            txtSoLuong_Sach.Enabled = edit;
            txtSoTrang_Sach.Enabled = edit;
            txtGiaBan_Sach.Enabled = edit;
            cbLoaiSach_Sach.Enabled = edit;
            cbNXB_Sach.Enabled = edit;
            cbTacGia_Sach.Enabled = edit;
            btThem_Sach.Enabled = !edit;
            btSua_Sach.Enabled = !edit;
            btXoa_Sach.Enabled = !edit;
            btCapNhat_Sach.Enabled = edit;
            btHuy_Sach.Enabled = edit;
        }

        private void txtTimKiem_Sach_KeyUp(object sender, KeyEventArgs e)
        {
            dgvTimKiem_Sach.DataSource = sachBLL.TimKiemTheoTen(txtTimKiem_Sach.Text.Trim());
        }

        private void dgvTimKiem_Sach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Đảm bảo rằng chỉ số hàng là hợp lệ (không phải hàng tiêu đề, không vượt quá số lượng hàng).
            int r = e.RowIndex;
            if (r >= 0 && r < dgvTimKiem_Sach.Rows.Count)
            {
                txtMaSach_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[0].Value.ToString();
                txtTenSach_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[1].Value.ToString();
                cbTacGia_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[2].Value.ToString();
                cbNXB_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[3].Value.ToString();
                cbLoaiSach_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[4].Value.ToString();
                txtSoTrang_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[5].Value.ToString();
                txtGiaBan_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[6].Value.ToString();
                txtSoLuong_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[7].Value.ToString();
            }
                
        }

        private void btThem_Sach_Click(object sender, EventArgs e)
        {
            ClearText();
            txtMaSach_Sach.Focus();
            bien = 1;
            SetControls(true);           
        }

        private void btSua_Sach_Click(object sender, EventArgs e)
        {
            txtMaSach_Sach.Enabled = false;
            txtTenSach_Sach.Focus();
            bien = 2;
            SetControls(true);     
        }

        private void btXoa_Sach_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach_Sach.Text.Trim();
            if (ma == "") return;

            if (MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (sachBLL.XoaSach(ma))
                {
                    MessageBox.Show("Xoá thành công!");
                    dgvTimKiem_Sach.DataSource = sachBLL.LayDanhSachSach();
                }
                else
                {
                    MessageBox.Show("Không thể xoá sách này vì đang được mượn.");
                }
            }
        }

        private void btCapNhat_Sach_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhap()) return; // Kiểm tra dữ liệu nhập

            // Tạo đối tượng SachDTO và gán giá trị từ form vào
            SachDTO sach = new SachDTO
            {
                MaSach = txtMaSach_Sach.Text.Trim(),
                TenSach = txtTenSach_Sach.Text.Trim(),
                MaTacGia = cbTacGia_Sach.Text,
                MaXB = cbNXB_Sach.Text,
                MaLoai = cbLoaiSach_Sach.Text,
                SoTrang = int.Parse(txtSoTrang_Sach.Text),
                GiaBan = int.Parse(txtGiaBan_Sach.Text),
                SoLuong = int.Parse(txtSoLuong_Sach.Text)
            };

            bool ketQua = false;

            // Nếu bien == 1 là thêm sách mới, bien == 2 là sửa sách
            if (bien == 1)
            {
                // Kiểm tra mã sách đã tồn tại chưa
                if (sachBLL.KiemTraTrungMaSach(sach.MaSach))
                {
                    MessageBox.Show("Mã sách đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ketQua = sachBLL.ThemSach(sach);
                this.DialogResult = DialogResult.OK;

            }
            else if (bien == 2)
                // Truyền đầy đủ tham số cho phương thức SuaSach
                ketQua = sachBLL.SuaSach(sach);

            if (ketQua)
            {
                MessageBox.Show("Thành công!");
                dgvTimKiem_Sach.DataSource = sachBLL.LayDanhSachSach(); // Cập nhật lại danh sách sách
                SetControls(false); // Tắt chế độ chỉnh sửa
            }
            else
            {
                MessageBox.Show("Thất bại hoặc trùng mã.");
            }
        }

        private void btHuy_Sach_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        private void ClearText()
        {
            txtMaSach_Sach.Clear();
            txtTenSach_Sach.Clear();
            txtGiaBan_Sach.Clear();
            txtSoLuong_Sach.Clear();
            txtSoTrang_Sach.Clear();
            cbTacGia_Sach.SelectedIndex = -1;
            cbNXB_Sach.SelectedIndex = -1;
            cbLoaiSach_Sach.SelectedIndex = -1;
        }

        private bool KiemTraNhap()
        {
            if (txtMaSach_Sach.Text == "" || txtTenSach_Sach.Text == "" ||
                txtGiaBan_Sach.Text == "" || txtSoLuong_Sach.Text == "" || txtSoTrang_Sach.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

            if (!int.TryParse(txtGiaBan_Sach.Text, out int gb) || gb < 0 ||
                !int.TryParse(txtSoLuong_Sach.Text, out int sl) || sl < 0 ||
                !int.TryParse(txtSoTrang_Sach.Text, out int st) || st < 0)
            {
                MessageBox.Show("Giá bán, số lượng, số trang phải là số dương!");
                return false;
            }

            return true;
        }
    }
}
