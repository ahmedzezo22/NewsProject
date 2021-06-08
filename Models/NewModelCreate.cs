using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewModelCreate
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Topic { get; set; }
        public IFormFile Image { get; set; }

        public DateTime Date { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
