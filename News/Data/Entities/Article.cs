using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
    }
}
