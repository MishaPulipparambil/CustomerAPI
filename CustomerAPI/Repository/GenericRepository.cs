using System.Linq.Expressions;
using CustomerAPI.Models;
using CustomerAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repository;
public class GenericRepository<T, TContext> : IGenericRepository<T> where T : class
where TContext : DbContext
{   
    
    private readonly TContext context;
    public GenericRepository(TContext context)
    {
        this.context = context;
    }
    public async Task<T> Add(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Delete(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> Get(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAll()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<T> Update(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
}