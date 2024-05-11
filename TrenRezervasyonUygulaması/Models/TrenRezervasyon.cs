using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrenRezervasyonUygulaması.Models
{
    public class TrenRezervasyon
    {
        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}