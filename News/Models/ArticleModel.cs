using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class ArticleModel
    {
        public int NewsId { get; set; }
        public string NewsText { get; set; }
        public string NewsHeader { get; set; }
    }
}
