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
    public partial class LoaiSach : Form
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;
        int bien = 1;

        public LoaiSach()
        {
            InitializeComponent();
        }

        private void btTrangChu_LoaiSach_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LoaiSach_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            SetControls(false);
            Display();
        }

        private void Display()
        {
            string query = "select * from LoaiSach";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimKiem_LoaiSach.DataSource = dt;
        }
        private void SetControls(bool edit)
        {
            txtMaLoai_LoaiSach.Enabled = edit;
            txtGhiChu_LoaiSach.Enabled = edit;
            btThem_LoaiSach.Enabled = !edit;
            btSua_LoaiSach.Enabled = !edit;
            btXoa_LoaiSach.Enabled = !edit;
            btCapNhat_LoaiSach.Enabled = edit;
            btHuy_LoaiSach.Enabled = edit;
        }

        private void txtTimKiem_LoaiSach_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "select * from LoaiSach where TenLoaiSach like N'%" + txtTimKiem_LoaiSach.Text + "%'";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimKiem_LoaiSach.DataSource = dt;
        }

        private void dgvTimKiem_LoaiSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaLoai_LoaiSach.Text = dgvTimKiem_LoaiSach.Rows[r].Cells[0].Value.ToString();
            txtTenLoai_LoaiSach.Text = dgvTimKiem_LoaiSach.Rows[r].Cells[1].Value.ToString();
            txtGhiChu_LoaiSach.Text = dgvTimKiem_LoaiSach.Rows[r].Cells[2].Value.ToString();
        }

        private void btThem_LoaiSach_Click(object sender, EventArgs e)
        {
            txtMaLoai_LoaiSach.Clear();
            txtTenLoai_LoaiSach.Clear();
            txtGhiChu_LoaiSach.Clear();
            txtMaLoai_LoaiSach.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btSua_LoaiSach_Click(object sender, EventArgs e)
        {
            txtMaLoai_LoaiSach.Focus();
            bien = 2;
            SetControls(true);
        }

        private void btXoa_LoaiSach_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = new DialogResult();
                dlr = MessageBox.Show("Bạn có muốn xóa? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No) return;
                int row = dgvTimKiem_LoaiSach.CurrentRow.Index;
                string Ma = dgvTimKiem_LoaiSach.Rows[row].Cells[0].Value.ToString();
                string query3 = "delete from LoaiSach where MaLoai = '" + Ma + "'";
                mySqlCommand = new SqlCommand(query3, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                Display();
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xoá", "Thông báo");
            }
        }

        private void btCapNhat_LoaiSach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai_LoaiSach.Text) ||
                string.IsNullOrWhiteSpace(txtTenLoai_LoaiSach.Text) ||
                string.IsNullOrWhiteSpace(txtGhiChu_LoaiSach.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bien == 1) // Thêm mới
            {
                foreach (DataGridViewRow row in dgvTimKiem_LoaiSach.Rows)
                {
                    if (row.Cells[0].Value != null && txtMaLoai_LoaiSach.Text == row.Cells[0].Value.ToString())
                    {
                        MessageBox.Show("Mã loại sách đã tồn tại. Vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string query1 = "INSERT INTO LoaiSach (MaLoai, TenLoaiSach, GhiChu) VALUES (@MaLoai, @TenLoaiSach, @GhiChu)";
                using (SqlCommand cmd = new SqlCommand(query1, mySqlconnection))
                {
                    cmd.Parameters.AddWithValue("@MaLoai", txtMaLoai_LoaiSach.Text);
                    cmd.Parameters.AddWithValue("@TenLoaiSach", txtTenLoai_LoaiSach.Text);
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu_LoaiSach.Text);
                    cmd.ExecuteNonQuery();
                }

                Display();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // Cập nhật
            {
                string Ma = txtMaLoai_LoaiSach.Text; // Lấy từ textbox thay vì DataGridView
                if (string.IsNullOrEmpty(Ma))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query2 = "UPDATE LoaiSach SET TenLoaiSach = @TenLoaiSach, GhiChu = @GhiChu WHERE MaLoai = @MaLoai";
                using (SqlCommand cmd = new SqlCommand(query2, mySqlconnection))
                {
                    cmd.Parameters.AddWithValue("@TenLoaiSach", txtTenLoai_LoaiSach.Text);
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu_LoaiSach.Text);
                    cmd.Parameters.AddWithValue("@MaLoai", txtMaLoai_LoaiSach.Text); // Sửa đúng mã loại

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã loại sách cần cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Display(); // Load lại dữ liệu mới
            }
        }

        private void btHuy_LoaiSach_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }

        private void dgvTimKiem_LoaiSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTimKiem_LoaiSach.DefaultCellStyle.Font = new Font("Arial", 12);

        }
    }
}
