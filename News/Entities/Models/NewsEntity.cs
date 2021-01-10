using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace News.Entities.Models
{
    public class NewsEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }

        [Display(Name ="Date")]
        public DateTime PublishDate { get; set; }
        public string Photo { get; set; }
        public int? CategoryId { get; set; }
        public virtual NewsCategoryEntity Category { get; set; }
    }
}
