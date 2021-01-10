using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Entities;
using News.Entities.Models;
using News.Models;
using News.Services;
using News.Interfaces;

namespace News.Controllers
{
    public class CategoriesController : Controller
    {
        INewsService _newsService = new NewsService();
        public IActionResult Index()
        {
            var categoriesList = _newsService.GetCategoriesList();
            return View(categoriesList);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Add(NewsCategoryModel newsCategory)
        {
            _newsService.AddCategory(newsCategory);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            _newsService.DeleteCategory(Id); 
            return RedirectToAction("Index", "Categories");
        }
        public IActionResult Edit(int Id)
        {
            return View(_newsService.GetCategory(Id));
        }
        public IActionResult EditCategory(NewsCategoryModel newsCategory)
        {
            _newsService.EditCategory(newsCategory);
            return RedirectToAction("Index", "Categories");
        }

        public IActionResult Details(int Id)
        {
            return View(_newsService.GetCategory(Id));
        }

    }
}
