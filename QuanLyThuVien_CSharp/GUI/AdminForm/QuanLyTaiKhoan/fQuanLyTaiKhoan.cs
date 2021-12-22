using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien_CSharp.GUI.AdminForm.QuanLyTaiKhoan
{
    public partial class fQuanLyTaiKhoan : Form
    {
        int index = -1;
        QuanLyThuVien_CSharpDataContext dataContext = new QuanLyThuVien_CSharpDataContext();

        public fQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                var s = from p in dataContext.TAIKHOANs
                        select new { AnhDaiDien = p.AnhDaiDien.ToArray(), p.TenDangNhap, p.MatKhau, p.TenNguoiDung, p.LoaiTaiKhoan, p.TinhTrang };
                dgvAccount.DataSource = s.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
            }
        }

        private void fQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            LoadData();
            dgvAccount.ClearSelection();
            cbbSearch.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fThemTaiKhoan f = new fThemTaiKhoan(this);
            f.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            fSuaTaiKhoan f = new fSuaTaiKhoan(this, dgvAccount.Rows[index].Cells[1].Value.ToString());
            f.ShowDialog();
            LoadData();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                if (index >= 0)
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
            }
        }

        private void deleteTaiKhoan()
        {
            try
            {
                if (index < 0)
                {
                    MessageBox.Show("Vui lòng chọn đối tượng cần xoá!");
                }
                else
                    if (MessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản " + dgvAccount.Rows[index].Cells[1].Value.ToString() + " không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var deleteAccount = dataContext.TAIKHOANs.Where(p => p.TenDangNhap == dgvAccount.Rows[index].Cells[1].Value.ToString());
                    foreach (var i in deleteAccount)
                    {
                        dataContext.TAIKHOANs.DeleteOnSubmit(i);
                        dataContext.SubmitChanges();
                    }
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteTaiKhoan();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            fQuanLyTaiKhoan_Load(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbSearch.Text == "Tên đăng nhập")
                {
                    var s = from p in dataContext.TAIKHOANs
                            where p.TenDangNhap.Contains(txtSearch.Text)
                            select new { AnhDaiDien = p.AnhDaiDien.ToArray(), p.TenDangNhap, p.MatKhau, p.TenNguoiDung, p.LoaiTaiKhoan, p.TinhTrang };
                    dgvAccount.DataSource = s.ToList();
                }
                else if (cbbSearch.Text == "Tên người dùng")
                {
                    var s = from p in dataContext.TAIKHOANs
                            where p.TenNguoiDung.Contains(txtSearch.Text)
                            select new { AnhDaiDien = p.AnhDaiDien.ToArray(), p.TenDangNhap, p.MatKhau, p.TenNguoiDung, p.LoaiTaiKhoan, p.TinhTrang };
                    dgvAccount.DataSource = s.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
            }
        }
    }
}
