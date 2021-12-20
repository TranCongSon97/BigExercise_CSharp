using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuVien_CSharp.GUI.AdminForm.QuanLyTaiKhoan
{
    public partial class fSuaTaiKhoan : Form
    {
        QuanLyThuVien_CSharpDataContext dataContext = new QuanLyThuVien_CSharpDataContext();
        fQuanLyTaiKhoan QuanLyTaiKhoan;
        String userName;
        int IDAccount;

        public fSuaTaiKhoan(fQuanLyTaiKhoan f, string username)
{
            InitializeComponent();
            QuanLyTaiKhoan = f;
            userName = username;
            prepare();
        }
        private void prepare()
        {
            try
            {
                var s = from p in dataContext.TAIKHOANs
                        where p.TenDangNhap == userName
                        select new { p.IDTaiKhoan, AnhDaiDien = p.AnhDaiDien.ToArray(), p.TenDangNhap, p.MatKhau, p.TenNguoiDung, p.LoaiTaiKhoan, p.TinhTrang };
                foreach (var i in s.ToList())
                {
                    IDAccount = i.IDTaiKhoan;
                    lbl_image.Image = new BLL.ConvertImages().ConvertBytesToImage(i.AnhDaiDien);
                    txtUsername.Text = i.TenDangNhap;
                    txtName.Text = i.TenNguoiDung;
                    if (i.TinhTrang == true) rdbEnabled.Checked = true;
                    else rdDisabled.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
            }
        }

        private void btnChooseImg_Click(object sender, EventArgs e)
        {
            openImg.Title = "chọn ảnh";
            openImg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            Image img;
            if (openImg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img = Image.FromFile(openImg.FileName);
                    lbl_image.Image = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
                }
            }
        }

        private void editTaiKhoan()
        {
            try
            {
                if (txtName.Text.Equals(""))
                {
                    MessageBox.Show("Tên người dùng không được bỏ trống", "Có lỗi xảy ra");
                    return;
                }
                else
                {
                    var querry = (from p in dataContext.TAIKHOANs
                                  where p.IDTaiKhoan == IDAccount
                                  select p).FirstOrDefault<TAIKHOAN>();
                    querry.AnhDaiDien = new BLL.ConvertImages().ConvertImageToBytes(lbl_image.Image);
                    querry.TenNguoiDung = txtName.Text;
                    dataContext.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    this.Dispose();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Có lỗi xảy ra");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {           
            editTaiKhoan();           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
