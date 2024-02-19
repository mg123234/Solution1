using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Post : BaseEntity
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [StringLength(1000, MinimumLength = 3)]
        public string Content { get; set; }

        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 3)]
        public string Slug { set; get; }

        public bool Published { set; get; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public IList<PostCategory> PostCategories { get; set; }

    }
}
