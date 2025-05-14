namespace QLThuVien
{
    partial class TacGia
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTimKiem_TacGia = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btTrangChu_TacGia = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem_TacGia = new System.Windows.Forms.TextBox();
            this.btHuy_TacGia = new System.Windows.Forms.Button();
            this.btCapNhat_TacGia = new System.Windows.Forms.Button();
            this.btXoa_TacGia = new System.Windows.Forms.Button();
            this.btSua_TacGia = new System.Windows.Forms.Button();
            this.btThem_TacGia = new System.Windows.Forms.Button();
            this.txtGhiChu_TacGia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenTG_TacGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaTG_TacGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem_TacGia)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvTimKiem_TacGia);
            this.panel3.Location = new System.Drawing.Point(16, 63);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1119, 290);
            this.panel3.TabIndex = 5;
            // 
            // dgvTimKiem_TacGia
            // 
            this.dgvTimKiem_TacGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTimKiem_TacGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimKiem_TacGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimKiem_TacGia.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTimKiem_TacGia.Location = new System.Drawing.Point(9, 7);
            this.dgvTimKiem_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTimKiem_TacGia.Name = "dgvTimKiem_TacGia";
            this.dgvTimKiem_TacGia.RowHeadersWidth = 51;
            this.dgvTimKiem_TacGia.Size = new System.Drawing.Size(1100, 274);
            this.dgvTimKiem_TacGia.TabIndex = 86;
            this.dgvTimKiem_TacGia.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimKiem_TacGia_RowEnter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1152, 49);
            this.label1.TabIndex = 6;
            this.label1.Text = "TÁC GIẢ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btTrangChu_TacGia);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btHuy_TacGia);
            this.panel2.Controls.Add(this.btCapNhat_TacGia);
            this.panel2.Controls.Add(this.btXoa_TacGia);
            this.panel2.Controls.Add(this.btSua_TacGia);
            this.panel2.Controls.Add(this.btThem_TacGia);
            this.panel2.Controls.Add(this.txtGhiChu_TacGia);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtTenTG_TacGia);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMaTG_TacGia);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(16, 366);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1119, 268);
            this.panel2.TabIndex = 7;
            // 
            // btTrangChu_TacGia
            // 
            this.btTrangChu_TacGia.BackColor = System.Drawing.Color.DarkCyan;
            this.btTrangChu_TacGia.FlatAppearance.BorderSize = 0;
            this.btTrangChu_TacGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btTrangChu_TacGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btTrangChu_TacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTrangChu_TacGia.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTrangChu_TacGia.ForeColor = System.Drawing.Color.White;
            this.btTrangChu_TacGia.Location = new System.Drawing.Point(893, 207);
            this.btTrangChu_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btTrangChu_TacGia.Name = "btTrangChu_TacGia";
            this.btTrangChu_TacGia.Size = new System.Drawing.Size(145, 41);
            this.btTrangChu_TacGia.TabIndex = 78;
            this.btTrangChu_TacGia.Text = "TRANG CHỦ";
            this.btTrangChu_TacGia.UseVisualStyleBackColor = false;
            this.btTrangChu_TacGia.Click += new System.EventHandler(this.btTrangChu_TacGia_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimKiem_TacGia);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(592, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(480, 81);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // txtTimKiem_TacGia
            // 
            this.txtTimKiem_TacGia.Location = new System.Drawing.Point(20, 36);
            this.txtTimKiem_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem_TacGia.Name = "txtTimKiem_TacGia";
            this.txtTimKiem_TacGia.Size = new System.Drawing.Size(439, 34);
            this.txtTimKiem_TacGia.TabIndex = 86;
            this.txtTimKiem_TacGia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_TacGia_KeyUp);
            // 
            // btHuy_TacGia
            // 
            this.btHuy_TacGia.BackColor = System.Drawing.Color.DarkCyan;
            this.btHuy_TacGia.FlatAppearance.BorderSize = 0;
            this.btHuy_TacGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btHuy_TacGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btHuy_TacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHuy_TacGia.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy_TacGia.ForeColor = System.Drawing.Color.White;
            this.btHuy_TacGia.Location = new System.Drawing.Point(731, 207);
            this.btHuy_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btHuy_TacGia.Name = "btHuy_TacGia";
            this.btHuy_TacGia.Size = new System.Drawing.Size(145, 41);
            this.btHuy_TacGia.TabIndex = 77;
            this.btHuy_TacGia.Text = "HỦY";
            this.btHuy_TacGia.UseVisualStyleBackColor = false;
            this.btHuy_TacGia.Click += new System.EventHandler(this.btHuy_TacGia_Click);
            // 
            // btCapNhat_TacGia
            // 
            this.btCapNhat_TacGia.BackColor = System.Drawing.Color.DarkCyan;
            this.btCapNhat_TacGia.FlatAppearance.BorderSize = 0;
            this.btCapNhat_TacGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btCapNhat_TacGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btCapNhat_TacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCapNhat_TacGia.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat_TacGia.ForeColor = System.Drawing.Color.White;
            this.btCapNhat_TacGia.Location = new System.Drawing.Point(568, 207);
            this.btCapNhat_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btCapNhat_TacGia.Name = "btCapNhat_TacGia";
            this.btCapNhat_TacGia.Size = new System.Drawing.Size(145, 41);
            this.btCapNhat_TacGia.TabIndex = 76;
            this.btCapNhat_TacGia.Text = "CẬP NHẬT";
            this.btCapNhat_TacGia.UseVisualStyleBackColor = false;
            this.btCapNhat_TacGia.Click += new System.EventHandler(this.btCapNhat_TacGia_Click);
            // 
            // btXoa_TacGia
            // 
            this.btXoa_TacGia.BackColor = System.Drawing.Color.DarkCyan;
            this.btXoa_TacGia.FlatAppearance.BorderSize = 0;
            this.btXoa_TacGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btXoa_TacGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btXoa_TacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXoa_TacGia.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa_TacGia.ForeColor = System.Drawing.Color.White;
            this.btXoa_TacGia.Location = new System.Drawing.Point(405, 207);
            this.btXoa_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btXoa_TacGia.Name = "btXoa_TacGia";
            this.btXoa_TacGia.Size = new System.Drawing.Size(145, 41);
            this.btXoa_TacGia.TabIndex = 75;
            this.btXoa_TacGia.Text = "XÓA";
            this.btXoa_TacGia.UseVisualStyleBackColor = false;
            this.btXoa_TacGia.Click += new System.EventHandler(this.btXoa_TacGia_Click);
            // 
            // btSua_TacGia
            // 
            this.btSua_TacGia.BackColor = System.Drawing.Color.DarkCyan;
            this.btSua_TacGia.FlatAppearance.BorderSize = 0;
            this.btSua_TacGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btSua_TacGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btSua_TacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSua_TacGia.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua_TacGia.ForeColor = System.Drawing.Color.White;
            this.btSua_TacGia.Location = new System.Drawing.Point(243, 207);
            this.btSua_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btSua_TacGia.Name = "btSua_TacGia";
            this.btSua_TacGia.Size = new System.Drawing.Size(145, 41);
            this.btSua_TacGia.TabIndex = 74;
            this.btSua_TacGia.Text = "SỬA";
            this.btSua_TacGia.UseVisualStyleBackColor = false;
            this.btSua_TacGia.Click += new System.EventHandler(this.btSua_TacGia_Click);
            // 
            // btThem_TacGia
            // 
            this.btThem_TacGia.BackColor = System.Drawing.Color.DarkCyan;
            this.btThem_TacGia.FlatAppearance.BorderSize = 0;
            this.btThem_TacGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btThem_TacGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btThem_TacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThem_TacGia.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem_TacGia.ForeColor = System.Drawing.Color.White;
            this.btThem_TacGia.Location = new System.Drawing.Point(80, 207);
            this.btThem_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btThem_TacGia.Name = "btThem_TacGia";
            this.btThem_TacGia.Size = new System.Drawing.Size(145, 41);
            this.btThem_TacGia.TabIndex = 73;
            this.btThem_TacGia.Text = "THÊM";
            this.btThem_TacGia.UseVisualStyleBackColor = false;
            this.btThem_TacGia.Click += new System.EventHandler(this.btThem_TacGia_Click);
            // 
            // txtGhiChu_TacGia
            // 
            this.txtGhiChu_TacGia.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu_TacGia.Location = new System.Drawing.Point(187, 130);
            this.txtGhiChu_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu_TacGia.Name = "txtGhiChu_TacGia";
            this.txtGhiChu_TacGia.Size = new System.Drawing.Size(296, 36);
            this.txtGhiChu_TacGia.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(19, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 28);
            this.label6.TabIndex = 71;
            this.label6.Text = "Ghi chú:";
            // 
            // txtTenTG_TacGia
            // 
            this.txtTenTG_TacGia.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTG_TacGia.Location = new System.Drawing.Point(187, 80);
            this.txtTenTG_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenTG_TacGia.Name = "txtTenTG_TacGia";
            this.txtTenTG_TacGia.Size = new System.Drawing.Size(296, 36);
            this.txtTenTG_TacGia.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 28);
            this.label3.TabIndex = 59;
            this.label3.Text = "Tên tác giả:";
            // 
            // txtMaTG_TacGia
            // 
            this.txtMaTG_TacGia.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTG_TacGia.Location = new System.Drawing.Point(187, 27);
            this.txtMaTG_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTG_TacGia.Name = "txtMaTG_TacGia";
            this.txtMaTG_TacGia.Size = new System.Drawing.Size(296, 36);
            this.txtMaTG_TacGia.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 28);
            this.label2.TabIndex = 57;
            this.label2.Text = "Mã tác giả:";
            // 
            // TacGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 647);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TacGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TacGia";
            this.Load += new System.EventHandler(this.TacGia_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem_TacGia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvTimKiem_TacGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btTrangChu_TacGia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimKiem_TacGia;
        private System.Windows.Forms.Button btHuy_TacGia;
        private System.Windows.Forms.Button btCapNhat_TacGia;
        private System.Windows.Forms.Button btXoa_TacGia;
        private System.Windows.Forms.Button btSua_TacGia;
        private System.Windows.Forms.Button btThem_TacGia;
        private System.Windows.Forms.TextBox txtGhiChu_TacGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenTG_TacGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaTG_TacGia;
        private System.Windows.Forms.Label label2;
    }
}