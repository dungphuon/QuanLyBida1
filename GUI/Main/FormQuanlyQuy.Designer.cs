namespace QuanLyBida.GUI.Main
{
    partial class FormQuanlyQuy
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridThuChi = new System.Windows.Forms.DataGridView();
			this.colMaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLoaiThuChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNguoiNopNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridThuChi)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridThuChi
			// 
			this.dataGridThuChi.AllowUserToAddRows = false;
			this.dataGridThuChi.AllowUserToDeleteRows = false;
			this.dataGridThuChi.AllowUserToResizeRows = false;
			this.dataGridThuChi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			|	System.Windows.Forms.AnchorStyles.Left) 
			|	System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridThuChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridThuChi.BackgroundColor = System.Drawing.Color.White;
			this.dataGridThuChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridThuChi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dataGridThuChi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(243, 246, 253);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(243, 246, 253);
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridThuChi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridThuChi.ColumnHeadersHeight = 50;
			this.dataGridThuChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridThuChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.colMaPhieu,
			this.colThoiGian,
			this.colLoaiThuChi,
			this.colNguoiNopNhan,
			this.colGiaTri});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(232, 237, 250);
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridThuChi.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridThuChi.EnableHeadersVisualStyles = false;
			this.dataGridThuChi.GridColor = System.Drawing.Color.FromArgb(232, 237, 250);
			this.dataGridThuChi.Location = new System.Drawing.Point(24, 24);
			this.dataGridThuChi.MultiSelect = false;
			this.dataGridThuChi.Name = "dataGridThuChi";
			this.dataGridThuChi.ReadOnly = true;
			this.dataGridThuChi.RowHeadersVisible = false;
			this.dataGridThuChi.RowHeadersWidth = 51;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(232, 237, 250);
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
			this.dataGridThuChi.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridThuChi.RowTemplate.Height = 44;
			this.dataGridThuChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridThuChi.Size = new System.Drawing.Size(752, 402);
			this.dataGridThuChi.TabIndex = 0;
			// 
			// colMaPhieu
			// 
			this.colMaPhieu.HeaderText = "Mã phiếu";
			this.colMaPhieu.MinimumWidth = 120;
			this.colMaPhieu.Name = "colMaPhieu";
			this.colMaPhieu.ReadOnly = true;
			// 
			// colThoiGian
			// 
			this.colThoiGian.HeaderText = "Thời gian";
			this.colThoiGian.MinimumWidth = 140;
			this.colThoiGian.Name = "colThoiGian";
			this.colThoiGian.ReadOnly = true;
			// 
			// colLoaiThuChi
			// 
			this.colLoaiThuChi.HeaderText = "Loại thu chi";
			this.colLoaiThuChi.MinimumWidth = 180;
			this.colLoaiThuChi.Name = "colLoaiThuChi";
			this.colLoaiThuChi.ReadOnly = true;
			// 
			// colNguoiNopNhan
			// 
			this.colNguoiNopNhan.HeaderText = "Người nộp/nhận";
			this.colNguoiNopNhan.MinimumWidth = 160;
			this.colNguoiNopNhan.Name = "colNguoiNopNhan";
			this.colNguoiNopNhan.ReadOnly = true;
			// 
			// colGiaTri
			// 
			this.colGiaTri.HeaderText = "Giá trị";
			this.colGiaTri.MinimumWidth = 100;
			this.colGiaTri.Name = "colGiaTri";
			this.colGiaTri.ReadOnly = true;
			this.colGiaTri.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // FormQuanlyQuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridThuChi);
            this.Name = "FormQuanlyQuy";
			this.Text = "Quản Lý Quỹ";
			((System.ComponentModel.ISupportInitialize)(this.dataGridThuChi)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.DataGridView dataGridThuChi;
		private System.Windows.Forms.DataGridViewTextBoxColumn colMaPhieu;
		private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGian;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiThuChi;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNguoiNopNhan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTri;
    }
}