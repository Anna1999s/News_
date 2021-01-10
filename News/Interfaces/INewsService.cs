using News.Entities.Models;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Interfaces
{
    public interface INewsService
    {
        public NewsEntity AddNews(NewsModel news);
        public List<NewsModel> GetNewsList();
        public List<NewsModel> GetNewsList(int categoryId);
        public NewsCategoryEntity AddCategory(NewsCategoryModel newsCategory);
        public List<NewsCategoryModel> GetCategoriesList();
        public bool DeleteNews(int Id);
        public bool EditNews(NewsModel news);
        public NewsModel GetNews(int Id);
        public bool DeleteCategory(int Id);
        public NewsCategoryModel GetCategory(int Id);
        public bool EditCategory(NewsCategoryModel newsCategory);
    }
}
