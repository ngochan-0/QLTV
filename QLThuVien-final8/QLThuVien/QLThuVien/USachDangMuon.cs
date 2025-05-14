using BLL;
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
    public partial class USachDangMuon : UserControl
    {
        MuonTraBLL muonTraBLL = new MuonTraBLL();
        private string maDocGia;

        // Phương thức để gán mã độc giả vào UserControl
        public void SetMaDocGia(string ma)
        {
            maDocGia = ma;
            LoadSachDangMuon(); // Gọi ở đây cho chắc chắn là có maDocGia
        }

        public USachDangMuon()
        {
            InitializeComponent();
            
        }

        public void LoadSachDangMuon()
        {
            if (!string.IsNullOrEmpty(maDocGia))
            {
                DataTable dt = muonTraBLL.LaySachDangMuonUser(maDocGia);
                dgvUSachDangMuon.DataSource = dt;

                dgvUSachDangMuon.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu mượn";
                dgvUSachDangMuon.Columns["MaSach"].HeaderText = "Mã sách";
                dgvUSachDangMuon.Columns["TenSach"].HeaderText = "Tên sách";
                dgvUSachDangMuon.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                dgvUSachDangMuon.Columns["NgayTra"].HeaderText = "Ngày trả";
                dgvUSachDangMuon.Columns["GhiChu"].HeaderText = "Ghi chú";
                dgvUSachDangMuon.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
        }

        private void USachDangMuon_Load(object sender, EventArgs e)
        {
            // Khi form load, tự động lấy danh sách sách đang mượn của độc giả
            LoadSachDangMuon();
        }

        private void txtUTimKiem_SachDangMuon_KeyUp(object sender, KeyEventArgs e)
        {

            string tuKhoa = txtUTimKiem_SachDangMuon.Text.Trim();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                dgvUSachDangMuon.DataSource = muonTraBLL.TimSachDangMuonTheoTen(maDocGia, tuKhoa);
            }
            else
            {
                LoadSachDangMuon(); // Gõ xong xóa hết thì load lại toàn bộ
            }
        }
    }
}
