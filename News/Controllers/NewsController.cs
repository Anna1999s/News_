using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Entities.Models;
using News.Interfaces;
using News.Models;
using News.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        INewsService _newsService = new NewsService();
        public IActionResult Index(int Id)
        {
            
            var newsList = Id != 0 ? _newsService.GetNewsList(Id) : _newsService.GetNewsList();
            return View(newsList);
        }
        public IActionResult Create()
        {
            return View(new NewsModel {
                newsCategories = _newsService.GetCategoriesList()
            });
        }

        public IActionResult Add(NewsModel news)        
        {            
            _newsService.AddNews(SetImageFile(news));
            return RedirectToAction("Index", "News");
        }

        NewsModel SetImageFile(NewsModel news)
        {
            using (var ms = new MemoryStream())
            {
                if (news.ImageFile != null && news.ImageFile.Length > 0)
                {
                    news.ImageFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    news.Photo = $"data:{news.ImageFile.ContentType};base64,{Convert.ToBase64String(fileBytes)}";
                }
            }
            return news;
        }
        public IActionResult Delete(int Id)
        {
            _newsService.DeleteNews(Id);
            return RedirectToAction("Index", "News");
        }

        public IActionResult Edit(int Id)
        {
            var news = _newsService.GetNews(Id);
            news.newsCategories = _newsService.GetCategoriesList();
            return View(news);
        }
        public IActionResult EditNews (NewsModel news)
        {
            _newsService.EditNews(SetImageFile(news));
            return RedirectToAction("Index", "News");
        }

        public IActionResult Details(int Id)
        {
            return View(_newsService.GetNews(Id));
        }
    }
}
