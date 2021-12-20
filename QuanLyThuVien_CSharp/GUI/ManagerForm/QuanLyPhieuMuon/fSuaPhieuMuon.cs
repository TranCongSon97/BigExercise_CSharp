using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QuanLyThuVien_CSharp.GUI.ManagerForm.QLPhieuMuon
{
    public partial class fEditPhieuMuon : Form
    {
        QuanLyThuVien_CSharpDataContext db = new QuanLyThuVien_CSharpDataContext();
        int index = -1;
        int maPhieu;
        fQLPhieuMuon QLPhieuMuon;
        public fEditPhieuMuon()
        {
            InitializeComponent();
        }

        public fEditPhieuMuon(fQLPhieuMuon f, int ma)
        {
            InitializeComponent();
            QLPhieuMuon = f;
            this.maPhieu = ma;
        }

        private void fEditPhieuMuon_Load(object sender, EventArgs e)
        {
            loadForm();
        }
        public void loadForm()
        {
            lblSoPhieu.Text = maPhieu.ToString();
            var s = (from p in db.PHIEUMUONs
                     where p.SoPhieuMuon == maPhieu
                     select p).FirstOrDefault();
            txtNguoiMuon.Text = s.MaSinhVien;
            var a = (from p in db.CTPHIEUMUONs
                     where p.SoPhieuMuon == maPhieu
                     select p).FirstOrDefault();
            txtNgayMuon.Text = ((DateTime)a.NgayMuon).ToString("MM/dd/yyyy");
            var sachmuon = from p in db.CTPHIEUMUONs
                           join k in db.SACHes
                           on p.MaSach equals k.MaSach
                           where p.SoPhieuMuon == maPhieu
                           select new
                           {
                               p.ID,
                               p.MaSach,
                               k.TenSach,
                               TinhTrang = p.TinhTrang == false ? "Chưa trả" : "Đã trả",
                               NgayTra = p.NgayTra.HasValue ? p.NgayTra.Value.ToShortDateString() : null
                           };
            foreach (var u in sachmuon)
            {
                dgvSachMuon.Rows.Add(u.ID, u.MaSach, u.TenSach, u.TinhTrang, u.NgayTra);
            }
            var z = from p in db.CTPHIEUMUONs
                    where p.SoPhieuMuon == maPhieu && p.TinhTrang == false
                    select p;
            if (z.Count() > 0)
            {
                lblStatus.Text = "Tình trạng: Chưa trả đủ";
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.Text = "Tình trạng: Đã trả đủ";
                lblStatus.ForeColor = Color.Green;
            }
        }

        private void dgvSachMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                btnReturn.Enabled = true;
            }
            else
            {
                btnReturn.Enabled = false;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                dgvSachMuon.Rows[index].Cells[3].Value = "Đã trả";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            String currentDate = localDate.Date.ToString(new CultureInfo("en-GB")).Split(' ')[0];
            String ngay = currentDate.Substring(0, 2);
            String thang = currentDate.Substring(3, 2);
            String nam = currentDate.Substring(6);
            for (int i = 0; i < dgvSachMuon.Rows.Count; i++)
            {
                var s = db.CTPHIEUMUONs.Single(p => p.ID == Int32.Parse(dgvSachMuon.Rows[i].Cells[0].Value.ToString()));
                if (s.TinhTrang == false && dgvSachMuon.Rows[i].Cells[3].Value.ToString().Equals("Đã trả"))
                {
                    s.TinhTrang = true;
                    s.NgayTra = DateTime.ParseExact(thang + "/" + ngay + "/" + nam, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    var s1 = db.SACHes.Single(p => p.MaSach == Int32.Parse(dgvSachMuon.Rows[i].Cells[1].Value.ToString()));
                    s1.SoLuong = s1.SoLuong + 1;
                    db.SubmitChanges();
                }
            }
            QLPhieuMuon.loadForm();
            this.Dispose();
        }
    }
}
