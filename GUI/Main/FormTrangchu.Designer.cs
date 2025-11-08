namespace QuanLyBida.GUI.Main
{
    partial class FormTrangchu
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
        private System.Windows.Forms.Label labelDoanhThu;
        private System.Windows.Forms.Panel panelDoanhThu;
        private System.Windows.Forms.Panel panelBanDung;
        private System.Windows.Forms.Label labelBanDungSo;
        private System.Windows.Forms.PictureBox pictureBan;
        private System.Windows.Forms.Panel panelKhach;
        private System.Windows.Forms.Label labelKhach;
        private System.Windows.Forms.Label labelKhachSo;
        private System.Windows.Forms.PictureBox pictureKhach;
        private System.Windows.Forms.Panel panelPhanLoai;
        private System.Windows.Forms.Label labelPhanLoai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhanLoai;
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrangchu));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelDoanhThu = new System.Windows.Forms.Label();
            this.panelDoanhThu = new System.Windows.Forms.Panel();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelBanDung = new System.Windows.Forms.Panel();
            this.labelBanDungSo = new System.Windows.Forms.Label();
            this.pictureBan = new System.Windows.Forms.PictureBox();
            this.panelKhach = new System.Windows.Forms.Panel();
            this.labelKhach = new System.Windows.Forms.Label();
            this.labelKhachSo = new System.Windows.Forms.Label();
            this.pictureKhach = new System.Windows.Forms.PictureBox();
            this.panelPhanLoai = new System.Windows.Forms.Panel();
            this.labelPhanLoai = new System.Windows.Forms.Label();
            this.chartPhanLoai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelBandangdung = new System.Windows.Forms.Label();
            this.panelDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panelBanDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBan)).BeginInit();
            this.panelKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKhach)).BeginInit();
            this.panelPhanLoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhanLoai)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDoanhThu
            // 
            this.labelDoanhThu.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelDoanhThu.Location = new System.Drawing.Point(60, 51);
            this.labelDoanhThu.Name = "labelDoanhThu";
            this.labelDoanhThu.Size = new System.Drawing.Size(300, 40);
            this.labelDoanhThu.TabIndex = 0;
            this.labelDoanhThu.Text = "Doanh Thu";
            this.labelDoanhThu.Click += new System.EventHandler(this.labelDashboard_Click);
            // 
            // panelDoanhThu
            // 
            this.panelDoanhThu.BackColor = System.Drawing.Color.White;
            this.panelDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDoanhThu.Controls.Add(this.chartDoanhThu);
            this.panelDoanhThu.Location = new System.Drawing.Point(140, 125);
            this.panelDoanhThu.Name = "panelDoanhThu";
            this.panelDoanhThu.Size = new System.Drawing.Size(600, 220);
            this.panelDoanhThu.TabIndex = 1;
            // 
            // chartDoanhThu
            // 
            chartArea3.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea3);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.Name = "DoanhThu";
            this.chartDoanhThu.Series.Add(series3);
            this.chartDoanhThu.Size = new System.Drawing.Size(598, 218);
            this.chartDoanhThu.TabIndex = 1;
            title2.Name = "Title1";
            title2.Text = "Doanh thu";
            this.chartDoanhThu.Titles.Add(title2);
            // 
            // panelBanDung
            // 
            this.panelBanDung.BackColor = System.Drawing.Color.White;
            this.panelBanDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBanDung.Controls.Add(this.labelBandangdung);
            this.panelBanDung.Controls.Add(this.labelBanDungSo);
            this.panelBanDung.Controls.Add(this.pictureBan);
            this.panelBanDung.Location = new System.Drawing.Point(48, 427);
            this.panelBanDung.Name = "panelBanDung";
            this.panelBanDung.Size = new System.Drawing.Size(180, 120);
            this.panelBanDung.TabIndex = 2;
            // 
            // labelBanDungSo
            // 
            this.labelBanDungSo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelBanDungSo.Location = new System.Drawing.Point(10, 40);
            this.labelBanDungSo.Name = "labelBanDungSo";
            this.labelBanDungSo.Size = new System.Drawing.Size(60, 40);
            this.labelBanDungSo.TabIndex = 1;
            this.labelBanDungSo.Text = "05";
            // 
            // pictureBan
            // 
            this.pictureBan.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBan.ErrorImage")));
            this.pictureBan.Image = ((System.Drawing.Image)(resources.GetObject("pictureBan.Image")));
            this.pictureBan.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBan.InitialImage")));
            this.pictureBan.Location = new System.Drawing.Point(73, 47);
            this.pictureBan.Name = "pictureBan";
            this.pictureBan.Size = new System.Drawing.Size(90, 59);
            this.pictureBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBan.TabIndex = 2;
            this.pictureBan.TabStop = false;
            // 
            // panelKhach
            // 
            this.panelKhach.BackColor = System.Drawing.Color.White;
            this.panelKhach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKhach.Controls.Add(this.labelKhach);
            this.panelKhach.Controls.Add(this.labelKhachSo);
            this.panelKhach.Controls.Add(this.pictureKhach);
            this.panelKhach.Location = new System.Drawing.Point(348, 427);
            this.panelKhach.Name = "panelKhach";
            this.panelKhach.Size = new System.Drawing.Size(180, 120);
            this.panelKhach.TabIndex = 3;
            // 
            // labelKhach
            // 
            this.labelKhach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelKhach.Location = new System.Drawing.Point(10, 6);
            this.labelKhach.Name = "labelKhach";
            this.labelKhach.Size = new System.Drawing.Size(160, 34);
            this.labelKhach.TabIndex = 0;
            this.labelKhach.Text = "Khách hiện tại";
            // 
            // labelKhachSo
            // 
            this.labelKhachSo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelKhachSo.Location = new System.Drawing.Point(10, 40);
            this.labelKhachSo.Name = "labelKhachSo";
            this.labelKhachSo.Size = new System.Drawing.Size(60, 40);
            this.labelKhachSo.TabIndex = 1;
            this.labelKhachSo.Text = "10";
            // 
            // pictureKhach
            // 
            this.pictureKhach.Image = ((System.Drawing.Image)(resources.GetObject("pictureKhach.Image")));
            this.pictureKhach.Location = new System.Drawing.Point(80, 46);
            this.pictureKhach.Name = "pictureKhach";
            this.pictureKhach.Size = new System.Drawing.Size(60, 40);
            this.pictureKhach.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureKhach.TabIndex = 2;
            this.pictureKhach.TabStop = false;
            // 
            // panelPhanLoai
            // 
            this.panelPhanLoai.BackColor = System.Drawing.Color.White;
            this.panelPhanLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPhanLoai.Controls.Add(this.labelPhanLoai);
            this.panelPhanLoai.Controls.Add(this.chartPhanLoai);
            this.panelPhanLoai.Location = new System.Drawing.Point(643, 427);
            this.panelPhanLoai.Name = "panelPhanLoai";
            this.panelPhanLoai.Size = new System.Drawing.Size(200, 120);
            this.panelPhanLoai.TabIndex = 4;
            // 
            // labelPhanLoai
            // 
            this.labelPhanLoai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelPhanLoai.Location = new System.Drawing.Point(10, 10);
            this.labelPhanLoai.Name = "labelPhanLoai";
            this.labelPhanLoai.Size = new System.Drawing.Size(180, 25);
            this.labelPhanLoai.TabIndex = 0;
            this.labelPhanLoai.Text = "Phân loại bàn";
            // 
            // chartPhanLoai
            // 
            chartArea4.Name = "ChartArea1";
            this.chartPhanLoai.ChartAreas.Add(chartArea4);
            this.chartPhanLoai.Location = new System.Drawing.Point(10, 40);
            this.chartPhanLoai.Name = "chartPhanLoai";
            this.chartPhanLoai.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Name = "PhanLoai";
            this.chartPhanLoai.Series.Add(series4);
            this.chartPhanLoai.Size = new System.Drawing.Size(180, 70);
            this.chartPhanLoai.TabIndex = 1;
            // 
            // labelBandangdung
            // 
            this.labelBandangdung.AutoSize = true;
            this.labelBandangdung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBandangdung.Location = new System.Drawing.Point(7, 7);
            this.labelBandangdung.Name = "labelBandangdung";
            this.labelBandangdung.Size = new System.Drawing.Size(156, 28);
            this.labelBandangdung.TabIndex = 5;
            this.labelBandangdung.Text = "Bàn đang dùng";
            // 
            // FormTrangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(891, 618);
            this.Controls.Add(this.labelDoanhThu);
            this.Controls.Add(this.panelDoanhThu);
            this.Controls.Add(this.panelBanDung);
            this.Controls.Add(this.panelKhach);
            this.Controls.Add(this.panelPhanLoai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTrangchu";
            this.Text = "FormTrangchu";
            this.panelDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panelBanDung.ResumeLayout(false);
            this.panelBanDung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBan)).EndInit();
            this.panelKhach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureKhach)).EndInit();
            this.panelPhanLoai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPhanLoai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label labelBandangdung;
    }
}