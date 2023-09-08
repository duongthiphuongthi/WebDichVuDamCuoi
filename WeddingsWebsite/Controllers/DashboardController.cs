using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WeddingsWebsite.Models;

namespace WeddingsWebsite.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        DBWeddingDataContext db = new DBWeddingDataContext();
        public ActionResult Index()
        {
            var DC = db.CTHDDOCUOIs.GroupBy(p => p.MASP, (g, key) =>  new { MaSP = g ,num = key.Sum(x=>x.SOLUONG) });
            List<string> lTen = new List<string>();
            List<int> lInt = new List<int>();
            foreach(var i in DC.ToList())
            {
                lInt.Add((int)i.num);
                lTen.Add(db.DOCUOIs.ToList().Single(e => e.MASP.Equals(i.MaSP)).TENSP);
            }

            //Bieu Do Doanh thu
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string jsonobj = jsSerializer.Serialize(lInt.ToArray());
            string kq = "[";
            for (int i = 0; i < lTen.Count; i++)
            {
                kq += "`" + lTen[i] + "`";
                if (i < lTen.Count - 1)
                    kq += ",";
            }
            kq += "]";
            ViewBag.arr = jsonobj;
            ViewBag.arr2 = kq;

            //Lich su mua ban
            var ls = from p1 in db.HOADONs
                 join p2 in db.CTHDDOCUOIs on p1.MAHD equals p2.MAHD
                 join p3 in db.DOCUOIs on p2.MASP equals p3.MASP
                 select new
                 {
                     MaHD = p1.MAHD,
                     NgayXuat = p1.NGAYXUAT,
                     sl = p2.SOLUONG,
                     tenSP = p3.TENSP
                 };
            
            List<LichSuBan> llichSu = new List<LichSuBan>();
            foreach(var e in ls)
            {
                llichSu.Add(new LichSuBan { MaHD = e.MaHD, ngatxuat = DateTime.Parse(e.NgayXuat.ToString()), sl = (int)e.sl, tenSP = e.tenSP });
            }
            Session["lichsuBan"] = llichSu;

            //lich su nhập
            ls = from p1 in db.PHIEUNHAPHANGs
                     join p2 in db.CTPHIEUNHAPs on p1.MAPHIEU equals p2.MAPHIEU
                     join p3 in db.DOCUOIs on p2.MASP equals p3.MASP
                     select new
                     {
                         MaHD = p1.MAPHIEU,
                         NgayXuat = p1.NGAYNHAP,
                         sl = p2.SOLUONG,
                         tenSP = p3.TENSP,
                     };
            List<LichSuBan> llichSu2 = new List<LichSuBan>();
            foreach (var e in ls)
            {
                llichSu2.Add(new LichSuBan { MaHD = e.MaHD, ngatxuat = DateTime.Parse(e.NgayXuat.ToString()), sl = (int)e.sl, tenSP = e.tenSP });
            }
            Session["lichnhap"] = llichSu2;

            return View();
        }

        public ActionResult QLSanPham()
        {
            return View(db.DOCUOIs.ToList());
        }

        public ActionResult CaNhan()
        {
            return View();
        }

        public ActionResult Xoa(string maSP, string url)
        {
            try
            {
                DOCUOI t = db.DOCUOIs.Where(x => x.MASP.Equals(maSP)).Single();
                db.DOCUOIs.DeleteOnSubmit(t);
                db.SubmitChanges();
                return Redirect(url);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }


        public ActionResult NhapSanPham()
        {
            Session["thongtin"] = db.THONGTINCTs.ToList();
            return View(db.NHATHIETKEs.ToList());
        }
        [HttpPost]
        public ActionResult ThemSanPham(FormCollection f)
        {
            try
            {
                //them phieu nhap
                //them do cuoi
                int count = db.DOCUOIs.ToList().Count();
                DOCUOI t = new DOCUOI();
                t.MASP = "SP" + DateTime.Now.ToString("yy") + (count+1).ToString("000000");
                t.TENSP = f["TenSP"].ToString();
                t.MANTK = f["ntk"].ToString();
                t.SOLUONGTON = int.Parse(f["soluong"].ToString());
                t.GIABAN = float.Parse(f["gia"].ToString());
                t.MOTA = f["mota"].ToString();
                t.MATT = f["matt"].ToString();

                db.DOCUOIs.InsertOnSubmit(t);
                db.SubmitChanges();
                return RedirectToAction("NhapSanPham","Dashboard");
            }
            catch(Exception err)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            
        }
    }
}