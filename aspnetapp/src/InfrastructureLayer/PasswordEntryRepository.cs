using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer;

public class PasswordEntryRepository(AppDbContext dbContext) : IPasswordEntryRepository
{
    private readonly DbSet<PasswordEntry> _passwordEntries = dbContext.Set<PasswordEntry>();
    public async Task<List<PasswordEntry>> GetAllAsync()
    {
        return await _passwordEntries.OrderByDescending(PasswordEntrySpecifications.OrderByData()).ToListAsync();
    }

    public async Task<List<PasswordEntry>> FilterAsync(string name)
    {
        return await _passwordEntries.Where(PasswordEntrySpecifications.ByName(name)).ToListAsync();
    }
    
    public async Task<PasswordEntry> GetByNameAsync(string name)
    {
        return await _passwordEntries.FirstOrDefaultAsync(PasswordEntrySpecifications.ByName(name));
    }

    public async Task AddAsync(PasswordEntry entry)
    {
        await _passwordEntries.AddAsync(entry);
        await dbContext.SaveChangesAsync();
    }
}
