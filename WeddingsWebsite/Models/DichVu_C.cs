using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingsWebsite.Models
{
    public class DichVu_C
    {
        public string MaDV { get; set; }
        public string tenDV { get; set; }
        public string moTa { get; set; }
        public double gia { get; set; }

        public List<string> hinhAnhs = new List<string>();
    }
}