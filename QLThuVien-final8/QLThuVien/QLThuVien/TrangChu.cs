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

namespace QLThuVien
{
    public partial class TrangChu : Form
    {
        
        private string tenNguoiDung;

        public TrangChu(string ten)
        {
            InitializeComponent();
            tenNguoiDung = ten;
        }
        
        private void TrangChu_Load(object sender, EventArgs e)
        {
            lblXinChao.Text = "Xin chào! " + tenNguoiDung;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult kt = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(kt == DialogResult.Yes)
            {
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
        }

        private void bt_TrangChu_Click(object sender, EventArgs e)
        {
            home1.Visible = true;
            qlDocGia1.Visible = false;
            qlMuonTra1.Visible = false;
            qlNhanVien1.Visible = false;
            qlSach1.Visible = false;
            baoCao1.Visible = false;
            qlDatSach1.Visible = false;
        }

        private void btQLSach_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            qlDocGia1.Visible = false;
            qlMuonTra1.Visible = false;
            qlNhanVien1.Visible = false;
            qlSach1.Visible = true;
            baoCao1.Visible = false;
            qlDatSach1.Visible = false;

            qlSach1.LoadQLSach();
        }

        private void btQLMuonTra_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            qlDocGia1.Visible = false;
            qlMuonTra1.Visible = true;
            qlNhanVien1.Visible = false;
            qlSach1.Visible = false;
            baoCao1.Visible = false;
            qlDatSach1.Visible = false;

            qlMuonTra1.TaiDuLieu();
        }

        private void btQLDocGia_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            qlDocGia1.Visible = true;
            qlMuonTra1.Visible = false;
            qlNhanVien1.Visible = false;
            qlSach1.Visible = false;
            baoCao1.Visible = false;
            qlDatSach1.Visible = false;
        }

        private void btQLNhanVien_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            qlDocGia1.Visible = false;
            qlMuonTra1.Visible = false;
            qlNhanVien1.Visible = true;
            qlSach1.Visible = false;
            baoCao1.Visible = false;
            qlDatSach1.Visible = false;
        }

        private void btThongke_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            qlDocGia1.Visible = false;
            qlMuonTra1.Visible = false;
            qlNhanVien1.Visible = false;
            qlSach1.Visible = false;
            baoCao1.Visible = true;
            qlDatSach1.Visible = false;

            baoCao1.LoadThongKe();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btQLDatSach_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            qlDocGia1.Visible = false;
            qlMuonTra1.Visible = false;
            qlNhanVien1.Visible = false;
            qlSach1.Visible = false;
            baoCao1.Visible = false;
            qlDatSach1.Visible = true;
        }
    }
}
