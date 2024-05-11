using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrenRezervasyonUygulaması.Models
{
    public class Cevap
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}