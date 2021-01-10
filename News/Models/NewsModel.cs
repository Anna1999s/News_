using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using News.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewsModel: NewsEntity
    {
        public List<NewsCategoryModel> newsCategories { get; set; }
                
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
