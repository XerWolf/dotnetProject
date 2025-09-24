using ContactsApi.Data;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Repositories;

public class ContactsRepository : IContactsRepository
{
    private readonly ContactsDbContext _db;

    public ContactsRepository(ContactsDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        return await _db.Contacts.ToListAsync();
    }

    public async Task AddAsync(Contact contact)
    {
        await _db.Contacts.AddAsync(contact);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var contact = await _db.Contacts.FindAsync(id);
        if (contact != null)
        {
            _db.Contacts.Remove(contact);
            await _db.SaveChangesAsync();
        }
    }
}