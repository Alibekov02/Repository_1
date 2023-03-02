using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stroy.kg.Data;
using Stroy.kg.Models;
using System.Data;

namespace Stroy.kg.Controllers
{
    [Authorize(Roles = WC.AdminRole)]

    public class ApplicationTypesController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ApplicationTypesController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<ApplicationType> objlist = _db.ApplicationType;
			return View(objlist);
		}
		//GET-CREATE
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		//GET-CREATE
		public IActionResult Create(ApplicationType obj)
		{
			if(ModelState.IsValid)
			{
                _db.ApplicationType.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
			return View(obj);
		}
		//GET-EDIT
		public IActionResult Edit(int? id)
		{
			if (id == null||id==0)
			{
				return NotFound();
			}
			var obj= _db.ApplicationType.Find(id);
			if(obj==null)
			{
				return NotFound();
			}
			return View(obj);
		}
		//POST-EDIT
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ApplicationType obj)
		{
			if (ModelState.IsValid)
			{
				_db.ApplicationType.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);

		}
		//POST-DELETE
		public IActionResult Delete(int? id)
		{
			if(id == null||id==0)
			{
				return NotFound();
			}
			var obj=_db.ApplicationType.Find(id);
			if(obj==null)
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
			var obj=_db.ApplicationType.Find(id);
			_db.ApplicationType.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
