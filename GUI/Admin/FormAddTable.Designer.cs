namespace QuanLyBida.GUI.Admin
{
    partial class FormAddTable
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
            this.comboBoxTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.textBoxGiaBan = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelGiaBan = new System.Windows.Forms.Label();
            this.comboBoxLoaiBan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelLoaiBan = new System.Windows.Forms.Label();
            this.textBoxTenBan = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelTenBan = new System.Windows.Forms.Label();
            this.buttonCancel = new Guna.UI2.WinForms.Guna2Button();
            this.buttonSave = new Guna.UI2.WinForms.Guna2Button();
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
            this.labelTitle.Size = new System.Drawing.Size(201, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Thêm bàn mới";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderRadius = 10;
            this.panelMain.Controls.Add(this.comboBoxTrangThai);
            this.panelMain.Controls.Add(this.labelTrangThai);
            this.panelMain.Controls.Add(this.textBoxGiaBan);
            this.panelMain.Controls.Add(this.labelGiaBan);
            this.panelMain.Controls.Add(this.comboBoxLoaiBan);
            this.panelMain.Controls.Add(this.labelLoaiBan);
            this.panelMain.Controls.Add(this.textBoxTenBan);
            this.panelMain.Controls.Add(this.labelTenBan);
            this.panelMain.Location = new System.Drawing.Point(32, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(827, 400);
            this.panelMain.TabIndex = 1;
            // 
            // comboBoxTrangThai
            // 
            this.comboBoxTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxTrangThai.BorderRadius = 6;
            this.comboBoxTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxTrangThai.ItemHeight = 30;
            this.comboBoxTrangThai.Items.AddRange(new object[] {
            "Đang hoạt động",
            "Trống",
            "Bảo trì"});
            this.comboBoxTrangThai.Location = new System.Drawing.Point(180, 240);
            this.comboBoxTrangThai.Name = "comboBoxTrangThai";
            this.comboBoxTrangThai.Size = new System.Drawing.Size(500, 36);
            this.comboBoxTrangThai.TabIndex = 7;
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.AutoSize = true;
            this.labelTrangThai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTrangThai.Location = new System.Drawing.Point(30, 245);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(100, 25);
            this.labelTrangThai.TabIndex = 6;
            this.labelTrangThai.Text = "Trạng thái:";
            // 
            // textBoxGiaBan
            // 
            this.textBoxGiaBan.BorderRadius = 6;
            this.textBoxGiaBan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxGiaBan.DefaultText = "";
            this.textBoxGiaBan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxGiaBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxGiaBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxGiaBan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxGiaBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxGiaBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxGiaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.textBoxGiaBan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxGiaBan.Location = new System.Drawing.Point(180, 180);
            this.textBoxGiaBan.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxGiaBan.Name = "textBoxGiaBan";
            this.textBoxGiaBan.PlaceholderText = "Nhập giá bàn";
            this.textBoxGiaBan.SelectedText = "";
            this.textBoxGiaBan.Size = new System.Drawing.Size(500, 36);
            this.textBoxGiaBan.TabIndex = 5;
            // 
            // labelGiaBan
            // 
            this.labelGiaBan.AutoSize = true;
            this.labelGiaBan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGiaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelGiaBan.Location = new System.Drawing.Point(30, 185);
            this.labelGiaBan.Name = "labelGiaBan";
            this.labelGiaBan.Size = new System.Drawing.Size(81, 25);
            this.labelGiaBan.TabIndex = 4;
            this.labelGiaBan.Text = "Giá bàn:";
            // 
            // comboBoxLoaiBan
            // 
            this.comboBoxLoaiBan.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxLoaiBan.BorderRadius = 6;
            this.comboBoxLoaiBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxLoaiBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoaiBan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxLoaiBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxLoaiBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxLoaiBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxLoaiBan.ItemHeight = 30;
            //this.comboBoxLoaiBan.Items.AddRange(new object[] {
            //"Bàn thường",
            //"Bàn VIP",
            //"Bàn đôi"});
            this.comboBoxLoaiBan.Location = new System.Drawing.Point(180, 120);
            this.comboBoxLoaiBan.Name = "comboBoxLoaiBan";
            this.comboBoxLoaiBan.Size = new System.Drawing.Size(500, 36);
            this.comboBoxLoaiBan.TabIndex = 3;
            // 
            // labelLoaiBan
            // 
            this.labelLoaiBan.AutoSize = true;
            this.labelLoaiBan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoaiBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelLoaiBan.Location = new System.Drawing.Point(30, 125);
            this.labelLoaiBan.Name = "labelLoaiBan";
            this.labelLoaiBan.Size = new System.Drawing.Size(88, 25);
            this.labelLoaiBan.TabIndex = 2;
            this.labelLoaiBan.Text = "Loại bàn:";
            // 
            // textBoxTenBan
            // 
            this.textBoxTenBan.BorderRadius = 6;
            this.textBoxTenBan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTenBan.DefaultText = "";
            this.textBoxTenBan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxTenBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxTenBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxTenBan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxTenBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxTenBan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxTenBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.textBoxTenBan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxTenBan.Location = new System.Drawing.Point(180, 60);
            this.textBoxTenBan.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTenBan.Name = "textBoxTenBan";
            this.textBoxTenBan.PlaceholderText = "Nhập tên bàn";
            this.textBoxTenBan.SelectedText = "";
            this.textBoxTenBan.Size = new System.Drawing.Size(500, 36);
            this.textBoxTenBan.TabIndex = 1;
            // 
            // labelTenBan
            // 
            this.labelTenBan.AutoSize = true;
            this.labelTenBan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTenBan.Location = new System.Drawing.Point(30, 65);
            this.labelTenBan.Name = "labelTenBan";
            this.labelTenBan.Size = new System.Drawing.Size(82, 25);
            this.labelTenBan.TabIndex = 0;
            this.labelTenBan.Text = "Tên bàn:";
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
            this.buttonCancel.Location = new System.Drawing.Point(699, 495);
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
            this.buttonSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(124)))), ((int)(((byte)(250)))));
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(533, 495);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(160, 40);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Lưu";
            // 
            // FormAddTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(891, 618);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAddTable";
            this.Text = "Thêm bàn mới";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private System.Windows.Forms.Label labelTenBan;
        private Guna.UI2.WinForms.Guna2TextBox textBoxTenBan;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxLoaiBan;
        private System.Windows.Forms.Label labelLoaiBan;
        private Guna.UI2.WinForms.Guna2TextBox textBoxGiaBan;
        private System.Windows.Forms.Label labelGiaBan;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxTrangThai;
        private System.Windows.Forms.Label labelTrangThai;
        private Guna.UI2.WinForms.Guna2Button buttonSave;
        private Guna.UI2.WinForms.Guna2Button buttonCancel;
    }
}