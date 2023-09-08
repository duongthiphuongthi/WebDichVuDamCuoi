using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingsWebsite.Models
{
    public class GioHang
    {
        public string MaSanPham { get; set; }
        public string tenSanPham { get; set; }
        public string anh { get; set; }
        public int soLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }

        public GioHang(string maSP)
        {
            DBWeddingDataContext db = new DBWeddingDataContext();
            DOCUOI x = db.DOCUOIs.Single(t => t.MASP.Equals(maSP));
            //load ảnh
            var infoAnh = from p1 in db.HADOCUOIs.Where(t=>t.MASP.Equals(maSP))
                          join p2 in db.HINHANHs on p1.MAHINH equals p2.MAHINH
                          select new
                          {
                              MASP = p1.MASP,
                              TENHINH = p2.TENFILE
                          };
            var temp = infoAnh.Where(e => e.MASP == maSP).ToList();
            MaSanPham = maSP;
            tenSanPham = x.TENSP;
            anh = temp[0].TENHINH;
            soLuong = 1;
            DonGia = (float)x.GIABAN;
            ThanhTien = soLuong * DonGia;
        }
        public GioHang(string maDV, string hinh, string tenDV, float gia)
        {
            MaSanPham = maDV;
            anh = hinh;
            tenSanPham = tenDV;
            DonGia = gia;
            soLuong = 1;
            ThanhTien = DonGia * soLuong;
        }
    }
}