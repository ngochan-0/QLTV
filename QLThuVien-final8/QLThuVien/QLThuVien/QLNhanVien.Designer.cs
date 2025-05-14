namespace QLThuVien
{
    partial class QLNhanVien
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
            this.btDangKy = new System.Windows.Forms.Button();
            this.btXoa_QLNV = new System.Windows.Forms.Button();
            this.dgvQLNhanVien = new System.Windows.Forms.DataGridView();
            this.btDoiMK_QLNV = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btDangKy);
            this.panel1.Controls.Add(this.btXoa_QLNV);
            this.panel1.Controls.Add(this.dgvQLNhanVien);
            this.panel1.Controls.Add(this.btDoiMK_QLNV);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 539);
            this.panel1.TabIndex = 0;
            // 
            // btDangKy
            // 
            this.btDangKy.BackColor = System.Drawing.Color.DarkCyan;
            this.btDangKy.FlatAppearance.BorderSize = 0;
            this.btDangKy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btDangKy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDangKy.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangKy.ForeColor = System.Drawing.Color.White;
            this.btDangKy.Location = new System.Drawing.Point(349, 470);
            this.btDangKy.Name = "btDangKy";
            this.btDangKy.Size = new System.Drawing.Size(153, 39);
            this.btDangKy.TabIndex = 62;
            this.btDangKy.Text = "ĐĂNG KÝ";
            this.btDangKy.UseVisualStyleBackColor = false;
            this.btDangKy.Click += new System.EventHandler(this.btDangKy_Click);
            // 
            // btXoa_QLNV
            // 
            this.btXoa_QLNV.BackColor = System.Drawing.Color.DarkCyan;
            this.btXoa_QLNV.FlatAppearance.BorderSize = 0;
            this.btXoa_QLNV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btXoa_QLNV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btXoa_QLNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXoa_QLNV.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa_QLNV.ForeColor = System.Drawing.Color.White;
            this.btXoa_QLNV.Location = new System.Drawing.Point(593, 470);
            this.btXoa_QLNV.Name = "btXoa_QLNV";
            this.btXoa_QLNV.Size = new System.Drawing.Size(153, 39);
            this.btXoa_QLNV.TabIndex = 61;
            this.btXoa_QLNV.Text = "XÓA";
            this.btXoa_QLNV.UseVisualStyleBackColor = false;
            this.btXoa_QLNV.Click += new System.EventHandler(this.btXoa_QLNV_Click);
            // 
            // dgvQLNhanVien
            // 
            this.dgvQLNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQLNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQLNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQLNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQLNhanVien.Location = new System.Drawing.Point(13, 12);
            this.dgvQLNhanVien.Name = "dgvQLNhanVien";
            this.dgvQLNhanVien.RowTemplate.Height = 26;
            this.dgvQLNhanVien.Size = new System.Drawing.Size(823, 427);
            this.dgvQLNhanVien.TabIndex = 0;
            // 
            // btDoiMK_QLNV
            // 
            this.btDoiMK_QLNV.BackColor = System.Drawing.Color.DarkCyan;
            this.btDoiMK_QLNV.FlatAppearance.BorderSize = 0;
            this.btDoiMK_QLNV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btDoiMK_QLNV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btDoiMK_QLNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDoiMK_QLNV.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDoiMK_QLNV.ForeColor = System.Drawing.Color.White;
            this.btDoiMK_QLNV.Location = new System.Drawing.Point(105, 470);
            this.btDoiMK_QLNV.Name = "btDoiMK_QLNV";
            this.btDoiMK_QLNV.Size = new System.Drawing.Size(153, 39);
            this.btDoiMK_QLNV.TabIndex = 60;
            this.btDoiMK_QLNV.Text = "ĐỔI MẬT KHẨU";
            this.btDoiMK_QLNV.UseVisualStyleBackColor = false;
            this.btDoiMK_QLNV.Click += new System.EventHandler(this.btDoiMK_QLNV_Click);
            // 
            // QLNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "QLNhanVien";
            this.Size = new System.Drawing.Size(880, 565);
            this.Load += new System.EventHandler(this.QLNhanVien_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvQLNhanVien;
        private System.Windows.Forms.Button btXoa_QLNV;
        private System.Windows.Forms.Button btDoiMK_QLNV;
        private System.Windows.Forms.Button btDangKy;
    }
}
