using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        //[NotMapped]
        public List<Post> Posts { get; set; } //Navigation propertyy to Post

    }
}
