using System.Linq.Expressions;

namespace DomainLayer;

public static class PasswordEntrySpecifications
{
    public static Expression<Func<PasswordEntry, bool>> ByName(string name)
    {
        return entry => entry.Name.Contains(name, StringComparison.OrdinalIgnoreCase);
    }
    
    public static Expression<Func<PasswordEntry, DateTime>> OrderByData()
    {
        return entry => entry.CreatedAt;
    }
}
