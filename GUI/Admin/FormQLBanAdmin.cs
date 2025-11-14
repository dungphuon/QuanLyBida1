using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBida.GUI.Admin
{
    public partial class FormQLBanAdmin : Form
    {
        // Class để lưu dữ liệu mẫu bàn
        private class BanMau
        {
            public string TenBan { get; set; }
            public string LoaiBan { get; set; }
            public decimal GiaBan { get; set; }
        }

        private List<BanMau> danhSachBan;

        public FormQLBanAdmin()
        {
            InitializeComponent();
            RegisterEvents();
            TaoDuLieuMau();
            HienThiDuLieu();
        }

        private void RegisterEvents()
        {
            this.buttonAdd.Click += ButtonAdd_Click;
            this.gridTables.CellContentClick += GridTables_CellContentClick;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            using (var addTableForm = new FormAddTable())
            {
                addTableForm.StartPosition = FormStartPosition.CenterParent;
                addTableForm.ShowDialog(this);
            }
        }

        private void TaoDuLieuMau()
        {
            danhSachBan = new List<BanMau>
            {
                new BanMau
                {
                    TenBan = "Bàn 01",
                    LoaiBan = "Bàn thường",
                    GiaBan = 50000
                },
                new BanMau
                {
                    TenBan = "Bàn 02",
                    LoaiBan = "Bàn VIP",
                    GiaBan = 100000
                }
            };
        }

        private void HienThiDuLieu()
        {
            gridTables.Rows.Clear();
            foreach (var ban in danhSachBan)
            {
                gridTables.Rows.Add(
                    ban.TenBan,
                    ban.LoaiBan,
                    ban.GiaBan.ToString("N0") + " VNĐ"
                );
            }
        }

        private void GridTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Kiểm tra nếu click vào cột "Xem"
            if (gridTables.Columns[e.ColumnIndex].Name == "colView")
            {
                var row = gridTables.Rows[e.RowIndex];
                string tenBan = row.Cells["colTenBan"].Value?.ToString() ?? "";
                string loaiBan = row.Cells["colLoaiBan"].Value?.ToString() ?? "";
                string giaBanStr = row.Cells["colGiaBan"].Value?.ToString() ?? "";
                
                // Lấy giá bàn (bỏ phần " VNĐ")
                decimal giaBan = 0;
                if (!string.IsNullOrEmpty(giaBanStr))
                {
                    string giaBanNumber = giaBanStr.Replace(" VNĐ", "").Replace(",", "");
                    decimal.TryParse(giaBanNumber, out giaBan);
                }

                // Tìm bàn trong danh sách
                var ban = danhSachBan.FirstOrDefault(b => b.TenBan == tenBan);
                
                // Mở form EditTable
                using (var editTableForm = new FormEditTable())
                {
                    // Truyền dữ liệu vào form
                    editTableForm.SetTableData(tenBan, loaiBan, giaBan);
                    editTableForm.StartPosition = FormStartPosition.CenterParent;
                    editTableForm.ShowDialog(this);
                }
            }
            // Kiểm tra nếu click vào cột "Xóa"
            else if (gridTables.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var row = gridTables.Rows[e.RowIndex];
                string tenBan = row.Cells["colTenBan"].Value?.ToString() ?? "";

                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa bàn '{tenBan}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    var ban = danhSachBan.FirstOrDefault(b => b.TenBan == tenBan);
                    if (ban != null)
                    {
                        danhSachBan.Remove(ban);
                        HienThiDuLieu();
                        MessageBox.Show("Đã xóa bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
