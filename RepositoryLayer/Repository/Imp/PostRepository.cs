using AutoMapper;
using DomainLayer.Custom;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Impl.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.Imp
{
    public class PostRepository : CRUDRepository<Post>, IPostRepository
    {
        private readonly IMapper _mapper;
        public PostRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        

        public Post Create(PostCreateDTO dto)
        {
            Post model;
            if (dto != null)
            {
                model=entities.Add(_mapper.Map<Post>(dto)).Entity;
            }
            else
            {
                throw new ArgumentNullException(nameof(dto));
            }
            return model;
        }

        public Post Update(PostEditDTO dto)
        {
            Post entity;
            if (dto != null)
            {
                entity = entities
                    .Include(x=>x.PostCategories)
                    .FirstOrDefault(x => x.Id == dto.Id);
                if (entity!=null)
                {
                    entity.Name = dto.Name;
                    entity.Description = dto.Description;
                    entity.Content = dto.Content;
                    entity.Published = dto.Published;
                    entity.Slug = dto.Slug;
                    entity.IsActive = dto.IsActive;
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(dto));
            }
            return entity;
        }

        public PostEditDTO Edit(int id)
        {
            PostEditDTO dto;
            if (id > 0)
            {
                var entity = entities
                    .Include(x=>x.User)
                    .Include(x=>x.PostCategories)
                    .AsNoTracking()
                    .FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    dto = _mapper.Map<PostEditDTO>(entity);
                }
                else
                {
                    throw new Exception("PostEditDTO not found");
                }
            }
            else
            {
                throw new ArgumentNullException("edit id is less than 1");
            }
            return dto;
        }

        public IList<PostIndexDTO> Index(PageInfo pageInfo)
        {
            IList<PostIndexDTO> list;
            if (pageInfo != null)
            {
                var queryable = entities
                    .Include(x=>x.User)
                    .Include(x=>x.PostCategories)
                     .ThenInclude(x=>x.Category)
                    .AsNoTracking();
                if (pageInfo.SearchColumn.Equals("Description"))
                {
                    queryable = queryable
                        .Where(x => string.IsNullOrEmpty(pageInfo.SearchValue) || x.Description.Contains(pageInfo.SearchValue));
                }
                else
                {
                    queryable = queryable
                        .Where(x => string.IsNullOrEmpty(pageInfo.SearchValue) || x.Name.Contains(pageInfo.SearchValue));
                }
                pageInfo.ItemNumber = queryable.Count();
                Expression<Func<Post, object>> orderByFunc;
                if (pageInfo.OrderColumn == "Name")
                {
                    orderByFunc = x => x.Name;
                }
                else if (pageInfo.OrderColumn == "Description")
                {
                    orderByFunc = x => x.Description;
                }
                else if (pageInfo.OrderColumn == "User")
                {
                    orderByFunc = x => x.User.UserName;
                }
                else if (pageInfo.OrderColumn == "CreatedDate")
                {
                    orderByFunc = x => x.CreatedDate;
                }
                else if (pageInfo.OrderColumn == "UpdatedDate")
                {
                    orderByFunc = x => x.UpdatedDate;
                }
                else if (pageInfo.OrderColumn == "IsActive")
                {
                    orderByFunc = x => x.IsActive;
                }
                else
                {
                    orderByFunc = x => x.Id;
                }
                if (pageInfo.OrderAsc)
                {
                    queryable = queryable.OrderBy(orderByFunc);
                }
                else
                {
                    queryable = queryable.OrderByDescending(orderByFunc);
                }
                queryable = queryable
                    .Skip((pageInfo.PageIndex - 1) * pageInfo.PageSize)
                    .Take(pageInfo.PageSize);
                
                list = _mapper.Map<IList<PostIndexDTO>>(queryable);
                //foreach (var item in list)
                //item.PostCategories = item.PostCategories.Where(x => x.Id != 4).ToList();
            }
            else
            {
                throw new ArgumentNullException(nameof(pageInfo));
            }

            return list;
        }

        public PostDetailsDTO Details(int id)
        {
            PostDetailsDTO dto;
            if (id > 0)
            {
                var entity = entities
                    .Include(x=>x.User)
                    .Include(x => x.PostCategories)
                        .ThenInclude(x=>x.Category)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    dto = _mapper.Map<PostDetailsDTO>(entity);
                }
                else
                {
                    throw new Exception("PostDetailsDTO not found");
                }
            }
            else
            {
                throw new ArgumentNullException("details id is less than 1");
            }

            return dto;
        }

    }
}
