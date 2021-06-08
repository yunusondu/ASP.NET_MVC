using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstproject.Entity;

namespace firstproject.Controllers
{
    public class urunController : Controller
    {
       
        HalloEntities8 ra = new HalloEntities8();
        

            
        // GET: urun
        public ActionResult Index()
        {
           
            var degerler = ra.TblUrun.ToList();
            
            return View(degerler);
        }
         [HttpGet]

         public ActionResult UrunEkle()
        {
            
            List<SelectListItem> degerler = (from i in ra.TblUrunGrub.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.UrunTurAdi,
                                                 Value = i.UrunTurID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return RedirectToAction("Index");
        }

        [HttpPost]

        public ActionResult UrunEkle(TblUrun s1)
        {
            ra.TblUrun.Add(s1);
            ra.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult SİL(int id)
        {
            var urun = ra.TblUrun.Find(id);
            ra.TblUrun.Remove(urun);
            ra.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = ra.TblUrun.Find(id);
            return View("UrunGetir", urun);
        }
        
        public ActionResult GÜNCELLE(TblUrun p1)
        {
            var urun = ra.TblUrun.Find(p1);
            urun.UrunID = p1.UrunID;
            urun.UrunAdı = p1.UrunAdı;
            urun.BirimID = p1.BirimID;
            urun.UrunKayitTarih = p1.UrunKayitTarih;
            urun.KayitBilgisiID = p1.KayitBilgisiID;
            urun.UrunKodu = p1.UrunKodu;
            urun.UrunGrubuID = p1.UrunGrubuID;
            return RedirectToAction("Index");
                

        }
    }
}