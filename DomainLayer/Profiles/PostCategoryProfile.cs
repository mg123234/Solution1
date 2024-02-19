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
    public class PostCategoryProfile : Profile
    {
        public PostCategoryProfile()
        {
            CreateMap<PostCategoryPostIndexDTO, PostCategory>();
            CreateMap<PostCategory, PostCategoryPostIndexDTO>()
                .ForMember(vm => vm.CategorySelectDTO, m => m.MapFrom(x => x.Category));

            CreateMap<PostCategoryCreateDTO, PostCategory>();
            CreateMap<PostCategory, PostCategoryCreateDTO>();

            CreateMap<PostCategoryOfPostDTO, PostCategory>();
            CreateMap<PostCategory, PostCategoryOfPostDTO>();
        }
    }
}
