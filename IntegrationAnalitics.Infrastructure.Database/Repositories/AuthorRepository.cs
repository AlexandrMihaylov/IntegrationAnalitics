using System.Linq.Expressions;
using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace IntegrationAnalitics.Infrastructure.Database.Repositories;

public class AuthorRepository:IRepository<Author>
{
    private readonly BARSContext _context;
    private readonly DbSet<Author> _db;

    public AuthorRepository(BARSContext context)
    {
        _context = context;
        _db = context.Set<Author>();
    }

    public int Create(Author item)
    {
        _db.Add(item);
        return _context.SaveChanges();
    }

    public Author FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Author> Get()
    {
        return _db.AsNoTracking().ToList();
    }

    public IEnumerable<Author> Get(Func<Author, bool> predicate)
    {
        return _db.AsNoTracking().Where(predicate).ToList();
    }

    public int Remove(Author item)
    {
        throw new NotImplementedException();
    }

    public int Update(Author item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Author> GetWithInclude(Func<Author, bool> predicate, params Expression<Func<Author, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Author> GetWithInclude(object includeProperty, params Expression<Func<Author, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }
}