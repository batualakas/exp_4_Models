using exp_4_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_4_Models.Controllers
{

    // read only : proje çalıştığında değeri bir kez set edilebilir. sonrasında değer değiştirilemez.
    public class CategoryController : Controller
    {
        private readonly NorthwindDbContext _db;
        public CategoryController()
        {
            _db = new NorthwindDbContext();
        }

        // GET: Category
        public ActionResult List()
        {


            var categories = _db.Categories.ToList();

            return View(categories);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var category = new Category();
            return View(category);
        }
        [HttpPost]
        public ActionResult Add(Category model)
        {
            if (!ModelState.IsValid)
            {
                // kullanıcı model attribute olarak eklenen validationı atlatmış olabilir.
                return View(model);
            }
            if (!_db.Categories.Any(x => x.CategoryName.ToLower() == model.CategoryName.ToLower()))
            {
                _db.Categories.Add(model);
                var sonuc = _db.SaveChanges();
                if (sonuc > 0)
                {
                    // db'ye kaydetme
                    return RedirectToAction("List");
                }
            }
            else
            {
                ViewBag.Mesaj = "Aynı isimde bir kategori daha eklenemez. Lütfen başka bir isimde kategori ekleyiniz.";
                return View("Add", model);
            }
            return null;

        }

        public ActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.CategoryID == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                int sonuc = _db.SaveChanges();
                if (sonuc > 0)
                {
                    TempData["Mesaj"] = "Silme işlemi başarılı.";
                    return RedirectToAction("List");

                }

            }
            return null;
        }
    }
}