using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public interface ICRUDService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
