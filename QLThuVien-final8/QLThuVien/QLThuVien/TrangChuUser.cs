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
    public partial class TrangChuUser : Form
    {
        private string maDocGia;
        

        public TrangChuUser(string ma)
        {
            InitializeComponent();
            maDocGia = ma;

            // Gán mã độc giả vào UserControl
            uSachDangMuon1.SetMaDocGia(maDocGia); // maUser là mã người dùng đã đăng nhập
            uSachQuaHan1.SetMaDocGia(maDocGia);
            uttCaNhan1.SetMaDocGia(maDocGia);
            uTimKiemSach1.SetMaDocGia(maDocGia);
            uSachDaDat1.SetMaDocGia(maDocGia);
        }

        private void TrangChuUser_Load(object sender, EventArgs e)
        {
            lblXinChaoUser.Text = "Xin chào! "; 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btUDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult kt = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kt == DialogResult.Yes)
            {
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
        }

        private void bt_UTrangChu_Click(object sender, EventArgs e)
        {
            home1.Visible = true;
            uSachQuaHan1.Visible = false;
            uSachDangMuon1.Visible = false;
            uTimKiemSach1.Visible = false;
            uttCaNhan1.Visible = false;
            uSachDaDat1.Visible = false;
        }

        private void bt_UTimKiemSach_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            uSachQuaHan1.Visible = false;
            uSachDangMuon1.Visible = false;
            uTimKiemSach1.Visible = true;
            uttCaNhan1.Visible = false;
            uSachDaDat1.Visible = false;
        }

        
        private void bt_UTTCaNhan_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            uSachQuaHan1.Visible = false;
            uSachDangMuon1.Visible = false;
            uTimKiemSach1.Visible = false;
            uttCaNhan1.Visible = true;
            uSachDaDat1.Visible = false;
        }

        private void bt_USachQuaHan_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            uSachQuaHan1.Visible = true;
            uSachDangMuon1.Visible = false;
            uTimKiemSach1.Visible = false;
            uttCaNhan1.Visible = false;
            uSachDaDat1.Visible = false;
        }

        private void bt_USachDangMuon_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            uSachQuaHan1.Visible = false;
            uSachDangMuon1.Visible = true;
            uTimKiemSach1.Visible = false;
            uttCaNhan1.Visible = false;
            uSachDaDat1.Visible = false;
        }

        private void bt_USachDaDat_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            uSachQuaHan1.Visible = false;
            uSachDangMuon1.Visible = false;
            uTimKiemSach1.Visible = false;
            uttCaNhan1.Visible = false;
            uSachDaDat1.Visible = true;

            uSachDaDat1.LoadSachDaDat(); // ← GỌI LẠI DỮ LIỆU Ở ĐÂY
        }
    }
}
