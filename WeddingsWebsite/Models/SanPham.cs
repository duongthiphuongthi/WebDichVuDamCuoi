using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingsWebsite.Models
{
    public class SanPham
    {
        public string maDo { get; set; }
        public string theLoai { get; set; }
        public string tenDoCuoi { get; set; }
        public string moTa { get; set; }
        public int slTon { get; set; }
        public string mauSac { get; set; }
        public string chatLieu { get; set; }
        public string KichThuoc { get; set; }
        public List<string> hinhAnhs = new List<string>();
        public double Gia { get; set; }
    }
}