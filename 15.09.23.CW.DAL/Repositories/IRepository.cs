using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._09._23.CW.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Remove(T entity);

        IEnumerable<T> GetAll();

        T Get(int id);

        void Update(int id, T Entity);
    }
}
