using Microsoft.EntityFrameworkCore;
using News.Entities;
using News.Entities.Models;
using News.Interfaces;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Services
{
    public class NewsService : INewsService
    {
        NewsContext _dbContext = new NewsContext();
        public NewsEntity AddNews(NewsModel news)
        {
            var _news = new NewsEntity
            {
                Name = news.Name,
                Context = news.Context,
                Category = news.Category,
                CategoryId = news.CategoryId,
                Photo = news.Photo,
                PublishDate = DateTime.UtcNow
                
            };
            _dbContext.News.Add(_news);
            _dbContext.SaveChanges();
            return _news;
        }

        public List<NewsModel> GetNewsList()
        { 
            var news = _dbContext.News.Include(_ => _.Category).OrderByDescending(_=> _.PublishDate).Take(6).ToList();
            var newsList = new List<NewsModel>();
            foreach (var item in news)
            {
                newsList.Add(new NewsModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Context = item.Context,
                    Category = item.Category,
                    CategoryId = item.CategoryId,
                    Photo = item.Photo,
                    PublishDate = item.PublishDate
                });
            }
            return newsList;
        }

        public NewsCategoryEntity AddCategory(NewsCategoryModel newsCategory)
        {

            var _categories = new NewsCategoryEntity
            {
                Name = newsCategory.Name
            };
            _dbContext.Categories.Add(_categories);
            _dbContext.SaveChanges();
            return _categories;
        }

        public List<NewsCategoryModel> GetCategoriesList()
        {
            var categories = _dbContext.Categories.ToList();

            var categoriesList = new List<NewsCategoryModel>();
            foreach (var item in categories)
            {
                categoriesList.Add(new NewsCategoryModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return categoriesList;
        }

        public bool DeleteNews(int Id)
        {
            try
            {
               var news = _dbContext.News.FirstOrDefault(_ => _.Id == Id);
                if (news != null)
                {
                    _dbContext.Entry(news).State = EntityState.Deleted;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }

        public bool EditNews(NewsModel news)
        {
            var _news = _dbContext.News.Include(_ => _.Category).FirstOrDefault(_ => _.Id == news.Id);
            if (_news != null)
            {
                _news.Name = news.Name;
                _news.Context = news.Context;
                if(news.Photo != null)
                    _news.Photo = news.Photo;
                _news.PublishDate = news.PublishDate;
                //_news.Category = news.Category;
                _news.CategoryId = news.CategoryId;

                _dbContext.News.Update(_news);
                _dbContext.SaveChanges();
               return true;
            }
            return false;

        }

        public NewsModel GetNews(int Id)
        {
            NewsModel newsModel = new NewsModel();
            var news = _dbContext.News.Include(_=>_.Category).FirstOrDefault(_ => _.Id == Id);
            if (news != null)
            {
                newsModel.Id = news.Id;
                newsModel.Name = news.Name;
                newsModel.Photo = news.Photo;
                newsModel.PublishDate = news.PublishDate;
                newsModel.Category = news.Category;
                newsModel.CategoryId = news.CategoryId;
                newsModel.Context = news.Context;
            }
            return newsModel;
        }

        public bool DeleteCategory(int Id)
        {
            try
            {
                var category = _dbContext.Categories.FirstOrDefault(_ => _.Id == Id);
                if (category != null)
                {
                    _dbContext.Entry(category).State = EntityState.Deleted;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        public NewsCategoryModel GetCategory(int Id)
        {
            NewsCategoryModel newsCategoryModel = new NewsCategoryModel();
            var category = _dbContext.Categories.Include(_ => _.News).FirstOrDefault(_ => _.Id == Id);
            if (category != null)
            {
                newsCategoryModel.Id = category.Id;
                newsCategoryModel.Name = category.Name;
                newsCategoryModel.News = category.News;

            }
            return newsCategoryModel;
        }
        public bool EditCategory(NewsCategoryModel newsCategory)
        {

            _dbContext.Categories.Update(
                new NewsCategoryEntity
                {
                    Id = newsCategory.Id,
                    Name = newsCategory.Name
                });
            _dbContext.SaveChanges();
            return true;
        }

        public List<NewsModel> GetNewsList(int categoryId)
        {
            var _news = new List<NewsModel>();

            var news = _dbContext.News.Include(_=>_.Category).Where(_ => _.CategoryId == categoryId).ToList();

            foreach(var item in news)
            {
                _news.Add(
                    new NewsModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Photo = item.Photo,
                        PublishDate = item.PublishDate,
                        Category = item.Category,
                        CategoryId = item.CategoryId,
                        Context = item.Context

                    }); 
            }

            return _news;

        }
    }
}
