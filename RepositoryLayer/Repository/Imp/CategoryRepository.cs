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
    public class CategoryRepository : CRUDRepository<Category>, ICategoryRepository
    {
        private readonly IMapper _mapper;

        public CategoryRepository(IMapper mapper, AppDbContext context) : base(context)
        {
            _mapper = mapper;
        }

        public void Create(CategoryCreateDTO dto)
        {
            if (dto != null)
            {
                entities.Add(_mapper.Map<Category>(dto));
            }
            else
            {
                throw new ArgumentNullException(nameof(dto));
            }
        }

        public void Update(CategoryEditDTO dto)
        {
            if (dto != null)
            {
                var entity = entities.FirstOrDefault(x => x.Id == dto.Id);
                if (entity!=null)
                {
                    entity.Name = dto.Name;
                    entity.Description = dto.Description;
                    entity.IsActive = dto.IsActive;
                    entity.ParentId = dto.ParentId;
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
        }

        public CategoryEditDTO Edit(int id)
        {
            CategoryEditDTO dto;
            if (id > 0)
            {
                var entity = entities
                    .AsNoTracking()
                    .FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    dto = _mapper.Map<CategoryEditDTO>(entity);
                }
                else
                {
                    throw new Exception("CategoryEditDTO not found");
                }
            }
            else
            {
                throw new ArgumentNullException("edit id is less than 1");
            }
            return dto;
        }

        public IList<CategoryIndexDTO> Index(PageInfo pageInfo)
        {
            IList<CategoryIndexDTO> list;
            if (pageInfo != null)
            {
                var queryable = entities
                    .AsNoTracking();
                if (pageInfo.SearchColumn.Equals("Description"))
                {
                    queryable = queryable
                        .Where(x => string.IsNullOrEmpty(pageInfo.SearchValue) || x.Description.Contains(pageInfo.SearchValue));
                    pageInfo.ItemNumber = queryable.Count();
                }
                else if(pageInfo.SearchColumn.Equals("Name"))
                {
                    queryable = queryable
                        .Where(x => string.IsNullOrEmpty(pageInfo.SearchValue) || x.Name.Contains(pageInfo.SearchValue));
                    pageInfo.ItemNumber = queryable.Count();
                }
                else
                {
                    queryable = queryable
                        .Where(x => string.IsNullOrEmpty(pageInfo.SearchValue) || x.Name.Contains(pageInfo.SearchValue));
                    pageInfo.ItemNumber = queryable.Count();
                }
                Expression<Func<Category, object>> orderByFunc;
                if (pageInfo.OrderColumn == "Name")
                {
                    orderByFunc = x => x.Name;
                }
                else if (pageInfo.OrderColumn == "Description")
                {
                    orderByFunc = x => x.Description;
                }
                else if (pageInfo.OrderColumn == "Parent")
                {
                    orderByFunc = x => x.Parent.Name;
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
                list = _mapper.Map<IList<CategoryIndexDTO>>(queryable);
            }
            else
            {
                throw new ArgumentNullException(nameof(pageInfo));
            }
           
            return list;
        }

        public CategoryDetailsDTO Details(int id)
        {
            CategoryDetailsDTO dto;
            if (id > 0)
            {
                var entity = entities
                    .Include(x => x.Parent)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    dto = _mapper.Map<CategoryDetailsDTO>(entity);
                }
                else
                {
                    throw new Exception("categoryDetailsDTO not found");
                }
            }
            else
            {
                throw new ArgumentNullException("details id is less than 1");
            }

            return dto;
        }

        public IList CategorySelectList()
        {
            IList list;
            list = entities.AsNoTracking().Select(x => new 
            {
                x.Id,
                x.Name
            }).ToList();
            return list;
        }

    }
}
