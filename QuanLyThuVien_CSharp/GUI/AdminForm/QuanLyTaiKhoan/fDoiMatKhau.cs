using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien_CSharp.GUI.QuanLyTaiKhoan
{
    public partial class fDoiMatKhau : Form
    {
        QuanLyThuVien_CSharpDataContext dataContext = new QuanLyThuVien_CSharpDataContext();
        String userName;

        public fDoiMatKhau(string username)
        {
            InitializeComponent();
            userName = username;
        }

        private void ChangePassword()
        {
            try
            {
                if (txtOldPassword.Text.Equals("") || txtNewPassword.Text.Equals("") || txtConfirmPassword.Text.Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin", "Có lỗi xảy ra");
                    return;
                }
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Xác nhận mật khẩu mới không đúng", "Có lỗi xảy ra");
                    return;
                }
                if (dataContext.TAIKHOANs.Where(p => p.MatKhau == txtOldPassword.Text).Count() <= 0)
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác", "Có lỗi xảy ra");
                    return;
                }
                if (dataContext.TAIKHOANs.Where(p => p.MatKhau == txtOldPassword.Text).Count() > 0)
                {
                    var querry = (from p in dataContext.TAIKHOANs
                                  where p.TenDangNhap == userName
                                  select p).FirstOrDefault<TAIKHOAN>();
                    querry.MatKhau = txtNewPassword.Text;
                    dataContext.SubmitChanges();
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Dispose();
                }
                                  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
            }
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
