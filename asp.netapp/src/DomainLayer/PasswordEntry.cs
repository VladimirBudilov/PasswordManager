using System.ComponentModel.DataAnnotations;

namespace DomainLayer;

public class PasswordEntry(string name, string password, EntryType type)
{
    public Guid Id { get; set; }
    public string Name { get; set; } = name;
    public string Password { get; set; } = password;
    public EntryType Type { get; set; } = type;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public enum EntryType
{
    [Display(Name = "Website")] Website,
    [Display(Name = "Email")] Email
}