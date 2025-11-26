namespace GUI.Admin
{
    partial class FormBaotrisuco
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
            this.panelAddIncident = new Guna.UI2.WinForms.Guna2Panel();
            this.buttonAddIncident = new Guna.UI2.WinForms.Guna2Button();
            this.comboBoxStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.comboBoxType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelDeviceTable = new System.Windows.Forms.Label();
            this.comboBoxTable = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelTable = new System.Windows.Forms.Label();
            this.textBoxDevice = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelDevice = new System.Windows.Forms.Label();
            this.labelAddIncidentTitle = new System.Windows.Forms.Label();
            this.panelIncidentList = new Guna.UI2.WinForms.Guna2Panel();
            this.gridIncidents = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeviceTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.labelIncidentListTitle = new System.Windows.Forms.Label();
            this.panelAddIncident.SuspendLayout();
            this.panelIncidentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIncidents)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelTitle.Location = new System.Drawing.Point(26, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(220, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Bảo Trì & Sự Cố";
            // 
            // panelAddIncident
            // 
            this.panelAddIncident.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAddIncident.BackColor = System.Drawing.Color.White;
            this.panelAddIncident.BorderRadius = 10;
            this.panelAddIncident.Controls.Add(this.buttonAddIncident);
            this.panelAddIncident.Controls.Add(this.comboBoxStatus);
            this.panelAddIncident.Controls.Add(this.labelStatus);
            this.panelAddIncident.Controls.Add(this.textBoxDescription);
            this.panelAddIncident.Controls.Add(this.labelDescription);
            this.panelAddIncident.Controls.Add(this.textBoxDevice);
            this.panelAddIncident.Controls.Add(this.labelDevice);
            this.panelAddIncident.Controls.Add(this.comboBoxTable);
            this.panelAddIncident.Controls.Add(this.labelTable);
            this.panelAddIncident.Controls.Add(this.comboBoxType);
            this.panelAddIncident.Controls.Add(this.labelDeviceTable);
            this.panelAddIncident.Controls.Add(this.labelAddIncidentTitle);
            this.panelAddIncident.Location = new System.Drawing.Point(26, 75);
            this.panelAddIncident.Name = "panelAddIncident";
            this.panelAddIncident.Padding = new System.Windows.Forms.Padding(30);
            this.panelAddIncident.Size = new System.Drawing.Size(1002, 250);
            this.panelAddIncident.TabIndex = 1;
            // 
            // labelAddIncidentTitle
            // 
            this.labelAddIncidentTitle.AutoSize = true;
            this.labelAddIncidentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddIncidentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelAddIncidentTitle.Location = new System.Drawing.Point(30, 30);
            this.labelAddIncidentTitle.Name = "labelAddIncidentTitle";
            this.labelAddIncidentTitle.Size = new System.Drawing.Size(200, 32);
            this.labelAddIncidentTitle.TabIndex = 0;
            this.labelAddIncidentTitle.Text = "Thêm Sự Cố Mới";
            // 
            // labelDeviceTable
            // 
            this.labelDeviceTable.AutoSize = true;
            this.labelDeviceTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeviceTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelDeviceTable.Location = new System.Drawing.Point(30, 80);
            this.labelDeviceTable.Name = "labelDeviceTable";
            this.labelDeviceTable.Size = new System.Drawing.Size(120, 23);
            this.labelDeviceTable.TabIndex = 1;
            this.labelDeviceTable.Text = "Thiết bị / Bàn:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxType.BorderRadius = 6;
            this.comboBoxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxType.ItemHeight = 30;
            this.comboBoxType.Items.AddRange(new object[] {
            "Thiết bị",
            "Bàn"});
            this.comboBoxType.Location = new System.Drawing.Point(30, 105);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(200, 36);
            this.comboBoxType.TabIndex = 2;
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelTable.Location = new System.Drawing.Point(250, 80);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(40, 23);
            this.labelTable.TabIndex = 8;
            this.labelTable.Text = "Bàn:";
            this.labelTable.Visible = false;
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxTable.BorderRadius = 6;
            this.comboBoxTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTable.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxTable.ItemHeight = 30;
            this.comboBoxTable.Location = new System.Drawing.Point(250, 105);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(200, 36);
            this.comboBoxTable.TabIndex = 9;
            this.comboBoxTable.Visible = false;
            // 
            // labelDevice
            // 
            this.labelDevice.AutoSize = true;
            this.labelDevice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelDevice.Location = new System.Drawing.Point(250, 80);
            this.labelDevice.Name = "labelDevice";
            this.labelDevice.Size = new System.Drawing.Size(75, 23);
            this.labelDevice.TabIndex = 10;
            this.labelDevice.Text = "Thiết bị:";
            this.labelDevice.Visible = false;
            // 
            // textBoxDevice
            // 
            this.textBoxDevice.BorderRadius = 6;
            this.textBoxDevice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxDevice.DefaultText = "";
            this.textBoxDevice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxDevice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxDevice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxDevice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxDevice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxDevice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.textBoxDevice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxDevice.Location = new System.Drawing.Point(250, 105);
            this.textBoxDevice.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDevice.Name = "textBoxDevice";
            this.textBoxDevice.PlaceholderText = "Nhập tên thiết bị";
            this.textBoxDevice.SelectedText = "";
            this.textBoxDevice.Size = new System.Drawing.Size(200, 36);
            this.textBoxDevice.TabIndex = 11;
            this.textBoxDevice.Visible = false;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelDescription.Location = new System.Drawing.Point(30, 155);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(130, 23);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Mô tả sự cố:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BorderRadius = 6;
            this.textBoxDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxDescription.DefaultText = "";
            this.textBoxDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.textBoxDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxDescription.Location = new System.Drawing.Point(30, 180);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.PlaceholderText = "Mô tả chi tiết sự cố";
            this.textBoxDescription.SelectedText = "";
            this.textBoxDescription.Size = new System.Drawing.Size(400, 50);
            this.textBoxDescription.TabIndex = 4;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.labelStatus.Location = new System.Drawing.Point(460, 80);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(84, 23);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Trạng thái:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxStatus.BorderRadius = 6;
            this.comboBoxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxStatus.ItemHeight = 30;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Đang xử lý",
            "Đã xử lý",
            "Chờ xử lý"});
            this.comboBoxStatus.Location = new System.Drawing.Point(460, 105);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(200, 36);
            this.comboBoxStatus.TabIndex = 6;
            // 
            // buttonAddIncident
            // 
            this.buttonAddIncident.BorderRadius = 6;
            this.buttonAddIncident.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonAddIncident.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonAddIncident.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonAddIncident.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonAddIncident.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
            this.buttonAddIncident.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddIncident.ForeColor = System.Drawing.Color.White;
            this.buttonAddIncident.Location = new System.Drawing.Point(700, 105);
            this.buttonAddIncident.Name = "buttonAddIncident";
            this.buttonAddIncident.Size = new System.Drawing.Size(160, 40);
            this.buttonAddIncident.TabIndex = 7;
            this.buttonAddIncident.Text = "Thêm sự cố";
            // 
            // panelIncidentList
            // 
            this.panelIncidentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelIncidentList.BackColor = System.Drawing.Color.White;
            this.panelIncidentList.BorderRadius = 10;
            this.panelIncidentList.Controls.Add(this.gridIncidents);
            this.panelIncidentList.Controls.Add(this.labelIncidentListTitle);
            this.panelIncidentList.Location = new System.Drawing.Point(26, 345);
            this.panelIncidentList.Name = "panelIncidentList";
            this.panelIncidentList.Padding = new System.Windows.Forms.Padding(30);
            this.panelIncidentList.Size = new System.Drawing.Size(1002, 400);
            this.panelIncidentList.TabIndex = 2;
            // 
            // labelIncidentListTitle
            // 
            this.labelIncidentListTitle.AutoSize = true;
            this.labelIncidentListTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIncidentListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelIncidentListTitle.Location = new System.Drawing.Point(30, 30);
            this.labelIncidentListTitle.Name = "labelIncidentListTitle";
            this.labelIncidentListTitle.Size = new System.Drawing.Size(200, 32);
            this.labelIncidentListTitle.TabIndex = 0;
            this.labelIncidentListTitle.Text = "Danh Sách Sự Cố";
            // 
            // gridIncidents
            // 
            this.gridIncidents.AllowUserToAddRows = false;
            this.gridIncidents.AllowUserToDeleteRows = false;
            this.gridIncidents.AllowUserToResizeRows = false;
            this.gridIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridIncidents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridIncidents.BackgroundColor = System.Drawing.Color.White;
            this.gridIncidents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridIncidents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridIncidents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridIncidents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridIncidents.ColumnHeadersHeight = 50;
            this.gridIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridIncidents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colDeviceTable,
            this.colDescription,
            this.colStatus,
            this.colAction});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridIncidents.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridIncidents.EnableHeadersVisualStyles = false;
            this.gridIncidents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            this.gridIncidents.Location = new System.Drawing.Point(30, 80);
            this.gridIncidents.MultiSelect = false;
            this.gridIncidents.Name = "gridIncidents";
            this.gridIncidents.ReadOnly = true;
            this.gridIncidents.RowHeadersVisible = false;
            this.gridIncidents.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(237)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.gridIncidents.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridIncidents.RowTemplate.Height = 44;
            this.gridIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridIncidents.Size = new System.Drawing.Size(942, 290);
            this.gridIncidents.TabIndex = 1;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 60;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colDeviceTable
            // 
            this.colDeviceTable.HeaderText = "Thiết bị / Bàn";
            this.colDeviceTable.MinimumWidth = 150;
            this.colDeviceTable.Name = "colDeviceTable";
            this.colDeviceTable.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Mô tả";
            this.colDescription.MinimumWidth = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.MinimumWidth = 120;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colAction
            // 
            this.colAction.HeaderText = "Hành động";
            this.colAction.MinimumWidth = 120;
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            this.colAction.Text = "Cập nhật";
            this.colAction.UseColumnTextForButtonValue = true;
            // 
            // FormBaotrisuco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1054, 780);
            this.Controls.Add(this.panelIncidentList);
            this.Controls.Add(this.panelAddIncident);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBaotrisuco";
            this.Text = "Bảo Trì & Sự Cố";
            this.panelAddIncident.ResumeLayout(false);
            this.panelAddIncident.PerformLayout();
            this.panelIncidentList.ResumeLayout(false);
            this.panelIncidentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIncidents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Panel panelAddIncident;
        private System.Windows.Forms.Label labelAddIncidentTitle;
        private System.Windows.Forms.Label labelDeviceTable;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxType;
        private System.Windows.Forms.Label labelTable;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxTable;
        private System.Windows.Forms.Label labelDevice;
        private Guna.UI2.WinForms.Guna2TextBox textBoxDevice;
        private System.Windows.Forms.Label labelDescription;
        private Guna.UI2.WinForms.Guna2TextBox textBoxDescription;
        private System.Windows.Forms.Label labelStatus;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxStatus;
        private Guna.UI2.WinForms.Guna2Button buttonAddIncident;
        private Guna.UI2.WinForms.Guna2Panel panelIncidentList;
        private System.Windows.Forms.Label labelIncidentListTitle;
        private System.Windows.Forms.DataGridView gridIncidents;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
    }
}
