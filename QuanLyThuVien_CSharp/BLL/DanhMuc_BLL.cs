using QuanLyThuVien_CSharp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien_CSharp.BLL
{
    class DanhMuc_BLL
    {
        DataConnection dataConnection = new DataConnection();
        public DataTable GetDanhMuc()
        {
            string sql = "SELECT * FROM [dbo].[DANHMUC]";
            DataTable table = new DataTable();
            table = dataConnection.GetTable(sql);
            return table;
        }
    }
}
