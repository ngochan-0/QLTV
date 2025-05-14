using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QLThuVien
{
    public partial class QLMuonTra : UserControl
    {
        // Khai báo đối tượng BLL
        MuonTraBLL muonTraBLL = new MuonTraBLL();
        int bien = 0;

        public QLMuonTra()
        {
            InitializeComponent();
        }

        private void QLMuonTra_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
            SetControls(false);

            dgvMuonTra.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu mượn";
            dgvMuonTra.Columns["MaDG"].HeaderText = "Mã độc giả";
            dgvMuonTra.Columns["TenDG"].HeaderText = "Tên độc giả";
            dgvMuonTra.Columns["MaSach"].HeaderText = "Mã sách";
            dgvMuonTra.Columns["TenSach"].HeaderText = "Tên sách";
            dgvMuonTra.Columns["NgayMuon"].HeaderText = "Ngày mượn";
            dgvMuonTra.Columns["NgayTra"].HeaderText = "Ngày trả";
            dgvMuonTra.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvMuonTra.Columns["TrangThai"].HeaderText = "Trạng Thái";


            //dgvMuonTra.DataSource = muonTraBLL.LayDanhSachMuonTra();
        }

        public void LoadDS()
        {
            dgvMuonTra.DataSource = muonTraBLL.LayDanhSachMuonTra();
        }

        public void TaiDuLieu()
        {
            muonTraBLL.CapNhatTrangThaiQuaHan(); // <- Gọi hàm này trước

            dgvMuonTra.DataSource = muonTraBLL.LayDanhSachMuonTra();

            cbMaDG_PM.DataSource = muonTraBLL.LayDanhSachMaDocGia();
            cbMaDG_PM.DisplayMember = "MaDG";
            cbMaDG_PM.ValueMember = "MaDG";

            cbTenSach_PM.DataSource = muonTraBLL.LayDanhSachTenSach();
            cbTenSach_PM.DisplayMember = "TenSach";
            cbTenSach_PM.ValueMember = "TenSach";
        }

        private void SetControls(bool edit)
        {
            cbTenSach_PM.Enabled = edit;
            date_NgayMuon_PM.Enabled = edit;
            date_NgayTra_PM.Enabled = edit;
            cbMaDG_PM.Enabled = edit;
            txtTTSach_PM.Enabled = edit;
            date_NgayMuon_PM.Visible = true;
            date_NgayTra_PM.Visible = true;

            btMuon_QLMuonTra.Enabled = !edit;
            btGiaHan_QLMuonTra.Enabled = !edit;
            btTra_QLMuonTra.Enabled = !edit;
            btCapNhat_QLMuonTra.Enabled = edit;
            btHuy_QLMuonTra.Enabled = edit;  
        }

        
        private void cbTenSach_PM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenSach = cbTenSach_PM.Text;
            DataTable sach = muonTraBLL.LayThongTinSachTheoTen(tenSach);
            if (sach.Rows.Count > 0)
            {
                txtMaSach_TTS.Text = sach.Rows[0]["MaSach"].ToString();
                txtTenSach_TTS.Text = sach.Rows[0]["TenSach"].ToString();
                txtTenTG_TTS.Text = sach.Rows[0]["TacGia"].ToString();
                txtSLCon_TTS.Text = sach.Rows[0]["SoLuong"].ToString();
            }
        }

        private void txtTimKiemMuonTra_KeyUp(object sender, KeyEventArgs e)
        {
            string tuKhoa = txtTimKiemMuonTra.Text;
            if (raMaDG_QLMuonTra.Checked)
            {
                dgvMuonTra.DataSource = muonTraBLL.LayThongTinDocGiaTheoMa(tuKhoa);
            }
            else if (raMaSach_QLMuonTra.Checked)
            {
                dgvMuonTra.DataSource = muonTraBLL.LayThongTinSachTheoMa(tuKhoa);
            }
        }

        private void btMuon_QLMuonTra_Click(object sender, EventArgs e)
        {
            cbTenSach_PM.Focus();
            bien = 2;
            SetControls(true);
            date_NgayMuon_PM.Visible = false;
        }

        private void btTra_QLMuonTra_Click(object sender, EventArgs e)
        {
           
            var result = MessageBox.Show("Bạn có chắc chắn muốn trả sách?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dgvMuonTra.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn dòng cần trả sách!", "Thông báo");
                    return;
                }

                // Lấy dữ liệu từ dòng hiện tại
                int maPhieuMuon = Convert.ToInt32(dgvMuonTra.CurrentRow.Cells["MaPhieuMuon"].Value);
                string maSach = dgvMuonTra.CurrentRow.Cells["MaSach"].Value.ToString();

                try
                {
                    muonTraBLL.TraSach(maPhieuMuon); // Cập nhật trạng thái trả sách
                    muonTraBLL.SoLuongSauTra(maSach); // Cập nhật số lượng sách

                    MessageBox.Show("Trả sách thành công!", "Thông báo");
                    TaiDuLieu(); // Refresh lại danh sách
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trả sách không thành công, vui lòng kiểm tra lại thông tin!", "Thông báo");
                }
            }
        }

        private void btGiaHan_QLMuonTra_Click(object sender, EventArgs e)
        {
            bien = 3;

            SetControls(true);
            txtMaPM_PM.Enabled = false;
            cbTenSach_PM.Enabled = false;
            cbMaDG_PM.Enabled = false;
            txtTTSach_PM.Enabled = false;
            date_NgayMuon_PM.Enabled = false;
        }

        private void btCapNhat_QLMuonTra_Click(object sender, EventArgs e)
        {
            MuonTraDTO muon = new MuonTraDTO
            {
                MaDG = cbMaDG_PM.Text.Trim(),
                MaSach = txtMaSach_TTS.Text.Trim(),
                GhiChu = txtTTSach_PM.Text.Trim(),
                NgayTra = date_NgayTra_PM.Value,
                TrangThai = "Đang mượn"
            };

            if (date_NgayTra_PM.Value <= DateTime.Now)
            {
                MessageBox.Show("Thời gian trả không hợp lệ!");
                return;
            }

            if (bien == 2)
            {
                //string maDG = cbMaDG_PM.Text;
                //string maSach = txtMaSach_TTS.Text;

                // Kiểm tra số sách đang mượn
                int soLuongDangMuon = muonTraBLL.DemSoLuongSachDangMuon(muon.MaDG);
                if (soLuongDangMuon >= 5)
                {
                    MessageBox.Show("Sinh viên này đã mượn 5 cuốn, vui lòng trả sách để có thể tiếp tục mượn", "Thông báo");
                    return;
                }

                // Kiểm tra số lượng sách còn
                int soLuongCon = int.Parse(txtSLCon_TTS.Text);
                if (soLuongCon <= 0)
                {
                    MessageBox.Show("Sách đã hết!", "Thông báo");
                    return;
                }

                // Kiểm tra độc giả đã mượn cuốn này và chưa trả
                if (muonTraBLL.KiemTraDocGiaDangMuonSach(muon.MaDG, muon.MaSach))
                {
                    MessageBox.Show("Độc giả này đã mượn cuốn sách này rồi (đang mượn hoặc quá hạn) và chưa trả!", "Thông báo");
                    return;
                }

                // Kiểm tra kết quả mượn sách
                bool ketQuaMuon = muonTraBLL.MuonSach(muon);
                if (ketQuaMuon)
                {
                    muonTraBLL.SoLuongSauMuon(muon.MaSach); // Trừ số lượng sách
                    MessageBox.Show("Mượn sách thành công!");
                    TaiDuLieu();
                    SetControls(false);
                }
                else
                {
                    MessageBox.Show("Mượn sách không thành công, vui lòng kiểm tra lại thông tin!", "Thông báo");
                }
            }
            else if (bien == 3)
            {
                int maPhieuMuon = Convert.ToInt32(txtMaPM_PM.Text);
                bool ketQuaGiaHan = muonTraBLL.GiaHan(maPhieuMuon, date_NgayTra_PM.Value);
                if (ketQuaGiaHan)
                {
                    MessageBox.Show("Gia hạn thành công.");
                    TaiDuLieu();
                    SetControls(false);
                }
                else
                {
                    MessageBox.Show("Gia hạn không thành công. Vui lòng kiểm tra lại thông tin.", "Lỗi");
                }
            }
        }

        private void btHuy_QLMuonTra_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }


        private void dgvMuonTra_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                // Kiểm tra dữ liệu trước khi gán giá trị vào các control
                txtMaPM_PM.Text = dgvMuonTra.Rows[r].Cells["MaPhieuMuon"].Value?.ToString() ?? string.Empty;
                cbMaDG_PM.Text = dgvMuonTra.Rows[r].Cells["MaDG"].Value?.ToString() ?? string.Empty;
                cbTenSach_PM.Text = dgvMuonTra.Rows[r].Cells["TenSach"].Value?.ToString() ?? string.Empty;

                // Kiểm tra null cho các ô ngày
                date_NgayMuon_PM.Value = dgvMuonTra.Rows[r].Cells["NgayMuon"].Value != DBNull.Value ? Convert.ToDateTime(dgvMuonTra.Rows[r].Cells["NgayMuon"].Value) : DateTime.Now;
                date_NgayTra_PM.Value = dgvMuonTra.Rows[r].Cells["NgayTra"].Value != DBNull.Value ? Convert.ToDateTime(dgvMuonTra.Rows[r].Cells["NgayTra"].Value) : DateTime.Now;

                txtTTSach_PM.Text = dgvMuonTra.Rows[r].Cells["GhiChu"].Value?.ToString() ?? string.Empty;
            }
        }

        private void cbMaDG_PM_SelectedIndexChanged(object sender, EventArgs e)
        {           
            string maDocGia = cbMaDG_PM.Text;
            DataTable dt = muonTraBLL.LayThongTinDocGiaTheoMa(maDocGia); 
            if (dt.Rows.Count > 0)
            {
                txtMaDG_TTDG.Text = dt.Rows[0]["MaDG"].ToString();  
                txtTenDG_TTDG.Text = dt.Rows[0]["TenDG"].ToString(); 
            }
        }
    }
}
