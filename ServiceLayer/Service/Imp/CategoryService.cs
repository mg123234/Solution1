using DomainLayer.Custom;
using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer.Service.Imp
{
    public class CategoryService : CRUDService<Category>, ICategoryService
    {
     
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo):base(repo)
        {
            _repo = repo;
        }

        public void Edit(CategoryEditDTO dto)
        {
            _repo.Update(dto);
            _repo.SaveChanges();
        }
        public void Create(CategoryCreateDTO dto)
        {
            _repo.Create(dto);
            _repo.SaveChanges();
        }

        public IList<CategoryIndexDTO> Index(PageInfo info)
        {
            return _repo.Index(info);
        }

        public CategoryEditDTO Edit(int id)
        {
            return _repo.Edit(id);
        }

        public void Update(CategoryEditDTO dto)
        {
            _repo.Update(dto);
            _repo.SaveChanges();
        }

        public CategoryDetailsDTO Details(int id)
        {
            return _repo.Details(id);
        }
        
        public IList CategorySelectList()
        {
            return _repo.CategorySelectList();
        }
    }
}
