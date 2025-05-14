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
    public partial class NhaXuatBan : Form
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;
        int bien = 1;

        public NhaXuatBan()
        {
            InitializeComponent();
        }

        private void btTrangChu_NXB_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NhaXuatBan_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            SetControls(false);
            Display();
        }

        private void Display()
        {
            string query = "select * from NhaXuatBan";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimKiem_NXB.DataSource = dt;
        }
        private void SetControls(bool edit)
        {
            txtMaNXB_NXB.Enabled = edit;
            txtTenNXB_NXB.Enabled = edit;
            txtGhiChu_NXB.Enabled = edit;
            btThem_NXB.Enabled = !edit;
            btSua_NXB.Enabled = !edit;
            btXoa_NXB.Enabled = !edit;
            btCapNhat_NXB.Enabled = edit;
            btHuy_NXB.Enabled = edit;
        }

        private void txtTimKiem_NXB_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "select * from NhaXuatBan where NhaXuatBan like N'%" + txtTimKiem_NXB.Text + "%'";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimKiem_NXB.DataSource = dt;
        }

        private void dgvTimKiem_NXB_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaNXB_NXB.Text = dgvTimKiem_NXB.Rows[r].Cells[0].Value.ToString();
            txtTenNXB_NXB.Text = dgvTimKiem_NXB.Rows[r].Cells[1].Value.ToString();
            txtGhiChu_NXB.Text = dgvTimKiem_NXB.Rows[r].Cells[2].Value.ToString();
        }

        private void btThem_NXB_Click(object sender, EventArgs e)
        {
            txtMaNXB_NXB.Clear();
            txtTenNXB_NXB.Clear();
            txtGhiChu_NXB.Clear();
            txtMaNXB_NXB.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btSua_NXB_Click(object sender, EventArgs e)
        {
            txtMaNXB_NXB.Focus();
            bien = 2;
            SetControls(true);
        }

        private void btXoa_NXB_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTimKiem_NXB.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No) return;

                int row = dgvTimKiem_NXB.CurrentRow.Index;
                string Ma = dgvTimKiem_NXB.Rows[row].Cells[0].Value.ToString();

                string query3 = "DELETE FROM NhaXuatBan WHERE MaXB = @MaXB";

                using (SqlCommand cmd = new SqlCommand(query3, mySqlconnection))
                {
                    cmd.Parameters.AddWithValue("@MaXB", Ma);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã nhà xuất bản để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Display(); // Load lại dữ liệu mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btCapNhat_NXB_Click(object sender, EventArgs e)
        {
            if (txtMaNXB_NXB.Text == "" || txtTenNXB_NXB.Text == "" || txtGhiChu_NXB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Conn))
                {
                    conn.Open();
                    if (bien == 1) // Trường hợp thêm mới
                    {
                        // Kiểm tra trùng mã trước khi thêm
                        string checkQuery = "SELECT COUNT(*) FROM NhaXuatBan WHERE MaXB = @MaXB";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@MaXB", txtMaNXB_NXB.Text);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("Mã nhà xuất bản đã tồn tại. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Thêm dữ liệu mới
                        string query1 = "INSERT INTO NhaXuatBan (MaXB, NhaXuatBan, GhiChu) VALUES (@MaXB, @TenNXB, @GhiChu)";
                        using (SqlCommand cmd = new SqlCommand(query1, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaXB", txtMaNXB_NXB.Text);
                            cmd.Parameters.AddWithValue("@TenNXB", txtTenNXB_NXB.Text);
                            cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu_NXB.Text);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else // Trường hợp cập nhật dữ liệu
                    {
                        if (dgvTimKiem_NXB.CurrentRow == null)
                        {
                            MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string Ma = dgvTimKiem_NXB.CurrentRow.Cells[0].Value.ToString();

                        string query2 = "UPDATE NhaXuatBan SET NhaXuatBan = @TenNXB, GhiChu = @GhiChu WHERE MaXB = @MaXB";
                        using (SqlCommand cmd = new SqlCommand(query2, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaXB", Ma);
                            cmd.Parameters.AddWithValue("@TenNXB", txtTenNXB_NXB.Text);
                            cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu_NXB.Text);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Không tìm thấy mã nhà xuất bản để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Display(); // Load lại dữ liệu mới
        }

        private void btHuy_NXB_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }
    }

}
