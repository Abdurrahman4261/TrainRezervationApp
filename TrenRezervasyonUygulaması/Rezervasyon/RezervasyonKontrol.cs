using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrenRezervasyonUygulaması.Models;

namespace TrenRezervasyonUygulaması.Rezervasyon
{
    public class RezervasyonKontrol
    {
        public Cevap Kontrol(TrenRezervasyon trenRezervasyon)
        {
            int eklenenKisiSayisi = 0, kapasite, yerlesebilecekKisiSayisi;
            int kalanKisiSayisi = trenRezervasyon.RezervasyonYapilacakKisiSayisi;

            List<YerlesimAyrinti> yerlesimAyrintiListesi = new List<YerlesimAyrinti>();

            for (int vagonIndis = 0; vagonIndis < trenRezervasyon.Tren.Vagonlar.Count; vagonIndis++)
            {
                Vagon vagon = trenRezervasyon.Tren.Vagonlar[vagonIndis];
                kapasite = (vagon.Kapasite * 70) / 100;
                yerlesebilecekKisiSayisi = kapasite - vagon.DoluKoltukAdet;
                if (yerlesebilecekKisiSayisi == 0)
                {
                    continue;
                }
                if (yerlesebilecekKisiSayisi >= kalanKisiSayisi)
                {
                    // Kalan tüm kişiler bu vagona yerleştirilebiliyorsa yerleştirme işlemi yapılır ve döngü sonlandırılır.
                    eklenenKisiSayisi += kalanKisiSayisi;
                    yerlesimAyrintiListesi.Add(new YerlesimAyrinti(vagon.Ad, kalanKisiSayisi));
                    kalanKisiSayisi = 0;

                    break;
                }
                if (trenRezervasyon.KisilerFarkliVagonlaraYerlestirilebilir == false)
                {
                    // Bu vagonda kalan tüm kişilere yer olmadığı için sonraki vagona geçilir.
                    continue;
                }

                // Bu vagona yerleşebilecek kadar kişi yerleştirilir. 
                eklenenKisiSayisi += yerlesebilecekKisiSayisi;
                yerlesimAyrintiListesi.Add(new YerlesimAyrinti(vagon.Ad, yerlesebilecekKisiSayisi));

                kalanKisiSayisi = trenRezervasyon.RezervasyonYapilacakKisiSayisi - eklenenKisiSayisi;

                if (kalanKisiSayisi == 0)
                {
                    break;
                }

            }
            Cevap cevap = new Cevap();
            if (kalanKisiSayisi > 0)
            {
                cevap.RezervasyonYapilabilir = false;
                cevap.YerlesimAyrinti = new List<YerlesimAyrinti>();
            }
            else
            {
                cevap.RezervasyonYapilabilir = true;
                cevap.YerlesimAyrinti = yerlesimAyrintiListesi;
            }
            return cevap;
        }
    }
}