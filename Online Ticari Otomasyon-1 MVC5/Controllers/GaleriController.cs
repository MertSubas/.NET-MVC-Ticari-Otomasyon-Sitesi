using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon_1_MVC5.Models.Siniflar;

namespace Online_Ticari_Otomasyon_1_MVC5.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri

        Context c= new Context();
        public ActionResult Index()
        {
            var degerler=c.Uruns.ToList();

            return View(degerler);
        }
    }
}
