using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CustomerAPI.Repository.Interface;
public interface IGenericRepository<T> where T : class 
{
    Task<List<T>> GetAll();
    Task<T> Get(Guid id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
}