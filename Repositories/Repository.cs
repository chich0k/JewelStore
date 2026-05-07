using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using JewelStore.Data;

namespace JewelStore.Repositories;

// Базовая реализация универсального репозитория поверх EF Core
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly JewelDbContext _vault;
    protected readonly DbSet<T> _setOf;

    public Repository(JewelDbContext context)
    {
        _vault = context;
        _setOf = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await _setOf.ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id) => await _setOf.FindAsync(id);

    // Поиск по произвольному условию
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _setOf.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity) => await _setOf.AddAsync(entity);
    public void Update(T entity) => _setOf.Update(entity);
    public void Remove(T entity) => _setOf.Remove(entity);

    public async Task<int> SaveChangesAsync() => await _vault.SaveChangesAsync();
}
