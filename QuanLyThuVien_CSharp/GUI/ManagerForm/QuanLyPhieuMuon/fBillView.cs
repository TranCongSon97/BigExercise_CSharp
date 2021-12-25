using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyThuVien_CSharp.GUI.ManagerForm.QuanLyPhieuMuon
{
    public partial class fBillView : Form
    {
        DataSet ds;
        String MaSinhVien;
        String SoPhieuMuon;
        String TongTien;
        String NgayLapPhieu;
        String NguoiLapPhieu;

        public fBillView(DataSet ds, String MaSinhVien, String SoPhieuMuon, String TongTien,
           String NgayLapPhieu, String NguoiLapPhieu)
        {
            this.ds = ds;
            this.MaSinhVien = MaSinhVien;
            this.SoPhieuMuon = SoPhieuMuon;
            this.TongTien = TongTien;
            this.NgayLapPhieu = NgayLapPhieu;
            this.NguoiLapPhieu = NguoiLapPhieu;
            InitializeComponent();
        }

        private void fBillView_Load(object sender, EventArgs e)
        {
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportEmbeddedResource = "QuanLyThuVien_CSharp.GUI.ManagerForm.QuanLyPhieuMuon.PhieuMuon.rdlc";

            ReportParameter rpmMaSinhVien = new ReportParameter("MaSinhVien");
            rpmMaSinhVien.Values.Add(MaSinhVien);
            this.reportViewer.LocalReport.SetParameters(rpmMaSinhVien);

            ReportParameter rpmSoPhieuMuon = new ReportParameter("SoPhieuMuon");
            rpmSoPhieuMuon.Values.Add(SoPhieuMuon);
            this.reportViewer.LocalReport.SetParameters(rpmSoPhieuMuon);

            ReportParameter rpmTongTien = new ReportParameter("TongTien");
            rpmTongTien.Values.Add(TongTien);
            this.reportViewer.LocalReport.SetParameters(rpmTongTien);

            ReportParameter rpmNgayLapPhieu = new ReportParameter("NgayLapPhieu");
            rpmNgayLapPhieu.Values.Add(NgayLapPhieu);
            this.reportViewer.LocalReport.SetParameters(rpmNgayLapPhieu);

            ReportParameter rpmTaiKhoanLap = new ReportParameter("TaiKhoanLap");
            rpmTaiKhoanLap.Values.Add(NguoiLapPhieu);
            this.reportViewer.LocalReport.SetParameters(rpmTaiKhoanLap);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsSach";
                rds.Value = ds.Tables[0];

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);
            }
            reportViewer.RefreshReport();
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
        }
    }
}
