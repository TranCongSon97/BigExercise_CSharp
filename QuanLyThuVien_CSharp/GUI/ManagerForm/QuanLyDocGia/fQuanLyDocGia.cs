using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;
using FastMember;
using OfficeExcel = Microsoft.Office.Interop.Excel;
using QuanLyThuVien_CSharp.DTO;

namespace QuanLyThuVien_CSharp.GUI.ManagerForm.QLDocGia
{
    public partial class fQLDocGia : Form
    {
        String currentDate;
        List<DocGia_DTO> items;
        int index = -1;
        int i = 0;
        bool isCurrent;
        public fQLDocGia()
        {
            InitializeComponent();
            loadForm();
        }

        public void loadForm()
        {
            timer.Start();
            DateTime localDate = DateTime.Now;
            currentDate = localDate.Date.ToString(new CultureInfo("en-GB")).Split(' ')[0];
            Directory.CreateDirectory("LichSuDocGia");
            String ngay = currentDate.Substring(0, 2);
            String thang = currentDate.Substring(3, 2);
            String nam = currentDate.Substring(6);
            using (StreamWriter writer = File.AppendText(@"LichSuDocGia/" + nam + thang + ngay + ".txt")) ;
            loadCombo();
            cbbDate.SelectedIndex = 0;
            cbbSearch.SelectedIndex = -1;
        }

        public void loadCombo()
        {
            cbbDate.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(@"LichSuDocGia");
            FileInfo[] Files = d.GetFiles("*.txt");
            for (int i = Files.Length - 1; i >= 0; i--)
            {
                var file = Files[i];
                string nam = file.Name.Substring(0, 4);
                string thang = file.Name.Substring(4, 2);
                string ngay = file.Name.Substring(6, 2);
                cbbDate.Items.Add(ngay + "/" + thang + "/" + nam);
            }
        }

