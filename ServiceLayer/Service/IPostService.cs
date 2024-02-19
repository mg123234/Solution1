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
    public interface IPostService : ICRUDService<Post>
    {
        PostDetailsDTO Details(int id);
        PostEditDTO Edit(int id);
        void Create(PostCreateDTO dto);
        void Update(PostEditDTO dto);
        IList<PostIndexDTO> Index(PageInfo pageInfo);
        IList CategorySelectList();
    }
}
