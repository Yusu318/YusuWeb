using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SD7501Yusu.DataAccess.Repository.IRepository;
using SD7501Yusu.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   
using YusuWeb.Data;
using YusuWeb.Models;


namespace YusuWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

        public class ProductController : Controller
        {
            private readonly IUnitOfWork _unitOfWork;
            public ProductController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
            {
                //List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
                IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            ViewBag.CategoryList = CategoryList;
                return View();
        }
            //private readonly ApplicationDbContext _db;
            //public ProductController(ApplicationDbContext db)
            //{
            //    _db = db;
            //}

            //public IActionResult Index()
            //{
            //    //var objProductList= _db.Categories;
            //    List<Product> objProductList = _db.Categories.ToList();
            //    return View(objProductList);
            //}
        
            [HttpPost]
            public IActionResult Create(Product obj)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Product Created successfully";
                    return RedirectToAction("Index");
                }
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem 
            {
                Text = i.Name, 
                Value = i.Id.ToString() 
            });
            ViewBag.CategoryList = CategoryList;
            return View();
            }



            //Edit Button
            public IActionResult Edit(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

                if (productFromDb == null)
                {
                    return NotFound();
                }
                return View(productFromDb);
            }

            [HttpPost]
            public IActionResult Edit(Product obj)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Product Updated successfully";
                    return RedirectToAction("Index");
                }
                return View();
            }

            //DELETE BUTTON
            public IActionResult Delete(int? id)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

                if (productFromDb == null)
                {
                    return NotFound();
                }
                return View(productFromDb);
            }
            [HttpPost, ActionName("Delete")]
            public IActionResult DeletePost(int? id)
            {
                Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
                if (obj == null)
                {
                    return NotFound();
                }
                _unitOfWork.Product.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Deleted successfully";
                return RedirectToAction("Index");
            }
        }//end of class
    }//end of namespace
