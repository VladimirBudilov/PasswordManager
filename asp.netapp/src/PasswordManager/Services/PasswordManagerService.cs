using DomainLayer;

namespace PasswordManager.Services;

// PasswordManagerService.cs
public class PasswordManagerService(IPasswordEntryRepository repository)
{
    public async Task<bool> TryAddPasswordEntryAsync(PasswordEntry entry)
    {
        var existingEntry = await repository.GetAllAsync();
        if (existingEntry.Any(e => e.Name.Equals(entry.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }
        
        await repository.AddAsync(entry);
        return true;
    }

    public async Task<List<PasswordEntry>> GetPasswordEntriesAsync(string occurrenceInEmail)
    {
        if (string.IsNullOrEmpty(occurrenceInEmail))
        {
            return await repository.GetAllAsync();
        }

        return await repository.FilterAsync(occurrenceInEmail);
    }
}
