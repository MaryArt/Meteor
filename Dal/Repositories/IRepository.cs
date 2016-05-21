using System;
using System.Collections.Generic;

namespace Dal.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T state);
        void Update(T state);
        void Delete(int id);
    }
}
