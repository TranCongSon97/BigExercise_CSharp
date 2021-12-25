using Newtonsoft.Json;
using QuanLyThuVien_CSharp.BLL;
using QuanLyThuVien_CSharp.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuVien_CSharp.GUI.AdminForm.ThongKe
{
    public partial class fThongKe : Form
    {
        public fThongKe()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            cbbNam.Items.Clear();
            cbbThang.Items.Clear();
            int NamHienTai = DateTime.Now.Year;
            for (int i = NamHienTai - 10; i <= NamHienTai; i++)
            {
                cbbNam.Items.Add(i);
            }

            cbbThang.Items.Add("Tất cả");
            for (int i = 1; i <= 12; i++)
            {
                cbbThang.Items.Add("Tháng " + i);
            }
            cbbNam.SelectedIndex = 0;
            cbbThang.SelectedIndex = 0;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int month, year;
            if (cbbThang.SelectedIndex == 0)
                month = 0;
            else
                month = Int32.Parse(cbbThang.SelectedItem.ToString().Split(' ')[1]);
            year = Int32.Parse(cbbNam.SelectedItem.ToString());
            DataTable table = new DataTable();
            if (month != 0)
            {
                table.Columns.Add("Ngày", typeof(string));
                table.Columns.Add("Số sách được mượn", typeof(int));
                table.Columns.Add("Số sách được trả", typeof(int));
                table.Columns.Add("Số độc giả đến thư viện", typeof(string));
                int days = DateTime.DaysInMonth(year, month);
                for (int i = 1; i <= days; i++)
                {
                    ThongKe_BLL thongKe = new ThongKe_BLL();
                    string date = year + "-" + (month < 10 ? "0" + month.ToString() : month.ToString()) + "-" + (i < 10 ? "0" + i.ToString() : i.ToString());
                    DataRow row = table.NewRow();
                    row["Ngày"] = "Ngày " + i + "/" + month + "/" + year;
                    row["Số sách được mượn"] = thongKe.getSachMuonNgay(date);
                    row["Số sách được trả"] = thongKe.getSachTraNgay(date);
                    if (File.Exists(@"LichSuDocGia/" + date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2) + ".txt"))
                    {
                        int slDocGia = 0;
                        using (StreamReader r = new StreamReader(@"LichSuDocGia/" + date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2) + ".txt"))
                        {
                            string json = r.ReadToEnd();
                            List<DocGia_DTO> items = JsonConvert.DeserializeObject<List<DocGia_DTO>>(json);
                            if (items != null)
                            {
                                slDocGia = items.Count;
                            }
                        }
                        row["Số độc giả đến thư viện"] = slDocGia.ToString();
                    }
                    else
                    {
                        row["Số độc giả đến thư viện"] = "Không có dữ liệu";
                    }
                    table.Rows.Add(row);
                }
            }
            else
            {
                table.Columns.Add("Tháng", typeof(string));
                table.Columns.Add("Số sách được mượn", typeof(int));
                table.Columns.Add("Số sách được trả", typeof(int));
                table.Columns.Add("Số độc giả đến thư viện", typeof(string));
                for (int i = 1; i <= 12; i++)
                {
                    ThongKe_BLL thongKe = new ThongKe_BLL();
                    DataRow row = table.NewRow();
                    row["Tháng"] = "Tháng " + i;
                    row["Số sách được mượn"] = thongKe.getSachMuonThang(i, year);
                    row["Số sách được trả"] = thongKe.getSachTraThang(i, year);
                    int slDocGia = 0;
                    int days = DateTime.DaysInMonth(year, i);
                    for (int dayIndex = 1; dayIndex <= days; dayIndex++)
                    {
                        string date = year + "-" + (i < 10 ? "0" + i.ToString() : i.ToString()) + "-" + (dayIndex < 10 ? "0" + dayIndex.ToString() : dayIndex.ToString());
                        if (File.Exists(@"LichSuDocGia/" + date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2) + ".txt"))
                        {
                            using (StreamReader r = new StreamReader(@"LichSuDocGia/" + date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2) + ".txt"))
                            {
                                string json = r.ReadToEnd();
                                List<DocGia_DTO> items = JsonConvert.DeserializeObject<List<DocGia_DTO>>(json);
                                if (items != null)
                                {
                                    slDocGia += items.Count;
                                }
                            }
                        }
                    }
                    row["Số độc giả đến thư viện"] = slDocGia;
                    table.Rows.Add(row);
                }
            }
            dgvThongKe.DataSource = table;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Chọn chỗ lưu";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "Excel files (*.xlsx) | *.xlsx";
            saveFileDialog.FileName = "unname";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                int month;
                int year;
                if (cbbThang.SelectedIndex == 0)
                    month = 0;
                else
                    month = Int32.Parse(cbbThang.SelectedItem.ToString().Split(' ')[1]);
                year = Int32.Parse(cbbNam.SelectedItem.ToString());
                DataTable table = new DataTable();
                if (month != 0)
                {
                    table.Columns.Add("Ngày", typeof(string));
                    table.Columns.Add("Số sách được mượn", typeof(int));
                    table.Columns.Add("Số sách được trả", typeof(int));
                    table.Columns.Add("Số độc giả đến thư viện", typeof(string));
                    int days = DateTime.DaysInMonth(year, month);
                    for (int i = 1; i <= days; i++)
                    {
                        ThongKe_BLL thongKe = new ThongKe_BLL();
                        string date = year + "-" + (month < 10 ? "0" + month.ToString() : month.ToString()) + "-" + (i < 10 ? "0" + i.ToString() : i.ToString());
                        DataRow row = table.NewRow();
                        row["Ngày"] = "Ngày " + i + "/" + month + "/" + year;
                        row["Số sách được mượn"] = thongKe.getSachMuonNgay(date);
                        row["Số sách được trả"] = thongKe.getSachTraNgay(date);
                        if (File.Exists(@"LichSuDocGia/" + date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2) + ".txt"))
                        {
                            int slDocGia = 0;
                            using (StreamReader r = new StreamReader(@"LichSuDocGia/" + date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2) + ".txt"))
                            {
                                string json = r.ReadToEnd();
                                List<DocGia_DTO> items = JsonConvert.DeserializeObject<List<DocGia_DTO>>(json);
                                if (items != null)
                                {
                                    slDocGia = items.Count;
                                }
                            }
                            row["Số độc giả đến thư viện"] = slDocGia.ToString();
                        }
                        else
                        {
                            row["Số độc giả đến thư viện"] = "Không có dữ liệu";
                        }
                        table.Rows.Add(row);
                    }
                }
                else
                {
                    table.Columns.Add("Tháng", typeof(string));
                    table.Columns.Add("Số sách được mượn", typeof(int));
                    table.Columns.Add("Số sách được trả", typeof(int));
                    table.Columns.Add("Số độc giả đến thư viện", typeof(string));
                    for (int i = 1; i <= 12; i++)
                    {
                        ThongKe_BLL thongKe = new ThongKe_BLL();
                        DataRow row = table.NewRow();
                        row["Tháng"] = "Tháng " + i;
                        row["Số sách được mượn"] = thongKe.getSachMuonThang(i, year);
                        row["Số sách được trả"] = thongKe.getSachTraThang(i, year);
                        int slDocGia = 0;
                        int days = DateTime.DaysInMonth(year, i);
                        for (int dayIndex = 1; dayIndex <= days; dayIndex++)
                        {
                            string date = year + "-" + (i < 10 ? "0" + i.ToString() : i.ToString()) + "-" + (dayIndex < 10 ? "0" + dayIndex.ToString() : dayIndex.ToString());
                            if (File.Exists(@"LichSuDocGia/" + date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2) + ".txt"))
                            {
                                using (StreamReader r = new StreamReader(@"LichSuDocGia/" + date.Substring(0, 4) + date.Substring(5, 2) + date.Substring(8, 2) + ".txt"))
                                {
                                    string json = r.ReadToEnd();
                                    List<DocGia_DTO> items = JsonConvert.DeserializeObject<List<DocGia_DTO>>(json);
                                    if (items != null)
                                    {
                                        slDocGia += items.Count;
                                    }
                                }
                            }
                        }
                        row["Số độc giả đến thư viện"] = slDocGia;
                        table.Rows.Add(row);
                    }
                }
                ExportDataSetToExcel(table, saveFileDialog.FileName, "Thống kê thư viện năm " + year);

                string fileOpen = saveFileDialog.FileName;
                if (MessageBox.Show("Bạn có muốn xem file vừa lưu không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (File.Exists(fileOpen))
                    {
                        FileInfo fi = new FileInfo(fileOpen);
                        System.Diagnostics.Process.Start(fileOpen);
                    }
                    else
                    {
                        MessageBox.Show("File không tồn tại", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void ExportDataSetToExcel(DataTable table, string fileName, string v)
        {
            int inHeaderLength = 3, inColumn = 0, inRow = 0;
            System.Reflection.Missing Default = System.Reflection.Missing.Value;
            //Tao file excel
            OfficeExcel.Application excelApp = new OfficeExcel.Application();
            OfficeExcel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);
            //Tao sheet
            OfficeExcel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default, excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
            //excelWorkSheet.Name = ds.TableName;

            //Tao cot
            for (int i = 0; i < table.Columns.Count; i++)
                excelWorkSheet.Cells[inHeaderLength + 1, i + 1] = table.Columns[i].ColumnName.ToUpper();

            //Tao dong
            for (int m = 0; m < table.Rows.Count; m++)
            {
                for (int n = 0; n < table.Columns.Count; n++)
                {
                    inColumn = n + 1;
                    inRow = inHeaderLength + 2 + m;
                    excelWorkSheet.Cells[inRow, inColumn] = table.Rows[m].ItemArray[n].ToString();
                    if (m % 2 == 0)
                        excelWorkSheet.get_Range("A" + inRow.ToString(), "D" + inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");
                }
            }

            //Tieu de
            OfficeExcel.Range cellRang = excelWorkSheet.get_Range("A1", "D3");
            cellRang.Merge(false);
            cellRang.Interior.Color = System.Drawing.Color.White;
            cellRang.Font.Color = System.Drawing.Color.Red;
            cellRang.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
            cellRang.VerticalAlignment = OfficeExcel.XlVAlign.xlVAlignCenter;
            cellRang.Font.Size = 16;
            excelWorkSheet.Cells[1, 1] = v;

            //Dinh dang cot
            cellRang = excelWorkSheet.get_Range("A4", "D4");
            cellRang.Font.Bold = true;
            cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#F2AB0E");

            excelWorkSheet.Columns[1].ColumnWidth = 15;
            excelWorkSheet.Columns[2].ColumnWidth = 20;
            excelWorkSheet.Columns[3].ColumnWidth = 20;
            excelWorkSheet.Columns[4].ColumnWidth = 30;
            //excelWorkSheet.Columns.AutoFit();

            excelWorkBook.SaveAs(fileName, Default, Default, Default, false, Default, OfficeExcel.XlSaveAsAccessMode.xlNoChange, Default, Default, Default, Default, Default);
            excelWorkBook.Close();
            excelApp.Quit();

            MessageBox.Show("Tạo thành công file execel tại \n " + fileName);
        }

    }
}
