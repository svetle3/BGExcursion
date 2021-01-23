using Newtonsoft.Json;
using BGExcursion.Repository;
using BGExcursion.DAL;
using BGExcursion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BGExcursion.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
        }

        public ActionResult Categories()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetCategory());
        }
        public ActionResult CategoryEdit(int categoryId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstorDefault(categoryId));
        }
        [HttpPost]
        public ActionResult CategoryEdit(Tbl_Category tbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(tbl);
                return RedirectToAction("Categories");
            }
            return View(tbl);
        }
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Tbl_Category tbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetRepositoryInstance<Tbl_Category>().Add(tbl);
                return RedirectToAction("Categories");
            }
            return View(tbl);
        }

        public List<SelectListItem> GetSubcategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var sub = _unitOfWork.GetRepositoryInstance<Tbl_Subcategory>().GetAllRecords();
            foreach (var item in sub)
            {
                list.Add(new SelectListItem { Value = item.SubcategoryId.ToString(), Text = item.SubcategoryName });
            }
            return list;
        }

        public ActionResult Subcategory()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Subcategory>().GetSubcategory());
        }
        public ActionResult SubcategoryEdit(int subcategoryId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Subcategory>().GetFirstorDefault(subcategoryId));
        }
        [HttpPost]
        public ActionResult SubcategoryEdit(Tbl_Subcategory tbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetRepositoryInstance<Tbl_Subcategory>().Update(tbl);
                return RedirectToAction("Subcategory");
            }
            return View(tbl);

        }
        public ActionResult SubcategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubcategoryAdd(Tbl_Subcategory tbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetRepositoryInstance<Tbl_Subcategory>().Add(tbl);
                return RedirectToAction("Subcategory");
            }
                return View(tbl);            
        }
        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetProduct());
        }
        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstorDefault(productId));
        }
        [HttpPost]
        public ActionResult ProductEdit(Tbl_Product tbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string pic = null;
                if (file != null)
                {
                    pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                    // file is uploaded
                    file.SaveAs(path);
                }
                tbl.ProductImage = file != null ? pic : tbl.ProductImage;
                tbl.ModifiedDate = DateTime.Now;
                _unitOfWork.GetRepositoryInstance<Tbl_Product>().Update(tbl);
                return RedirectToAction("Product");
            }
            return View(tbl);
        }
        public ActionResult ProductAdd()
        {
                ViewBag.CategoryList = GetCategory();
                return View();           
        }
        [HttpPost]
        public ActionResult ProductAdd(Tbl_Product tbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;
            tbl.CreatedDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(tbl);
            return RedirectToAction("Product");
            }

            //ViewBag.ProductName = new SelectList(_unitOfWork.ProductName, "ProdctName", "Name", tbl.ProductName);
            return View(tbl);
            
        }
    }
}

