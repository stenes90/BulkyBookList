using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            var category = new Category();
            if (id == null)
            {
                // create category
                return View(category);
            }
            var categoryInDb = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (categoryInDb == null)
            {
                return NotFound();
            }
            return View(categoryInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {

                if (category.Id != 0)
                {
                    _unitOfWork.Category.Update(category);
                }
                else
                {
                    _unitOfWork.Category.Add(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var objInDb = _unitOfWork.Category.Get(id);
            _unitOfWork.Category.Remove(objInDb);
            _unitOfWork.Save();
        }


        #endregion


    }
}