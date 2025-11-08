using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormTrangchu : Form
    {
        public FormTrangchu()
        {
            InitializeComponent();
            this.Load += FormTrangchu_Load;
        }

        private void chartDoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void labelDashboard_Click(object sender, EventArgs e)
        {

        }

        private void FormTrangchu_Load(object sender, EventArgs e)
        {
            // Demo dữ liệu cho biểu đồ Doanh thu theo tháng
            var now = DateTime.Now;
            var months = Enumerable.Range(0, 6).Select(i => now.AddMonths(-i)).Reverse().ToList();
            chartDoanhThu.Series[0].Points.Clear();
            foreach (var m in months)
            {
                var label = $"{m:MM/yyyy}";
                var value = 10_000_000 + (m.Month * 1_000_000); // dữ liệu giả lập
                chartDoanhThu.Series[0].Points.AddXY(label, value);
            }

            // Demo dữ liệu cho biểu đồ Phân loại bàn (pie)
            chartPhanLoai.Series[0].Points.Clear();
            chartPhanLoai.Series[0].Points.AddXY("VIP", 5);
            chartPhanLoai.Series[0].Points.AddXY("Thường", 12);
            chartPhanLoai.Series[0].Points.AddXY("Mini", 3);

            // Cập nhật các số liệu tổng quan demo
            labelBanDungSo.Text = "05";
            labelKhachSo.Text = "10";
        }
    }
}
