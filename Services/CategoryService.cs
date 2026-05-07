using JewelStore.Models;
using JewelStore.Repositories;

namespace JewelStore.Services;

// Бизнес-сервис для работы с категориями товаров
public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task CreateAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _piecesRepo;

    public CategoryService(IRepository<Category> repo) => _piecesRepo = repo;

    public Task<IEnumerable<Category>> GetAllAsync() => _piecesRepo.GetAllAsync();
    public Task<Category?> GetByIdAsync(int id) => _piecesRepo.GetByIdAsync(id);

    public async Task CreateAsync(Category category)
    {
        await _piecesRepo.AddAsync(category);
        await _piecesRepo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _piecesRepo.Update(category);
        await _piecesRepo.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var c = await _piecesRepo.GetByIdAsync(id);
        if (c is null) return;
        _piecesRepo.Remove(c);
        await _piecesRepo.SaveChangesAsync();
    }
}
