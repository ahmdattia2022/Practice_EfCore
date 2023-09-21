using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.Models
{
    public class Post
    {
        [Key]
        public int BookKey { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Tag> Tags { get; set; }//collection navigation property
        public List<PostTag> PostTags { get; set; }
        public Blog Blog { get; set; } //Navigation property
    }
    public class Tag
    {
        public string TagId { get; set; }
        public ICollection<Post> Posts{ get; set; }
        public List<PostTag> PostTags { get; set; }
    }
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string TagId { get; set; }
        public Tag Tag { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}
