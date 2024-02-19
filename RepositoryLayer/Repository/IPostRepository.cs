using DomainLayer.Custom;
using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface IPostRepository :ICRUDRepository<Post>
    {
        PostDetailsDTO Details(int id);
        PostEditDTO Edit(int id);
        Post Create(PostCreateDTO dto);
        Post Update(PostEditDTO dto);
        IList<PostIndexDTO> Index(PageInfo pageInfo);
        
    }
}
