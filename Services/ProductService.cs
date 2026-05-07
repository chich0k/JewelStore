using JewelStore.Models;
using JewelStore.Repositories;

namespace JewelStore.Services;

// Бизнес-сервис для работы с товарами
public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _piecesRepo;

    public ProductService(IProductRepository repo) => _piecesRepo = repo;

    public Task<IEnumerable<Product>> GetAllAsync() => _piecesRepo.GetAllWithCategoryAsync();
    public Task<Product?> GetByIdAsync(int id) => _piecesRepo.GetByIdWithDetailsAsync(id);
    public Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId) => _piecesRepo.GetByCategoryAsync(categoryId);

    public async Task CreateAsync(Product product)
    {
        await _piecesRepo.AddAsync(product);
        await _piecesRepo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _piecesRepo.Update(product);
        await _piecesRepo.SaveChangesAsync();
    }

    // Удаление: сначала ищем сущность, потом удаляем
    public async Task DeleteAsync(int id)
    {
        var p = await _piecesRepo.GetByIdAsync(id);
        if (p is null) return;
        _piecesRepo.Remove(p);
        await _piecesRepo.SaveChangesAsync();
    }
}
