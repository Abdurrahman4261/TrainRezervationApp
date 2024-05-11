using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrenRezervasyonUygulaması.Models
{
    public class Tren
    {
        public string Ad { get; set; }
        public List<Vagon> Vagonlar { get; set; }
    }
}