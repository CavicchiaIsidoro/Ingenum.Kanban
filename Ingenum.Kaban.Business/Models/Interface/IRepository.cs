using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ingenum.Kaban.Business.Models.Interface
{
    public interface IRepository<T> where T : class, new()
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
