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
    public partial class QLSach : UserControl
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;

        public QLSach()
        {
            InitializeComponent();
        }

        private void btSach_Click(object sender, EventArgs e)
        {
            Sach S = new Sach();
            S.Show();
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
            if (rbTenSach.Checked)
            {
                string query = "select S.TenSach, Ls.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, S.SoTrang, S.GiaBan, S.SoLuong from LoaiSach LS join Sach S on LS.MaLoai = S.MaLoai join NhaXuatBan XB on XB.MaXB = S.MaXB join TacGia TG on TG.MaTacGia = S.MaTacGia  where S.TenSach like N'%" + txtTimKiem_QLSach.Text + "%' order by Soluong";
                mySqlCommand = new SqlCommand(query, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                SqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvTimSach.DataSource = dt;
            }
            if (rbLoaiSach.Checked)
            {
                string query = "select S.TenSach, Ls.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, S.SoTrang, S.GiaBan, S.SoLuong  from LoaiSach LS join Sach S on LS.MaLoai = S.MaLoai join NhaXuatBan XB on XB.MaXB = S.MaXB join TacGia TG on TG.MaTacGia = S.MaTacGia where LS.TenLoaiSach like N'%" + txtTimKiem_QLSach.Text + "%'";
                mySqlCommand = new SqlCommand(query, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                SqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvTimSach.DataSource = dt;
            }
            if (rbTacGia.Checked)
            {
                string query = "select S.TenSach, Ls.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, S.SoTrang, S.GiaBan, S.SoLuong from LoaiSach LS join Sach S on LS.MaLoai = S.MaLoai join NhaXuatBan XB on XB.MaXB = S.MaXB join TacGia TG on TG.MaTacGia = S.MaTacGia where TG.TacGia like N'%" + txtTimKiem_QLSach.Text + "%'";
                mySqlCommand = new SqlCommand(query, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                SqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvTimSach.DataSource = dt;
            }
            if (rbNXB.Checked)
            {
                string query = "select S.TenSach, Ls.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, S.SoTrang, S.GiaBan, S.SoLuong from LoaiSach LS join Sach S on LS.MaLoai = S.MaLoai join NhaXuatBan XB on XB.MaXB = S.MaXB join TacGia TG on TG.MaTacGia = S.MaTacGia where XB.NhaXuatBan like N'%" + txtTimKiem_QLSach.Text + "%'";
                mySqlCommand = new SqlCommand(query, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                SqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvTimSach.DataSource = dt;
            }
        }

        private void QLSach_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            TraCuuSach();
        }

        public void TraCuuSach()
        {
            string query = "select S.TenSach, Ls.TenLoaiSach, XB.NhaXuatBan, TG.TacGia, S.SoTrang, S.GiaBan, S.SoLuong from LoaiSach LS join Sach S on LS.MaLoai = S.MaLoai join NhaXuatBan XB on XB.MaXB = S.MaXB join TacGia TG on TG.MaTacGia = S.MaTacGia";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimSach.DataSource = dt;
        }
    }
}
