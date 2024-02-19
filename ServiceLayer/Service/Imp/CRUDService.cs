using DomainLayer.Models;
using RepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Imp
{
    public class CRUDService<T> : ICRUDService<T> where T : BaseEntity
    {
        private readonly ICRUDRepository<T> _repo;
        public CRUDService(ICRUDRepository<T> repo)
        {
            _repo = repo;
        }
        public void Create(T entity)
        {
            _repo.Create(entity);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _repo.GetAll();
        }

        public T Get(int id)
        {
            return _repo.Get(id);
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
            _repo.SaveChanges();
        }
    }
}
