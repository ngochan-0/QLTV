namespace QLThuVien
{
    partial class USachDaDat
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
            this.dgvUSachDaDat = new System.Windows.Forms.DataGridView();
            this.btXoaPhieuDat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUSachDaDat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUSachDaDat
            // 
            this.dgvUSachDaDat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUSachDaDat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUSachDaDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUSachDaDat.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUSachDaDat.Location = new System.Drawing.Point(16, 20);
            this.dgvUSachDaDat.Name = "dgvUSachDaDat";
            this.dgvUSachDaDat.RowTemplate.Height = 26;
            this.dgvUSachDaDat.Size = new System.Drawing.Size(830, 420);
            this.dgvUSachDaDat.TabIndex = 0;
            // 
            // btXoaPhieuDat
            // 
            this.btXoaPhieuDat.BackColor = System.Drawing.Color.DarkCyan;
            this.btXoaPhieuDat.FlatAppearance.BorderSize = 0;
            this.btXoaPhieuDat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.btXoaPhieuDat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btXoaPhieuDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btXoaPhieuDat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoaPhieuDat.ForeColor = System.Drawing.Color.White;
            this.btXoaPhieuDat.Location = new System.Drawing.Point(355, 464);
            this.btXoaPhieuDat.Name = "btXoaPhieuDat";
            this.btXoaPhieuDat.Size = new System.Drawing.Size(153, 39);
            this.btXoaPhieuDat.TabIndex = 80;
            this.btXoaPhieuDat.Text = "XÓA";
            this.btXoaPhieuDat.UseVisualStyleBackColor = false;
            this.btXoaPhieuDat.Click += new System.EventHandler(this.btXoaPhieuDat_Click);
            // 
            // USachDaDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btXoaPhieuDat);
            this.Controls.Add(this.dgvUSachDaDat);
            this.Name = "USachDaDat";
            this.Size = new System.Drawing.Size(862, 524);
            this.Load += new System.EventHandler(this.USachDaDat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUSachDaDat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUSachDaDat;
        private System.Windows.Forms.Button btXoaPhieuDat;
    }
}
