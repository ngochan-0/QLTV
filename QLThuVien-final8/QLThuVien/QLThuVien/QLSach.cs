using BLL;
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

namespace QLThuVien
{
    public partial class QLSach : UserControl
    {        
        SachBLL sachBLL = new SachBLL();

        public QLSach()
        {
            InitializeComponent();
        }

        private void btSach_Click(object sender, EventArgs e)
        {
            Sach S = new Sach();
            if (S.ShowDialog() == DialogResult.OK)
            {
                // GỌI LẠI DANH SÁCH SAU KHI THÊM THÀNH CÔNG
                dgvTimSach.DataSource = sachBLL.LayTatCaSach();
            }
        }

        private void btLoaiSach_Click(object sender, EventArgs e)
        {
            LoaiSach LS = new LoaiSach();
            LS.Show();
        }

        private void btTacGia_Click(object sender, EventArgs e)
        {
            TacGia TG = new TacGia();
            TG.Show();
        }

        private void btNXB_Click(object sender, EventArgs e)
        {
            NhaXuatBan NXB = new NhaXuatBan();
            NXB.Show();
        }

        private void txtTimKiem_QLSach_KeyUp(object sender, KeyEventArgs e)
        {
            string tuKhoa = txtTimKiem_QLSach.Text.Trim();
            string tieuChi = "";

            if (rbTenSach.Checked) tieuChi = "Tên Sách";
            else if (rbLoaiSach.Checked) tieuChi = "Loại Sách";
            else if (rbTacGia.Checked) tieuChi = "Tác Giả";
            else if (rbNXB.Checked) tieuChi = "NXB";

            dgvTimSach.DataSource = sachBLL.TimKiemSach(tuKhoa, tieuChi);
        }

        private void QLSach_Load(object sender, EventArgs e)
        {
            LoadQLSach();
        }

        public void LoadQLSach()
        {
            dgvTimSach.DataSource = sachBLL.LayTatCaSach();
            dgvTimSach.Columns["MaSach"].HeaderText = "Mã sách";
            dgvTimSach.Columns["TenSach"].HeaderText = "Tên sách";
            dgvTimSach.Columns["TenLoaiSach"].HeaderText = "Tên loại sách";
            dgvTimSach.Columns["NhaXuatBan"].HeaderText = "Nhà xuất bản";
            dgvTimSach.Columns["TacGia"].HeaderText = "Tác giả";
            dgvTimSach.Columns["SoTrang"].HeaderText = "Số trang";
            dgvTimSach.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvTimSach.Columns["SoLuong"].HeaderText = "Số lượng";
        }
    }
}
