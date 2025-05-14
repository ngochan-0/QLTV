namespace QLThuVien
{
    partial class LoaiSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem_LoaiSach = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btTrangChu_LoaiSach = new System.Windows.Forms.Button();
            this.btHuy_LoaiSach = new System.Windows.Forms.Button();
            this.btCapNhat_LoaiSach = new System.Windows.Forms.Button();
            this.btXoa_LoaiSach = new System.Windows.Forms.Button();
            this.btSua_LoaiSach = new System.Windows.Forms.Button();
            this.btThem_LoaiSach = new System.Windows.Forms.Button();
            this.txtGhiChu_LoaiSach = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenLoai_LoaiSach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaLoai_LoaiSach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTimKiem_LoaiSach = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem_LoaiSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 42);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(862, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOẠI SÁCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimKiem_LoaiSach);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(444, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 66);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // txtTimKiem_LoaiSach
            // 
            this.txtTimKiem_LoaiSach.Location = new System.Drawing.Point(15, 29);
            this.txtTimKiem_LoaiSach.Name = "txtTimKiem_LoaiSach";
            this.txtTimKiem_LoaiSach.Size = new System.Drawing.Size(330, 26);
            this.txtTimKiem_LoaiSach.TabIndex = 86;
            this.txtTimKiem_LoaiSach.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_LoaiSach_KeyUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btTrangChu_LoaiSach);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btHuy_LoaiSach);
            this.panel2.Controls.Add(this.btCapNhat_LoaiSach);
            this.panel2.Controls.Add(this.btXoa_LoaiSach);
            this.panel2.Controls.Add(this.btSua_LoaiSach);
            this.panel2.Controls.Add(this.btThem_LoaiSach);
            this.panel2.Controls.Add(this.txtGhiChu_LoaiSach);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtTenLoai_LoaiSach);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMaLoai_LoaiSach);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 218);
            this.panel2.TabIndex = 3;
            // 
            // btTrangChu_LoaiSach
            // 
            this.btTrangChu_LoaiSach.BackColor = System.Drawing.Color.DarkCyan;
            this.btTrangChu_LoaiSach.FlatAppearance.BorderSize = 0;
            this.btTrangChu_LoaiSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btTrangChu_LoaiSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btTrangChu_LoaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTrangChu_LoaiSach.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTrangChu_LoaiSach.ForeColor = System.Drawing.Color.White;
            this.btTrangChu_LoaiSach.Location = new System.Drawing.Point(670, 168);
            this.btTrangChu_LoaiSach.Name = "btTrangChu_LoaiSach";
            this.btTrangChu_LoaiSach.Size = new System.Drawing.Size(109, 33);
            this.btTrangChu_LoaiSach.TabIndex = 78;
            this.btTrangChu_LoaiSach.Text = "TRANG CHỦ";
            this.btTrangChu_LoaiSach.UseVisualStyleBackColor = false;
            this.btTrangChu_LoaiSach.Click += new System.EventHandler(this.btTrangChu_LoaiSach_Click);
            // 
            // btHuy_LoaiSach
            // 
            this.btHuy_LoaiSach.BackColor = System.Drawing.Color.DarkCyan;
            this.btHuy_LoaiSach.FlatAppearance.BorderSize = 0;
            this.btHuy_LoaiSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btHuy_LoaiSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btHuy_LoaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHuy_LoaiSach.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy_LoaiSach.ForeColor = System.Drawing.Color.White;
            this.btHuy_LoaiSach.Location = new System.Drawing.Point(548, 168);
            this.btHuy_LoaiSach.Name = "btHuy_LoaiSach";
            this.btHuy_LoaiSach.Size = new System.Drawing.Size(109, 33);
            this.btHuy_LoaiSach.TabIndex = 77;
            this.btHuy_LoaiSach.Text = "HỦY";
            this.btHuy_LoaiSach.UseVisualStyleBackColor = false;
            this.btHuy_LoaiSach.Click += new System.EventHandler(this.btHuy_LoaiSach_Click);
            // 
            // btCapNhat_LoaiSach
            // 
            this.btCapNhat_LoaiSach.BackColor = System.Drawing.Color.DarkCyan;
            this.btCapNhat_LoaiSach.FlatAppearance.BorderSize = 0;
            this.btCapNhat_LoaiSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btCapNhat_LoaiSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btCapNhat_LoaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCapNhat_LoaiSach.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat_LoaiSach.ForeColor = System.Drawing.Color.White;
            this.btCapNhat_LoaiSach.Location = new System.Drawing.Point(426, 168);
            this.btCapNhat_LoaiSach.Name = "btCapNhat_LoaiSach";
            this.btCapNhat_LoaiSach.Size = new System.Drawing.Size(109, 33);
            this.btCapNhat_LoaiSach.TabIndex = 76;
            this.btCapNhat_LoaiSach.Text = "CẬP NHẬT";
            this.btCapNhat_LoaiSach.UseVisualStyleBackColor = false;
            this.btCapNhat_LoaiSach.Click += new System.EventHandler(this.btCapNhat_LoaiSach_Click);
            // 
            // btXoa_LoaiSach
            // 
            this.btXoa_LoaiSach.BackColor = System.Drawing.Color.DarkCyan;
            this.btXoa_LoaiSach.FlatAppearance.BorderSize = 0;
            this.btXoa_LoaiSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btXoa_LoaiSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btXoa_LoaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXoa_LoaiSach.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa_LoaiSach.ForeColor = System.Drawing.Color.White;
            this.btXoa_LoaiSach.Location = new System.Drawing.Point(304, 168);
            this.btXoa_LoaiSach.Name = "btXoa_LoaiSach";
            this.btXoa_LoaiSach.Size = new System.Drawing.Size(109, 33);
            this.btXoa_LoaiSach.TabIndex = 75;
            this.btXoa_LoaiSach.Text = "XÓA";
            this.btXoa_LoaiSach.UseVisualStyleBackColor = false;
            this.btXoa_LoaiSach.Click += new System.EventHandler(this.btXoa_LoaiSach_Click);
            // 
            // btSua_LoaiSach
            // 
            this.btSua_LoaiSach.BackColor = System.Drawing.Color.DarkCyan;
            this.btSua_LoaiSach.FlatAppearance.BorderSize = 0;
            this.btSua_LoaiSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btSua_LoaiSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btSua_LoaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSua_LoaiSach.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua_LoaiSach.ForeColor = System.Drawing.Color.White;
            this.btSua_LoaiSach.Location = new System.Drawing.Point(182, 168);
            this.btSua_LoaiSach.Name = "btSua_LoaiSach";
            this.btSua_LoaiSach.Size = new System.Drawing.Size(109, 33);
            this.btSua_LoaiSach.TabIndex = 74;
            this.btSua_LoaiSach.Text = "SỬA";
            this.btSua_LoaiSach.UseVisualStyleBackColor = false;
            this.btSua_LoaiSach.Click += new System.EventHandler(this.btSua_LoaiSach_Click);
            // 
            // btThem_LoaiSach
            // 
            this.btThem_LoaiSach.BackColor = System.Drawing.Color.DarkCyan;
            this.btThem_LoaiSach.FlatAppearance.BorderSize = 0;
            this.btThem_LoaiSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btThem_LoaiSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btThem_LoaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThem_LoaiSach.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem_LoaiSach.ForeColor = System.Drawing.Color.White;
            this.btThem_LoaiSach.Location = new System.Drawing.Point(60, 168);
            this.btThem_LoaiSach.Name = "btThem_LoaiSach";
            this.btThem_LoaiSach.Size = new System.Drawing.Size(109, 33);
            this.btThem_LoaiSach.TabIndex = 73;
            this.btThem_LoaiSach.Text = "THÊM";
            this.btThem_LoaiSach.UseVisualStyleBackColor = false;
            this.btThem_LoaiSach.Click += new System.EventHandler(this.btThem_LoaiSach_Click);
            // 
            // txtGhiChu_LoaiSach
            // 
            this.txtGhiChu_LoaiSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu_LoaiSach.Location = new System.Drawing.Point(140, 106);
            this.txtGhiChu_LoaiSach.Name = "txtGhiChu_LoaiSach";
            this.txtGhiChu_LoaiSach.Size = new System.Drawing.Size(223, 24);
            this.txtGhiChu_LoaiSach.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 103);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 23);
            this.label6.TabIndex = 71;
            this.label6.Text = "Ghi chú:";
            // 
            // txtTenLoai_LoaiSach
            // 
            this.txtTenLoai_LoaiSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLoai_LoaiSach.Location = new System.Drawing.Point(140, 65);
            this.txtTenLoai_LoaiSach.Name = "txtTenLoai_LoaiSach";
            this.txtTenLoai_LoaiSach.Size = new System.Drawing.Size(223, 24);
            this.txtTenLoai_LoaiSach.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 59;
            this.label3.Text = "Tên loại:";
            // 
            // txtMaLoai_LoaiSach
            // 
            this.txtMaLoai_LoaiSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoai_LoaiSach.Location = new System.Drawing.Point(140, 22);
            this.txtMaLoai_LoaiSach.Name = "txtMaLoai_LoaiSach";
            this.txtMaLoai_LoaiSach.Size = new System.Drawing.Size(223, 24);
            this.txtMaLoai_LoaiSach.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 23);
            this.label2.TabIndex = 57;
            this.label2.Text = "Mã loại:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvTimKiem_LoaiSach);
            this.panel3.Location = new System.Drawing.Point(12, 290);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(840, 224);
            this.panel3.TabIndex = 4;
            // 
            // dgvTimKiem_LoaiSach
            // 
            this.dgvTimKiem_LoaiSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimKiem_LoaiSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimKiem_LoaiSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimKiem_LoaiSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTimKiem_LoaiSach.Location = new System.Drawing.Point(10, 8);
            this.dgvTimKiem_LoaiSach.Name = "dgvTimKiem_LoaiSach";
            this.dgvTimKiem_LoaiSach.RowTemplate.Height = 26;
            this.dgvTimKiem_LoaiSach.Size = new System.Drawing.Size(818, 206);
            this.dgvTimKiem_LoaiSach.TabIndex = 86;
            this.dgvTimKiem_LoaiSach.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimKiem_LoaiSach_RowEnter);
            // 
            // LoaiSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 526);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LoaiSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoaiSach";
            this.Load += new System.EventHandler(this.LoaiSach_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem_LoaiSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimKiem_LoaiSach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btTrangChu_LoaiSach;
        private System.Windows.Forms.Button btHuy_LoaiSach;
        private System.Windows.Forms.Button btCapNhat_LoaiSach;
        private System.Windows.Forms.Button btXoa_LoaiSach;
        private System.Windows.Forms.Button btSua_LoaiSach;
        private System.Windows.Forms.Button btThem_LoaiSach;
        private System.Windows.Forms.TextBox txtGhiChu_LoaiSach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenLoai_LoaiSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaLoai_LoaiSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTimKiem_LoaiSach;
    }
}