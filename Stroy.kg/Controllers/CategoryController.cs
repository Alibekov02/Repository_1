using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stroy.kg.Data;
using Stroy.kg.Models;
using System.Data;

namespace Stroy.kg.Controllers
{
    [Authorize(Roles = WC.AdminRole)]

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CategoryM> objlist = _db.Category;
            return View(objlist);
        }
        //  GET-CREATE
        public IActionResult Create() 
        {
            return View();
        }
        //  POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(CategoryM obj)
		{
            if (ModelState.IsValid)
            {
				_db.Category.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
            return View(obj);
            
		}
        // GET-Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //  POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET-DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        //POST-DELETE   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfim(int? id)
        {
            var obj = _db.Category.Find(id);
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
