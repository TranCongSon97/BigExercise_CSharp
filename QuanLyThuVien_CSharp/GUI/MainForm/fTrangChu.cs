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
    public partial class fTrangChu : Form
    {
        private Button currentBtn;
        private Form currentChildForm;
        bool userMenu = false;
        string userName, tenND;
        int accountType;
        public fTrangChu()
        {
            InitializeComponent();
            LoadData();
        }
        public fTrangChu(string userName, string tenND, int accountType)
        {
            InitializeComponent();
            this.userName = userName;
            this.tenND = tenND;
            this.accountType = accountType;
            LoadData();
        }
        public void LoadData()
        {
            btnDoiMatKhau.Visible = false;
            btnDangXuat.Visible = false;
            btnUser.Text = tenND;
            if(currentChildForm!=null)
                currentChildForm.Close();
            if(accountType == 0)
            {
                btnQuanLySach.Visible = true;
                btnQuanLyTaiKhoan.Visible = true;
                btnThongKe.Visible = true;
                btnXemSach.Visible = false;
            }
            else
            {
                btnQuanLySach.Visible = false;
                btnQuanLyTaiKhoan.Visible = false;
                btnThongKe.Visible = false;
                btnXemSach.Visible = true;
            }
            OpenChildForm(new Welcome());
            lblTieuDe.Text = "Trang chủ";
            lblIcon.Image = QuanLyThuVien_CSharp.Properties.Resources.home;
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.Crimson;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleRight;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                lblTieuDe.Text = currentBtn.Text;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Beige;
                currentBtn.ForeColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Clear();
            pnlHienThi.Controls.Add(childForm);
            pnlHienThi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lbl_currentChildForm.Text = childForm.Text;
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(255, 255, 255);
            public static Color color2 = Color.FromArgb(0, 48, 96);
            public static Color color3 = Color.FromArgb(24, 154, 180);
            public static Color color4 = Color.FromArgb(0, 0, 0);
            public static Color color5 = Color.FromArgb(0, 0, 0);
            public static Color color6 = Color.FromArgb(0, 0, 0);
        }
        
        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!userMenu)
            {
                btnDoiMatKhau.Visible = true;
                btnDangXuat.Visible = true;
                userMenu = true;
            }
            else
            {
                btnDoiMatKhau.Visible = false;
                btnDangXuat.Visible = false;
                userMenu = false;
            }
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            lblIcon.Image = QuanLyThuVien_CSharp.Properties.Resources.manage_book;
            OpenChildForm(new AdminForm.QuanLySach.fQuanLySach());
        }

        private void btnXemSach_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            lblIcon.Image = QuanLyThuVien_CSharp.Properties.Resources.manage_book;
            OpenChildForm(new ManagerForm.XemSach.fXemSach());
        }

        private void btnQuanLyMuonTra_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            lblIcon.Image = QuanLyThuVien_CSharp.Properties.Resources.ticket;
            //OpenChildForm(new ManagerForm.QLPhieuMuon.fQLPhieuMuon(tenND));
        }

        private void btnQuanLyDocGia_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            lblIcon.Image = QuanLyThuVien_CSharp.Properties.Resources.reader;
            //OpenChildForm(new ManagerForm.QLDocGia.fQLDocGia());
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            lblIcon.Image = QuanLyThuVien_CSharp.Properties.Resources.manage_account;
            OpenChildForm(new AdminForm.QuanLyTaiKhoan.fQuanLyTaiKhoan());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            lblIcon.Image = QuanLyThuVien_CSharp.Properties.Resources.statistic;
            OpenChildForm(new AdminForm.ThongKe.fThongKe());
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new QuanLyTaiKhoan.fDoiMatKhau(btnUser.Text));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadData();
            DisableButton();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát khỏi hệ thống không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            fDangNhap f = new fDangNhap();
            this.Close();
            f.Show();
        }
    }
}
