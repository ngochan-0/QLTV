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
    public partial class TacGia : Form
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;
        int bien = 1;

        public TacGia()
        {
            InitializeComponent();
        }

        private void btTrangChu_TacGia_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            SetControls(false);
            Display();
        }

        private void Display()
        {
            string query = "select * from TacGia";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimKiem_TacGia.DataSource = dt;
        }

        private void SetControls(bool edit)
        {
            txtMaTG_TacGia.Enabled = edit;
            txtTenTG_TacGia.Enabled = edit;
            txtGhiChu_TacGia.Enabled = edit;
            btThem_TacGia.Enabled = !edit;
            btSua_TacGia.Enabled = !edit;
            btXoa_TacGia.Enabled = !edit;
            btCapNhat_TacGia.Enabled = edit;
            btHuy_TacGia.Enabled = edit;
        }

        private void dgvTimKiem_TacGia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaTG_TacGia.Text = dgvTimKiem_TacGia.Rows[r].Cells[0].Value.ToString();
            txtTenTG_TacGia.Text = dgvTimKiem_TacGia.Rows[r].Cells[1].Value.ToString();
            txtGhiChu_TacGia.Text = dgvTimKiem_TacGia.Rows[r].Cells[2].Value.ToString();
        }

        private void txtTimKiem_TacGia_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "select * from TacGia where TacGia like N'%" + txtTimKiem_TacGia.Text + "%'";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimKiem_TacGia.DataSource = dt;
        }

        private void btThem_TacGia_Click(object sender, EventArgs e)
        {
            txtMaTG_TacGia.Clear();
            txtTenTG_TacGia.Clear();
            txtGhiChu_TacGia.Clear();
            txtMaTG_TacGia.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btSua_TacGia_Click(object sender, EventArgs e)
        {
            txtMaTG_TacGia.Focus();
            bien = 2;
            SetControls(true);
        }

        private void btXoa_TacGia_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = new DialogResult();
                dlr = MessageBox.Show("Bạn có muốn xóa? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No) return;
                int row = dgvTimKiem_TacGia.CurrentRow.Index;
                string Ma = dgvTimKiem_TacGia.Rows[row].Cells[0].Value.ToString();
                string query3 = "delete from TacGia where MaTacGia = '" + Ma + "'";
                mySqlCommand = new SqlCommand(query3, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                Display();
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xoá. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btCapNhat_TacGia_Click(object sender, EventArgs e)
        {
            if (bien == 1) // THÊM MỚI
            {
                if (txtMaTG_TacGia.Text == "" || txtTenTG_TacGia.Text == "" || txtGhiChu_TacGia.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra trùng mã tác giả
                for (int i = 0; i < dgvTimKiem_TacGia.RowCount - 1; i++) // Trừ 1 để bỏ dòng trống cuối cùng
                {
                    var cellValue = dgvTimKiem_TacGia.Rows[i].Cells[0].Value;
                    if (cellValue != null && txtMaTG_TacGia.Text == cellValue.ToString())
                    {
                        MessageBox.Show("Trùng mã tác giả. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Thêm tác giả mới vào database
                string query1 = "insert into TacGia(MaTacGia, TacGia, GhiChu) values(N'" + txtMaTG_TacGia.Text + "',N'" + txtTenTG_TacGia.Text + "',N'" + txtGhiChu_TacGia.Text + "')";
                mySqlCommand = new SqlCommand(query1, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                Display();
                MessageBox.Show("Thêm tác giả thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // CHỈNH SỬA
            {
                if (txtMaTG_TacGia.Text == "" || txtTenTG_TacGia.Text == "" || txtGhiChu_TacGia.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập lại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Cập nhật thông tin tác giả
                int row = dgvTimKiem_TacGia.CurrentRow.Index;
                string Ma = dgvTimKiem_TacGia.Rows[row].Cells[0].Value.ToString();
                string query2 = "update TacGia set TacGia = N'" + txtTenTG_TacGia.Text + "', GhiChu = N'" + txtGhiChu_TacGia.Text + "' where MaTacGia ='" + Ma + "'";
                mySqlCommand = new SqlCommand(query2, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                Display();
                MessageBox.Show("Sửa tác giả thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btHuy_TacGia_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }
    }
}
