using Microsoft.EntityFrameworkCore;
using JewelStore.Data;
using JewelStore.Models;

namespace JewelStore.Services;

// Упрощённый сервис текущего пользователя (без авторизации, для демо)
public interface ICurrentUserService
{
    Task<Customer> GetOrCreateGuestVisitorAsync();
}

public class CurrentUserService : ICurrentUserService
{
    private readonly JewelDbContext _vault;

    // Email фиктивного покупателя демо-режима
    private const string GuestVisitorEmail = "guest@jewelstore.local";

    public CurrentUserService(JewelDbContext context) => _vault = context;

    // Возвращает существующего демо-покупателя или создаёт нового
    public async Task<Customer> GetOrCreateGuestVisitorAsync()
    {
        var customer = await _vault.Customers.FirstOrDefaultAsync(c => c.Email == GuestVisitorEmail);

        if (customer == null)
        {
            customer = new Customer
            {
                FullName = "Demo Visitor",
                Email = GuestVisitorEmail,
                RegisteredAt = DateTime.UtcNow
            };
            _vault.Customers.Add(customer);
            await _vault.SaveChangesAsync();
        }
        return customer;
    }
}
