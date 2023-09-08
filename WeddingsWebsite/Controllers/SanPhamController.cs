using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingsWebsite.Models;
using PagedList;

namespace WeddingsWebsite.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        DBWeddingDataContext db = new DBWeddingDataContext();
        public ActionResult TheLoaiPartial()
        {
            return PartialView(db.THELOAIs.ToList());
        }
        public ActionResult KichThuocPartial()
        {
            return PartialView();
        }
        public ActionResult GiaBanPartial()
        {
            return PartialView();
        }

        public ActionResult Index(int ? page)
        {
            #region loadData
            List<SanPham> lsp = new List<SanPham>();
            //ten 4 sản phẩm
            foreach (var item in db.DOCUOIs)
            {
                lsp.Add(new SanPham() { maDo = item.MASP, moTa = item.MOTA, tenDoCuoi = item.TENSP, Gia = (double)item.GIABAN });
            }
            //load tên thể loại
            var infoTheLoai = from p1 in db.DOCUOIs
                              join p2 in db.PHANLOAIDCs on p1.MASP equals p2.MASP
                              join p3 in db.THELOAIs on p2.MATL equals p3.MATL
                              select new
                              {
                                  MASP = p1.MASP,
                                  TENTL = p3.TENTL,
                              };
            foreach (var item in lsp)
            {
                var temp = infoTheLoai.Where(e => e.MASP == item.maDo).ToList();
                for (int i = 0; i < temp.Count(); i++)
                {
                    item.theLoai += temp[i].TENTL;
                    if (i < temp.Count() - 1)
                        item.theLoai += ", ";
                }
            }
            //load ảnh
            var infoAnh = from p1 in db.DOCUOIs
                          join p2 in db.HADOCUOIs on p1.MASP equals p2.MASP
                          join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                          select new
                          {
                              MASP = p1.MASP,
                              TENHINH = p3.TENFILE
                          };
            foreach (var item in lsp)
            {
                var temp = infoAnh.Where(e => e.MASP == item.maDo).ToList();
                foreach (var e in temp)
                {
                    item.hinhAnhs.Add(e.TENHINH);
                }
            }
            #endregion
            int pageNumber = page ?? 1;
            int pageSize = 6;

            var clientList = lsp.OrderBy(x => x.tenDoCuoi).ToPagedList(pageNumber, pageSize);

            return View(clientList);
        }


        public ActionResult DanhSachSanPhamTheo(string filter)
        {
            #region loadSP
            List<SanPham> lsp = new List<SanPham>();
            //ten 4 sản phẩm
            foreach (var item in db.DOCUOIs)
            {
                lsp.Add(new SanPham() { maDo = item.MASP, moTa = item.MOTA, tenDoCuoi = item.TENSP, Gia = (double)item.GIABAN });
            }
            //load tên thể loại
            var infoTheLoai = from p1 in db.DOCUOIs
                              join p2 in db.PHANLOAIDCs on p1.MASP equals p2.MASP
                              join p3 in db.THELOAIs on p2.MATL equals p3.MATL
                              select new
                              {
                                  MASP = p1.MASP,
                                  TENTL = p3.TENTL,
                              };
            foreach (var item in lsp)
            {
                var temp = infoTheLoai.Where(e => e.MASP == item.maDo).ToList();
                for (int i = 0; i < temp.Count(); i++)
                {
                    item.theLoai += temp[i].TENTL;
                    if (i < temp.Count() - 1)
                        item.theLoai += ", ";
                }
            }
            //load ảnh
            var infoAnh = from p1 in db.DOCUOIs
                          join p2 in db.HADOCUOIs on p1.MASP equals p2.MASP
                          join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                          select new
                          {
                              MASP = p1.MASP,
                              TENHINH = p3.TENFILE
                          };
            foreach (var item in lsp)
            {
                var temp = infoAnh.Where(e => e.MASP == item.maDo).ToList();
                foreach (var e in temp)
                {
                    item.hinhAnhs.Add(e.TENHINH);
                }
            }
            #endregion
            if (filter == null || filter == string.Empty)
                return RedirectToAction("PageNotFound", "Home");
            return View(lsp.Where(e => e.theLoai.Contains(filter.Trim())).ToList());
        }

        [HttpPost]
        public ActionResult LocTheoGia(FormCollection f)
        {
            #region loadData
            List<SanPham> lsp = new List<SanPham>();
            //ten 4 sản phẩm
            foreach (var item in db.DOCUOIs)
            {
                lsp.Add(new SanPham() { maDo = item.MASP, moTa = item.MOTA, tenDoCuoi = item.TENSP, Gia = (double)item.GIABAN });
            }
            //load tên thể loại
            var infoTheLoai = from p1 in db.DOCUOIs
                              join p2 in db.PHANLOAIDCs on p1.MASP equals p2.MASP
                              join p3 in db.THELOAIs on p2.MATL equals p3.MATL
                              select new
                              {
                                  MASP = p1.MASP,
                                  TENTL = p3.TENTL,
                              };
            foreach (var item in lsp)
            {
                var temp = infoTheLoai.Where(e => e.MASP == item.maDo).ToList();
                for (int i = 0; i < temp.Count(); i++)
                {
                    item.theLoai += temp[i].TENTL;
                    if (i < temp.Count() - 1)
                        item.theLoai += ", ";
                }
            }
            //load ảnh
            var infoAnh = from p1 in db.DOCUOIs
                          join p2 in db.HADOCUOIs on p1.MASP equals p2.MASP
                          join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                          select new
                          {
                              MASP = p1.MASP,
                              TENHINH = p3.TENFILE
                          };
            foreach (var item in lsp)
            {
                var temp = infoAnh.Where(e => e.MASP == item.maDo).ToList();
                foreach (var e in temp)
                {
                    item.hinhAnhs.Add(e.TENHINH);
                }
            }
            #endregion

            if (f["min"] == null || f["max"] == null)
                return RedirectToAction("PageNotFound", "Home");

            float min = float.Parse(f["min"].ToString());
            float max = float.Parse(f["max"].ToString());

            return View(lsp.Where(i => i.Gia >= min && i.Gia <= max).ToList());
        }

        [HttpPost]
        public ActionResult DanhSachSanPhamLoc(FormCollection f)
        {
            #region loadSP
            List<SanPham> lsp = new List<SanPham>();
            //ten 4 sản phẩm
            foreach (var item in db.DOCUOIs)
            {
                lsp.Add(new SanPham() { maDo = item.MASP, moTa = item.MOTA, tenDoCuoi = item.TENSP, Gia = (double)item.GIABAN });
            }
            //load tên thể loại
            var infoTheLoai = from p1 in db.DOCUOIs
                              join p2 in db.PHANLOAIDCs on p1.MASP equals p2.MASP
                              join p3 in db.THELOAIs on p2.MATL equals p3.MATL
                              select new
                              {
                                  MASP = p1.MASP,
                                  TENTL = p3.TENTL,
                              };
            foreach (var item in lsp)
            {
                var temp = infoTheLoai.Where(e => e.MASP == item.maDo).ToList();
                for (int i = 0; i < temp.Count(); i++)
                {
                    item.theLoai += temp[i].TENTL;
                    if (i < temp.Count() - 1)
                        item.theLoai += ", ";
                }
            }
            //load ảnh
            var infoAnh = from p1 in db.DOCUOIs
                          join p2 in db.HADOCUOIs on p1.MASP equals p2.MASP
                          join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                          select new
                          {
                              MASP = p1.MASP,
                              TENHINH = p3.TENFILE
                          };
            foreach (var item in lsp)
            {
                var temp = infoAnh.Where(e => e.MASP == item.maDo).ToList();
                foreach (var e in temp)
                {
                    item.hinhAnhs.Add(e.TENHINH);
                }
            }
            #endregion
            if (f["searchDress"] == null)
                return RedirectToAction("PageNotFound","Home");
            string searchStr = f["searchDress"].ToString();
            List<SanPham> filter = lsp.Where(e => e.tenDoCuoi.Contains(searchStr.Trim())).ToList();
            return View(filter);
        }

        public ActionResult LocTheoKichThuoc(FormCollection f)
        {
            #region loadSP
            List<SanPham> lsp = new List<SanPham>();
            //ten 4 sản phẩm
            foreach (var item in db.DOCUOIs)
            {
                lsp.Add(new SanPham() { maDo = item.MASP
                    , moTa = item.MOTA
                    , tenDoCuoi = item.TENSP
                    , Gia = (double)item.GIABAN
                    , KichThuoc= db.DOCUOIs.Single(t => t.MASP.Equals(item.MASP)).THONGTINCT.KICHTHUOC});
            }
            //load tên thể loại
            var infoTheLoai = from p1 in db.DOCUOIs
                              join p2 in db.PHANLOAIDCs on p1.MASP equals p2.MASP
                              join p3 in db.THELOAIs on p2.MATL equals p3.MATL
                              select new
                              {
                                  MASP = p1.MASP,
                                  TENTL = p3.TENTL,
                              };
            foreach (var item in lsp)
            {
                var temp = infoTheLoai.Where(e => e.MASP == item.maDo).ToList();
                for (int i = 0; i < temp.Count(); i++)
                {
                    item.theLoai += temp[i].TENTL;
                    if (i < temp.Count() - 1)
                        item.theLoai += ", ";
                }
            }
            //load ảnh
            var infoAnh = from p1 in db.DOCUOIs
                          join p2 in db.HADOCUOIs on p1.MASP equals p2.MASP
                          join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                          select new
                          {
                              MASP = p1.MASP,
                              TENHINH = p3.TENFILE
                          };
            foreach (var item in lsp)
            {
                var temp = infoAnh.Where(e => e.MASP == item.maDo).ToList();
                foreach (var e in temp)
                {
                    item.hinhAnhs.Add(e.TENHINH);
                }
            }
            #endregion
            if (f["size"] == null)
                return RedirectToAction("PageNotFound", "Home");
            string size = f["size"].ToString();
            List<SanPham> filter = lsp.Where(e => e.KichThuoc.Contains(size.Trim())).ToList();
            return View(filter);
        }

        public List<GioHang> LayGioHang()
        {
            List<GioHang> lGH = Session["giohang"] as List<GioHang>;
            if (lGH == null)
            {
                lGH = new List<GioHang>();
                Session["giohang"] = lGH;
            }
            return lGH;
        }

        public ActionResult ThemGioHang(string maSP, string url)
        {
            //lay gio hang hien tai, neu khong co thi khoi tao moi
            List<GioHang> lGH = LayGioHang();
            //tim xem gio hang co item trung hay khong
            GioHang gh = lGH.Find(t => t.MaSanPham.Equals(maSP));
            if (gh == null)//chua co trong gio hang
            {
                gh = new GioHang(maSP);//khoi tao doi tuong san pham trong gio hang
                lGH.Add(gh);
            }
            else
            {
                gh.soLuong++;
                gh.ThanhTien = gh.soLuong * gh.DonGia;
            }
            return Redirect(url);
        }

        public ActionResult XoaSanPhamGH(string maSP, string url)
        {
            //lay gio hang hien tai, neu khong co thi khoi tao moi
            List<GioHang> lGH = LayGioHang();
            //tim xem gio hang co item trung hay khong
            GioHang gh = lGH.Find(t => t.MaSanPham.Equals(maSP));
            if (gh != null)//tìm thay
            {
                lGH.Remove(gh);
            }
            return Redirect(url);
        }

        [HttpPost]
        public ActionResult SuaSanPhamGH(string maSP, string url, FormCollection f)
        {
            //lay gio hang hien tai, neu khong co thi khoi tao moi
            List<GioHang> lGH = LayGioHang();
            //tim xem gio hang co item trung hay khong
            GioHang gh = lGH.Find(t => t.MaSanPham.Equals(maSP));
            if (gh != null)//tìm thay
            {
                gh.soLuong = int.Parse(f["soluong"].ToString()) ;
            }
            return Redirect(url);
        }

        public ActionResult ThemGioHangDV(string maDV, string url)
        {
            try
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
                string hinh = HinhDV.ToList().FirstOrDefault(i => i.MaDV.Equals(maDV)).tenFile.ToString();

                //lay gio hang hien tai, neu khong co thi khoi tao moi
                List<GioHang> lGH = LayGioHang();
                //tim xem gio hang co item trung hay khong
                GioHang gh = lGH.Find(t => t.MaSanPham.Equals(maDV));
                if (gh == null)//chua co trong gio hang
                {
                    gh = new GioHang(dv.MADV, hinh, dv.TENDV, (float)dv.GIADV);//khoi tao doi tuong san pham trong gio hang
                    lGH.Add(gh);
                }
                else
                {
                    gh.soLuong++;
                    gh.ThanhTien = gh.soLuong * gh.DonGia;
                }
                return Redirect(url);
            }
            catch
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        public ActionResult ChiTietSanPham(string maSP)
        {
            try
            {
                if(maSP.StartsWith("DV"))
                {
                    return RedirectToAction("ChiTietDV", "DichVu",new { maDV = maSP });
                }
                #region DoCuoi
                SanPham sp = new SanPham();
                DOCUOI x = db.DOCUOIs.Single(t => t.MASP.Equals(maSP));

                //load tên thể loại
                var infoTheLoai = from p2 in db.PHANLOAIDCs.Where(t=>t.MASP.Equals(maSP))
                                    join p3 in db.THELOAIs on p2.MATL equals p3.MATL
                                    select new
                                    {
                                        MASP = p2.MASP,
                                        TENTL = p3.TENTL,
                                    };

                var temp = infoTheLoai.Where(e => e.MASP == x.MASP).ToList();
                for (int i = 0; i < temp.Count(); i++)
                {
                    sp.theLoai += temp[i].TENTL;
                    if (i < temp.Count() - 1)
                        sp.theLoai += ", ";
                }
                //load ảnh
                var infoAnh = from p2 in db.HADOCUOIs.Where(t=>t.MASP.Equals(maSP))
                                join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                                select new
                                {
                                    MASP = p2.MASP,
                                    TENHINH = p3.TENFILE
                                };

                var temp2 = infoAnh.Where(e => e.MASP == maSP);
                foreach(var e in temp2)
                {
                    sp.hinhAnhs.Add(e.TENHINH);
                }

                //load detail size, color dress
                sp.maDo = maSP;
                sp.slTon = (int)x.SOLUONGTON;
                sp.tenDoCuoi = x.TENSP;
                sp.moTa = x.MOTA;
                sp.chatLieu = db.DOCUOIs.Single(t => t.MASP.Equals(maSP)).THONGTINCT.CHATLIEU;
                sp.mauSac = db.DOCUOIs.Single(t => t.MASP.Equals(maSP)).THONGTINCT.MAUSAC;
                sp.KichThuoc = db.DOCUOIs.Single(t => t.MASP.Equals(maSP)).THONGTINCT.KICHTHUOC;
                sp.Gia = (float)x.GIABAN;
                return View(sp);
                #endregion
            }
            catch(Exception err)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
        }

        public ActionResult GioHang()
        {
            List<GioHang> lGH = Session["giohang"] as List<GioHang>;
            if (lGH == null)
            {
                return View();
            }
            ViewBag.TongThanhTien = lGH.Sum(t => t.ThanhTien);
            ViewBag.TongSL = lGH.Sum(t => t.soLuong);
            return View(lGH);
        }

        public ActionResult GioHangPartial()
        {
            List<GioHang> lGH = Session["giohang"] as List<GioHang>;
            if (lGH == null)
                ViewBag.soLuong = 0;
            else
                ViewBag.soLuong = lGH.Sum(t => t.soLuong);
            return PartialView();
        }
    }
}