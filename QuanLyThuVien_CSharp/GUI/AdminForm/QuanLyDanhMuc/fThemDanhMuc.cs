using QuanLyThuVien_CSharp.GUI.AdminForm.QuanLySach;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien_CSharp.GUI.AdminForm.QuanLyDanhMuc
{
    public partial class fThemDanhMuc : Form
    {
        QuanLyThuVien_CSharpDataContext dataContext = new QuanLyThuVien_CSharpDataContext();
        fThemSach ThemSach;
        public fThemDanhMuc()
        {
            InitializeComponent();
        }
        public fThemDanhMuc(fThemSach f)
        {
            InitializeComponent();
            ThemSach = f;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenDanhMuc.Text.Equals(""))
                {
                    ActiveControl = txtTenDanhMuc;
                    MessageBox.Show("Tên danh mục không được để trống", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var danhMuc = dataContext.DANHMUCs.Where(p => p.TenDanhMuc == txtTenDanhMuc.Text);

                if (danhMuc.Count() > 0)
                {
                    MessageBox.Show("Tên danh mục đã trùng trong hệ thống", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DANHMUC themDanhMuc = new DANHMUC();
                themDanhMuc.TenDanhMuc = txtTenDanhMuc.Text;

                dataContext.DANHMUCs.InsertOnSubmit(themDanhMuc);
                dataContext.SubmitChanges();
                ThemSach.LoadData();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
