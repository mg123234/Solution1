using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{

    public class PostCategoryPostIndexDTO
    {
        public CategorySelectDTO CategorySelectDTO { get; set; }
    }
    public class PostCategoryCreateDTO
    {
        public Post Post { get; set; }
        public int CategoryId { get; set; }
    }
    public class PostCategoryOfPostDTO
    {
        public int CategoryId { get; set; }
    }
}
