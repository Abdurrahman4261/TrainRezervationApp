using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrenRezervasyonUygulaması.Models
{
    public class YerlesimAyrinti
    {
        public YerlesimAyrinti(string VagonAdi, int KisiSayisi)
        {
            this.VagonAdi = VagonAdi;
            this.KisiSayisi = KisiSayisi;
        }
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}