namespace QuanLyBida.GUI.Admin
{
    partial class FormEditProduct
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.textBoxSoLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.textBoxGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelGia = new System.Windows.Forms.Label();
            this.comboBoxLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelLoai = new System.Windows.Forms.Label();
            this.textBoxTenHang = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelTenHang = new System.Windows.Forms.Label();
            this.buttonCancel = new Guna.UI2.WinForms.Guna2Button();
            this.buttonSave = new Guna.UI2.WinForms.Guna2Button();
            this.buttonEdit = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTitle.Location = new System.Drawing.Point(26, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(267, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Thông tin hàng hóa";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderRadius = 10;
            this.panelMain.Controls.Add(this.textBoxSoLuong);
            this.panelMain.Controls.Add(this.labelSoLuong);
            this.panelMain.Controls.Add(this.textBoxGia);
            this.panelMain.Controls.Add(this.labelGia);
            this.panelMain.Controls.Add(this.comboBoxLoai);
            this.panelMain.Controls.Add(this.labelLoai);
            this.panelMain.Controls.Add(this.textBoxTenHang);
            this.panelMain.Controls.Add(this.labelTenHang);
            this.panelMain.Location = new System.Drawing.Point(32, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(827, 300);
            this.panelMain.TabIndex = 1;
            // 
            // textBoxSoLuong
            // 
            this.textBoxSoLuong.BorderRadius = 6;
            this.textBoxSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSoLuong.DefaultText = "";
            this.textBoxSoLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxSoLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxSoLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxSoLuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxSoLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.textBoxSoLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxSoLuong.Location = new System.Drawing.Point(242, 220);
            this.textBoxSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSoLuong.Name = "textBoxSoLuong";
            this.textBoxSoLuong.PlaceholderText = "Nhập số lượng trong kho";
            this.textBoxSoLuong.SelectedText = "";
            this.textBoxSoLuong.Size = new System.Drawing.Size(500, 36);
            this.textBoxSoLuong.TabIndex = 5;
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelSoLuong.Location = new System.Drawing.Point(30, 220);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(84, 25);
            this.labelSoLuong.TabIndex = 4;
            this.labelSoLuong.Text = "Tồn kho:";
            // 
            // textBoxGia
            // 
            this.textBoxGia.BorderRadius = 6;
            this.textBoxGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxGia.DefaultText = "";
            this.textBoxGia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxGia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.textBoxGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxGia.Location = new System.Drawing.Point(242, 158);
            this.textBoxGia.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxGia.Name = "textBoxGia";
            this.textBoxGia.PlaceholderText = "Nhập giá bán (VNĐ)";
            this.textBoxGia.SelectedText = "";
            this.textBoxGia.Size = new System.Drawing.Size(500, 36);
            this.textBoxGia.TabIndex = 3;
            // 
            // labelGia
            // 
            this.labelGia.AutoSize = true;
            this.labelGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelGia.Location = new System.Drawing.Point(30, 158);
            this.labelGia.Name = "labelGia";
            this.labelGia.Size = new System.Drawing.Size(72, 25);
            this.labelGia.TabIndex = 2;
            this.labelGia.Text = "Giá (₫):";
            // 
            // comboBoxLoai
            // 
            this.comboBoxLoai.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxLoai.BorderRadius = 6;
            this.comboBoxLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxLoai.ItemHeight = 30;
            this.comboBoxLoai.Items.AddRange(new object[] {
            "Đồ ăn",
            "Đồ uống",
            "Phụ kiện"});
            this.comboBoxLoai.Location = new System.Drawing.Point(242, 94);
            this.comboBoxLoai.Name = "comboBoxLoai";
            this.comboBoxLoai.Size = new System.Drawing.Size(500, 36);
            this.comboBoxLoai.TabIndex = 1;
            this.comboBoxLoai.SelectedIndexChanged += new System.EventHandler(this.comboBoxLoai_SelectedIndexChanged);
            // 
            // labelLoai
            // 
            this.labelLoai.AutoSize = true;
            this.labelLoai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelLoai.Location = new System.Drawing.Point(33, 97);
            this.labelLoai.Name = "labelLoai";
            this.labelLoai.Size = new System.Drawing.Size(51, 25);
            this.labelLoai.TabIndex = 0;
            this.labelLoai.Text = "Loại:";
            // 
            // textBoxTenHang
            // 
            this.textBoxTenHang.BorderRadius = 6;
            this.textBoxTenHang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTenHang.DefaultText = "";
            this.textBoxTenHang.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxTenHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxTenHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxTenHang.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxTenHang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxTenHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxTenHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.textBoxTenHang.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxTenHang.Location = new System.Drawing.Point(242, 34);
            this.textBoxTenHang.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTenHang.Name = "textBoxTenHang";
            this.textBoxTenHang.PlaceholderText = "Nhập tên hàng hóa";
            this.textBoxTenHang.SelectedText = "";
            this.textBoxTenHang.Size = new System.Drawing.Size(500, 36);
            this.textBoxTenHang.TabIndex = 1;
            // 
            // labelTenHang
            // 
            this.labelTenHang.AutoSize = true;
            this.labelTenHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTenHang.Location = new System.Drawing.Point(30, 34);
            this.labelTenHang.Name = "labelTenHang";
            this.labelTenHang.Size = new System.Drawing.Size(93, 25);
            this.labelTenHang.TabIndex = 0;
            this.labelTenHang.Text = "Tên hàng:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BorderRadius = 6;
            this.buttonCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(699, 440);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(160, 40);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Hủy";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BorderRadius = 6;
            this.buttonSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(213)))), ((int)(((byte)(115)))));
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(533, 440);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(160, 40);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Lưu";
            this.buttonSave.Visible = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.BorderRadius = 6;
            this.buttonEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(533, 440);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(160, 40);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Sửa";
            // 
            // FormEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(891, 570);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelTitle);
            this.MinimumSize = new System.Drawing.Size(891, 570);
            this.Name = "FormEditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin hàng hóa";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label labelTenHang;
        private Guna.UI2.WinForms.Guna2TextBox textBoxTenHang;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxLoai;
        private System.Windows.Forms.Label labelLoai;
        private Guna.UI2.WinForms.Guna2TextBox textBoxGia;
        private System.Windows.Forms.Label labelGia;
        private Guna.UI2.WinForms.Guna2TextBox textBoxSoLuong;
        private System.Windows.Forms.Label labelSoLuong;
        private Guna.UI2.WinForms.Guna2Button buttonSave;
        private Guna.UI2.WinForms.Guna2Button buttonCancel;
        private Guna.UI2.WinForms.Guna2Button buttonEdit;
    }
}
