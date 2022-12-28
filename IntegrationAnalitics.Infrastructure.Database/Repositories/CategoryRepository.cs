using System.Linq.Expressions;
using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace IntegrationAnalitics.Infrastructure.Database.Repositories;

public class CategoryRepository : IRepository<Category>
{
    private readonly BARSContext _context;
    private readonly DbSet<Category> _db;

    public CategoryRepository(BARSContext context)
    {
        _context = context;
        _db = context.Set<Category>();
    }

    public int Create(Category item)
    {
        _db.Add(item);
        return _context.SaveChanges();
    }

    public Category FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> Get()
    {
        return _db.AsNoTracking().ToList();
    }

    public IEnumerable<Category> Get(Func<Category, bool> predicate)
    {
        return _db.AsNoTracking().Where(predicate).ToList();
    }

    public int Remove(Category item)
    {
        throw new NotImplementedException();
    }

    public int Update(Category item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetWithInclude(Func<Category, bool> predicate, params Expression<Func<Category, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetWithInclude(object includeProperty, params Expression<Func<Category, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }
}