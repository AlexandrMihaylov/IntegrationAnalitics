using System.Linq.Expressions;
using IntegrationAnalitics.Application.Abstractions;
using IntegrationAnalitics.Application.Domain.Entities;
using IntegrationAnalitics.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace IntegrationAnalitics.Infrastructure.Database.Repositories;

public class QARepository:IRepository<QA>
{
    private readonly BARSContext _context;
    private readonly DbSet<QA> _db;

    public QARepository(BARSContext context)
    {
        _context = context;
        _db = context.Set<QA>();
    }

    public int Create(QA item)
    {
        _db.Add(item);
        return _context.SaveChanges();
    }

    public QA FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<QA> Get()
    {
        return _db.AsNoTracking().ToList();
    }

    public IEnumerable<QA> Get(Func<QA, bool> predicate)
    {
        return _db.AsNoTracking().Where(predicate).ToList();
    }

    public int Remove(QA item)
    {
        throw new NotImplementedException();
    }

    public int Update(QA item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<QA> GetWithInclude(Func<QA, bool> predicate, params Expression<Func<QA, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<QA> GetWithInclude(object includeProperty, params Expression<Func<QA, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }
}