using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SD7501Yusu.DataAccess.Repository.IRepository;
using SD7501Yusu.Models;
using SD7501Yusu.Models.ViewModels;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
            public ProductController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
            {
                _unitOfWork = unitOfWork;
                _webHostEnvironment = webHostEnvironment;
            }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text=u.Name,
                    Value=u.Id.ToString()
                }),
                Product=new Product()
            };
            if(id==null||id==0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
            //ProductVM productVM = new()
            //{
            //    CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            //    { 
            //        Text=u.Name,
            //        Value=u.Id.ToString()
            //    }),
            //    Product=new Product()
            //};
                //List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
                //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                //{
                //    Text = i.Name,
                //    Value = i.Id.ToString()
                //});
            // ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;
                //return View(productVM);
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
            public IActionResult Upsert(ProductVM productVM, IFormFile? file)
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath=_webHostEnvironment.WebRootPath;
                    if(file!=null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath=Path.Combine(wwwRootPath, @"images\product");
                        using (var fileStream=new FileStream(Path.Combine(productPath,fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        productVM.Product.ImageUrl = @"\images\product\" + fileName;
                    }

                    //to check whether the user is updating or creating a product.
                    if (productVM.Product.Id==0)
                    {
                        _unitOfWork.Product.Add(productVM.Product);
                    }
                    else
                    {
                        _unitOfWork.Product.Update(productVM.Product);
                    }
                    //_unitOfWork.Product.Add(productVM.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product Created successfully";
                    return RedirectToAction("Index");
                }
                else
                 {
                    productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                    return View(productVM);
            }
                //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem 
                //{
                //    Text = i.Name, 
                //    Value = i.Id.ToString() 
                //});
                //ViewBag.CategoryList = CategoryList;
                //return View();
            }



            //Edit Button
            //public IActionResult Edit(int? id)
            //{
            //    if (id == null || id == 0)
            //    {
            //        return NotFound();
            //    }
            //    Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            //    if (productFromDb == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(productFromDb);
            //}

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
