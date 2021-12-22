using QuanLyThuVien_CSharp.GUI.AdminForm.QuanLyDanhMuc;
using QuanLyThuVien_CSharp.GUI.AdminForm.QuanLySach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuVien_CSharp.GUI.AdminForm.QuanLySach
{
    public partial class fQuanLySach : Form
    {
        QuanLyThuVien_CSharpDataContext dataContext = new QuanLyThuVien_CSharpDataContext();
        int index = -1;
        public fQuanLySach()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            cbbTimKiem.Items.Clear();
            cbbTimKiem.Items.Add("Tên sách");
            cbbTimKiem.Items.Add("Tác giả");
            cbbTimKiem.Items.Add("Nhà xuất bản");
            cbbTimKiem.Items.Add("Năm xuất bản");
            cbbTimKiem.Items.Add("Tên danh mục");
            cbbTimKiem.SelectedIndex = 0;
            txtNoiDungTim.Clear();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            try
            {
                var s = from p in dataContext.SACHes
                        join k in dataContext.DANHMUCs
                        on p.MaDanhMuc equals k.MaDanhMuc
                        select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                dgvSach.DataSource = s.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemSach themSach = new fThemSach(this);
            themSach.ShowDialog();
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            fSuaThongTinSach suaThongTinSach = new fSuaThongTinSach(this, Int32.Parse(dgvSach.Rows[index].Cells[1].Value.ToString()));
            suaThongTinSach.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá sách này không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var xoa = dataContext.SACHes.Where(p => p.MaSach == Int32.Parse(dgvSach.Rows[index].Cells[1].Value.ToString()));

                    foreach (var i in xoa)
                    {
                        dataContext.SACHes.DeleteOnSubmit(i);
                        dataContext.SubmitChanges();
                    }
                    LoadData();
                    MessageBox.Show("Xóa thành công", "Successfully", MessageBoxButtons.OK);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoiDungTim.Text.Equals(""))
                {
                    MessageBox.Show("Nếu muốn tìm kiếm thì nhập nội dung nhé!", "Empty", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    switch (cbbTimKiem.SelectedIndex)
                    {
                        case 0:
                            var s = from p in dataContext.SACHes
                                    join k in dataContext.DANHMUCs
                                    on p.MaDanhMuc equals k.MaDanhMuc
                                    where SqlMethods.Like(p.TenSach, "%" + txtNoiDungTim.Text + "%")
                                    select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                        case 1:
                            s = from p in dataContext.SACHes
                                join k in dataContext.DANHMUCs
                                on p.MaDanhMuc equals k.MaDanhMuc
                                where SqlMethods.Like(p.TacGia, "%" + txtNoiDungTim.Text + "%")
                                select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                        case 2:
                            s = from p in dataContext.SACHes
                                join k in dataContext.DANHMUCs
                                on p.MaDanhMuc equals k.MaDanhMuc
                                where SqlMethods.Like(p.NhaXuatBan, "%" + txtNoiDungTim.Text + "%")
                                select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                        case 3:
                            s = from p in dataContext.SACHes
                                join k in dataContext.DANHMUCs
                                on p.MaDanhMuc equals k.MaDanhMuc
                                where (p.NamXuatBan.ToString().Contains(txtNoiDungTim.Text))
                                select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                        case 4:
                            s = from p in dataContext.SACHes
                                join k in dataContext.DANHMUCs
                                on p.MaDanhMuc equals k.MaDanhMuc
                                where SqlMethods.Like(k.TenDanhMuc, "%" + txtNoiDungTim.Text + "%")
                                select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTimKiem.SelectedIndex == 0) label2.Text = "Nhập tên sách";
            if (cbbTimKiem.SelectedIndex == 1) label2.Text = "Nhập tên tác giả";
            if (cbbTimKiem.SelectedIndex == 2) label2.Text = "Nhà xuất bản";
            if (cbbTimKiem.SelectedIndex == 3) label2.Text = "Thời gian xuất bản";
            if (cbbTimKiem.SelectedIndex == 4) label2.Text = "Nhập tên danh mục";
        }

        private void ExportDataSetToExcel(DataTable table, object fileName, int tongSach)
        {
            int inHeaderLength = 3, inColumn = 0, inRow = 0;
            System.Reflection.Missing Default = System.Reflection.Missing.Value;
            //Tao file excel
            OfficeExcel.Application excelApp = new OfficeExcel.Application();
            OfficeExcel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);
            //Tao sheet
            OfficeExcel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default, excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
            //excelWorkSheet.Name = table.TableName;

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
                        excelWorkSheet.get_Range("A" + inRow.ToString(), "H" + inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#DCF3F6");
                }
            }
            excelWorkSheet.Cells[table.Rows.Count + inHeaderLength + 2, 8] = "Tổng sách: " + tongSach.ToString();
            excelWorkSheet.get_Range("H" + (table.Rows.Count + inHeaderLength + 2).ToString(), "H" + (table.Rows.Count + inHeaderLength + 2).ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");

            //Tieu de
            OfficeExcel.Range cellRang = excelWorkSheet.get_Range("A1", "H3");
            cellRang.Merge(false);
            cellRang.Interior.Color = System.Drawing.Color.White;
            cellRang.Font.Color = System.Drawing.Color.Red;
            cellRang.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
            cellRang.VerticalAlignment = OfficeExcel.XlVAlign.xlVAlignCenter;
            cellRang.Font.Size = 16;
            excelWorkSheet.Cells[1, 1] = "Danh sách các sách trong kho";

            //Dinh dang cot
            cellRang = excelWorkSheet.get_Range("A4", "H4");
            cellRang.Font.Bold = true;
            cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#F2AB0E");
            cellRang.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
            cellRang.VerticalAlignment = OfficeExcel.XlVAlign.xlVAlignCenter;
            excelWorkSheet.Rows[4].RowHeight = 20;

            excelWorkSheet.Columns[1].ColumnWidth = 10;
            excelWorkSheet.Columns[2].ColumnWidth = 25;
            excelWorkSheet.Columns[3].ColumnWidth = 25;
            excelWorkSheet.Columns[4].ColumnWidth = 20;
            excelWorkSheet.Columns[5].ColumnWidth = 20;
            excelWorkSheet.Columns[6].ColumnWidth = 25;
            excelWorkSheet.Columns[7].ColumnWidth = 15;
            excelWorkSheet.Columns[8].ColumnWidth = 30;
            //excelWorkSheet.Columns.AutoFit();

            excelWorkBook.SaveAs(fileName, Default, Default, Default, false, Default, OfficeExcel.XlSaveAsAccessMode.xlNoChange, Default, Default, Default, Default, Default);
            excelWorkBook.Close();
            excelApp.Quit();

            MessageBox.Show("Tạo thành công file excel tại \n " + fileName);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Chọn chỗ lưu";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "Excel file (*.xlsx) | *.xlsx";
            saveFileDialog.FileName = "Untitled";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var sach = from s in dataContext.SACHes
                           join d in dataContext.DANHMUCs
                           on s.MaDanhMuc equals d.MaDanhMuc
                           select new { s.MaSach, s.TenSach, s.TacGia, s.NhaXuatBan, d.TenDanhMuc, s.NamXuatBan, s.LanXuatBan, s.SoLuong };
                DataTable table = new DataTable();
                table.Columns.Add("Mã sách", typeof(int));
                table.Columns.Add("Tên sách", typeof(string));
                table.Columns.Add("Tác giả", typeof(string));
                table.Columns.Add("Nhà xuất bản", typeof(string));
                table.Columns.Add("Danh mục", typeof(string));
                table.Columns.Add("Năm xuất bản", typeof(DateTime));
                table.Columns.Add("Lần xuất bản", typeof(int));
                table.Columns.Add("Số lượng trong kho", typeof(int));

                int tongsach = 0;
                foreach (var a in sach)
                {
                    DataRow row = table.NewRow();
                    row["Mã sách"] = a.MaSach;
                    row["Tên sách"] = a.TenSach;
                    row["Tác giả"] = a.TacGia;
                    row["Nhà xuất bản"] = a.NhaXuatBan;
                    row["Danh mục"] = a.TenDanhMuc;
                    row["Năm xuất bản"] = a.NamXuatBan;
                    row["Lần xuất bản"] = a.LanXuatBan;
                    row["Số lượng trong kho"] = a.SoLuong;
                    tongsach += (int)a.SoLuong;
                    table.Rows.Add(row);
                }
                ExportDataSetToExcel(table, saveFileDialog.FileName, tongsach);


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

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            fQuanLyDanhMuc fDanhMuc = new fQuanLyDanhMuc();
            fDanhMuc.ShowDialog();
        }
    }
}
