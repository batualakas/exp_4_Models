using exp_4_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_4_Models.Controllers
{
    public class ShippersController : Controller
    {
        private readonly NorthwindDbContext _db;
        public ShippersController()
        {
            _db = new NorthwindDbContext();
        }
        // GET: Shippers
        public ActionResult List()
        {
            var shippers = _db.Shippers.ToList();

            return View(shippers);
        }
        public ActionResult Add()
        {
            var shippers = new Shipper();
            return View(shippers);
        }
        [HttpPost]
        public ActionResult Add(Shipper Model)
        {
            if (!ModelState.IsValid)
            {
                return View(Model);
            }
            if (!_db.Shippers.Any(x => x.CompanyName.ToLower() == Model.CompanyName.ToLower()))
            {

                _db.Shippers.Add(Model);
                var sonuc = _db.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.Message = "Aynı isimde bir shipper zaten var";
                    return View("Add", Model);

                }


            }
            return null;
        }
        public ActionResult Delete(int id)
        {
            var shipper = _db.Shippers.FirstOrDefault(x => x.ShipperID == id);
            if (shipper != null)
            {
                _db.Shippers.Remove(shipper);
                int sonuc = _db.SaveChanges();
                if (sonuc > 0)
                {
                    TempData["Mesaj"] = "Silme işlemi başarılı.";
                    return RedirectToAction("List");

                }

            }

            return null;
        }
        public ActionResult Edit(int id)
        {
            var shipper = _db.Shippers.FirstOrDefault(x => x.ShipperID == id);
            if (shipper != null)
            {
                return View(shipper);
            }
            TempData["Mesaj"] = "Düzenelicek Shipper bulunamadı.";
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(Shipper model)
        {
            var shipper = _db.Shippers.FirstOrDefault(x => x.ShipperID == model.ShipperID);
            if (shipper != null)
            {
                shipper.CompanyName = model.CompanyName;
                shipper.Phone = model.Phone;
                var sonuc = _db.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("List");
                }
            }
            ViewBag.mesaj = "Shipper bulunamadı";
            return null;
        }

    }
}