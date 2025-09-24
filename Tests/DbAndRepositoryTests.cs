using ContactsApi.Data;
using ContactsApi.Models;
using ContactsApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContactsApi.Tests;

public class DbAndRepositoryTests
{
    private ContactsDbContext CreateInMemoryDb()
    {
        var options = new DbContextOptionsBuilder<ContactsDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // fresh DB per test
            .Options;

        return new ContactsDbContext(options);
    }

    [Fact]
    public void Seed_ShouldPopulateDatabase_WhenEmpty()
    {
        // Arrange
        var db = CreateInMemoryDb();

        // Act
        DbInitializer.Seed(db);

        // Assert
        var allContacts = db.Contacts.ToList();
        Assert.Equal(2, allContacts.Count);
        Assert.Contains(allContacts, c => c.FirstName == "John");
        Assert.Contains(allContacts, c => c.FirstName == "Jane");
    }

    [Fact]
    public async Task AddAsync_ShouldStoreContact()
    {
        var db = CreateInMemoryDb();
        var repo = new ContactsRepository(db);
        var contact = new Contact 
        { 
            Id = Guid.NewGuid(), 
            FirstName = "Alice", 
            LastName = "Brown", 
            PhoneNumber = "555-555" 
        };

        await repo.AddAsync(contact);

        var all = await repo.GetAllAsync();
        Assert.Single(all);
        Assert.Equal("Alice", all.First().FirstName);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveContact()
    {
        var db = CreateInMemoryDb();
        var repo = new ContactsRepository(db);
        var contact = new Contact 
        { 
            Id = Guid.NewGuid(), 
            FirstName = "Bob", 
            LastName = "Green", 
            PhoneNumber = "555-123" 
        };

        await repo.AddAsync(contact);
        await repo.DeleteAsync(contact.Id);

        var all = await repo.GetAllAsync();
        Assert.Empty(all);
    }
}
