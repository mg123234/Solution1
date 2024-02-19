using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{

    public class CategoryIndexDTO
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public int Id { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }
        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }
    }

    public class CategoryCreateDTO
    {
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
       
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Parent")]
        public int? ParentId { get; set; }
    }
    public class CategoryEditDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
    }
    public class CategoryDetailsDTO
    {
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Display(Name = "Active")]
        [DataType(DataType.Text)]
        public bool IsActive { get; set; }
        public int Id { get; set; }
        [Display(Name = "Created Date")]
        [DataType(DataType.Text)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Updated Date")]
        [DataType(DataType.Text)]
        public DateTime UpdatedDate { get; set; }
        [Display(Name = "Parent Name")]
        [DataType(DataType.Text)]
        public string ParentName { get; set; }
    }
    public class CategorySelectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
