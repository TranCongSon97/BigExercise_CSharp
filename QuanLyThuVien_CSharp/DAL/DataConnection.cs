using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien_CSharp.DAL
{
    class DataConnection
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyThuVienCSharp;Integrated Security=True");
        }

        public DataTable GetTable(string sql)
        {
            try
            {
                SqlConnection conn = GetConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (SqlException x)
            {
                MessageBox.Show(x.Message);
                return null;
            }
        }
        public void ExecuteNonQuery(String sql)
        {
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public void ExecuteNonQueryWithImage(String sql, byte[] img)
        {
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@image", img));
                cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