        public void loadList()
        {
            i = 0;
            String currentchooseDate = cbbDate.SelectedItem.ToString();
            String ngay = currentchooseDate.Substring(0, 2);
            String thang = currentchooseDate.Substring(3, 2);
            String nam = currentchooseDate.Substring(6);
            using (StreamReader r = new StreamReader(@"LichSuDocGia/" + nam + thang + ngay + ".txt"))
            {
                String js = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<DocGia_DTO>>(js);
                if (items != null)
                {
                    dgvList.DataSource = items;
                }
                else
                {
                    items = new List<DocGia_DTO>();
                    dgvList.DataSource = items;
                }
            }
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        public void searchStudentName()
        {
            i = 1;
            String chooseDate = cbbDate.SelectedItem.ToString();
            String ngay = chooseDate.Substring(0, 2);
            String thang = chooseDate.Substring(3, 2);
            String nam = chooseDate.Substring(6);
            using (StreamReader reader = new StreamReader(@"LichSuDocGia" + "/" + nam + thang + ngay + ".txt"))
            {
                String js = reader.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<DocGia_DTO>>(js);
                List<DocGia_DTO> newList = new List<DocGia_DTO>();
                foreach (var a in items)
                {
                    if (a.hoTen.Contains(txtSearch.Text))
                        newList.Add(a);
                }
                if (newList != null)
                {
                    dgvList.DataSource = newList;
                }
                else
                {
                    newList = new List<DocGia_DTO>();
                    dgvList.DataSource = newList;
                }
            }
        }

        public void searchStudentCode()
        {
            i = 2;
            String chooseDate = cbbDate.SelectedItem.ToString();
            String ngay = chooseDate.Substring(0, 2);
            String thang = chooseDate.Substring(3, 2);
            String nam = chooseDate.Substring(6);
            using (StreamReader reader = new StreamReader(@"LichSuDocGia" + "/" + nam + thang + ngay + ".txt"))
            {
                String js = reader.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<DocGia_DTO>>(js);
                List<DocGia_DTO> newList = new List<DocGia_DTO>();
                foreach (var a in items)
                {
                    if (a.maSV.Contains(txtSearch.Text))
                        newList.Add(a);
                }
                if (newList != null)
                {
                    dgvList.DataSource = newList;
                }
                else
                {
                    newList = new List<DocGia_DTO>();
                    dgvList.DataSource = newList;
                }
            }
        }

        public void addReader(String TenDocGia, String MaSV, String NgayNhap)
        {
            String chooseDate = cbbDate.SelectedItem.ToString();
            String ngay = chooseDate.Substring(0, 2);
            String thang = chooseDate.Substring(3, 2);
            String nam = chooseDate.Substring(6);
            items.Add(new DocGia_DTO()
            {
                hoTen = TenDocGia,
                maSV = MaSV,
                thoiGian = DateTime.Now.ToString("h:mm:ss tt")
            });

            String jsOut = JsonConvert.SerializeObject(items.ToArray(), Formatting.Indented);

            //write file
            File.WriteAllText(@"LichSuDocGia/" + NgayNhap + ".txt", jsOut);
            txtStudentName.Clear();
            txtStudentCode.Clear();
            txtStudentName.Focus();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentName.Text.Equals(""))
                {
                    txtStudentName.Focus();
                    MessageBox.Show("Tên không được để trống");
                    return;
                }
                if (txtStudentCode.Text.Equals(""))
                {
                    txtStudentCode.Focus();
                    MessageBox.Show("Mã sinh viên không được để trống");
                    return;
                }
                String chooseDate = cbbDate.SelectedItem.ToString();
                String ngay = chooseDate.Substring(0, 2);
                String thang = chooseDate.Substring(3, 2);
                String nam = chooseDate.Substring(6);
                addReader(txtStudentName.Text, txtStudentCode.Text, nam + thang + ngay);
                loadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
        }
        private void dgvList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                txtStudentName.Text = dgvList.Rows[index].Cells[0].Value.ToString();
                txtStudentCode.Text = dgvList.Rows[index].Cells[1].Value.ToString();
                if (isCurrent)
                {
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                }
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (index < 0)
                MessageBox.Show("Vui lòng chọn đối tượng cần sửa");
            else
            {
                String chooseDate = cbbDate.SelectedItem.ToString();
                String ngay = chooseDate.Substring(0, 2);
                String thang = chooseDate.Substring(3, 2);
                String nam = chooseDate.Substring(6);
                if (i == 0)
                {
                    items[index].hoTen = txtStudentName.Text;
                    items[index].maSV = txtStudentCode.Text;
                }
                else if (i == 1)
                {
                    int realIndex = -1;
                    foreach (var a in items)
                    {
                        realIndex++;
                        if (a.hoTen.Contains(txtSearch.Text))
                            i--;
                        if (i == 0)
                            break;
                    }
                    items[realIndex].hoTen = txtStudentName.Text;
                    items[realIndex].maSV = txtStudentCode.Text;
                }
                else if (i == 2)
                {
                    int realIndex = -1;
                    foreach (var a in items)
                    {
                        realIndex++;
                        if (a.maSV.Contains(txtSearch.Text))
                            i--;
                        if (i == 0)
                            break;
                    }
                    items[realIndex].hoTen = txtStudentName.Text;
                    items[realIndex].maSV = txtStudentCode.Text;
                }
                String jsOut = JsonConvert.SerializeObject(items.ToArray(), Formatting.Indented);

                //write string to file
                File.WriteAllText(@"LichSuDocGia/" + nam + thang + ngay + ".txt", jsOut);
            }
            txtStudentName.Clear();
            txtStudentCode.Clear();
            loadList();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                int index = dgvList.CurrentCell.RowIndex;
                if (index < 0)
                    MessageBox.Show("Vui lòng chọn đối tượng cần xóa");
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắc muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        String chooseDate = cbbDate.SelectedItem.ToString();
                        String ngay = chooseDate.Substring(0, 2);
                        String thang = chooseDate.Substring(3, 2);
                        String nam = chooseDate.Substring(6);
                        if (i == 0)
                            items.RemoveAt(index);
                        else if (i == 1)
                        {
                            int realIndex = -1;
                            foreach (var a in items)
                            {
                                realIndex++;
                                if (a.hoTen.Contains(txtSearch.Text))
                                    i--;
                                if (i == 0)
                                    break;
                            }
                            items.RemoveAt(realIndex);
                        }
                        else if (i == 2)
                        {
                            int realIndex = -1;
                            foreach (var a in items)
                            {
                                realIndex++;
                                if (a.maSV.Contains(txtSearch.Text))
                                    i--;
                                if (i == 0)
                                    break;
                            }
                            items.RemoveAt(realIndex);
                        }
                        String jsOut = JsonConvert.SerializeObject(items.ToArray(), Formatting.Indented);

