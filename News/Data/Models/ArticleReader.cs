using System.Globalization;

namespace News.Data.Models
{
    public class ArticleReader
    {
        public int ArticleId { get; set; }
        public string ArticleHeader { get; set; }=string.Empty;
        public string ArticleBody { get; set; } =string.Empty;
        public int UserId { get; set; } 

    }
}
