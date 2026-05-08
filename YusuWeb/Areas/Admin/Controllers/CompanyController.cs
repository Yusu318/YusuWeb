using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SD7501Yusu.DataAccess.Repository.IRepository;
using SD7501Yusu.Models;
using SD7501Yusu.Models.ViewModels;
using SD7501Yusu.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   
using YusuWeb.Data;
using YusuWeb.Models;


namespace YusuWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
        {
            private readonly IUnitOfWork _unitOfWork;
        //private readonly IWebHostEnvironment _webHostEnvironment;
            public CompanyController(IUnitOfWork unitOfWork)//,IWebHostEnvironment webHostEnvironment)
            {
                _unitOfWork = unitOfWork;
                //_webHostEnvironment = webHostEnvironment;
            }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();//(includeProperties:"Category").ToList();
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            //CompanyVM companyVM = new()
            //{
            //    CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            //    {
            //        Text=u.Name,
            //        Value=u.Id.ToString()
            //    }),
            //    Company=new Company()
            //};
            if(id==null||id==0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
            //CompanyVM companyVM = new()
            //{
            //    CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            //    { 
            //        Text=u.Name,
            //        Value=u.Id.ToString()
            //    }),
            //    Company=new Company()
            //};
                //List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
                //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                //{
                //    Text = i.Name,
                //    Value = i.Id.ToString()
                //});
            // ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;
                //return View(companyVM);
        }
            //private readonly ApplicationDbContext _db;
            //public CompanyController(ApplicationDbContext db)
            //{
            //    _db = db;
            //}

            //public IActionResult Index()
            //{
            //    //var objCompanyList= _db.Categories;
            //    List<Company> objCompanyList = _db.Categories.ToList();
            //    return View(objCompanyList);
            //}
        
            [HttpPost]
            public IActionResult Upsert(Company companyObj)
            {
                if (ModelState.IsValid)
                {
                    //string wwwRootPath=_webHostEnvironment.WebRootPath;
                    //if(file!=null)
                    //{
                    ////if (companyVM.Company.Id != 0)
                    //string fileName=Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                    //string companyPath=Path.Combine(wwwRootPath, @"images\company");
                    //{
                    //    if (!string.IsNullOrEmpty(companyVM.Company.ImageUrl))
                    //    {
                    //        //Delete the old image by getting the path of that image
                    //        var oldImagePath = Path.Combine(wwwRootPath,companyVM.Company.ImageUrl.TrimStart('\\'));
                    //        if (System.IO.File.Exists(oldImagePath))
                    //        {
                    //            System.IO.File.Delete(oldImagePath);
                    //        }
                    //    }
                    //}
                    //    //string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    //    //string companyPath=Path.Combine(wwwRootPath, @"images\company");
                    //    using (var fileStream=new FileStream(Path.Combine(companyPath,fileName), FileMode.Create))
                    //    {
                    //        file.CopyTo(fileStream);
                    //    }
                    //    companyVM.Company.ImageUrl = @"\images\company\" + fileName;
                    //}

                    //to check whether the user is updating or creating a company.
                    if (companyObj.Id==0)
                    {
                        _unitOfWork.Company.Add(companyObj);
                    }
                    else
                    {
                        _unitOfWork.Company.Update(companyObj);
                    }
                    //_unitOfWork.Company.Add(companyVM.Company);
                    _unitOfWork.Save();
                    TempData["success"] = "Company Created successfully";
                    return RedirectToAction("Index");
                }
                else
            {
                //   companyVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                //   {
                //       Text = u.Name,
                //       Value = u.Id.ToString()
                //   });
                return View(companyObj);
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
            //    Company? companyFromDb = _unitOfWork.Company.Get(u => u.Id == id);

            //    if (companyFromDb == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(companyFromDb);
            //}

            //[HttpPost]
            //public IActionResult Edit(Company obj)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _unitOfWork.Company.Update(obj);
            //        _unitOfWork.Save();
            //        TempData["success"] = "Company Updated successfully";
            //        return RedirectToAction("Index");
            //    }
            //    return View();
            //}

            //DELETE BUTTON
            //public IActionResult Delete(int? id)
            //{
            //    if (id == null || id == 0)
            //    {
            //        return NotFound();
            //    }
            //    Company? companyFromDb = _unitOfWork.Company.Get(u => u.Id == id);

            //    if (companyFromDb == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(companyFromDb);
            //}
            //[HttpPost, ActionName("Delete")]
            //public IActionResult DeletePost(int? id)
            //{
            //    Company? obj = _unitOfWork.Company.Get(u => u.Id == id);
            //    if (obj == null)
            //    {
            //        return NotFound();
            //    }
            //    _unitOfWork.Company.Remove(obj);
            //    _unitOfWork.Save();
            //    TempData["success"] = "Company Deleted successfully";
            //    return RedirectToAction("Index");
            //}
        #region API calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        [HttpDelete]//告诉 ASP.NET Core，这个方法只处理 Delete 请求
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            //var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, companyToBeDeleted.ImageUrl.TrimStart('\\'));
            //if (System.IO.File.Exists(oldImagePath))
            //{
            //    System.IO.File.Delete(oldImagePath);
            //}
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }//end of class
}//end of namespace
