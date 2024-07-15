using DomainLayer;

namespace PasswordManager.Services;

// PasswordManagerService.cs
public class PasswordManagerService(IPasswordEntryRepository repository)
{
    public async Task<bool> TryAddPasswordEntryAsync(string name, string password, EntryType type)
    {
        var existingEntry = await repository.GetAllAsync();
        if (existingEntry.Any(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }

        var newEntry = new PasswordEntry(name, password, type);

        await repository.AddAsync(newEntry);
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
