using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Ticari_Otomasyon_1_MVC5.Models.Siniflar;

namespace Online_Ticari_Otomasyon_1_MVC5.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c= new Context();
        public ActionResult Index()
        {
            var liste= c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle (Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var ftr = c.Faturalars.Find(id);
            return View("FaturaGetir", ftr);
        }

        public ActionResult FaturaGuncelle (Faturalar f)
        {
            var ft=c.Faturalars.Find(f.FaturaID);
            ft.FaturaSeriNo= f.FaturaSeriNo;
            ft.FaturaSiraNo= f.FaturaSiraNo;
            ft.FaturaTarih= f.FaturaTarih;
            ft.Saat=f.Saat;
            ft.TeslimAlan = f.TeslimAlan;
            ft.TeslimEden = f.TeslimEden;
            ft.Toplam=f.Toplam;
            ft.VergiDairesi=f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FaturaDetay (int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo, DateTime Tarih, string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSıraNo;
            f.FaturaTarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Toplam);
            c.Faturalars.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.Faturaid = x.FaturaKalemID;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}