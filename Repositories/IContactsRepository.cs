using ContactsApi.Models;

namespace ContactsApi.Repositories;

public interface IContactsRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task AddAsync(Contact contact);
    Task DeleteAsync(Guid id);
}