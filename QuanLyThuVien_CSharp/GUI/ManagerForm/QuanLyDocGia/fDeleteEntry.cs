using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuanLyThuVien_CSharp.GUI.ManagerForm.QLDocGia
{
    public partial class fDeleteEntry : Form
    {
        fQLDocGia QLDocGia;
        public fDeleteEntry(fQLDocGia f)
        {
            InitializeComponent();
            QLDocGia = f;
            cbbChooseDate.SelectedIndex = 0;
        }

        private void btnDeleteAndSave_Click(object sender, EventArgs e)
        {
            try
            {
                int sl = 0;
                if (cbbChooseDate.SelectedIndex == 0)
                    sl = 3;
                if (cbbChooseDate.SelectedIndex == 1)
                    sl = 7;
                if (cbbChooseDate.SelectedIndex == 2)
                    sl = 30;
                DirectoryInfo d = new DirectoryInfo(@"LichSuDocGia");
                FileInfo[] files = d.GetFiles("*.txt");
                if (sl == 0)
                {
                    if (files.Length > 1)
                    {
                        for (int i = 0; i < files.Length - 1; i++)
                        {
                            File.Delete(@"LichSuDocGia\" + files[i].Name);
                        }
                    }
                }
                else
                {
                    if (sl > files.Length - 1)
                        sl = files.Length - 1;
                    if (files.Length > 1)
                        for (int i = 0; i < sl; i++)
                        {
                            File.Delete(@"LichSuDocGia\" + files[i].Name);
                        }
                }
                QLDocGia.loadForm();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi");
            }
        }
    }
}
