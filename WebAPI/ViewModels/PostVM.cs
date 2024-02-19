using DomainLayer.Custom;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Areas.Admin.ViewModels
{

    public class PostVM
    {
        public PageInfo PageInfo { get; set; }
        public IList<PostIndexDTO> PostList { get; set; }
        public SelectList PageSizeSelectList { get; set; }
    }
    public class PostCreateVM
    {
        public PostCreateDTO PostCreateDTO { get; set; }
        public IList<SelectListItem> CategorySelectList { get; set; }
    }
    public class PostEditVM
    {
        public PostEditDTO PostEditDTO { get; set; }

        public IList<SelectListItem> CategorySelectList { get; set; }
    }
    public class PostDetailsVM
    {
        public PostDetailsDTO PostDetailsDTO { get; set; }
        [Display(Name = "Category List")]
        public IList<SelectListItem> CategorySelectList { get; set; }
    }

}
