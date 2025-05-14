namespace QLThuVien
{
    partial class UTimKiemSach
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvUTimSach = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUTimKiem = new System.Windows.Forms.TextBox();
            this.rbUNXB = new System.Windows.Forms.RadioButton();
            this.rbUTacGia = new System.Windows.Forms.RadioButton();
            this.rbULoaiSach = new System.Windows.Forms.RadioButton();
            this.rbUTenSach = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUTimSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvUTimSach);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(13, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 496);
            this.panel1.TabIndex = 2;
            // 
            // dgvUTimSach
            // 
            this.dgvUTimSach.AllowUserToAddRows = false;
            this.dgvUTimSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUTimSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUTimSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUTimSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUTimSach.Location = new System.Drawing.Point(22, 164);
            this.dgvUTimSach.Name = "dgvUTimSach";
            this.dgvUTimSach.RowTemplate.Height = 26;
            this.dgvUTimSach.Size = new System.Drawing.Size(793, 315);
            this.dgvUTimSach.TabIndex = 5;
            this.dgvUTimSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUTimSach_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUTimKiem);
            this.groupBox1.Controls.Add(this.rbUNXB);
            this.groupBox1.Controls.Add(this.rbUTacGia);
            this.groupBox1.Controls.Add(this.rbULoaiSach);
            this.groupBox1.Controls.Add(this.rbUTenSach);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 112);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txtUTimKiem
            // 
            this.txtUTimKiem.Location = new System.Drawing.Point(182, 75);
            this.txtUTimKiem.Name = "txtUTimKiem";
            this.txtUTimKiem.Size = new System.Drawing.Size(409, 26);
            this.txtUTimKiem.TabIndex = 4;
            this.txtUTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUTimKiem_KeyUp);
            // 
            // rbUNXB
            // 
            this.rbUNXB.AutoSize = true;
            this.rbUNXB.Location = new System.Drawing.Point(615, 33);
            this.rbUNXB.Name = "rbUNXB";
            this.rbUNXB.Size = new System.Drawing.Size(121, 24);
            this.rbUNXB.TabIndex = 3;
            this.rbUNXB.TabStop = true;
            this.rbUNXB.Text = "Nhà xuất bản";
            this.rbUNXB.UseVisualStyleBackColor = true;
            // 
            // rbUTacGia
            // 
            this.rbUTacGia.AutoSize = true;
            this.rbUTacGia.Location = new System.Drawing.Point(434, 33);
            this.rbUTacGia.Name = "rbUTacGia";
            this.rbUTacGia.Size = new System.Drawing.Size(78, 24);
            this.rbUTacGia.TabIndex = 2;
            this.rbUTacGia.TabStop = true;
            this.rbUTacGia.Text = "Tác giả";
            this.rbUTacGia.UseVisualStyleBackColor = true;
            // 
            // rbULoaiSach
            // 
            this.rbULoaiSach.AutoSize = true;
            this.rbULoaiSach.Location = new System.Drawing.Point(237, 33);
            this.rbULoaiSach.Name = "rbULoaiSach";
            this.rbULoaiSach.Size = new System.Drawing.Size(95, 24);
            this.rbULoaiSach.TabIndex = 1;
            this.rbULoaiSach.TabStop = true;
            this.rbULoaiSach.Text = "Loại sách";
            this.rbULoaiSach.UseVisualStyleBackColor = true;
            // 
            // rbUTenSach
            // 
            this.rbUTenSach.AutoSize = true;
            this.rbUTenSach.Location = new System.Drawing.Point(43, 33);
            this.rbUTenSach.Name = "rbUTenSach";
            this.rbUTenSach.Size = new System.Drawing.Size(92, 24);
            this.rbUTenSach.TabIndex = 0;
            this.rbUTenSach.TabStop = true;
            this.rbUTenSach.Text = "Tên sách";
            this.rbUTenSach.UseVisualStyleBackColor = true;
            // 
            // UTimKiemSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UTimKiemSach";
            this.Size = new System.Drawing.Size(864, 526);
            this.Load += new System.EventHandler(this.UTimKiemSach_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUTimSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUTimKiem;
        private System.Windows.Forms.RadioButton rbUNXB;
        private System.Windows.Forms.RadioButton rbUTacGia;
        private System.Windows.Forms.RadioButton rbULoaiSach;
        private System.Windows.Forms.RadioButton rbUTenSach;
        private System.Windows.Forms.DataGridView dgvUTimSach;
    }
}
