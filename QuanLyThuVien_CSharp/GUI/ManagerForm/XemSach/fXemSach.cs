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

namespace QuanLyThuVien_CSharp.GUI.ManagerForm.XemSach
{
    public partial class fXemSach : Form
    {
        QuanLyThuVien_CSharpDataContext db = new QuanLyThuVien_CSharpDataContext();
        public fXemSach()
        {
            InitializeComponent();
            loadForm();
        }
        public void loadForm()
        {
            try
            {
                var s = from p in db.SACHes
                        join k in db.DANHMUCs
                        on p.MaDanhMuc equals k.MaDanhMuc
                        select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, 
                            p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                dgvSach.DataSource = s.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Equals(""))
                {
                    loadForm();
                }
                else
                {
                    switch (cbbSearch.SelectedIndex)
                    {
                        case 0:
                            var s = from p in db.SACHes
                                    join k in db.DANHMUCs
                                    on p.MaDanhMuc equals k.MaDanhMuc
                                    where SqlMethods.Like(p.TenSach, "%" + txtSearch.Text + "%")
                                    select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                        case 1:
                            s = from p in db.SACHes
                                join k in db.DANHMUCs
                                on p.MaDanhMuc equals k.MaDanhMuc
                                where SqlMethods.Like(p.TacGia, "%" + txtSearch.Text + "%")
                                select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                        case 2:
                            s = from p in db.SACHes
                                join k in db.DANHMUCs
                                on p.MaDanhMuc equals k.MaDanhMuc
                                where SqlMethods.Like(p.NhaXuatBan, "%" + txtSearch.Text + "%")
                                select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                        case 3:
                            s = from p in db.SACHes
                                join k in db.DANHMUCs
                                on p.MaDanhMuc equals k.MaDanhMuc
                                where (p.LanXuatBan.ToString().Contains(txtSearch.Text))
                                select new { AnhSach = p.AnhSach.ToArray(), p.MaSach, p.TenSach, p.TacGia, p.NhaXuatBan, k.TenDanhMuc, p.NamXuatBan, p.LanXuatBan, p.SoLuong, p.GiaMuon };
                            dgvSach.DataSource = s.ToList();
                            break;
                        case 4:
                            s = from p in db.SACHes
                                join k in db.DANHMUCs
                                on p.MaDanhMuc equals k.MaDanhMuc
                                where SqlMethods.Like(k.TenDanhMuc, "%" + txtSearch.Text + "%")
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
    }
}
