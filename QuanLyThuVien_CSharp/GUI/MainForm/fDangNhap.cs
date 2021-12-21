using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien_CSharp.GUI.MainForm
{
    public partial class fDangNhap : Form
    {
        QuanLyThuVien_CSharpDataContext dataContext = new QuanLyThuVien_CSharpDataContext();
        string status, tenND;
        int accountType;

        public fDangNhap()
        {
            InitializeComponent();
            txtPassword.Clear();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == "" || txtUsername.Text == "")
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu chưa được nhập", "Thông báo");
                    return;
                }
                if (dataContext.TAIKHOANs.Where(p => p.TenDangNhap == txtUsername.Text && p.MatKhau == txtPassword.Text).Count() > 0)
                {
                    var s = from p in dataContext.TAIKHOANs
                            where p.TenDangNhap == txtUsername.Text && p.MatKhau == txtPassword.Text
                            select new { p.LoaiTaiKhoan, p.TinhTrang, p.TenNguoiDung };

                    foreach (var i in s)
                    {
                        accountType = i.LoaiTaiKhoan.Value;
                        status = i.TinhTrang.ToString();
                        tenND = i.TenNguoiDung;
                    }
                    if (status == "false")
                    {
                        MessageBox.Show("Tài khoản bị vô hiệu hóa!", "Thông báo");
                    }
                    this.Hide();
                    fTrangChu fAdmin = new fTrangChu(txtUsername.Text, tenND, accountType);
                    fAdmin.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Lỗi đăng nhập");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

    }
}
