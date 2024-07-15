using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer;

// PasswordEntryRepository.cs
public class PasswordEntryRepository(DbContext dbContext) : IPasswordEntryRepository
{
    private readonly DbSet<PasswordEntry> _passwordEntries = dbContext.Set<PasswordEntry>();
    public async Task<List<PasswordEntry>> GetAllAsync()
    {
        return await _passwordEntries.OrderBy(PasswordEntrySpecifications.OrderByData()).ToListAsync();
    }

    public async Task<List<PasswordEntry>> FilterAsync(string name)
    {
        return await _passwordEntries.Where(PasswordEntrySpecifications.ByName(name)).ToListAsync();
    }

    public async Task<PasswordEntry> GetByIdAsync(int id)
    {
        return await _passwordEntries.FindAsync(id);
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
