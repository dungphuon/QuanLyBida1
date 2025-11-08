using QuanLyBida.DAL;
using QuanLyBida.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Main
{
    public partial class FormDichVu : Form
    {
        private readonly string tableName;
        private readonly int maBan;
        public List<ServiceItem> SelectedItems { get; } = new List<ServiceItem>();

        public class ServiceItem
        {
            public int MaSP { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public string DonViTinh { get; set; }
            public int Quantity { get; set; }
        }

        public FormDichVu(string tableName, int maBan)
        {
            this.tableName = tableName;
            this.maBan = maBan;
            InitializeComponent();
            Shown += FormDichVu_Shown;
        }

        private void FormDichVu_Shown(object sender, EventArgs e)
        {
            labelTitle.Text = $"Thêm Dịch Vụ - {tableName}";
            LoadDanhSachDichVu();
        }

        private void LoadDanhSachDichVu()
        {
            try
            {
                var sanPhamDAL = new SanPhamDAL();
                var danhSachSanPham = sanPhamDAL.GetAllSanPham();

                foreach (var sanPham in danhSachSanPham)
                {
                    flowServices.Controls.Add(BuildServiceRow(
                        sanPham.MaSP,
                        sanPham.TenSP,
                        (int)sanPham.GiaBan,
                        sanPham.DonViTinh
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load dịch vụ: {ex.Message}", "Lỗi");
            }
        }

        private Control BuildServiceRow(int maSP, string name, int price, string donViTinh)
        {
            var container = new Panel
            {
                Width = flowServices.ClientSize.Width - 30,
                Height = 70,
                Margin = new Padding(6),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = maSP
            };

            var lblName = new Label
            {
                Text = $"{name} ({donViTinh})",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(12, 10),
                Tag = maSP
            };
            container.Controls.Add(lblName);

            var lblPrice = new Label
            {
                Text = $"{price:N0} đ",
                ForeColor = Color.Firebrick,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(12, 38),
                Tag = maSP
            };
            container.Controls.Add(lblPrice);

            var btnMinus = new Button
            {
                Text = "-",
                Width = 40,
                Height = 40,
                BackColor = Color.FromArgb(99, 122, 214),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(container.Width - 160, 14),
                Tag = maSP
            };
            btnMinus.FlatAppearance.BorderSize = 0;

            var lblQty = new Label
            {
                Text = "0",
                Width = 30,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(container.Width - 115, 20),
                Tag = maSP
            };

            var btnPlus = new Button
            {
                Text = "+",
                Width = 40,
                Height = 40,
                BackColor = Color.FromArgb(99, 122, 214),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(container.Width - 70, 14),
                Tag = maSP
            };
            btnPlus.FlatAppearance.BorderSize = 0;

            btnMinus.Click += (s, e) =>
            {
                int q = int.Parse(lblQty.Text);
                if (q > 0)
                {
                    lblQty.Text = (q - 1).ToString();
                    lblQty.ForeColor = q - 1 > 0 ? Color.Black : Color.Gray;
                }
            };

            btnPlus.Click += (s, e) =>
            {
                int q = int.Parse(lblQty.Text);
                lblQty.Text = (q + 1).ToString();
                lblQty.ForeColor = Color.Black;
            };

            container.Resize += (s, e) =>
            {
                btnMinus.Left = container.Width - 160;
                lblQty.Left = container.Width - 115;
                btnPlus.Left = container.Width - 70;
            };

            container.Controls.Add(btnMinus);
            container.Controls.Add(lblQty);
            container.Controls.Add(btnPlus);

            return container;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedItems.Clear();

            foreach (Control row in flowServices.Controls)
            {
                if (row is Panel container)
                {
                    var labels = container.Controls.OfType<Label>().ToList();
                    var nameLabel = labels.FirstOrDefault(l => l.Location.Y == 10);
                    var priceLabel = labels.FirstOrDefault(l => l.Location.Y == 38);
                    var qtyLabel = labels.FirstOrDefault(l => l.TextAlign == ContentAlignment.MiddleCenter);

                    if (nameLabel == null || priceLabel == null || qtyLabel == null) continue;

                    int qty = int.Parse(qtyLabel.Text);
                    if (qty <= 0) continue;

                    int price = 0;
                    var txt = priceLabel.Text.Replace(" đ", "").Replace(".", "").Trim();
                    int.TryParse(txt, out price);

                    // Lấy đơn vị tính từ tên (format: "Tên SP (ĐVT)")
                    string donViTinh = "Cái";
                    if (nameLabel.Text.Contains("(") && nameLabel.Text.Contains(")"))
                    {
                        int start = nameLabel.Text.IndexOf("(") + 1;
                        int end = nameLabel.Text.IndexOf(")");
                        donViTinh = nameLabel.Text.Substring(start, end - start);
                    }

                    SelectedItems.Add(new ServiceItem
                    {
                        MaSP = (int)container.Tag,
                        Name = nameLabel.Text.Replace($" ({donViTinh})", ""),
                        Price = price,
                        DonViTinh = donViTinh,
                        Quantity = qty
                    });
                }
            }

            if (SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dịch vụ!", "Thông báo");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void LuuHoaDonDichVu(List<ServiceItem> selectedItems)
        {
            try
            {
                var hoaDonDAL = new HoaDonDAL();

                // Tạo hóa đơn mới - sử dụng maBan đã lưu
                var hoaDon = new HoaDonDTO
                {
                    MaBan = maBan, // Sử dụng mã bàn từ constructor
                    NgayLap = DateTime.Now,
                    TongTien = selectedItems.Sum(item => item.Price * item.Quantity),
                    GiamGia = 0,
                    TrangThaiThanhToan = "Chưa thanh toán"
                };

                // Thêm chi tiết hóa đơn
                foreach (var item in selectedItems)
                {
                    hoaDon.ChiTiet.Add(new ChiTietHoaDonDTO
                    {
                        MaSP = item.MaSP,
                        TenSP = item.Name,
                        SoLuong = item.Quantity,
                        DonGia = item.Price,
                        ThanhTien = item.Price * item.Quantity
                    });

                    // Cập nhật số lượng tồn
                    hoaDonDAL.CapNhatSoLuongTon(item.MaSP, item.Quantity);
                }

                // Lưu hóa đơn vào database
                int maHD = hoaDonDAL.CreateHoaDon(hoaDon);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi");
            }
        }
    }
}