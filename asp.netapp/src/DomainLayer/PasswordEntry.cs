namespace DomainLayer;

// PasswordEntry.cs (Entity)
public class PasswordEntry
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public EntryType Type { get; set; } 
    public DateTime CreatedAt { get; set; }
    
    public PasswordEntry(string name, string password, EntryType type)
    {
        Name = name;
        Password = password;
        Type = type;
        CreatedAt = DateTime.UtcNow;
    }
    
    public string RevealPassword()
    {
        return Password;
    }
}

public enum EntryType
{
    Website,
    Email
}
