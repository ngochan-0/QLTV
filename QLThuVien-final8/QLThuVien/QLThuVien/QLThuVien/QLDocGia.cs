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
    public partial class QLDocGia : UserControl
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;
        int bien = 1;

        public QLDocGia()
        {
            InitializeComponent();
        }

        private void QLDocGia_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            DocGia();
            //SetControls(false);
        }

        private void DocGia()
        {
            string query = "select * from DocGia";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvDocGia.DataSource = dt;
            SetControls(false);
        }

        private void SetControls(bool edit)
        {
            txtMaDG_QLDG.Enabled = edit;
            txtTenDG_QLDG.Enabled = edit;
            cbGioiTinh_QLDG.Enabled = edit;
            txtDiaChi_QLDG.Enabled = edit;
            txtSDT_QLDG.Enabled = edit;
            btThem_QLDG.Enabled = !edit;
            btSua_QLDG.Enabled = !edit;
            btXoa_QLDG.Enabled = !edit;
            btCapNhat_QLDG.Enabled = edit;
            btHuy_QLDG.Enabled = edit;

            //cbTenSach.Enabled = edit;
            //cbNgayMuon.Enabled = edit;
            //cbNgayTra.Enabled = edit;
            //cbMaSV.Enabled = edit;
            //txtGhiChu.Enabled = edit;
            //btnMuon.Enabled = !edit;
            //btnGiaHan.Enabled = !edit;
            //btnTraSach.Enabled = !edit;
            //btnGhii.Enabled = edit;
            //btnHuyy.Enabled = edit;
            //cbNgayMuon.Visible = true;
            //lbNgayMuon.Visible = true;
        }

        private void btThem_QLDG_Click(object sender, EventArgs e)
        {
            txtMaDG_QLDG.Clear();
            txtTenDG_QLDG.Clear();
            txtDiaChi_QLDG.Clear();
            txtSDT_QLDG.Clear();
            txtMaDG_QLDG.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btSua_QLDG_Click(object sender, EventArgs e)
        {
            txtMaDG_QLDG.Focus();
            bien = 2;

            SetControls(true);
        }

        private void btXoa_QLDG_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = new DialogResult();
                dlr = MessageBox.Show("Bạn có muốn xóa? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No) return;
                int row = dgvDocGia.CurrentRow.Index;
                string MaDG = dgvDocGia.Rows[row].Cells[0].Value.ToString();
                string query3 = "delete from DocGia where MaDG = " + MaDG;
                mySqlCommand = new SqlCommand(query3, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                DocGia();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xoá! Độc giả này đang mượn sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btCapNhat_QLDG_Click(object sender, EventArgs e)
        {
            if (bien == 1)
            {
                if (txtMaDG_QLDG.Text.Trim() == "" || txtTenDG_QLDG.Text.Trim() == "" || cbGioiTinh_QLDG.Text.Trim() == "" || txtDiaChi_QLDG.Text.Trim() == "" || txtSDT_QLDG.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập lại !!!");
                }
                else
                {
                    for (int i = 0; i < dgvDocGia.RowCount; i++)
                    {
                        if (txtMaDG_QLDG.Text == dgvDocGia.Rows[i].Cells[0].Value.ToString())
                        {
                            MessageBox.Show("Trùng mã độc giả. Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    double x;
                    bool kt = double.TryParse(txtMaDG_QLDG.Text, out x);
                    if (kt == false)
                    {
                        MessageBox.Show("Vui lòng Nhập lại dưới dạng số!", "Thông báo");
                        return;
                    }
                    string query1 = "insert into DocGia(MaDG,TenDG, GioiTinh, DiaChi, SoDienThoai) values('" + txtMaDG_QLDG.Text + "',N'" + txtTenDG_QLDG.Text + "',N'" + cbGioiTinh_QLDG.Text + "', N'" + txtDiaChi_QLDG.Text + "', N'" + txtSDT_QLDG.Text + "')";
                    mySqlCommand = new SqlCommand(query1, mySqlconnection);
                    mySqlCommand.ExecuteNonQuery();
                    DocGia();
                    MessageBox.Show("Thên sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (txtMaDG_QLDG.Text.Trim() == "" || txtTenDG_QLDG.Text.Trim() == "" || cbGioiTinh_QLDG.Text.Trim() == "" || txtDiaChi_QLDG.Text.Trim() == "" || txtSDT_QLDG.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập lại !!!");
                }
                else
                {
                    int row = dgvDocGia.CurrentRow.Index;
                    string MaDG = dgvDocGia.Rows[row].Cells[0].Value.ToString();
                    string query2 = "update DocGia set MaDG = '" + txtMaDG_QLDG.Text + "', TenDG = N'" + txtTenDG_QLDG.Text + "', GioiTinh = N'" + cbGioiTinh_QLDG.Text + "', DiaChi = N'" + txtDiaChi_QLDG.Text + "', SoDienThoai = N'" + txtSDT_QLDG.Text + "' where MaDG = " + MaDG;
                    mySqlCommand = new SqlCommand(query2, mySqlconnection);
                    mySqlCommand.ExecuteNonQuery();
                    DocGia();
                    MessageBox.Show("Sửa độc giả thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btHuy_QLDG_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        private void dgvDocGia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaDG_QLDG.Text = dgvDocGia.Rows[r].Cells[0].Value.ToString();
            txtTenDG_QLDG.Text = dgvDocGia.Rows[r].Cells[1].Value.ToString();
            cbGioiTinh_QLDG.Text = dgvDocGia.Rows[r].Cells[2].Value.ToString();
            txtDiaChi_QLDG.Text = dgvDocGia.Rows[r].Cells[3].Value.ToString();
            txtSDT_QLDG.Text = dgvDocGia.Rows[r].Cells[4].Value.ToString();
        }

        private void txtTimKiemDocGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (rbMaDG_QLDG.Checked)
            {
                string query = "select * from DocGia where MaDG like N'%" + txtTimKiemDocGia.Text + "%'";
                mySqlCommand = new SqlCommand(query, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                SqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvDocGia.DataSource = dt;
            }

            if (rbTenDG_QLDG.Checked)
            {
                string query = "select * from DocGia where TenDG like N'%" + txtTimKiemDocGia.Text + "%'";
                mySqlCommand = new SqlCommand(query, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                SqlDataReader dr = mySqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvDocGia.DataSource = dt;
            }
        }
    }
}
