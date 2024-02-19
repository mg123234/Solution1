using DomainLayer.Custom;
using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryLayer.Repository
{
    public interface ICategoryRepository : ICRUDRepository<Category>
    {
        CategoryDetailsDTO Details(int id);
        CategoryEditDTO Edit(int id);
        void Create(CategoryCreateDTO dto);
        void Update(CategoryEditDTO dto);
        IList<CategoryIndexDTO> Index(PageInfo pageInfo);
        IList CategorySelectList();
    }
}
