namespace QuanLyBida.GUI.Main
{
    partial class FormQuanlyban
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
        private System.Windows.Forms.FlowLayoutPanel flowTables;
        private System.Windows.Forms.Label labelTitle;
        private void InitializeComponent()
        {
            this.flowTables = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowTables
            // 
            this.flowTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowTables.AutoScroll = true;
            this.flowTables.BackColor = System.Drawing.Color.White;
            this.flowTables.Location = new System.Drawing.Point(24, 72);
            this.flowTables.Name = "flowTables";
            this.flowTables.Padding = new System.Windows.Forms.Padding(4);
            this.flowTables.Size = new System.Drawing.Size(752, 354);
            this.flowTables.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(18, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(240, 41);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Quản lý bàn chơi";
            // 
            // FormQuanlyban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.flowTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuanlyban";
            this.Text = "FormQuanlyban";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}