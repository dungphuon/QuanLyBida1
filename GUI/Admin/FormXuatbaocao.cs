using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
// Thư viện Excel (EPPlus)
using OfficeOpenXml;
using OfficeOpenXml.Style;
// 🔥 QUAN TRỌNG: Thêm thư viện PDF (iTextSharp)
using iTextSharp.text;
using iTextSharp.text.pdf;
using QuanLyBida.BLL;
using QuanLyBida.DTO;
// Vì iTextSharp cũng có class 'Font' và 'Rectangle' trùng tên với WinForm
// nên ta dùng alias để tránh lỗi
using PdfFont = iTextSharp.text.Font;
using PdfRectangle = iTextSharp.text.Rectangle;

namespace GUI.Admin
{
    public partial class FormXuatbaocao : Form
    {
        private readonly PhieuThuChiBLL _bll = new PhieuThuChiBLL();

        public FormXuatbaocao()
        {
            InitializeComponent();
            Load += FormXuatbaocao_Load;
        }

        private void FormXuatbaocao_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dateTimePickerFrom.Value = new DateTime(now.Year, now.Month, 1);
            dateTimePickerTo.Value = now;

            radioButtonExcel.Checked = true;
            checkBoxDoanhthu.Checked = true;
            checkBoxTongChi.Checked = true;
            checkBoxChiTietGiaoDich.Checked = true;

            LoadDataPreview();

            buttonExport.Click += ButtonExport_Click;
            buttonCancel.Click += ButtonCancel_Click;

            dateTimePickerFrom.ValueChanged += Filter_Changed;
            dateTimePickerTo.ValueChanged += Filter_Changed;
            checkBoxDoanhthu.CheckedChanged += Filter_Changed;
            checkBoxTongChi.CheckedChanged += Filter_Changed;
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LoadDataPreview();
        }

        private void LoadDataPreview()
        {
            try
            {
                DateTime from = dateTimePickerFrom.Value.Date;
                DateTime to = dateTimePickerTo.Value.Date.AddDays(1).AddSeconds(-1);

                var list = _bll.LayDanhSachPhieu(from, to);

                var filteredList = list.Where(p =>
                    (checkBoxDoanhthu.Checked && (p.LoaiPhieu == "Thu" || p.LoaiPhieu == "THU")) ||
                    (checkBoxTongChi.Checked && (p.LoaiPhieu == "Chi" || p.LoaiPhieu == "CHI"))
                ).ToList();

                gridPreview.Rows.Clear();

                foreach (var item in filteredList)
                {
                    int index = gridPreview.Rows.Add();
                    var row = gridPreview.Rows[index];

                    string maHienThi = item.LoaiPhieu.ToUpper() == "THU" ? $"PT_{item.MaPhieu}" : $"PC_{item.MaPhieu}";

                    row.Cells["colMaPhieu"].Value = maHienThi;
                    row.Cells["colThoiGian"].Value = item.NgayTao.ToString("dd/MM/yyyy HH:mm");
                    row.Cells["colLoaiThuChi"].Value = item.LoaiGiaoDichDisplay;
                    row.Cells["colNguoiNopNhan"].Value = item.TenNhanVien;
                    row.Cells["colGiaTri"].Value = item.SoTien;
                }

                gridPreview.Columns["colGiaTri"].DefaultCellStyle.Format = "N0";
                gridPreview.Columns["colGiaTri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            if (gridPreview.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radioButtonExcel.Checked)
            {
                ExportToExcel_XLSX();
            }
            else if (radioButtonPDF.Checked)
            {
                ExportToPDF(); // 🔥 Gọi hàm xuất PDF mới
            }
        }

        // --- HÀM XUẤT PDF (SỬ DỤNG ITEXTSHARP) ---
        private void ExportToPDF()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"BaoCao_TaiChinh_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 1. Cấu hình khổ giấy A4, lề
                        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                        pdfDoc.Open();

                        // 2. Đăng ký Font chữ tiếng Việt (Arial)
                        string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        PdfFont fontTitle = new PdfFont(bf, 18, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
                        PdfFont fontHeader = new PdfFont(bf, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                        PdfFont fontData = new PdfFont(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        PdfFont fontDataBold = new PdfFont(bf, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                        // 3. Viết Tiêu đề
                        Paragraph title = new Paragraph("BÁO CÁO TÀI CHÍNH", fontTitle);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 5f;
                        pdfDoc.Add(title);

                        Paragraph subTitle = new Paragraph($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}", new PdfFont(bf, 10, iTextSharp.text.Font.ITALIC));
                        subTitle.Alignment = Element.ALIGN_CENTER;
                        subTitle.SpacingAfter = 20f;
                        pdfDoc.Add(subTitle);

                        // 4. Tạo Bảng
                        PdfPTable pdfTable = new PdfPTable(gridPreview.Columns.Count);
                        pdfTable.WidthPercentage = 100; // Độ rộng 100% trang
                        // Set độ rộng tương đối cho các cột (Mã, Thời gian, Loại, Người, Tiền)
                        pdfTable.SetWidths(new float[] { 15f, 20f, 15f, 30f, 20f });

                        // 5. Thêm Header Bảng
                        foreach (DataGridViewColumn column in gridPreview.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontHeader));
                            cell.BackgroundColor = new BaseColor(92, 124, 250); // Màu xanh giống giao diện
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.Padding = 5;
                            cell.BorderColor = BaseColor.DARK_GRAY;
                            pdfTable.AddCell(cell);
                        }

                        // 6. Thêm Dữ liệu từ Grid
                        foreach (DataGridViewRow row in gridPreview.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    string cellValue = cell.Value?.ToString() ?? "";

                                    // Format tiền tệ nếu là cột giá trị
                                    if (cell.ColumnIndex == 4 && decimal.TryParse(cellValue, out decimal money))
                                    {
                                        cellValue = money.ToString("N0");
                                    }

                                    PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue, fontData));
                                    pdfCell.Padding = 5;
                                    pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                                    // Canh lề: Cột tiền (index 4) canh phải, còn lại canh trái/giữa
                                    if (cell.ColumnIndex == 4)
                                        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    else if (cell.ColumnIndex == 1 || cell.ColumnIndex == 2)
                                        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    else
                                        pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;

                                    pdfTable.AddCell(pdfCell);
                                }
                            }
                        }

                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();

