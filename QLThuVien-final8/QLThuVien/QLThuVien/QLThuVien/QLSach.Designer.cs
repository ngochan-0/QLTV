namespace QLThuVien
{
    partial class QLSach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem_QLSach = new System.Windows.Forms.TextBox();
            this.rbNXB = new System.Windows.Forms.RadioButton();
            this.rbTacGia = new System.Windows.Forms.RadioButton();
            this.rbLoaiSach = new System.Windows.Forms.RadioButton();
            this.rbTenSach = new System.Windows.Forms.RadioButton();
            this.btNXB = new System.Windows.Forms.Button();
            this.btTacGia = new System.Windows.Forms.Button();
            this.btLoaiSach = new System.Windows.Forms.Button();
            this.btSach = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTimSach = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btNXB);
            this.panel1.Controls.Add(this.btTacGia);
            this.panel1.Controls.Add(this.btLoaiSach);
            this.panel1.Controls.Add(this.btSach);
            this.panel1.Location = new System.Drawing.Point(16, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 285);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimKiem_QLSach);
            this.groupBox1.Controls.Add(this.rbNXB);
            this.groupBox1.Controls.Add(this.rbTacGia);
            this.groupBox1.Controls.Add(this.rbLoaiSach);
            this.groupBox1.Controls.Add(this.rbTenSach);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(52, 121);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1029, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txtTimKiem_QLSach
            // 
            this.txtTimKiem_QLSach.Location = new System.Drawing.Point(243, 92);
            this.txtTimKiem_QLSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem_QLSach.Name = "txtTimKiem_QLSach";
            this.txtTimKiem_QLSach.Size = new System.Drawing.Size(544, 34);
            this.txtTimKiem_QLSach.TabIndex = 4;
            this.txtTimKiem_QLSach.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_QLSach_KeyUp);
            // 
            // rbNXB
            // 
            this.rbNXB.AutoSize = true;
            this.rbNXB.Location = new System.Drawing.Point(820, 41);
            this.rbNXB.Margin = new System.Windows.Forms.Padding(4);
            this.rbNXB.Name = "rbNXB";
            this.rbNXB.Size = new System.Drawing.Size(173, 33);
            this.rbNXB.TabIndex = 3;
            this.rbNXB.TabStop = true;
            this.rbNXB.Text = "Nhà xuất bản";
            this.rbNXB.UseVisualStyleBackColor = true;
            // 
            // rbTacGia
            // 
            this.rbTacGia.AutoSize = true;
            this.rbTacGia.Location = new System.Drawing.Point(579, 41);
            this.rbTacGia.Margin = new System.Windows.Forms.Padding(4);
            this.rbTacGia.Name = "rbTacGia";
            this.rbTacGia.Size = new System.Drawing.Size(114, 33);
            this.rbTacGia.TabIndex = 2;
            this.rbTacGia.TabStop = true;
            this.rbTacGia.Text = "Tác giả";
            this.rbTacGia.UseVisualStyleBackColor = true;
            // 
            // rbLoaiSach
            // 
            this.rbLoaiSach.AutoSize = true;
            this.rbLoaiSach.Location = new System.Drawing.Point(316, 41);
            this.rbLoaiSach.Margin = new System.Windows.Forms.Padding(4);
            this.rbLoaiSach.Name = "rbLoaiSach";
            this.rbLoaiSach.Size = new System.Drawing.Size(136, 33);
            this.rbLoaiSach.TabIndex = 1;
            this.rbLoaiSach.TabStop = true;
            this.rbLoaiSach.Text = "Loại sách";
            this.rbLoaiSach.UseVisualStyleBackColor = true;
            // 
            // rbTenSach
            // 
            this.rbTenSach.AutoSize = true;
            this.rbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTenSach.Location = new System.Drawing.Point(57, 41);
            this.rbTenSach.Margin = new System.Windows.Forms.Padding(4);
            this.rbTenSach.Name = "rbTenSach";
            this.rbTenSach.Size = new System.Drawing.Size(133, 33);
            this.rbTenSach.TabIndex = 0;
            this.rbTenSach.TabStop = true;
            this.rbTenSach.Text = "Tên sách";
            this.rbTenSach.UseVisualStyleBackColor = true;
            // 
            // btNXB
            // 
            this.btNXB.BackColor = System.Drawing.Color.DarkCyan;
            this.btNXB.FlatAppearance.BorderSize = 0;
            this.btNXB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btNXB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btNXB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNXB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNXB.ForeColor = System.Drawing.Color.White;
            this.btNXB.Location = new System.Drawing.Point(900, 30);
            this.btNXB.Margin = new System.Windows.Forms.Padding(4);
            this.btNXB.Name = "btNXB";
            this.btNXB.Size = new System.Drawing.Size(144, 58);
            this.btNXB.TabIndex = 3;
            this.btNXB.Text = "NXB";
            this.btNXB.UseVisualStyleBackColor = false;
            this.btNXB.Click += new System.EventHandler(this.btNXB_Click);
            // 
            // btTacGia
            // 
            this.btTacGia.BackColor = System.Drawing.Color.DarkCyan;
            this.btTacGia.FlatAppearance.BorderSize = 0;
            this.btTacGia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btTacGia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btTacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTacGia.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTacGia.ForeColor = System.Drawing.Color.White;
            this.btTacGia.Location = new System.Drawing.Point(625, 30);
            this.btTacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btTacGia.Name = "btTacGia";
            this.btTacGia.Size = new System.Drawing.Size(144, 58);
            this.btTacGia.TabIndex = 2;
            this.btTacGia.Text = "TÁC GIẢ";
            this.btTacGia.UseVisualStyleBackColor = false;
            this.btTacGia.Click += new System.EventHandler(this.btTacGia_Click);
            // 
            // btLoaiSach
            // 
            this.btLoaiSach.BackColor = System.Drawing.Color.DarkCyan;
            this.btLoaiSach.FlatAppearance.BorderSize = 0;
            this.btLoaiSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btLoaiSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btLoaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLoaiSach.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLoaiSach.ForeColor = System.Drawing.Color.White;
            this.btLoaiSach.Location = new System.Drawing.Point(349, 30);
            this.btLoaiSach.Margin = new System.Windows.Forms.Padding(4);
            this.btLoaiSach.Name = "btLoaiSach";
            this.btLoaiSach.Size = new System.Drawing.Size(144, 58);
            this.btLoaiSach.TabIndex = 1;
            this.btLoaiSach.Text = "LOẠI SÁCH";
            this.btLoaiSach.UseVisualStyleBackColor = false;
            this.btLoaiSach.Click += new System.EventHandler(this.btLoaiSach_Click);
            // 
            // btSach
            // 
            this.btSach.BackColor = System.Drawing.Color.DarkCyan;
            this.btSach.FlatAppearance.BorderSize = 0;
            this.btSach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btSach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSach.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSach.ForeColor = System.Drawing.Color.White;
            this.btSach.Location = new System.Drawing.Point(89, 30);
            this.btSach.Margin = new System.Windows.Forms.Padding(4);
            this.btSach.Name = "btSach";
            this.btSach.Size = new System.Drawing.Size(144, 58);
            this.btSach.TabIndex = 0;
            this.btSach.Text = "SÁCH";
            this.btSach.UseVisualStyleBackColor = false;
            this.btSach.Click += new System.EventHandler(this.btSach_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvTimSach);
            this.panel2.Location = new System.Drawing.Point(16, 321);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1135, 360);
            this.panel2.TabIndex = 2;
            // 
            // dgvTimSach
            // 
            this.dgvTimSach.AllowUserToAddRows = false;
            this.dgvTimSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTimSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTimSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTimSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTimSach.Location = new System.Drawing.Point(27, 20);
            this.dgvTimSach.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTimSach.Name = "dgvTimSach";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTimSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTimSach.RowHeadersWidth = 51;
            this.dgvTimSach.Size = new System.Drawing.Size(1081, 320);
            this.dgvTimSach.TabIndex = 0;
            // 
            // QLSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QLSach";
            this.Size = new System.Drawing.Size(1173, 695);
            this.Load += new System.EventHandler(this.QLSach_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btNXB;
        private System.Windows.Forms.Button btTacGia;
        private System.Windows.Forms.Button btLoaiSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimKiem_QLSach;
        private System.Windows.Forms.RadioButton rbNXB;
        private System.Windows.Forms.RadioButton rbTacGia;
        private System.Windows.Forms.RadioButton rbLoaiSach;
        private System.Windows.Forms.RadioButton rbTenSach;
        private System.Windows.Forms.DataGridView dgvTimSach;
    }
}
