using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface ICRUDRepository<T> where T : BaseEntity
    {
        void DeleteRange(IEnumerable<T> e);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Update(T entity);
        void SaveChanges();
        
    }
}
