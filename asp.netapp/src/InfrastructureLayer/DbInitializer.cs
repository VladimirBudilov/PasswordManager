namespace Infrastructure_Layer;

using DomainLayer;
using Microsoft.EntityFrameworkCore;

public static class DbInitializer
{
    public static void SeedDatabase(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.PasswordEntries.Any())
        {
            var passwordEntries = new List<PasswordEntry>
            {
                new PasswordEntry ( "Entry1", "Password1", EntryType.Email ),
                new PasswordEntry ( "Entry2", "Password2", EntryType.Website ),
                new PasswordEntry ( "Entry3", "Password3", EntryType.Email ),
                new PasswordEntry( "Entry4", "Password4", EntryType.Website ),
                new PasswordEntry( "Entry5", "Password5", EntryType.Email ),
                new PasswordEntry( "Entry6", "Password6", EntryType.Website ),
                new PasswordEntry( "Entry7", "Password7", EntryType.Email ),
                new PasswordEntry( "Entry8", "Password8", EntryType.Website ),
                new PasswordEntry( "Entry9", "Password9", EntryType.Email ),
                new PasswordEntry( "Entry10", "Password10", EntryType.Website )
            };

            context.PasswordEntries.AddRange(passwordEntries);
            context.SaveChanges();
        }
    }
}