using DomainLayer.Custom;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace WebApplication1.Areas.Admin.ViewModels
{
    public class CategoryVM
    {
        public PageInfo PageInfo { get; set; }
        public IList<CategoryIndexDTO> CategoryList { get; set; }
        public SelectList PageSizeSelectList { get; set; }
    }
    public class CategoryCreateVM
    {
        public CategoryCreateDTO CategoryCreateDTO { get; set; }
        public IList<SelectListItem> CategorySelectList { get; set; }
        /*public List<SelectListItem> IsActiveList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = null, Text = "Not Set" },
            new SelectListItem { Value = "true", Text = "True" },
            new SelectListItem { Value = "false", Text = "False" },
        };*/
    }
    public class CategoryEditVM
    {
        public CategoryEditDTO CategoryEditDTO { get; set; }

        public IList<SelectListItem> CategorySelectList { get; set; }
        /*
        public List<SelectListItem> IsActiveList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = null, Text = "Not Set" },
            new SelectListItem { Value = "true", Text = "True" },
            new SelectListItem { Value = "false", Text = "False" },
        };*/
    }
    public class CategoryDetailsVM
    {
        public CategoryDetailsDTO CategoryDetailsDTO { get; set; }
     
    }
}
