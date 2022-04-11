using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon_1_MVC5.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace Online_Ticari_Otomasyon_1_MVC5.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public ActionResult KategoriSil(int id)
        {
            var kate=c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGüncelle(int id)
        {
            var katg = c.Kategoris.Find(id);
            return View("KategoriGüncelle", katg);

        }
        public ActionResult KategoriGüncelleme(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriID);
            ktgr.KategoriAD = k.KategoriAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme()
        {
            Class3 cs = new Class3();
            cs.Kategoriler = new SelectList(c.Kategoris, "KategoriID", "KategoriAD");
            cs.Urunler = new SelectList(c.Uruns, "UrunID", "UrunAD");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in c.Uruns
                               join y in c.Kategoris
                               on x.Kategori.KategoriID equals y.KategoriID
                               where x.Kategori.KategoriID == p
                               select new
                               {
                                   Text = x.UrunAD,
                                   Value = x.UrunID.ToString()
                               }).ToList();
            return Json(urunlistesi, JsonRequestBehavior.AllowGet);
        }
    }
}