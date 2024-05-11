using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrenRezervasyonUygulaması.Controllers
{
    public class TrenController : ApiController
    {
        [HttpPost]
        [Route("api/rezervasyonyap")]
        public IHttpActionResult Post([FromBody] TrenRezervasyon rezervasyon)
        {
            RezervasyonKontrol rezervasyonKontrol = new RezervasyonKontrol();
            Cevap cevap = rezervasyonKontrol.Kontrol(rezervasyon);
            return Ok<Cevap>(cevap);
        }
    }
}
