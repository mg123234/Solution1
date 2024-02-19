using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface IPostCategoryRepository : ICRUDRepository<PostCategory>
    {
        void Create(PostCategoryCreateDTO dto);
    }
}
