using Microsoft.EntityFrameworkCore;
using ContactsApi.Models;

namespace ContactsApi.Data;

public class ContactsDbContext(DbContextOptions<ContactsDbContext> options) : DbContext(options)
{
    public DbSet<Contact> Contacts => Set<Contact>();
}
