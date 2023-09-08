using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WeddingsWebsite.Models;

namespace WeddingsWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DBWeddingDataContext db = new DBWeddingDataContext();
        public ActionResult Index()
        {
            List<WhatHot> lhot = new List<WhatHot>();
            var top4Dress = db.DOCUOIs.Take(4);
            //ten 4 sản phẩm
            foreach (var item in top4Dress)
            {
                lhot.Add(new WhatHot() { maDo = item.MASP, tenDoCuoi = item.TENSP, Gia = (double)item.GIABAN });
            }
            //load tên thể loại
            var infoTheLoai = from p1 in top4Dress join p2 in db.PHANLOAIDCs on p1.MASP equals p2.MASP join p3 in db.THELOAIs on p2.MATL equals p3.MATL select new 
            {
                MASP = p1.MASP,
                TENTL = p3.TENTL,
            };
            foreach (var item in lhot)
            {
                var temp = infoTheLoai.Where(e => e.MASP == item.maDo).ToList();
                for(int i=0;i<temp.Count();i++)
                {
                    item.theLoai += temp[i].TENTL;
                    if (i < temp.Count() - 1)
                        item.theLoai += ", ";
                }
            }
            //load ảnh
            var infoAnh = from p1 in top4Dress
                            join p2 in db.HADOCUOIs on p1.MASP equals p2.MASP
                            join p3 in db.HINHANHs on p2.MAHINH equals p3.MAHINH
                            select new
                            {
                                MASP = p1.MASP,
                                TENHINH = p3.TENFILE
                            };
            foreach (var item in lhot)
            {
                var temp = infoAnh.Where(e => e.MASP == item.maDo).ToList();
                foreach (var e in temp)
                {
                    item.hinhAnhs.Add(e.TENHINH);
                }
            }
            return View(lhot);
        }

        public ActionResult PageNotFound()
        {
            return View();
        }

        public JsonResult SendMailToUser()
        {
            bool result = false;
            result = SendMail("phatlongtoan@gmail.com","Hi Welcome to Wedding Services Love Of You","<p> Thanks for your subcribe Nice to see you ! </p>");

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool SendMail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                client.Send(mailMessage);

                return true;
            }
            catch(Exception err)
            {
                return false;
            }
        }
    }
}