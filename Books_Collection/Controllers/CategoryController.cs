﻿using Books.DataAccess.Data;
using Books.Models;
using Books_Collection.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Book.DataAccess.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext _db;
        //get data from Categories table
        public CategoryController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        //HttpGet method
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //Custom validation
            if (category.DisplayOrder.ToString() == category.Name)
            {
                ModelState.AddModelError("name", "DisplayOrder cannot exactly match the Name.");
            }
            Category? CategoryfromDB = _db.Categories.FirstOrDefault(c => c.Name == category.Name);
            if(CategoryfromDB != null &&  CategoryfromDB.Name == category.Name)
            {
                ModelState.AddModelError("Name", "Name is already exist");
            }

            //server-side validation
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();

                TempData["success"] = "Category Created Successfully.";// TempData will show pop-up using 'success' key.
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryIDFromDB = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (CategoryIDFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryIDFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //server-side validation
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryIDFromDB = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (CategoryIDFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryIDFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.FirstOrDefault(x=> x.Id == id);
            if (id == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully.";
            return RedirectToAction("Index");
        }
    }
}
