using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien_CSharp.DTO
{
    class Sach_DTO
    {
        public string MaSach { get; set; }
        public byte[] AnhSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public string TacGia { get; set; }
        public string NhaXuatBan { get; set; }
        public DateTime NamXuatBan { get; set; }
        public int LanXuatBan { get; set; }
        public int GiaMuon { get; set; }
        public int MaDanhMuc { get; set; }
    }
}