                        MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try { System.Diagnostics.Process.Start(sfd.FileName); } catch { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- HÀM XUẤT EXCEL (EPPLUS) - GIỮ NGUYÊN ---
        private void ExportToExcel_XLSX()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = $"BaoCao_TaiChinh_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Báo Cáo");

                            worksheet.Cells["A1:E1"].Merge = true;
                            worksheet.Cells["A1"].Value = "BÁO CÁO TÀI CHÍNH";
                            worksheet.Cells["A1"].Style.Font.Size = 16;
                            worksheet.Cells["A1"].Style.Font.Bold = true;
                            worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            worksheet.Cells["A2:E2"].Merge = true;
                            worksheet.Cells["A2"].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                            worksheet.Cells["A2"].Style.Font.Italic = true;
                            worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            string[] headers = { "Mã Phiếu", "Thời Gian", "Loại", "Người Thực Hiện", "Số Tiền" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                var cell = worksheet.Cells[4, i + 1];
                                cell.Value = headers[i];
                                cell.Style.Font.Bold = true;
                                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));
                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            int rowIndex = 5;
                            foreach (DataGridViewRow row in gridPreview.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    worksheet.Cells[rowIndex, 1].Value = row.Cells["colMaPhieu"].Value?.ToString();
                                    worksheet.Cells[rowIndex, 2].Value = row.Cells["colThoiGian"].Value?.ToString();
                                    worksheet.Cells[rowIndex, 3].Value = row.Cells["colLoaiThuChi"].Value?.ToString();
                                    worksheet.Cells[rowIndex, 4].Value = row.Cells["colNguoiNopNhan"].Value?.ToString();

                                    if (decimal.TryParse(row.Cells["colGiaTri"].Value?.ToString(), out decimal amount))
                                    {
                                        worksheet.Cells[rowIndex, 5].Value = amount;
                                        worksheet.Cells[rowIndex, 5].Style.Numberformat.Format = "#,##0";
                                    }
                                    rowIndex++;
                                }
                            }

                            var dataRange = worksheet.Cells[4, 1, rowIndex - 1, 5];
                            dataRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            dataRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            dataRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            dataRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                            worksheet.Cells.AutoFitColumns();
                            FileInfo fi = new FileInfo(sfd.FileName);
                            package.SaveAs(fi);
                        }

                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try { System.Diagnostics.Process.Start(sfd.FileName); } catch { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxChiTietGiaoDich_CheckedChanged(object sender, EventArgs e)
        {
            gridPreview.Visible = checkBoxChiTietGiaoDich.Checked;
        }
    }
}