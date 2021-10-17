using System.Collections.Generic;
using HousingSystem.DomainLayer.Entities;

namespace HousingSystem.DomainLayer.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        int Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
