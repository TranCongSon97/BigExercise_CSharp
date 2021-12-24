using QuanLyThuVien_CSharp.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien_CSharp.GUI.AdminForm.QuanLySach
{
    public partial class fSuaThongTinSach : Form
    {
        QuanLyThuVien_CSharpDataContext dataContext = new QuanLyThuVien_CSharpDataContext();
        fQuanLySach QuanLySach;
        int MaSach;
        bool textChange;
        public fSuaThongTinSach()
        {
            InitializeComponent();
        }

        public fSuaThongTinSach(fQuanLySach f, int _MaSach)
        {
            InitializeComponent();
            QuanLySach = f;
            MaSach = _MaSach;
            this.LoadData();
        }

        public void LoadData()
        {
            cbbTenDanhMuc.DataSource = dataContext.DANHMUCs.Select(p => p);
            cbbTenDanhMuc.DisplayMember = "TenDanhMuc";
            cbbTenDanhMuc.ValueMember = "MaDanhMuc";

            var sach = dataContext.SACHes.Single(p => p.MaSach == MaSach);
            cbbTenDanhMuc.SelectedValue = sach.MaDanhMuc;
            txtTenSach.Text = sach.TenSach;
            txtTacGia.Text = sach.TacGia;
            nudSoLuong.Text = sach.SoLuong.ToString();
            txtGiaMuon.Text = sach.GiaMuon.ToString();
            txtNhaXuatBan.Text = sach.NhaXuatBan;
            dtpNamXuatBan.Value = sach.NamXuatBan.Value;
            nudLanXuatBan.Text = sach.LanXuatBan.ToString();
            ptbAnhSach.Image = new ConvertImages().ConvertBytesToImage((byte[])sach.AnhSach.ToArray());

            textChange = false;
            btnLuu.Enabled = false;
            btnXoaNDNhap.Enabled = true;
        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            textChange = true;
            btnLuu.Enabled = true;
            btnXoaNDNhap.Enabled = true;
        }

        private void txtTacGia_TextChanged(object sender, EventArgs e)
        {
            textChange = true;
            btnLuu.Enabled = true;
            btnXoaNDNhap.Enabled = true;
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            textChange = true;
            btnLuu.Enabled = true;
            btnXoaNDNhap.Enabled = true;
        }

        private void txtGiaMuon_TextChanged(object sender, EventArgs e)
        {
            textChange = true;
            btnLuu.Enabled = true;
            btnXoaNDNhap.Enabled = true;
        }

        private void txtNhaXuatBan_TextChanged(object sender, EventArgs e)
        {
            textChange = true;
            btnLuu.Enabled = true;
            btnXoaNDNhap.Enabled = true;
        }

        private void dtpNamXuatBan_ValueChanged(object sender, EventArgs e)
        {
            textChange = true;
            btnLuu.Enabled = true;
            btnXoaNDNhap.Enabled = true;
        }

        private void nudLanXuatBan_ValueChanged(object sender, EventArgs e)
        {
            textChange = true;
            btnLuu.Enabled = true;
            btnXoaNDNhap.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenSach.Text.Equals(""))
                {
                    MessageBox.Show("Tên sách không được để trống!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtTacGia.Text.Equals(""))
                {
                    MessageBox.Show("Tên tác giả không được để trống!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!UInt32.TryParse(txtGiaMuon.Text, out UInt32 o))
                {
                    MessageBox.Show("Giá mượn phải là số nguyên dương!", "Format error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtNhaXuatBan.Text.Equals(""))
                {
                    MessageBox.Show("Tên nhà xuất bản không được để trống!", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SACH sachNew = dataContext.SACHes.Single(p => p.MaSach == MaSach);
                sachNew.TenSach = txtTenSach.Text;
                sachNew.TacGia = txtTacGia.Text;
                sachNew.SoLuong = Int32.Parse(nudSoLuong.Text);
                sachNew.GiaMuon = Int32.Parse(txtGiaMuon.Text);
                sachNew.NhaXuatBan = txtNhaXuatBan.Text;
                sachNew.NamXuatBan = dtpNamXuatBan.Value;
                sachNew.LanXuatBan = Int32.Parse(nudLanXuatBan.Text);
                sachNew.MaDanhMuc = Int32.Parse(cbbTenDanhMuc.SelectedValue.ToString());
                sachNew.AnhSach = new ConvertImages().ConvertImageToBytes(ptbAnhSach.Image);

                dataContext.SubmitChanges();
                QuanLySach.LoadData();

                textChange = false;
                MessageBox.Show("Sửa thành công!", "Successfully", MessageBoxButtons.OK);
                this.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThayAnh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Chọn ảnh";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif";
            Image img;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    img = Image.FromFile(openFileDialog1.FileName);
                    ptbAnhSach.Image = img;
                    btnLuu.Enabled = true;
                }
                catch (FileNotFoundException fileEx)
                {
                    MessageBox.Show(fileEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (textChange == true)
            {
                if (MessageBox.Show("Bạn có muốn lưu lại thông tin sách không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    btnLuu_Click(sender, e);
                }
            }
            this.Dispose();
        }

        private void btnXoaNDNhap_Click(object sender, EventArgs e)
        {
            cbbTenDanhMuc.SelectedIndex = 0;
            txtTenSach.Clear();
            ActiveControl = txtTenSach;
            txtTacGia.Clear();
            txtNhaXuatBan.Clear();
            txtGiaMuon.Clear();

            btnLuu.Enabled = false;
            btnXoaNDNhap.Enabled = false;
            textChange = false;
        }

        private void fSuaThongTinSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textChange == true)
            {
                if (MessageBox.Show("Bạn có muốn lưu lại thông tin sách không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    btnLuu_Click(sender, e);
                }
            }
            this.Dispose();
        }

        private void txtTacGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtGiaMuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void cbbTenDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            textChange = true;
            btnLuu.Enabled = true;
            btnXoaNDNhap.Enabled = true;
        }
    }
}
