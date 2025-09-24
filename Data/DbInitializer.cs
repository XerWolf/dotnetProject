using ContactsApi.Models;

namespace ContactsApi.Data;

public static class DbInitializer
{
    public static void Seed(ContactsDbContext db)
    {
        db.Database.EnsureCreated();

        if (!db.Contacts.Any())
        {
            db.Contacts.AddRange(
                new Contact 
                { 
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                    FirstName = "John", 
                    LastName = "Doe", 
                    PhoneNumber = "123-456" 
                },
                new Contact 
                { 
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), 
                    FirstName = "Jane", 
                    LastName = "Smith", 
                    PhoneNumber = "987-654" 
                }
            );

            db.SaveChanges();
        }
    }
}
