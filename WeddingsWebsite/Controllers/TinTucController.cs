using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingsWebsite.Models;

namespace WeddingsWebsite.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        DBWeddingDataContext db = new DBWeddingDataContext();
        public ActionResult Index()
        {
            List<TinTuc_C> lNews = new List<TinTuc_C>();

            foreach(var e in db.TINTUCs.ToList())
            {
                TinTuc_C t = new TinTuc_C()
                {
                    MaTin = e.MATIN,
                    TieuDe = e.TIEUDE,
                    NoiDung = e.NOIDUNG,
                    MoTa = e.MOTA,
                    TheLoai = e.THELOAI,
                    NgayDang = DateTime.Parse(e.NGAYDANG.ToString())
                };
                lNews.Add(t);
            }
            //load hình
            var HinhtinTuc = from p2 in db.HATINTUCs 
                         join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                         select new
                         {
                             MaTin = p2.MATIN,
                             tenFile = p3.TENFILE

                         };
            foreach(var e in lNews)
            {
                HinhtinTuc.ToList()
                    .Where(i => i.MaTin.Equals(e.MaTin)).ToList()
                    .ForEach(x => e.hinhAnhs.Add(x.tenFile));
            }
            return View(lNews);
        }

        public ActionResult ChiTietTinTuc(string maTT)
        {
            List<TinTuc_C> lNews = new List<TinTuc_C>();
            foreach (var e in db.TINTUCs.ToList())
            {
                TinTuc_C t = new TinTuc_C()
                {
                    MaTin = e.MATIN,
                    TieuDe = e.TIEUDE,
                    NoiDung = e.NOIDUNG,
                    MoTa = e.MOTA,
                    TheLoai = e.THELOAI,
                    NgayDang = DateTime.Parse(e.NGAYDANG.ToString())
                };
                lNews.Add(t);
            }
            //load hình
            var HinhtinTuc = from p2 in db.HATINTUCs
                             join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                             select new
                             {
                                 MaTin = p2.MATIN,
                                 tenFile = p3.TENFILE

                             };
            foreach (var e in lNews)
            {
                HinhtinTuc.ToList()
                    .Where(i => i.MaTin.Equals(e.MaTin)).ToList()
                    .ForEach(x => e.hinhAnhs.Add(x.tenFile));
            }

            TinTuc_C k = lNews.Single(i => i.MaTin.Equals(maTT));

            return View(k);
        }
    }
}