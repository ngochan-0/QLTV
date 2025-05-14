using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace QLThuVien
{
    public partial class UTimKiemSach : UserControl
    {
        
        SachBLL sachBLL = new SachBLL();
        DatSachBLL bll = new DatSachBLL();
        private string maDocGia;

        public void SetMaDocGia(string ma)
        {
            maDocGia = ma;
        }

        public UTimKiemSach()
        {
            InitializeComponent();
        }

        private void txtUTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            string tuKhoa = txtUTimKiem.Text.Trim();
            string tieuChi = "";

            if (rbUTenSach.Checked) tieuChi = "Tên Sách";
            else if (rbULoaiSach.Checked) tieuChi = "Loại Sách";
            else if (rbUTacGia.Checked) tieuChi = "Tác Giả";
            else if (rbUNXB.Checked) tieuChi = "NXB";

            dgvUTimSach.DataSource = sachBLL.TimKiemSach(tuKhoa, tieuChi);
            ThemNutDatSach(); // Đảm bảo thêm lại nút nếu DataSource bị reset
        }

        private void UTimKiemSach_Load(object sender, EventArgs e)
        {
            // Load danh sách sách
            dgvUTimSach.DataSource = sachBLL.LayTatCaSach();

            dgvUTimSach.Columns["MaSach"].HeaderText = "Mã sách";
            dgvUTimSach.Columns["TenSach"].HeaderText = "Tên sách";
            dgvUTimSach.Columns["TenLoaiSach"].HeaderText = "Tên loại sách";
            dgvUTimSach.Columns["NhaXuatBan"].HeaderText = "Nhà xuất bản";
            dgvUTimSach.Columns["TacGia"].HeaderText = "Tác giả";
            dgvUTimSach.Columns["SoTrang"].HeaderText = "Số trang";
            dgvUTimSach.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvUTimSach.Columns["SoLuong"].HeaderText = "Số lượng";

            ThemNutDatSach();
        }

        private void ThemNutDatSach()
        {
            // Kiểm tra nếu chưa có cột thì mới thêm
            if (!dgvUTimSach.Columns.Contains("btnDatSach"))
            {
                DataGridViewButtonColumn btnDat = new DataGridViewButtonColumn();
                btnDat.Name = "btnDatSach";
                btnDat.HeaderText = "Đặt sách";
                btnDat.Text = "Đặt sách";
                btnDat.UseColumnTextForButtonValue = true;

                dgvUTimSach.Columns.Add(btnDat);
            }
        }

        private void dgvUTimSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo không lỗi null cột và không click vào header
            if (e.RowIndex >= 0 && dgvUTimSach.Columns[e.ColumnIndex]?.Name == "btnDatSach")
            {
                string maSach = dgvUTimSach.Rows[e.RowIndex].Cells["MaSach"].Value?.ToString();
                if (string.IsNullOrEmpty(maSach)) return;

                DatSachBLL bll = new DatSachBLL();
                string ketQua = bll.DatSach(maDocGia, maSach);

                //MessageBox.Show(ketQua, "Thông báo");
                if (ketQua != "Đặt sách thành công!")
                {
                    MessageBox.Show(ketQua, "Thông báo");
                    return; // ❌ Dừng luôn nếu không hợp lệ
                }
                else
                    MessageBox.Show(ketQua, "Thông báo"); // Nếu đặt thành công                
            }            
        }
    }
}
