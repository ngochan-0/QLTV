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
    public partial class BaoCao : UserControl
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;

        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            thongke();
        }

        private void btDangMuon_BC_Click(object sender, EventArgs e)
        {
            string query = "select MS.MaPhieuMuon, DG.MaDG, DG.TenDG, DG.SoDienThoai, S.TenSach,MS.NgayMuon,MS.NgayTra,MS.GhiChu from MuonTraSach MS join Sach S on S.MaSach = MS.MaSach join DocGia DG on DG.MaDG = MS.MaDG where MS.NgayTra > CONVERT(date,GETDATE())";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvBaoCao.DataSource = dt;
            lbdangmuon.Visible = true;
            lbquahan.Visible = false;
            lbTong.Text = dgvBaoCao.RowCount.ToString();
        }

        private void btQuaHan_BC_Click(object sender, EventArgs e)
        {
            string query = "select MS.MaPhieuMuon, DG.MaDG, DG.TenDG, DG.SoDienThoai, S.TenSach,MS.NgayMuon,MS.NgayTra,MS.GhiChu from MuonTraSach MS join Sach S on S.MaSach = MS.MaSach join DocGia DG on DG.MaDG = MS.MaDG where MS.NgayTra <= CONVERT(date,GETDATE())";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvBaoCao.DataSource = dt;
            lbdangmuon.Visible = false;
            lbquahan.Visible = true;
            lbTong.Text = dgvBaoCao.RowCount.ToString();
        }

        public void thongke()
        {
            string query = "select MS.MaPhieuMuon, DG.MaDG, DG.TenDG, DG.SoDienThoai, S.TenSach,MS.NgayMuon,MS.NgayTra,MS.GhiChu from MuonTraSach MS join Sach S on S.MaSach = MS.MaSach join DocGia DG on DG.MaDG = MS.MaDG where MS.NgayTra > CONVERT(date,GETDATE())";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvBaoCao.DataSource = dt;
            lbdangmuon.Visible = true;
            lbquahan.Visible = false;
            lbTong.Text = dgvBaoCao.RowCount.ToString();

            NhanVienn();
            SinhVien();
            Sach();
            MuonTraSach();
            LoaiSach();
            TacGia();
            NhaXuatBan();
        }

        public void NhanVienn()
        {
            string sSql1 = "select count(*) from NhanVien";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            TkAdmin.Text = dt.Rows[0][0].ToString();
        }

        public void SinhVien()
        {
            string sSql1 = "select count(*) from DocGia";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            TkDocGia.Text = dt.Rows[0][0].ToString();
        }

        public void Sach()
        {
            string sSql1 = "select count(*) from Sach";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            TkSach.Text = dt.Rows[0][0].ToString();
        }

        public void MuonTraSach()
        {
            string sSql1 = "select count(*) from MuonTraSach";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            TkMuonSach.Text = dt.Rows[0][0].ToString();
        }

        public void LoaiSach()
        {
            string sSql1 = "select count(*) from LoaiSach";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            TKLoaiSach.Text = dt.Rows[0][0].ToString();
        }
        public void TacGia()
        {
            string sSql1 = "select count(*) from TacGia";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            TKTacGia.Text = dt.Rows[0][0].ToString();
        }
        public void NhaXuatBan()
        {
            string sSql1 = "select count(*) from NhaXuatBan";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            TKNhaXB.Text = dt.Rows[0][0].ToString();
        }

        private void dgvBaoCao_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBaoCao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBaoCao.DefaultCellStyle.Font = new Font("Arial", 12);

        }
    }
}
