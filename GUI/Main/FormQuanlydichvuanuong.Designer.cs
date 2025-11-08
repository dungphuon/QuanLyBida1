namespace QuanLyBida.GUI.Main
{
    partial class FormQuanlydichvuanuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuanlydichvuanuong));
            this.buttonNhapHang = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridViewHangHoa = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2TextBoxTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelTimKiem = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridViewHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNhapHang
            // 
            this.buttonNhapHang.BorderRadius = 6;
            this.buttonNhapHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonNhapHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonNhapHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonNhapHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonNhapHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.buttonNhapHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNhapHang.ForeColor = System.Drawing.Color.White;
            this.buttonNhapHang.Location = new System.Drawing.Point(649, 120);
            this.buttonNhapHang.Name = "buttonNhapHang";
            this.buttonNhapHang.Size = new System.Drawing.Size(150, 40);
            this.buttonNhapHang.TabIndex = 0;
            this.buttonNhapHang.Text = "Nhập Hàng";
            this.buttonNhapHang.Click += new System.EventHandler(this.buttonNhapHang_Click);
            // 
            // guna2DataGridViewHangHoa
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridViewHangHoa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridViewHangHoa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2DataGridViewHangHoa.BackgroundColor = System.Drawing.Color.White;
            this.guna2DataGridViewHangHoa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guna2DataGridViewHangHoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridViewHangHoa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridViewHangHoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridViewHangHoa.ColumnHeadersHeight = 50;
            this.guna2DataGridViewHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridViewHangHoa.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridViewHangHoa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            this.guna2DataGridViewHangHoa.Location = new System.Drawing.Point(26, 187);
            this.guna2DataGridViewHangHoa.MultiSelect = false;
            this.guna2DataGridViewHangHoa.Name = "guna2DataGridViewHangHoa";
            this.guna2DataGridViewHangHoa.ReadOnly = true;
            this.guna2DataGridViewHangHoa.RowHeadersVisible = false;
            this.guna2DataGridViewHangHoa.RowHeadersWidth = 51;
            this.guna2DataGridViewHangHoa.RowTemplate.Height = 44;
            this.guna2DataGridViewHangHoa.Size = new System.Drawing.Size(827, 527);
            this.guna2DataGridViewHangHoa.TabIndex = 1;
            this.guna2DataGridViewHangHoa.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridViewHangHoa.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridViewHangHoa.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridViewHangHoa.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridViewHangHoa.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridViewHangHoa.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridViewHangHoa.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            this.guna2DataGridViewHangHoa.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridViewHangHoa.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.guna2DataGridViewHangHoa.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridViewHangHoa.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridViewHangHoa.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.guna2DataGridViewHangHoa.ThemeStyle.HeaderStyle.Height = 50;
            this.guna2DataGridViewHangHoa.ThemeStyle.ReadOnly = true;
            this.guna2DataGridViewHangHoa.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridViewHangHoa.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridViewHangHoa.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridViewHangHoa.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridViewHangHoa.ThemeStyle.RowsStyle.Height = 44;
            this.guna2DataGridViewHangHoa.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridViewHangHoa.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridViewHangHoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridViewHangHoa_CellContentClick);
            // 
            // guna2TextBoxTimKiem
            // 
            this.guna2TextBoxTimKiem.BorderRadius = 10;
            this.guna2TextBoxTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxTimKiem.DefaultText = "";
            this.guna2TextBoxTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxTimKiem.Location = new System.Drawing.Point(191, 120);
            this.guna2TextBoxTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBoxTimKiem.Name = "guna2TextBoxTimKiem";
            this.guna2TextBoxTimKiem.PlaceholderText = "Tìm kiếm loại hàng hóa...";
            this.guna2TextBoxTimKiem.SelectedText = "";
            this.guna2TextBoxTimKiem.Size = new System.Drawing.Size(239, 48);
            this.guna2TextBoxTimKiem.TabIndex = 2;
            this.guna2TextBoxTimKiem.TextChanged += new System.EventHandler(this.guna2TextBoxTimKiem_TextChanged);
            // 
            // labelTimKiem
            // 
            this.labelTimKiem.AutoSize = true;
            this.labelTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTimKiem.Location = new System.Drawing.Point(46, 131);
            this.labelTimKiem.Name = "labelTimKiem";
            this.labelTimKiem.Size = new System.Drawing.Size(123, 23);
            this.labelTimKiem.TabIndex = 3;
            this.labelTimKiem.Text = "Loại hàng hóa:";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(447, 123);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(40, 40);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(41, 49);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(290, 38);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Dịch Vụ Đồ Ăn Uống";
            // 
            // FormQuanlydichvuanuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(891, 751);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.labelTimKiem);
            this.Controls.Add(this.guna2TextBoxTimKiem);
            this.Controls.Add(this.guna2DataGridViewHangHoa);
            this.Controls.Add(this.buttonNhapHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuanlydichvuanuong";
            this.Text = "FormQuanlydichvuanuong";
            this.Load += new System.EventHandler(this.FormQuanlydichvuanuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridViewHangHoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button buttonNhapHang;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridViewHangHoa;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxTimKiem;
        private System.Windows.Forms.Label labelTimKiem;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label labelTitle;
    }
}
