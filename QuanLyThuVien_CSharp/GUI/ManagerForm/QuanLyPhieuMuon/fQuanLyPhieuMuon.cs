using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien_CSharp.GUI.ManagerForm.QuanLyPhieuMuon
{
    public partial class fQuanLyPhieuMuon : Form
    {
        QuanLyThuVien_CSharpDataContext db = new QuanLyThuVien_CSharpDataContext();
        int index = -1;
        String tenDN;

        public fQuanLyPhieuMuon(String TenDangNhap)
        {
            InitializeComponent();
            this.tenDN = TenDangNhap;
        }
        private void fQLPhieuMuon_Load(object sender, EventArgs e)
        {
            loadForm();
        }

        public void loadForm()
        {
            var s = from p in db.PHIEUMUONs
                    select new { p.SoPhieuMuon, p.TenDangNhap, p.MaSinhVien };
            dgvPhieuMuon.DataSource = s.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fThemPhieuMuon f = new fThemPhieuMuon(this, tenDN);
            f.ShowDialog();
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }

        private void dgvPhieuMuon_DoubleClick(object sender, EventArgs e)
        {
            fSuaPhieuMuon f = new fSuaPhieuMuon(this, Int32.Parse(dgvPhieuMuon.Rows[index].Cells[0].Value.ToString()));
            f.ShowDialog();
            index = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Equals(""))
                {
                    loadForm();
                }
                else if (cbbSearch.SelectedIndex == 0)
                {
                    var p = from z in db.PHIEUMUONs
                            where SqlMethods.Equals(z.SoPhieuMuon.ToString(), txtSearch.Text)
                            select new { z.SoPhieuMuon, z.TenDangNhap, z.MaSinhVien };
                    dgvPhieuMuon.DataSource = p;
                }
                else if (cbbSearch.SelectedIndex == 1)
                {
                    var p = from z in db.PHIEUMUONs
                            where SqlMethods.Like(z.TenDangNhap, "%" + txtSearch.Text + "%")
                            select new { z.SoPhieuMuon, z.TenDangNhap, z.MaSinhVien };
                    dgvPhieuMuon.DataSource = p;
                }
                else if (cbbSearch.SelectedIndex == 2)
                {
                    var p = from z in db.PHIEUMUONs
                            where SqlMethods.Like(z.MaSinhVien, "%" + txtSearch.Text + "%")
                            select new { z.SoPhieuMuon, z.TenDangNhap, z.MaSinhVien };
                    dgvPhieuMuon.DataSource = p;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
    }
}
