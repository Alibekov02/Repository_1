using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Stroy.kg.Data;
using Stroy.kg.Models;
using Stroy.kg.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Stroy.kg.Controllers
{
    [Authorize(Roles =WC.AdminRole)]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Product2> objlist = _db.Product2.Include(u=>u.Category).Include(u=>u.ApplicationType);
            //foreach(var obj in objlist)
            //{
            //    obj.Category = _db.Category.FirstOrDefault(u => u.Id ==obj.CategoryId);
            //    obj.ApplicationType = _db.ApplicationType.FirstOrDefault(u => u.Id == obj.CategoryId);
            //}

            return View(objlist);
        }
        //GET-UPSERT
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product2 = new Product2(),
                ApplicationSelectList = _db.ApplicationType.Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),

                CategorySelectList = _db.Category.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if(id == null)
            {
                //this is for create
                return View(productVM);
            }
            else
            {
                productVM.Product2 = _db.Product2.Find(id);
                if (productVM.Product2 == null)
                {
                    return NotFound();
                }
                return View(productVM);
            }
        }
        //POST-UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                if (productVM.Product2.Id == 0)
                {
                    //Creating
                    string upload = webRootPath + WC.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);
                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    productVM.Product2.Image = fileName + extension;
                    _db.Product2.Add(productVM.Product2);
                }
                else
                {
                    var objFromDb = _db.Product2.AsNoTracking().FirstOrDefault(i => i.Id == productVM.Product2.Id);
                    if (files.Count > 0)
                    {
                        //Updating

                        string upload = webRootPath + WC.ImagePath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);
                        var oldFile = Path.Combine(upload, objFromDb.Image);
                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        productVM.Product2.Image = fileName + extension;

                    }
                    else
                    {
                        productVM.Product2.Image = objFromDb.Image;
                    }
                    _db.Product2.Update(productVM.Product2);
                    

                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            productVM.CategorySelectList = _db.Category.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value=i.Id.ToString()
            });
            productVM.ApplicationSelectList=_db.ApplicationType.Select(u=>new SelectListItem
            {
                Text=u.Name,
                Value=u.Id.ToString()
            });
            return View(productVM);
        }
        //GET-DELETE
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Product2 product2 = new Product2();
            product2 = _db.Product2.Include(u => u.Category).Include(u=>u.ApplicationType).FirstOrDefault(u => u.Id == id);
            if (product2 == null)
            {
                return NotFound();
            }
            return View(product2);

        }
        //POST-DELETE
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Product2.Find(id);
            if (obj == null)
            {
                return NotFound(); 
            }
            string upload =_webHostEnvironment.WebRootPath + WC.ImagePath;
            var oldFile = Path.Combine(upload, obj.Image);
            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }
            _db.Product2.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
