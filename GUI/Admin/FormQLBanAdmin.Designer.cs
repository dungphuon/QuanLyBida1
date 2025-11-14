namespace QuanLyBida.GUI.Admin
{
    partial class FormQLBanAdmin
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonAdd = new Guna.UI2.WinForms.Guna2Button();
            this.gridTables = new System.Windows.Forms.DataGridView();
            this.colTenBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.comboBoxFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelFilter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTables)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
            this.labelTitle.Location = new System.Drawing.Point(26, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(344, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Quản lý hệ thống bàn chơi";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BorderRadius = 6;
            this.buttonAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonAdd.FillColor = System.Drawing.Color.FromArgb(92, 124, 250);
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(599, 19);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(260, 40);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Thêm bàn mới";
            // 
            // gridTables
            // 
            this.gridTables.AllowUserToAddRows = false;
            this.gridTables.AllowUserToDeleteRows = false;
            this.gridTables.AllowUserToResizeRows = false;
            this.gridTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTables.BackgroundColor = System.Drawing.Color.White;
            this.gridTables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTables.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridTables.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(243, 246, 253);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(243, 246, 253);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTables.ColumnHeadersHeight = 50;
            this.gridTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenBan,
            this.colLoaiBan,
            this.colGiaBan,
            this.colView,
            this.colDelete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(232, 237, 250);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTables.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTables.EnableHeadersVisualStyles = false;
            this.gridTables.GridColor = System.Drawing.Color.FromArgb(232, 237, 250);
            this.gridTables.Location = new System.Drawing.Point(32, 130);
            this.gridTables.MultiSelect = false;
            this.gridTables.Name = "gridTables";
            this.gridTables.ReadOnly = true;
            this.gridTables.RowHeadersVisible = false;
            this.gridTables.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(232, 237, 250);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
            this.gridTables.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTables.RowTemplate.Height = 44;
            this.gridTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTables.Size = new System.Drawing.Size(827, 456);
            this.gridTables.TabIndex = 2;
            // 
            // colTenBan
            // 
            this.colTenBan.HeaderText = "Tên bàn";
            this.colTenBan.MinimumWidth = 150;
            this.colTenBan.Name = "colTenBan";
            this.colTenBan.ReadOnly = true;
            // 
            // colLoaiBan
            // 
            this.colLoaiBan.HeaderText = "Loại bàn";
            this.colLoaiBan.MinimumWidth = 120;
            this.colLoaiBan.Name = "colLoaiBan";
            this.colLoaiBan.ReadOnly = true;
            // 
            // colGiaBan
            // 
            this.colGiaBan.HeaderText = "Giá bàn";
            this.colGiaBan.MinimumWidth = 100;
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // colView
            // 
            this.colView.ActiveLinkColor = System.Drawing.Color.Gold;
            this.colView.HeaderText = "Xem";
            this.colView.LinkColor = System.Drawing.Color.Gold;
            this.colView.MinimumWidth = 60;
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            this.colView.Text = "Xem";
            this.colView.UseColumnTextForLinkValue = true;
            this.colView.VisitedLinkColor = System.Drawing.Color.Gold;
            // 
            // colDelete
            // 
            this.colDelete.ActiveLinkColor = System.Drawing.Color.IndianRed;
            this.colDelete.HeaderText = "Xóa";
            this.colDelete.LinkColor = System.Drawing.Color.IndianRed;
            this.colDelete.MinimumWidth = 60;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "Xóa";
            this.colDelete.UseColumnTextForLinkValue = true;
            this.colDelete.VisitedLinkColor = System.Drawing.Color.IndianRed;
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxFilter.BorderRadius = 6;
            this.comboBoxFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.FocusedColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.comboBoxFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.comboBoxFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxFilter.ForeColor = System.Drawing.Color.FromArgb(68, 88, 112);
            this.comboBoxFilter.ItemHeight = 30;
            this.comboBoxFilter.Items.AddRange(new object[] {
            "Tất cả",
            "Bàn thường",
            "Bàn VIP",
            "Bàn đôi"});
            this.comboBoxFilter.Location = new System.Drawing.Point(32, 85);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(200, 36);
            this.comboBoxFilter.TabIndex = 3;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilter.ForeColor = System.Drawing.Color.FromArgb(45, 53, 69);
            this.labelFilter.Location = new System.Drawing.Point(28, 60);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(90, 23);
            this.labelFilter.TabIndex = 4;
            this.labelFilter.Text = "Lọc theo loại:";
            // 
            // FormQLBanAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(235, 242, 251);
            this.ClientSize = new System.Drawing.Size(891, 618);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.gridTables);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLBanAdmin";
            this.Text = "FormQLBanAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.gridTables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Button buttonAdd;
        private System.Windows.Forms.DataGridView gridTables;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewLinkColumn colView;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxFilter;
        private System.Windows.Forms.Label labelFilter;
    }
}