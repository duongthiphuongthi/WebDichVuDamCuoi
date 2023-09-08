using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingsWebsite.Models;
namespace WeddingsWebsite.Controllers
{
    public class DichVuController : Controller
    {
        // GET: DichVu
        DBWeddingDataContext db = new DBWeddingDataContext();
        public ActionResult Index()
        {
            List<DichVu_C> lDVs = new List<DichVu_C>();

            foreach (var e in db.DVCHUPANHs.ToList())
            {
                DichVu_C t = new DichVu_C()
                {
                    MaDV = e.MADV,
                    tenDV = e.TENDV,
                    moTa = e.MOTA,
                    gia = (double)e.GIADV,
                };
                lDVs.Add(t);
            }
            //load hình
            var HinhDV = from p2 in db.HADVCHUPANHs
                             join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                             select new
                             {
                                 MaDV = p2.MADV,
                                 tenFile = p3.TENFILE

                             };
            foreach (var e in lDVs)
            {
                HinhDV.ToList().Where(i => i.MaDV.Equals(e.MaDV))
                    .ToList().ForEach(i => e.hinhAnhs.Add(i.tenFile));
            }
            return View(lDVs);
        }

        public ActionResult ChiTietDV(string maDV)
        {
            DVCHUPANH dv = db.DVCHUPANHs.Single(t => t.MADV.Equals(maDV));
            //load hình
            var HinhDV = from p2 in db.HADVCHUPANHs.Where(t => t.MADV.Equals(maDV))
                         join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                         select new
                         {
                             MaDV = p2.MADV,
                             tenFile = p3.TENFILE
                         };
            DichVu_C x = new DichVu_C()
            {
                MaDV = dv.MADV,
                tenDV = dv.TENDV,
                moTa = dv.MOTA,
                gia = (float)dv.GIADV
            }; ;
            HinhDV.ToList().Where(i => i.MaDV.Equals(maDV)).ToList().ForEach(k => x.hinhAnhs.Add(k.tenFile));
            return View(x);
        }
    }
}