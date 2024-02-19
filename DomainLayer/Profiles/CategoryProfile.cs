using AutoMapper;
using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryIndexDTO>();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<Category, CategoryEditDTO>();
            CreateMap<CategoryEditDTO, Category>();
            CreateMap<Category, CategoryDetailsDTO>()
            .ForMember(vm => vm.ParentName, m => m.MapFrom(x => x.Parent.Name));

            CreateMap<Category, CategorySelectDTO>();
            CreateMap<CategorySelectDTO, Category>();
        }
    }
}
