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
    public class PostService :CRUDService<Post>, IPostService
    {
        private readonly IPostRepository _repo;
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PostService(IPostRepository repo, IPostCategoryRepository postCategoryRepository, ICategoryRepository categoryRepository) : base(repo)
        {
            _repo = repo;
            _postCategoryRepository = postCategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public PostEditDTO Edit(int id)
        {
            return _repo.Edit(id);
        }
        public void Create(PostCreateDTO dto)
        {
            Post post=_repo.Create(dto);
            foreach(var item in dto.CategoryIdList)
            {
                _postCategoryRepository.Create(new PostCategory()
                {
                    Post= post,
                    CategoryId=item
                });
            }
            _repo.SaveChanges();
        }

        public IList<PostIndexDTO> Index(PageInfo info)
        {
            return _repo.Index(info);
        }

   

        public void Update(PostEditDTO dto)
        {
            Post post = _repo.Update(dto);
            var oldIds = post.PostCategories.Select(x => x.Id).ToList();
            var newIds = dto.CategoryIdList;
            var removePCs = post.PostCategories.Where(x => !newIds.Contains(x.Id));
            _postCategoryRepository.DeleteRange(removePCs);
            var addIds = newIds.Where(x => !oldIds.Contains(x));
            foreach (var item in addIds) { 
                _postCategoryRepository.Create(new PostCategory()
                {
                    Post = post,
                    CategoryId = item
                });
            }
            _repo.SaveChanges();
        }

        public PostDetailsDTO Details(int id)
        {
            return _repo.Details(id);
        }

        public IList CategorySelectList()
        {
            return _categoryRepository.CategorySelectList();
        }
    }
}
