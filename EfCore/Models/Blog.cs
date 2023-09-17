using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(150)")]
        [Comment("the URL of the blog")]
        public string Url { get; set; }
        //[NotMapped] 

        public List<Post> Posts { get; set; } //Navigation propertyy to Post

    }
}
