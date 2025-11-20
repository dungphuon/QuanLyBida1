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

namespace QuanLyBida.GUI.Admin
{
    public partial class FormQLBanAdmin : Form
    {
        private TableBLL tableBLL;
        private List<TableDTO> danhSachBan;

        public FormQLBanAdmin()
        {
            InitializeComponent();
            tableBLL = new TableBLL();
            RegisterEvents();
            LoadDataFromDatabase();
            LoadFilterOptions();
        }

        private void RegisterEvents()
        {
            this.buttonAdd.Click += ButtonAdd_Click;
            this.gridTables.CellContentClick += GridTables_CellContentClick;
            this.comboBoxFilter.SelectedIndexChanged += ComboBoxFilter_SelectedIndexChanged;
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                danhSachBan = tableBLL.GetAllTables();
                HienThiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilterOptions()
        {
            try
            {
                // Xóa items cũ
                comboBoxFilter.Items.Clear();

                // Thêm "Tất cả" đầu tiên
                comboBoxFilter.Items.Add("Tất cả");

                // Lấy danh sách loại bàn duy nhất từ database
                var loaiBanList = danhSachBan
                    .Select(b => b.LoaiBan)
                    .Distinct()
                    .OrderBy(l => l)
                    .ToList();

                // Thêm các loại bàn vào combobox
                foreach (var loaiBan in loaiBanList)
                {
                    comboBoxFilter.Items.Add(loaiBan);
                }

                // Chọn "Tất cả" mặc định
                comboBoxFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải tùy chọn lọc: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDuLieu()
        {
            gridTables.Rows.Clear();

            var danhSachHienThi = danhSachBan;

            // Lọc dữ liệu nếu không chọn "Tất cả"
            if (comboBoxFilter.SelectedIndex > 0)
            {
                string loaiBanLoc = comboBoxFilter.SelectedItem.ToString();
                danhSachHienThi = danhSachBan
                    .Where(b => b.LoaiBan == loaiBanLoc)
                    .ToList();
            }

            foreach (var ban in danhSachHienThi)
            {
                gridTables.Rows.Add(
                    ban.TenBan,
                    ban.LoaiBan,
                    ban.GiaGio.ToString("N0") + " VNĐ"
                );
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var addTableForm = new FormAddTable())
            {
                addTableForm.StartPosition = FormStartPosition.CenterParent;
                if (addTableForm.ShowDialog(this) == DialogResult.OK)
                {
                    // Load lại cả dữ liệu và filter options
                    LoadDataFromDatabase();
                    LoadFilterOptions();
                }
            }
        }

        private void GridTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = gridTables.Rows[e.RowIndex];
            string tenBan = row.Cells["colTenBan"].Value?.ToString() ?? "";

            var ban = danhSachBan.FirstOrDefault(b => b.TenBan == tenBan);
            if (ban == null) return;

            if (gridTables.Columns[e.ColumnIndex].Name == "colView")
            {
                using (var editTableForm = new FormEditTable())
                {
                    editTableForm.SetTableData(ban);
                    editTableForm.StartPosition = FormStartPosition.CenterParent;

                    if (editTableForm.ShowDialog(this) == DialogResult.OK)
                    {
                        // Load lại cả dữ liệu và filter options
                        LoadDataFromDatabase();
                        LoadFilterOptions();
                    }
                }
            }
            else if (gridTables.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa bàn '{tenBan}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = tableBLL.DeleteTable(ban.MaBan);

                        if (success)
                        {
                            // Load lại cả dữ liệu và filter options
                            LoadDataFromDatabase();
                            LoadFilterOptions();
                            MessageBox.Show("Đã xóa bàn thành công!", "Thông báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa bàn!", "Lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa bàn: {ex.Message}", "Lỗi",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }
    }
}