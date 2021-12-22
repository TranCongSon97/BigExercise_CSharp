using QuanLyThuVien_CSharp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyThuVien_CSharp.BLL
{
    class ThongKe_BLL
    {
        DataConnection dataConnect = new DataConnection();
        public int getSachMuonNgay(string ngay)
        {
            string sql = "SELECT COUNT(ID) FROM [dbo].[CTPHIEUMUON] WHERE NgayMuon = '" + ngay + "'";
            DataTable da = dataConnect.GetTable(sql);
            return Int32.Parse(da.Rows[0].ItemArray[0].ToString());
        }
        public int getSachTraNgay(string ngay)
        {
            string sql = "SELECT COUNT(ID) FROM [dbo].[CTPHIEUMUON] WHERE NgayTra = '" + ngay + "'";
            DataTable da = dataConnect.GetTable(sql);
            return Int32.Parse(da.Rows[0].ItemArray[0].ToString());
        }
        public int getSachMuonThang(int thang, int nam)
        {
            string sql = "SELECT COUNT(ID) FROM [dbo].[CTPHIEUMUON] WHERE MONTH(NgayMuon) = '" + thang + "' AND YEAR(NgayMuon) = '" + nam + "'";
            DataTable da = dataConnect.GetTable(sql);
            return Int32.Parse(da.Rows[0].ItemArray[0].ToString());
        }
        public int getSachTraThang(int thang, int nam)
        {
            string sql = "SELECT COUNT(ID) FROM [dbo].[CTPHIEUMUON] WHERE MONTH(NgayTra) = '" + thang + "' AND YEAR(NgayTra) = '" + nam + "'";
            DataTable da = dataConnect.GetTable(sql);
            return Int32.Parse(da.Rows[0].ItemArray[0].ToString());
        }
    }
}
