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
    public partial class USachDaDat : UserControl
    {
        DatSachBLL datSachBLL = new DatSachBLL();
        private string maDocGia;

        public void SetMaDocGia(string ma)
        {
            maDocGia = ma;
            LoadSachDaDat(); // Gọi ở đây cho chắc chắn là có maDocGia
        }

        public USachDaDat()
        {
            InitializeComponent();
        }

        public void LoadSachDaDat()
        {
            if (!string.IsNullOrEmpty(maDocGia))
            {
                DataTable dt = datSachBLL.LayPhieuDatTheoMaDocGia(maDocGia);
                dgvUSachDaDat.DataSource = dt;

                dgvUSachDaDat.Columns["MaPhieuDat"].HeaderText = "Mã phiếu đặt";
                dgvUSachDaDat.Columns["MaDG"].HeaderText = "Mã độc giả";
                dgvUSachDaDat.Columns["MaSach"].HeaderText = "Mã sách";
                dgvUSachDaDat.Columns["NgayDat"].HeaderText = "Ngày đặt";
                dgvUSachDaDat.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
        }

        private void USachDaDat_Load(object sender, EventArgs e)
        {
            LoadSachDaDat();
        }

        private void btXoaPhieuDat_Click(object sender, EventArgs e)
        {
            if (dgvUSachDaDat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu đặt để xóa!", "Thông báo");
                return;
            }

            string trangThai = dgvUSachDaDat.CurrentRow.Cells["TrangThai"].Value.ToString();
            if (trangThai != "Chờ duyệt")
            {
                MessageBox.Show("Chỉ được xóa phiếu đặt có trạng thái là 'Chờ duyệt'.", "Thông báo");
                return;
            }

            int maPhieuDat = Convert.ToInt32(dgvUSachDaDat.CurrentRow.Cells["MaPhieuDat"].Value);

            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa phiếu đặt này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (xacNhan == DialogResult.Yes)
            {
                DatSachBLL bll = new DatSachBLL();
                bool ketQua = bll.XoaPhieuDat(maPhieuDat);
                if (ketQua)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    LoadSachDaDat(); // Làm mới DataGridView
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi");
                }
            }
        }
    }
}
