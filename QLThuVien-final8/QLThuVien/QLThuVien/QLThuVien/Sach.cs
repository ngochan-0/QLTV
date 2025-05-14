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
    public partial class Sach : Form
    {
        string Conn = "Data Source=.;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";
        SqlConnection mySqlconnection;
        SqlCommand mySqlCommand;
        int bien = 1;

        public Sach()
        {
            InitializeComponent();
        }

        private void btTrangChu_Sach_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Sach_Load(object sender, EventArgs e)
        {
            mySqlconnection = new SqlConnection(Conn);
            mySqlconnection.Open();

            SetControls(false);
            Display();
            loadComboBox();
        }

        private void Display()
        {
            string query = "select * from Sach";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimKiem_Sach.DataSource = dt;
        }

        public void loadComboBox()
        {
            string sSql1 = "select MaTacGia from TacGia";
            mySqlCommand = new SqlCommand(sSql1, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cbTacGia_Sach.Items.Add(dr[0].ToString());
            }

            string sSql2 = "select MaXB from NhaXuatBan";
            mySqlCommand = new SqlCommand(sSql2, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(mySqlCommand);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                cbNXB_Sach.Items.Add(dr[0].ToString());
            }

            string sSql3 = "select MaLoai from LoaiSach";
            mySqlCommand = new SqlCommand(sSql3, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(mySqlCommand);
            da3.Fill(dt3);
            foreach (DataRow dr in dt3.Rows)
            {
                cbLoaiSach_Sach.Items.Add(dr[0].ToString());
            }
        }

        private void SetControls(bool edit)
        {
            txtMaSach_Sach.Enabled = edit;
            txtTenSach_Sach.Enabled = edit;
            txtSoLuong_Sach.Enabled = edit;
            txtSoTrang_Sach.Enabled = edit;
            txtGiaBan_Sach.Enabled = edit;
            cbLoaiSach_Sach.Enabled = edit;
            cbNXB_Sach.Enabled = edit;
            cbTacGia_Sach.Enabled = edit;
            btThem_Sach.Enabled = !edit;
            btSua_Sach.Enabled = !edit;
            btXoa_Sach.Enabled = !edit;
            btCapNhat_Sach.Enabled = edit;
            btHuy_Sach.Enabled = edit;
        }

        private void txtTimKiem_Sach_KeyUp(object sender, KeyEventArgs e)
        {
            string query = "select * from Sach where TenSach like N'%" + txtTimKiem_Sach.Text + "%'";
            mySqlCommand = new SqlCommand(query, mySqlconnection);
            mySqlCommand.ExecuteNonQuery();
            SqlDataReader dr = mySqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvTimKiem_Sach.DataSource = dt;
        }

        private void dgvTimKiem_Sach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            txtMaSach_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[0].Value.ToString();
            txtTenSach_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[1].Value.ToString();
            cbTacGia_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[2].Value.ToString();
            cbNXB_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[3].Value.ToString();
            cbLoaiSach_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[4].Value.ToString();
            txtSoTrang_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[5].Value.ToString();
            txtGiaBan_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[6].Value.ToString();
            txtSoLuong_Sach.Text = dgvTimKiem_Sach.Rows[r].Cells[7].Value.ToString();
        }

        private void btThem_Sach_Click(object sender, EventArgs e)
        {
            txtMaSach_Sach.Clear();
            txtTenSach_Sach.Clear();
            txtSoLuong_Sach.Clear();
            txtSoTrang_Sach.Clear();
            txtGiaBan_Sach.Clear();
            txtMaSach_Sach.Focus();
            bien = 1;
            SetControls(true);
        }

        private void btSua_Sach_Click(object sender, EventArgs e)
        {
            txtMaSach_Sach.Focus();
            bien = 2;
            SetControls(true);
        }

        private void btXoa_Sach_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlr = new DialogResult();
                dlr = MessageBox.Show("Ban co chac chan muon xoa? ", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.No) return;

                int row = dgvTimKiem_Sach.CurrentRow.Index;
                string MaSach = dgvTimKiem_Sach.Rows[row].Cells[0].Value.ToString();
                string query3 = "delete from Sach where MaSach = '" + MaSach + "'";
                mySqlCommand = new SqlCommand(query3, mySqlconnection);
                mySqlCommand.ExecuteNonQuery();
                Display();
                MessageBox.Show("Đã xoá thành công", "Thông báo");
            }

            catch (Exception)
            {
                MessageBox.Show("Không thể xoá sách này đang được sinh viên mượn.", "Thông Báo");
            }
        }

        private void btCapNhat_Sach_Click(object sender, EventArgs e)
        {
            if (bien == 1)
            {
                if (txtMaSach_Sach.Text.Trim() == "" || txtTenSach_Sach.Text.Trim() == "" || txtGiaBan_Sach.Text.Trim() == "" || txtSoLuong_Sach.Text.Trim() == "" || txtSoTrang_Sach.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!");
                }
                else
                {

                    double x;
                    bool kt = double.TryParse(txtGiaBan_Sach.Text, out x);
                    bool kt1 = double.TryParse(txtSoLuong_Sach.Text, out x);
                    bool kt2 = double.TryParse(txtSoTrang_Sach.Text, out x);
                    if (kt == false || kt1 == false || kt2 == false || Convert.ToInt32(txtGiaBan_Sach.Text) < 0 || Convert.ToInt32(txtSoLuong_Sach.Text) < 0 || Convert.ToInt32(txtSoTrang_Sach.Text) < 0)
                    {
                        MessageBox.Show("Vui lòng Nhập lại dưới dạng số dương!", "Thông báo");
                        return;
                    }
                    for (int i = 0; i < dgvTimKiem_Sach.RowCount; i++)
                    {
                        if (txtMaSach_Sach.Text == dgvTimKiem_Sach.Rows[i].Cells[0].Value.ToString())
                        {
                            MessageBox.Show("Trùng mã sách. Vui lòng Nhập lại", "Thông báo");
                            return;
                        }
                    }
                    string query1 = "insert into Sach(MaSach,TenSach, MaTacGia, MaXB, MaLoai, SoTrang, GiaBan, SoLuong) values(N'" + txtMaSach_Sach.Text + "',N'" + txtTenSach_Sach.Text + "',N'" + cbTacGia_Sach.Text + "', N'" + cbNXB_Sach.Text + "',N'" + cbLoaiSach_Sach.Text + "','" + txtSoTrang_Sach.Text + "', N'" + txtGiaBan_Sach.Text + "', N'" + txtSoLuong_Sach.Text + "')";
                    mySqlCommand = new SqlCommand(query1, mySqlconnection);
                    mySqlCommand.ExecuteNonQuery();
                    Display();
                    SetControls(false);
                    MessageBox.Show("Đã thêm sách thành công", "Thông báo");
                }
            }
            else
            {
                if (txtTenSach_Sach.Text.Trim() == "" || txtGiaBan_Sach.Text.Trim() == "" || txtSoLuong_Sach.Text.Trim() == "" || txtSoTrang_Sach.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!");
                    return;
                }
                else
                {
                    double x;
                    bool kt = double.TryParse(txtGiaBan_Sach.Text, out x);
                    bool kt1 = double.TryParse(txtSoLuong_Sach.Text, out x);
                    bool kt2 = double.TryParse(txtSoTrang_Sach.Text, out x);
                    if (kt == false || kt1 == false || kt2 == false || Convert.ToInt32(txtGiaBan_Sach.Text) < 0 || Convert.ToInt32(txtSoLuong_Sach.Text) < 0 || Convert.ToInt32(txtSoTrang_Sach.Text) < 0)
                    {
                        MessageBox.Show("Vui lòng Nhập lại dưới dạng số dương!", "Thông báo");
                        return;
                    }
                    int row = dgvTimKiem_Sach.CurrentRow.Index;
                    string MaSach = dgvTimKiem_Sach.Rows[row].Cells[0].Value.ToString();
                    string query2 = "update Sach set TenSach = N'" + txtTenSach_Sach.Text + "', MaTacGia = N'" + cbTacGia_Sach.Text + "', MaXB = N'" + cbNXB_Sach.Text + "',Maloai = '" + cbLoaiSach_Sach.Text + "',SoTrang = '" + txtSoTrang_Sach.Text + "', GiaBan = N'" + txtGiaBan_Sach.Text + "', SoLuong = N'" + txtSoLuong_Sach.Text + "' where MaSach = '" + MaSach + "'";
                    mySqlCommand = new SqlCommand(query2, mySqlconnection);
                    mySqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Sửa sách thành công");
                    Display();
                    SetControls(false);
                }
            }
        }

        private void btHuy_Sach_Click(object sender, EventArgs e)
        {
            SetControls(false);
        }
    }
}
