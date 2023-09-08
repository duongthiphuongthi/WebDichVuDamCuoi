using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingsWebsite.Models
{
    public class WhatHot
    {
        public string maDo { get; set; }
        public string theLoai { get; set; }
        public string tenDoCuoi { get; set; }
        public List<string> hinhAnhs = new List<string>();
        public double Gia { get; set; }
    }
}