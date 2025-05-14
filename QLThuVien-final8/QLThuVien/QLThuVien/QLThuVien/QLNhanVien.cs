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
    public partial class QLNhanVien : UserControl
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;
        int bien = 1;

        public QLNhanVien()
        {
            InitializeComponent();
        }

        private void btDoiMK_QLNV_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau();
            doiMatKhau.Show();
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            NhanVien();
            
        }

        public void NhanVien()
        {
            string query = "select MaNhanVien, TenNhanVien, SoDienThoai, MatKhau from NhanVien";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvQLNhanVien.DataSource = dt;

        }

        private void btXoa_QLNV_Click(object sender, EventArgs e)
        {
            DialogResult dlr = new DialogResult();
            dlr = MessageBox.Show("Bạn có muốn xóa? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No) return;
            int row = dgvQLNhanVien.CurrentRow.Index;
            string MaNV = dgvQLNhanVien.Rows[row].Cells[0].Value.ToString();
            string query3 = "delete from NhanVien where MaNhanVien = '" + MaNV + "'";
            mySqlCommand = new SqlCommand(query3, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            NhanVien();
            MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
