using System.Linq.Expressions;

namespace DomainLayer;

// IPasswordEntryRepository.cs
public interface IPasswordEntryRepository
{
    Task<List<PasswordEntry>> GetAllAsync();
    Task<List<PasswordEntry>> FilterAsync(string name);
    Task<PasswordEntry> GetByIdAsync(int id);
    Task<PasswordEntry> GetByNameAsync(string name);
    Task AddAsync(PasswordEntry entry);
    
    
}
