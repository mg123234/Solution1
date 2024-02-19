using DomainLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{

    public class PostIndexDTO 
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Published")]
        public bool Published { set; get; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }
        [Display(Name = "Author")]
        public string User { get; set; }
        [Display(Name = "Category List")]
        public IList<PostCategoryPostIndexDTO> CategoryList { get; set; }
    }

    public class PostCreateDTO 
    {
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Description")]

        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.Text)]
        [StringLength(1000, MinimumLength = 3)]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Slug")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 3)]
        public string Slug { set; get; }

        [Display(Name = "Published")]
        public bool Published { set; get; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public string UserId { get; set; }
        [Required]
        [Display(Name = "Category List")]
        public IList<int> CategoryIdList { get; set; }
    }
    public class PostEditDTO
    {
        public int Id { get; set; }
        [Required] 
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Description")]

        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }
     
        [Display(Name = "Content")]
        [DataType(DataType.Text)]
        [StringLength(1000, MinimumLength = 3)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Slug")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 3)]
        public string Slug { set; get; }
        [Display(Name = "Author")]
        [DataType(DataType.Text)]
        public string User { get; set; }

        [Display(Name = "Published")]
        public bool Published { set; get; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public IList<PostCategoryOfPostDTO> PostCategories { get; set; }
        [Required]
        [Display(Name = "Category List")]
        public IList<int> CategoryIdList { get; set; }
    }
    public class PostDetailsDTO 
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Display(Name = "Content")]
        [DataType(DataType.Text)]
        [StringLength(1000, MinimumLength = 3)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Slug")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 3)]
        public string Slug { set; get; }
        [Display(Name = "Published")]
        public bool Published { set; get; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Updated Date")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }
        [Display(Name = "Author")]
        [DataType(DataType.Text)]
        public string User { get; set; }

        public IList<PostCategoryPostIndexDTO> CategoryList { get; set; }
    }
}
