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
    public partial class USachQuaHan : UserControl
    {
        MuonTraBLL muonTraBLL = new MuonTraBLL();
        private string maDocGia;

        // Phương thức để gán mã độc giả vào UserControl
        public void SetMaDocGia(string ma)
        {
            maDocGia = ma;
            LoadSachQuaHan(); // Gọi ở đây cho chắc chắn là có maDocGia
        }

        public USachQuaHan()
        {
            InitializeComponent();
        }

        public void LoadSachQuaHan()
        {
            if (!string.IsNullOrEmpty(maDocGia))
            {
                DataTable dt = muonTraBLL.LaySachQuaHanUser(maDocGia);
                dgvUSachQuaHan.DataSource = dt;

                // Thêm cột PhiPhat
                dt.Columns.Add("PhiPhat", typeof(string));

                // Tính phí phạt và gán dữ liệu có định dạng + đơn vị
                foreach (DataRow row in dt.Rows)
                {
                    DateTime ngayTra = Convert.ToDateTime(row["NgayTra"]);
                    int soNgayTre = (DateTime.Now.Date - ngayTra.Date).Days;
                    if (soNgayTre < 0) soNgayTre = 0;

                    int tienPhat = soNgayTre * 50000;
                    row["PhiPhat"] = $"{tienPhat:N0} VND"; 
                }

                dgvUSachQuaHan.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu mượn";
                dgvUSachQuaHan.Columns["MaSach"].HeaderText = "Mã sách";
                dgvUSachQuaHan.Columns["TenSach"].HeaderText = "Tên sách";
                dgvUSachQuaHan.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                dgvUSachQuaHan.Columns["NgayTra"].HeaderText = "Ngày trả";
                dgvUSachQuaHan.Columns["GhiChu"].HeaderText = "Ghi chú";
                dgvUSachQuaHan.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvUSachQuaHan.Columns["PhiPhat"].HeaderText = "Phí phạt";
            }
        }

        private void USachQuaHan_Load(object sender, EventArgs e)
        {
            LoadSachQuaHan();
        }
    }
}
