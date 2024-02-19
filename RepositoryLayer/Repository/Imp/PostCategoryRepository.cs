using AutoMapper;
using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Impl.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.Imp
{
    public class PostCategoryRepository : CRUDRepository<PostCategory>,IPostCategoryRepository
    {
        private readonly IMapper _mapper;
        public PostCategoryRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public void Create(PostCategoryCreateDTO dto)
        {
            if (dto != null)
            {
                entities.Add(_mapper.Map<PostCategory>(dto));
            }
            else
            {
                throw new ArgumentNullException(nameof(dto));
            }
        }

        
    }
}
