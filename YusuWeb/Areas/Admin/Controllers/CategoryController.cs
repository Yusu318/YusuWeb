using Microsoft.AspNetCore.Mvc;
using SD7501Yusu.DataAccess.Repository.IRepository;
using YusuWeb.Data;
using YusuWeb.Models;


namespace YusuWeb.Areas.Admin.Controllers
{
    //[Area("Admin")]
    public class CategoryController : Controller
    {
            private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        { 
            _categoryRepo=db;
        }
        public IActionResult Index()
        {
            //var objCategoryList= _db.Categories;
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        //private readonly ApplicationDbContext _db;
        //public CategoryController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}

        //public IActionResult Index()
        //{
        //    //var objCategoryList= _db.Categories;
        //    List<Category> objCategoryList = _db.Categories.ToList();
        //    return View(objCategoryList);
        //}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match with the name");
            }
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit Button
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            { 
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id);

            if (categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);    
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

       //DELETE BUTTON
       public IActionResult Delete(int? id)
        {
            if(id==null||id==0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj= _categoryRepo.Get(u => u.Id == id);
            if (obj==null)
            {
                return NotFound();
            }
            _categoryRepo.Add(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category Created successfully";
            return RedirectToAction("Index");
        }
    }//end of class
}//end of namespace
