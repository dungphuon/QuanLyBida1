using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBida.DTO;
using QuanLyBida.BLL; // Giả sử có lớp BLL

namespace QuanLyBida.GUI.Main
{
    public partial class FormQLKH : Form
    {
        private BindingList<KhachHangDTO> customers;
        private KhachHangBLL khachHangBLL; // Business Logic Layer

        public FormQLKH()
        {
            InitializeComponent();
            khachHangBLL = new KhachHangBLL(); // Khởi tạo BLL
            this.Load += FormQLKH_Load;
            this.buttonAdd.Click += buttonAdd_Click;
            this.gridCustomers.CellContentClick += gridCustomers_CellContentClick;
        }

        private void FormQLKH_Load(object sender, EventArgs e)
        {
            // Cấu hình binding cho các cột
            gridCustomers.AutoGenerateColumns = false;
            ConfigureDataGridViewColumns();
            LoadCustomersFromBLL();
        }

        private void ConfigureDataGridViewColumns()
        {
            // Xóa các cột cũ nếu có
            gridCustomers.Columns.Clear();

            // Thêm các cột mới

            gridCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colHoTen",
                HeaderText = "Họ Tên",
                DataPropertyName = nameof(KhachHangDTO.HoTen),
                Width = 150
            });

            gridCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colSoDienThoai",
                HeaderText = "Số ĐT",
                DataPropertyName = nameof(KhachHangDTO.SDT),
                Width = 100
            });

            gridCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colHangThanhVien",
                HeaderText = "Hạng TV",
                DataPropertyName = nameof(KhachHangDTO.Hang),
                Width = 80
            });

            // Trong ConfigureDataGridViewColumns(), thêm cột điểm tích lũy nếu cần
            gridCustomers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDiemTichLuy",
                HeaderText = "Điểm TL",
                DataPropertyName = "DiemTichLuy",
                Width = 80
            });

            // Thêm cột nút Sửa
            gridCustomers.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "colEdit",
                HeaderText = "Sửa",
                Text = "Sửa",
                UseColumnTextForButtonValue = true,
                Width = 50
            });

            // Thêm cột nút Xóa
            gridCustomers.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "colDelete",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 50
            });
        }

        private void LoadCustomersFromBLL()
        {
            try
            {
                // Gọi BLL để lấy dữ liệu
                var khachHangList = khachHangBLL.LayTatCaKhachHang();
                customers = new BindingList<KhachHangDTO>(khachHangList);
                gridCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var result = ShowCustomerDialog(out var newCustomer);
            if (result && newCustomer != null)
            {
                try
                {
                    // Gọi BLL để thêm khách hàng
                    bool success = khachHangBLL.ThemKhachHang(newCustomer);
                    if (success)
                    {
                        customers.Add(newCustomer);
                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var customer = gridCustomers.Rows[e.RowIndex].DataBoundItem as KhachHangDTO;
            if (customer == null) return;

            if (gridCustomers.Columns[e.ColumnIndex].Name == "colEdit")
            {
                var edited = new KhachHangDTO
                {
                    MaKH = customer.MaKH,
                    HoTen = customer.HoTen,
                    SDT = customer.SDT,
                    Email = customer.Email,
                    Hang = customer.Hang
                };
                var ok = ShowCustomerDialog(out var updated, edited);
                if (ok && updated != null)
                {
                    try
                    {
                        // Gọi BLL để cập nhật
                        bool success = khachHangBLL.CapNhatKhachHang(updated);
                        if (success)
                        {
                            customer.HoTen = updated.HoTen;
                            customer.SDT = updated.SDT;
                            customer.Email = updated.Email;
                            customer.Hang = updated.Hang;
                            gridCustomers.Refresh();
                            MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (gridCustomers.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa khách hàng '{customer.HoTen}'?\n\n" +
                    $"Khách hàng sẽ được xóa khỏi danh sách nhưng dữ liệu lịch sử\n" +
                    $"và hóa đơn vẫn được giữ nguyên để báo cáo.",
                    "Xác nhận xóa khách hàng",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        // Gọi BLL để xóa mềm
                        bool success = khachHangBLL.XoaKhachHang(customer.MaKH);
                        if (success)
                        {
                            customers.Remove(customer);
                            MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa khách hàng: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Trong file FormQLKH.cs

        // Trong file FormQLKH.cs

        private bool ShowCustomerDialog(out KhachHangDTO customer, KhachHangDTO seed = null)
        {
            customer = null;

            using (var dialog = new Form())
            {
                dialog.Text = seed == null ? "Thêm khách hàng" : "Sửa khách hàng";
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.MinimizeBox = false;
                dialog.MaximizeBox = false;
                dialog.ClientSize = new Size(420, 300);

                var labelHoTen = new Label { Text = "Họ tên", Left = 20, Top = 20, AutoSize = true };
                var inputHoTen = new TextBox { Left = 160, Top = 16, Width = 230 };

                var labelSoDienThoai = new Label { Text = "Số điện thoại", Left = 20, Top = 60, AutoSize = true };
                var inputSoDienThoai = new TextBox { Left = 160, Top = 56, Width = 230 };

                var labelEmail = new Label { Text = "Email", Left = 20, Top = 100, AutoSize = true };
                var inputEmail = new TextBox { Left = 160, Top = 96, Width = 230 };

                var labelHangThanhVien = new Label { Text = "Hạng thành viên", Left = 20, Top = 140, AutoSize = true };
                var inputHangThanhVien = new ComboBox { Left = 160, Top = 136, Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
                inputHangThanhVien.Items.AddRange(new object[] { "Thường", "Bạc", "Vàng", "Kim Cương" });

                var btnOk = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Left = 220, Width = 80, Top = 190 };
                var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Left = 310, Width = 80, Top = 190 };

                // --- 1. SẮP XẾP THỨ TỰ TAB ---
                inputHoTen.TabIndex = 0;
                inputSoDienThoai.TabIndex = 1;
                inputEmail.TabIndex = 2;
                inputHangThanhVien.TabIndex = 3;
                btnOk.TabIndex = 4;
                btnCancel.TabIndex = 5;

                // --- QUAN TRỌNG: BỎ DÒNG NÀY ĐI ---
                // dialog.AcceptButton = btnOk; <--- XÓA DÒNG NÀY ĐỂ KHÔNG BỊ ENTER LÀ LƯU LUÔN

                dialog.CancelButton = btnCancel; // Giữ lại dòng này để bấm Esc là thoát

                // --- 2. XỬ LÝ PHÍM ENTER (Code cũ giữ nguyên) ---
                // Họ tên -> Enter -> SĐT
                inputHoTen.KeyDown += (s, e) => {
                    if (e.KeyCode == Keys.Enter) { inputSoDienThoai.Focus(); e.SuppressKeyPress = true; }
                };

                // SĐT -> Enter -> Email
                inputSoDienThoai.KeyDown += (s, e) => {
                    if (e.KeyCode == Keys.Enter) { inputEmail.Focus(); e.SuppressKeyPress = true; }
                };

                // Email -> Enter -> Hạng thành viên
                inputEmail.KeyDown += (s, e) => {
                    if (e.KeyCode == Keys.Enter) { inputHangThanhVien.Focus(); e.SuppressKeyPress = true; }
                };

                // Hạng -> Enter -> Bấm LƯU luôn (Chỉ cho phép Lưu ở ô cuối cùng)
                inputHangThanhVien.KeyDown += (s, e) => {
                    if (e.KeyCode == Keys.Enter) { btnOk.PerformClick(); e.SuppressKeyPress = true; }
                };

                if (seed != null)
                {
                    inputHoTen.Text = seed.HoTen;
                    inputSoDienThoai.Text = seed.SDT;
                    inputEmail.Text = seed.Email;
                    inputHangThanhVien.SelectedItem = seed.Hang;
                }
                else
                {
                    inputHangThanhVien.SelectedIndex = 0;
                }

                dialog.Controls.AddRange(new Control[]
                {
            labelHoTen, inputHoTen,
            labelSoDienThoai, inputSoDienThoai,
            labelEmail, inputEmail,
            labelHangThanhVien, inputHangThanhVien,
            btnOk, btnCancel
                });

                // Vẫn cần gán DialogResult cho nút OK để Form biết bấm nút đó là thành công
                // Nhưng không gán vào property AcceptButton của Form
                btnOk.DialogResult = DialogResult.OK;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    customer = new KhachHangDTO
                    {
                        HoTen = inputHoTen.Text.Trim(),
                        SDT = inputSoDienThoai.Text.Trim(),
                        Email = inputEmail.Text.Trim(),
                        Hang = inputHangThanhVien.SelectedItem?.ToString() ?? "Thường"
                    };

                    if (seed != null)
                    {
                        customer.MaKH = seed.MaKH;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}