                        //write string to file
                        File.WriteAllText(@"LichSuDocGia/" + nam + thang + ngay + ".txt", jsOut);
                        index = -1;
                    }
                }
                txtStudentName.Clear();
                txtStudentCode.Clear();
                loadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
        }
        private void cbbDate_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!cbbDate.SelectedItem.Equals(currentDate))
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                isCurrent = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                isCurrent = true;
            }
            loadList();
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Equals(""))
                    loadCombo();
                else if (cbbSearch.SelectedIndex == 0)
                    searchStudentName();
                else if (cbbSearch.SelectedIndex == 1)
                    searchStudentCode();
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
        }

        public void ExportDateSetToExcel(DataTable ds, String filePath)
        {
            int inHeaderLength = 3, inColumn = 0, inRow = 0;
            System.Reflection.Missing Default = System.Reflection.Missing.Value;
            //tạo file excel
            OfficeExcel.Application excelApp = new OfficeExcel.Application();
            OfficeExcel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);
            //tạo sheet
            OfficeExcel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default,
                excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
            //tạo cột
            excelWorkSheet.Cells[inHeaderLength + 1, 1] = "Họ và tên";
            excelWorkSheet.Cells[inHeaderLength + 1, 2] = "Mã sinh viên";
            excelWorkSheet.Cells[inHeaderLength + 1, 3] = "Thời gian đến";
            //tạo dòng
            for (int j = 0; j < ds.Rows.Count; j++)
            {
                for (int k = 0; k < ds.Columns.Count; k++)
                {
                    inColumn = k + 1;
                    inRow = inHeaderLength + 2 + j;
                    excelWorkSheet.Cells[inRow, inColumn] = ds.Rows[j].ItemArray[k].ToString();
                    if (j % 2 == 0)
                    {
                        excelWorkSheet.get_Range("A" + inRow.ToString(), "C" +
                            inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");
                    }
                }
            }
            //Tiêu đề
            OfficeExcel.Range cellRang = excelWorkSheet.get_Range("A1", "C3");
            cellRang.Merge(false);
            cellRang.Interior.Color = System.Drawing.Color.White;
            cellRang.Font.Color = System.Drawing.Color.Gray;
            cellRang.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
            cellRang.VerticalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
            cellRang.Font.Size = 16;
            excelWorkSheet.Cells[1, 1] = "Danh sách đến thư viện ngày " + cbbDate.SelectedItem.ToString();

            //Định dạng cột
            cellRang = excelWorkSheet.get_Range("A4", "C4");
            cellRang.Font.Bold = true;
            cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");

            excelWorkSheet.Columns[1].ColumnWidth = 30;
            excelWorkSheet.Columns[2].ColumnWidth = 30;
            excelWorkSheet.Columns[3].ColumnWidth = 50;
            excelWorkSheet.Rows[3].ColumnWidth = 50;

            excelWorkBook.SaveAs(filePath, Default, Default, Default, false, Default,
                OfficeExcel.XlSaveAsAccessMode.xlNoChange, Default, Default, Default, Default, Default);
            excelWorkBook.Close();
            excelApp.Quit();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Chọn chỗ lưu";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "Excel files (*.xlsx) | *.xlsx";
            saveFileDialog.FileName = "LichSuDocGia" +cbbDate.Text;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String chooseDate = cbbDate.SelectedItem.ToString();
                String ngay = chooseDate.Substring(0, 2);
                String thang = chooseDate.Substring(3, 2);
                String nam = chooseDate.Substring(6);
                using (StreamReader reader = new StreamReader(@"LichSuDocGia/" + nam + thang + ngay + ".txt"))
                {
                    String js = reader.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<DocGia_DTO>>(js);
                    if (items == null)
                    {
                        items = new List<DocGia_DTO>();
                    }
                }
                DataTable table = new DataTable();
                using (var reader = ObjectReader.Create((List<DocGia_DTO>)dgvList.DataSource))
                {
                    table.Load(reader);
                }
                ExportDateSetToExcel(table, saveFileDialog.FileName);
                MessageBox.Show("Tạo thành công file execel tại \n " + saveFileDialog.FileName);
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

        private void btnDeleteHistory_Click(object sender, EventArgs e)
        {
            fDeleteEntry f = new fDeleteEntry(this);
            f.ShowDialog();
        }
    }
}
