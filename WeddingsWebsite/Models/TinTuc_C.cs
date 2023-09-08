using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingsWebsite.Models
{
    public class TinTuc_C
    {
        public string MaTin { get; set; }
        public DateTime NgayDang { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public string TheLoai { get; set; }

        public List<string> hinhAnhs = new List<string>();
    }
}