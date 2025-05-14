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
using DTO;

namespace QLThuVien
{
    public partial class QLDatSach : UserControl
    {
        DatSachBLL datSachBLL = new DatSachBLL();
        MuonTraBLL muonTraBLL = new MuonTraBLL();
        public QLDatSach()
        {
            InitializeComponent();
        }

        private void QLDatSach_Load(object sender, EventArgs e)
        {
            dgvDatSach.DataSource = datSachBLL.LayTatCaPhieuDat();

            dgvDatSach.Columns["MaPhieuDat"].HeaderText = "Mã phiếu đặt";
            dgvDatSach.Columns["MaDG"].HeaderText = "Mã độc giả";
            dgvDatSach.Columns["MaSach"].HeaderText = "Mã sách";
            dgvDatSach.Columns["NgayDat"].HeaderText = "Ngày đặt";
            dgvDatSach.Columns["TrangThai"].HeaderText = "Trạng thái";

            // Thêm cột nút DUYỆT nếu chưa có
            if (!dgvDatSach.Columns.Contains("btnDuyet"))
            {
                DataGridViewButtonColumn btnDuyet = new DataGridViewButtonColumn();
                btnDuyet.HeaderText = "Duyệt";
                btnDuyet.Name = "btnDuyet";
                btnDuyet.Text = "Duyệt";
                btnDuyet.UseColumnTextForButtonValue = true;
                dgvDatSach.Columns.Add(btnDuyet);
            }

            // Thêm cột nút TỪ CHỐI nếu chưa có
            if (!dgvDatSach.Columns.Contains("btnTuChoi"))
            {
                DataGridViewButtonColumn btnTuChoi = new DataGridViewButtonColumn();
                btnTuChoi.HeaderText = "Từ chối";
                btnTuChoi.Name = "btnTuChoi";
                btnTuChoi.Text = "Từ chối";
                btnTuChoi.UseColumnTextForButtonValue = true;
                dgvDatSach.Columns.Add(btnTuChoi);
            }
        }

        private void dgvDatSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string trangThai = dgvDatSach.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();

                if (trangThai != "Chờ duyệt")
                {
                    MessageBox.Show("Phiếu này đã được xử lý rồi. Không thể thay đổi trạng thái!", "Thông báo");
                    return;
                }

                int maDat = Convert.ToInt32(dgvDatSach.Rows[e.RowIndex].Cells["MaPhieuDat"].Value);
                if (dgvDatSach.Columns[e.ColumnIndex].Name == "btnDuyet")
                {
                    var phieuDat = datSachBLL.DuyetPhieuDat(maDat);
                    if (phieuDat != null)
                    {
                        // Hỏi người dùng nhập ngày trả
                        DateTime ngayTra = DateTime.Now.AddDays(30); 
                        var kq = muonTraBLL.MuonSach(new MuonTraDTO
                        {
                            MaDG = phieuDat.MaDG,
                            MaSach = phieuDat.MaSach,
                            NgayMuon = DateTime.Now,
                            NgayTra = ngayTra,
                            GhiChu = "Đặt online",
                            TrangThai = "Đang mượn"
                        });

                        if (kq)
                        {
                            datSachBLL.CapNhatTrangThai(maDat, "Đã duyệt");
                            MessageBox.Show("Đã duyệt và tạo phiếu mượn!", "Thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không thể tạo phiếu mượn!", "Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể duyệt phiếu!", "Lỗi");
                    }
                }

                else if (dgvDatSach.Columns[e.ColumnIndex].Name == "btnTuChoi")
                {
                    datSachBLL.CapNhatTrangThai(maDat, "Từ chối");
                    MessageBox.Show("Đã từ chối phiếu!", "Thông báo");
                }

                dgvDatSach.DataSource = datSachBLL.LayTatCaPhieuDat();
            }
        }
    }
}
