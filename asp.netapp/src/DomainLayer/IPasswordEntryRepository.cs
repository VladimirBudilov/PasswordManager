namespace DomainLayer;

public interface IPasswordEntryRepository
{
    Task<List<PasswordEntry>> GetAllAsync();
    Task<List<PasswordEntry>> FilterAsync(string name);
    Task<PasswordEntry> GetByNameAsync(string name);
    Task AddAsync(PasswordEntry entry);
}
