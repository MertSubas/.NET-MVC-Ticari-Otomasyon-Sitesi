using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon_1_MVC5.Models.Siniflar;


namespace Online_Ticari_Otomasyon_1_MVC5.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var car = c.Carilers.Find(id);
            car.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("Carigetir", cari);
        }

        public ActionResult CariGuncelle(Cariler p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
       
            var cari = c.Carilers.Find(p.CariID);
            cari.CariAD = p.CariAD;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir=p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MusteriSatis(int id)
        {
            var cr = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAD + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari=cr;
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
    }
}