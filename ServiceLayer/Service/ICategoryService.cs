using DomainLayer.Custom;
using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer.Service
{
    public interface ICategoryService :ICRUDService<Category>
    {
        IList CategorySelectList();
        CategoryDetailsDTO Details(int id);
        CategoryEditDTO Edit(int id);
        void Update(CategoryEditDTO dto);
        void Create(CategoryCreateDTO dto);
        IList<CategoryIndexDTO> Index(PageInfo pageInfo);
    }
}
