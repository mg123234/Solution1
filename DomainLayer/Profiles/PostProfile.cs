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
    public class PostProfile:Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostIndexDTO>()
                .ForMember(vm => vm.CategoryList, m => m.MapFrom(x => x.PostCategories))
                .ForMember(vm => vm.User, m => m.MapFrom(x => x.User.UserName));

            CreateMap<PostCreateDTO, Post>();

            CreateMap<Post, PostEditDTO>()
                .ForMember(vm => vm.User, m => m.MapFrom(x => x.User.UserName));
            CreateMap<PostEditDTO, Post>();

            CreateMap<Post, PostDetailsDTO>()
                .ForMember(vm => vm.User, m => m.MapFrom(x => x.User.UserName))
                .ForMember(vm => vm.CategoryList, m => m.MapFrom(x => x.PostCategories));

           
        }
    }
}
