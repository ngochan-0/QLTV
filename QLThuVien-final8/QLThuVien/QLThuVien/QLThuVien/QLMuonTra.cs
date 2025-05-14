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
    public partial class QLMuonTra : UserControl
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;
        int bien = 1;

        public QLMuonTra()
        {
            InitializeComponent();
        }

        private void QLMuonTra_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            Muontra();
            cbMuontra();
        }

        private void SetControls(bool edit)
        {
            cbTenSach_PM.Enabled = edit;
            date_NgayMuon_PM.Enabled = edit;
            date_NgayTra_PM.Enabled = edit;
            cbMaDG_PM.Enabled = edit;
            txtTTSach_PM.Enabled = edit;
            btMuon_QLMuonTra.Enabled = !edit;
            btGiaHan_QLMuonTra.Enabled = !edit;
            btTra_QLMuonTra.Enabled = !edit;
            btCapNhat_QLMuonTra.Enabled = edit;
            btHuy_QLMuonTra.Enabled = edit;
            date_NgayMuon_PM.Visible = true;
            lbNgayMuon.Visible = true;
        }

        public void Muontra()
        {
            string query = "select MS.MaPhieuMuon, DG.MaDG, DG.TenDG, S.MaSach, S.TenSach,MS.NgayMuon,MS.NgayTra,MS.GhiChu from MuonTraSach MS join Sach S on S.MaSach = MS.MaSach join DocGia DG on DG.MaDG = MS.MaDG";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvMuonTra.DataSource = dt;

            txtMaPM_PM.Enabled = false;
            txtMaSach_TTS.Enabled = false;
            txtTenSach_TTS.Enabled = false;
            txtSLCon_TTS.Enabled = false;
            txtTenTG_TTS.Enabled = false;
        }

        public void cbMuontra()
        {
            string sSql2 = "select MaDG from DocGia";
            mySqlCommand = new SqlCommand(sSql2, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(mySqlCommand);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                cbMaDG_PM.Items.Add(dr[0].ToString());
            }
            string sSql9 = "select TenSach from Sach";
            mySqlCommand = new SqlCommand(sSql9, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt9 = new DataTable();
            SqlDataAdapter da9 = new SqlDataAdapter(mySqlCommand);
            da9.Fill(dt9);
            foreach (DataRow dr in dt9.Rows)
            {
                cbTenSach_PM.Items.Add(dr[0].ToString());
            }
        }

        private void cbTenSach_PM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSql1 = "select s.MaSach, s.TenSach, tg.TacGia, s.SoLuong from Sach s join TacGia tg on s.MaTacGia = tg.MaTacGia where s.TenSach = '" + cbTenSach_PM.Text + "'";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(mySqlCommand);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                txtMaSach_TTS.Text = dr["MaSach"].ToString();
                txtTenSach_TTS.Text = dr["TenSach"].ToString();
                txtTenTG_TTS.Text = dr["TacGia"].ToString();
                txtSLCon_TTS.Text = dr["SoLuong"].ToString();
            }
        }

        private void txtTimKiemMuonTra_KeyUp(object sender, KeyEventArgs e)
        {
            if (raMaDG_QLMuonTra.Checked)
            {
                string query = "select MS.MaPhieuMuon, DG.MaDG, DG.TenDG, S.MaSach, S.TenSach,MS.NgayMuon,MS.NgayTra,MS.GhiChu from MuonTraSach MS join Sach S on S.MaSach = MS.MaSach join DocGia DG on DG.MaDG = MS.MaDG where DG.MaDG like N'%" + txtTimKiemMuonTra.Text + "%'";
                mySqlCommand = new SqlCommand(query, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                SqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvMuonTra.DataSource = dt;
            }
            if (raMaSach_QLMuonTra.Checked)
            {
                string query = "select MS.MaPhieuMuon, DG.MaDG, DG.TenDG, S.MaSach, S.TenSach,MS.NgayMuon,MS.NgayTra,MS.GhiChu from MuonTraSach MS join Sach S on S.MaSach = MS.MaSach join DocGia DG on DG.MaDG = MS.MaDG where S.MaSach like N'%" + txtTimKiemMuonTra.Text + "%'";
                mySqlCommand = new SqlCommand(query, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                SqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvMuonTra.DataSource = dt;
            }
        }

        private void btMuon_QLMuonTra_Click(object sender, EventArgs e)
        {
            cbTenSach_PM.Focus();
            bien = 5;
            SetControls(true);
            //cbNgayMuon.Enabled = false;
            date_NgayMuon_PM.Visible = false;
        }

        private void btTra_QLMuonTra_Click(object sender, EventArgs e)
        {
            DialogResult dlr = new DialogResult();
            dlr = MessageBox.Show("Bạn có chắc chắn muốn trả? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No) return;
            int row = dgvMuonTra.CurrentRow.Index;
            string MaMuonTra = dgvMuonTra.Rows[row].Cells[0].Value.ToString();
            string query3 = "delete from MuonTraSach where MaPhieuMuon = " + MaMuonTra;
            mySqlCommand = new SqlCommand(query3, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SoLuongSauTra();
            Muontra();
            MessageBox.Show("Trả sách thành công!", "Thông báo");
        }

        private void btGiaHan_QLMuonTra_Click(object sender, EventArgs e)
        {
            bien = 6;

            SetControls(true);
            txtMaPM_PM.Enabled = false;
            cbTenSach_PM.Enabled = false;
            cbMaDG_PM.Enabled = false;
            txtTTSach_PM.Enabled = false;
            date_NgayMuon_PM.Enabled = false;
        }

        private void btCapNhat_QLMuonTra_Click(object sender, EventArgs e)
        {
            int SoNgay;
            string sSql2 = "SELECT DATEDIFF(day, GETDATE(),'" + date_NgayTra_PM.Value + "')";
            mySqlCommand = new SqlCommand(sSql2, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter(mySqlCommand);
            da5.Fill(dt5);
            SoNgay = Convert.ToInt32(dt5.Rows[0][0].ToString());
            if (SoNgay > 0)
            {
                if (bien == 5)
                {
                    int SoLuongSach = 0;
                    //int MaSach = Convert.ToInt32(ttMaSach.Text);
                    //MessageBox.Show(Convert.ToString(MaSach));
                    string sSql1 = "select SoLuong from Sach where MaSach ='" + txtMaSach_TTS.Text + "'";
                    mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
                    mySqlCommand.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        SoLuongSach = Convert.ToInt32(dr["SoLuong"].ToString());
                    }
                    if (SoLuongSach > 0)
                    {
                        string sSql8 = "select * from MuonTraSach where MaDG='" + cbMaDG_PM.Text + "'";
                        mySqlCommand = new SqlCommand(sSql8, mySqlconnection);
                        mySqlCommand.ExecuteNonQuery();
                        DataTable dt8 = new DataTable();
                        SqlDataAdapter da8 = new SqlDataAdapter(mySqlCommand);
                        da8.Fill(dt8);
                        int count = Convert.ToInt32(dt8.Rows.Count.ToString());
                        if (count > 3)
                        {
                            MessageBox.Show("Sinh viên này đã mượn 3 cuốn, vui lòng trả sách để có thể tiếp tục mượn", "Thông báo");
                            return;
                        }
                        else
                        {
                            string query2 = "insert into MuonTraSach( MaDG, MaSach, NgayMuon, NgayTra, GhiChu) values('" + cbMaDG_PM.Text + "','" + txtMaSach_TTS.Text + "', GETDATE(),'" + date_NgayTra_PM.Value + "',N'" + txtTTSach_PM.Text + "')";
                            mySqlCommand = new SqlCommand(query2, mySqlconnection);
                            mySqlCommand.ExecuteNonQuery();
                            SoLuongSauMuon();
                            Muontra();
                            SetControls(false);
                            MessageBox.Show("Mượn sách thành công!", "Thông báo");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có sẵn sách này!", "Thông báo");
                    }
                }
                else
                {
                    int row = dgvMuonTra.CurrentRow.Index;
                    string MaMuonTra = dgvMuonTra.Rows[row].Cells[0].Value.ToString();
                    string query2 = "update MuonTraSach set NgayTra = '" + date_NgayTra_PM.Value + "' where MaPhieuMuon = " + MaMuonTra;
                    mySqlCommand = new SqlCommand(query2, mySqlconnection);
                    mySqlCommand.ExecuteNonQuery();
                    Muontra();
                    SetControls(false);
                    MessageBox.Show("Gia hạn thành công.", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Thời gian trả không hợp lệ!");
            }
        }

        private void btHuy_QLMuonTra_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        public void SoLuongSauMuon()// Hàm này để thay đổi số lượng sách khi mượn sách.
        {
            //int MaSach = Convert.ToInt32(cbMaSach.Text);
            //MessageBox.Show(Convert.ToString(MaSach));
            string sSql1 = "select SoLuong from Sach where MaSach ='" + txtMaSach_TTS.Text + "'";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int SoLuongSach = Convert.ToInt32(dr["SoLuong"].ToString());
                int SoLuong = SoLuongSach - 1;
                //MessageBox.Show(Convert.ToString(SoLuong));
                string query2 = "update Sach set SoLuong = " + SoLuong + " where MaSach = '" + txtMaSach_TTS.Text + "'";
                mySqlCommand = new SqlCommand(query2, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
            }
        }

        public void SoLuongSauTra()// Hàm này để thay đổi số lượng sách khi trả sách.
        {
            //int MaSach = Convert.ToInt32(cbMaSach.Text);
            string sSql1 = "select SoLuong from Sach where MaSach ='" + txtMaSach_TTS.Text + "'";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int SoLuongSach = Convert.ToInt32(dr["SoLuong"].ToString());
                int SoLuong = SoLuongSach + 1;
                //MessageBox.Show(Convert.ToString(SoLuong));
                string query2 = "update Sach set SoLuong = " + SoLuong + " where MaSach = '" + txtMaSach_TTS.Text + "'";
                mySqlCommand = new SqlCommand(query2, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
            }
        }

        private void dgvMuonTra_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaPM_PM.Text = dgvMuonTra.Rows[r].Cells[0].Value.ToString();
            cbTenSach_PM.Text = dgvMuonTra.Rows[r].Cells[4].Value.ToString();
            cbMaDG_PM.Text = dgvMuonTra.Rows[r].Cells[1].Value.ToString();
            date_NgayMuon_PM.Text = dgvMuonTra.Rows[r].Cells[5].Value.ToString();
            date_NgayTra_PM.Text = dgvMuonTra.Rows[r].Cells[6].Value.ToString();
            txtTTSach_PM.Text = dgvMuonTra.Rows[r].Cells[7].Value.ToString();

            string sSql1 = "select s.MaSach, s.TenSach, tg.TacGia, s.SoLuong from Sach s join TacGia tg on s.MaTacGia = tg.MaTacGia where s.TenSach = '" + cbTenSach_PM.Text + "'";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(mySqlCommand);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                txtMaSach_TTS.Text = dr["MaSach"].ToString();
                txtTenSach_TTS.Text = dr["TenSach"].ToString();
                txtTenTG_TTS.Text = dr["TacGia"].ToString();
                txtSLCon_TTS.Text = dr["SoLuong"].ToString();
            }

            string sSql2 = "select MaSV, TenSV from SinhVien where MaSV = '" + cbMaDG_PM.Text + "'";
            mySqlCommand = new SqlCommand(sSql2, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(mySqlCommand);
            da2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                txtMaDG_TTDG.Text = dr["MaSV"].ToString();
                txtTenDG_TTDG.Text = dr["TenSV"].ToString();
            }
        }

        private void cbMaDG_PM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sSql2 = "select MaDG, TenDG from DocGia where MaDG = '" + cbMaDG_PM.Text + "'";
            mySqlCommand = new SqlCommand(sSql2, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(mySqlCommand);
            da2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                txtMaDG_TTDG.Text = dr["MaDG"].ToString();
                txtTenDG_TTDG.Text = dr["TenDG"].ToString();
            }
        }
    }
}
