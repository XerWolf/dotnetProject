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
                new Contact (Guid.Parse("11111111-1111-1111-1111-111111111111"), "John", "Doe", "jd@email.com", " 123-456"),
                 new Contact (Guid.Parse("11111111-1111-1111-1111-111111111112"), "Jane", "Smith", "js@email.com", "987-654" ) 
            );

            db.SaveChanges();
        }
    }
}
