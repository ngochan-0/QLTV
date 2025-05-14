using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace QLThuVien
{
    public partial class BaoCao : UserControl
    {
        BaoCaoBLL baoCaoBLL = new BaoCaoBLL();
        MuonTraBLL muonTraBLL = new MuonTraBLL();
        private System.Windows.Forms.Timer autoEmailTimer;
        private DateTime lastSentDate = DateTime.MinValue; 

        public BaoCao()
        {
            InitializeComponent();
        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            LoadThongKe();
            HienThiDangMuon();
            // ĐỌC lastSentDate từ file
            string debugPath = AppDomain.CurrentDomain.BaseDirectory;
            string dateLogPath = Path.Combine(debugPath, "lastsentdate.txt");
            if (File.Exists(dateLogPath))
            {
                DateTime.TryParse(File.ReadAllText(dateLogPath), out lastSentDate);
            }

            autoEmailTimer = new System.Windows.Forms.Timer();
            autoEmailTimer.Interval = 10000; // kiểm tra mỗi phút
            autoEmailTimer.Tick += AutoEmailTimer_Tick;
            autoEmailTimer.Start();

        }

        private void btDangMuon_BC_Click(object sender, EventArgs e)
        {
            HienThiDangMuon();
        }

        private void btQuaHan_BC_Click(object sender, EventArgs e)
        {
            muonTraBLL.CapNhatTrangThaiQuaHan(); // <- Gọi hàm này trước
            dgvBaoCao.DataSource = baoCaoBLL.LayDanhSachQuaHan();
            lbquahan.Visible = true;
            lbdangmuon.Visible = false;
            lbTong.Text = dgvBaoCao.RowCount.ToString();
            btGuiEmail.Visible = true;
        }

        private void HienThiDangMuon()
        {
            dgvBaoCao.DataSource = baoCaoBLL.LayDanhSachDangMuon();

            dgvBaoCao.Columns["MaPhieuMuon"].HeaderText = "Mã phiếu mượn";
            dgvBaoCao.Columns["MaDG"].HeaderText = "Mã độc giả";
            dgvBaoCao.Columns["TenDG"].HeaderText = "Tên độc giả";
            dgvBaoCao.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvBaoCao.Columns["TenSach"].HeaderText = "Tên sách";
            dgvBaoCao.Columns["NgayMuon"].HeaderText = "Ngày mượn";
            dgvBaoCao.Columns["NgayTra"].HeaderText = "Ngày trả";
            dgvBaoCao.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvBaoCao.Columns["TrangThai"].HeaderText = "Trạng thái";

            lbdangmuon.Visible = true;
            lbquahan.Visible = false;
            lbDaTra.Visible = false;
            lbTong.Text = dgvBaoCao.RowCount.ToString();
            btGuiEmail.Visible = false;
        }

        public void LoadThongKe()
        {
            TkAdmin.Text = baoCaoBLL.DemSoLuong("NhanVien").ToString();
            TkDocGia.Text = baoCaoBLL.DemSoLuong("DocGia").ToString();
            TkSach.Text = baoCaoBLL.DemSoLuong("Sach").ToString();
            TkMuonSach.Text = baoCaoBLL.DemSoLuong("MuonTraSach").ToString();
            TKLoaiSach.Text = baoCaoBLL.DemSoLuong("LoaiSach").ToString();
            TKTacGia.Text = baoCaoBLL.DemSoLuong("TacGia").ToString();
            TKNhaXB.Text = baoCaoBLL.DemSoLuong("NhaXuatBan").ToString();
        }

        private void btDaTra_BC_Click(object sender, EventArgs e)
        {
            dgvBaoCao.DataSource = baoCaoBLL.LayDanhSachDaTra();
            lbquahan.Visible = false;
            lbDaTra.Visible = true;
            lbdangmuon.Visible = false;
            lbTong.Text = dgvBaoCao.RowCount.ToString();
            btGuiEmail.Visible = false;
        }

        private void btIN_BC_Click(object sender, EventArgs e)
        {
            FrmINBC f = new FrmINBC();
            f.ShowDialog();
        }


        private void btGuiEmail_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvBaoCao.SelectedRows)
            {
                if (row.Cells["Email"].Value != null && row.Cells["TenDG"].Value != null && row.Cells["TenSach"].Value != null && row.Cells["NgayTra"].Value != null)
                {
                    string email = row.Cells["Email"].Value.ToString();
                    string tenDG = row.Cells["TenDG"].Value.ToString();
                    string tenSach = row.Cells["TenSach"].Value.ToString();

                    // Kiểm tra định dạng email
                    if (!email.Contains("@") || !email.Contains(".")) continue;

                    DateTime ngayTra = Convert.ToDateTime(row.Cells["NgayTra"].Value);
                    TimeSpan treHan = DateTime.Now.Date - ngayTra.Date;
                    int soNgayTre = treHan.Days > 0 ? treHan.Days : 0;
                    int phiPhat = soNgayTre * 50000; // phí: 50000 VNĐ/ngày

                    string subject = "Thông báo quá hạn trả sách";
                    string body = $"Chào {tenDG},\n\n" +
                                  $"Sách bạn mượn: {tenSach} \n" +
                                  $"Bạn đã trễ hạn: {soNgayTre} ngày\n" +
                                  $"Phí phạt: {phiPhat:N0} VNĐ\n\n" +
                                  $"Vui lòng trả sách khi nhận được thông báo này!\n\n" +
                                  $"Thư viện QLThuVien.";

                    try
                    {
                        SendEmail(email, subject, body);
                        MessageBox.Show($"Đã gửi email thành công đến: {email}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Gửi email đến {email} thất bại.\nLỗi: {ex.Message}");
                    }
                }
            }
        }

        private void AutoEmailTimer_Tick(object sender, EventArgs e)
        {
            string debugPath = AppDomain.CurrentDomain.BaseDirectory;
            string dateLogPath = Path.Combine(debugPath, "lastsentdate.txt");

            // Đọc lại ngày gửi gần nhất từ file (nếu có)
            if (File.Exists(dateLogPath))
            {
                string dateText = File.ReadAllText(dateLogPath);
                DateTime.TryParseExact(dateText, "MM-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out lastSentDate);
            }
            else
            {
                lastSentDate = DateTime.MinValue;
            }

            // Nếu hôm nay chưa gửi
            if (DateTime.Now.Date != lastSentDate.Date)
            {
                lastSentDate = DateTime.Now.Date;
                File.WriteAllText(dateLogPath, lastSentDate.ToString("MM-dd-yyyy"));

                // Xoá emailsent.txt cũ
                string emailLogPath = Path.Combine(debugPath, "emailsent.txt");
                if (File.Exists(emailLogPath))
                {
                    try
                    {
                        File.Delete(emailLogPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa file emailsent.txt:\n" + ex.Message);
                    }
                }

                GuiEmailTuDong(); // Gửi lại email hôm nay
            }
        }

        private void GuiEmailTuDong()
        {
            string debugPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(debugPath, "emailsent.txt");

            // Đọc file log emailsent.txt thành Dictionary<MaPhieuMuon, SoLanGui>
            Dictionary<string, int> emailSentLog = new Dictionary<string, int>();
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int soLan))
                    {
                        string ma = parts[0].Trim();
                        emailSentLog[ma] = soLan;
                    }
                }
            }

            bool daGuiMoi = false;

            foreach (DataGridViewRow row in dgvBaoCao.Rows)
            {
                if (row.Cells["Email"].Value != null &&
                    row.Cells["TenDG"].Value != null &&
                    row.Cells["TenSach"].Value != null &&
                    row.Cells["NgayTra"].Value != null &&
                    row.Cells["MaPhieuMuon"].Value != null)
                {
                    string email = row.Cells["Email"].Value.ToString();
                    string tenDG = row.Cells["TenDG"].Value.ToString();
                    string tenSach = row.Cells["TenSach"].Value.ToString();
                    string maPhieu = row.Cells["MaPhieuMuon"].Value.ToString();
                    DateTime ngayTra = Convert.ToDateTime(row.Cells["NgayTra"].Value);

                    int soNgayTre = (DateTime.Now.Date - ngayTra.Date).Days;
                    if (soNgayTre <= 0) continue;

                    // Gửi lại mỗi ngày dù đã từng gửi → KHÔNG kiểm tra tồn tại nữa
                    int phiPhat = soNgayTre * 50000;
                    string subject = "Thông báo quá hạn trả sách";
                    string body = $"Chào {tenDG},\n\n" +
                                  $"Sách bạn mượn: {tenSach} \n" +
                                  $"Bạn đã trễ hạn: {soNgayTre} ngày\n" +
                                  $"Phí phạt: {phiPhat:N0} VNĐ\n\n" +
                                  $"Vui lòng trả sách khi nhận được thông báo này!\n\n" +
                                  $"Thư viện QLThuVien.\n\n" +
                                  $"(Đây là email tự động)";

                    try
                    {
                        SendEmail(email, subject, body);

                        // Cập nhật số lần gửi: +1 nếu đã có, =1 nếu chưa có
                        if (emailSentLog.ContainsKey(maPhieu))
                            emailSentLog[maPhieu]++;
                        else
                            emailSentLog[maPhieu] = 1;

                        daGuiMoi = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Gửi email đến {email} thất bại.\nLỗi: {ex.Message}");
                    }
                }
            }

            // Ghi lại file log nếu có thay đổi
            if (daGuiMoi)
            {
                try
                {
                    var lines = emailSentLog.Select(kvp => $"{kvp.Key} | {kvp.Value}");
                    File.WriteAllLines(filePath, lines);
                    MessageBox.Show($"Đã ghi danh sách mã phiếu và số lần gửi vào: {filePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi ghi file emailsent.txt:\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Không có email mới nào được gửi → Không ghi file.");
            }
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var fromEmail = "quanlythuvien3ce@gmail.com"; // Email gửi
            var password = "calquqgpawxyotgj"; // Mật khẩu ứng dụng Gmail (không phải mật khẩu tài khoản)

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fromEmail, password)
            };

            MailMessage message = new MailMessage(fromEmail, toEmail, subject, body);
            smtp.Send(message);
        }
    }
}
