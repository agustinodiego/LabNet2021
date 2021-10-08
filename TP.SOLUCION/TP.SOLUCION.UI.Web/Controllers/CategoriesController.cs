using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.SOLUCION.Business.Domain;
using TP.SOLUCION.Business.Logic;
using TP.SOLUCION.UI.Web.Models;

namespace TP.SOLUCION.UI.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoriesLogic _categoriesLogic = new CategoriesLogic();

        [HttpGet]
        public ActionResult Index()
        {
            List<Categories> categories = _categoriesLogic.GetAll();

            List<CategoriesVM> categoriesVM = categories.Select(c => new CategoriesVM
            {
                CategoryId = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();

            return View(categoriesVM);
        }

        [HttpGet]
        public PartialViewResult Insert()
        {
            return PartialView("InsertUpdate", new CategoriesVM());
        }
        [HttpGet]
        public PartialViewResult Update(int id)
        {

            var category = _categoriesLogic.GetByID(id);

            var categoryVM = new CategoriesVM();
            categoryVM.CategoryId = category.CategoryID;
            categoryVM.CategoryName = category.CategoryName;
            categoryVM.Description = category.Description;

            return PartialView("InsertUpdate", categoryVM);
        }

        [HttpPost]
        public ActionResult InsertUpdate(CategoriesVM categoriesVM)
        {
            if (ModelState.IsValid)
            {
                Categories category = new Categories();

                if (categoriesVM.CategoryId == 0)
                {
                    category.CategoryName = categoriesVM.CategoryName;
                    category.Description = categoriesVM.Description;

                    _categoriesLogic.Insert(category);
                }
                else
                {
                    category.CategoryID = categoriesVM.CategoryId;
                    category.CategoryName = categoriesVM.CategoryName;
                    category.Description = categoriesVM.Description;

                    _categoriesLogic.Update(category);
                }
                return RedirectToAction("Index");
            }
            return PartialView(categoriesVM);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var logic = new CategoriesLogic();
                logic.Delete(id);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/_ModalError.cshtml", new ErrorVM { Controller = "Categories", ActionToDo = "Delete" });
            }
        }

        [HttpGet]
        public PartialViewResult ModalDelete(CategoriesVM categoryVM)
        {
            return PartialView("_ModalDelete", categoryVM);
        }

        public PartialViewResult ModalErrorAction(ErrorVM errorVM)
        {
            return PartialView("_ModalErrorAction", errorVM);
        }
    }
}