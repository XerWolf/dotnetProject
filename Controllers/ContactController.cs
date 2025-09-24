using Microsoft.AspNetCore.Mvc;
using ContactsApi.Models;
using ContactsApi.DTOs;

namespace ContactsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    // Simple in-memory contact list for demonstration
    private static List<Contact> contacts = new List<Contact>();

    // Contact model
    // ...existing code...
    


[HttpPost]
public IActionResult CreateContact([FromBody] CreateContactDto contactDto)
{
    if (contactDto == null || string.IsNullOrWhiteSpace(contactDto.FirstName))
    {
        return BadRequest("Contact data is invalid.");
    }

    var contact = new Contact(
        contactDto.FirstName,
        contactDto.LastName,
        contactDto.Email,
        contactDto.Phone
    );

    contacts.Add(contact);
    return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
}

// DELETE: api/contact/{id}
[HttpDelete("{id}")]
public IActionResult DeleteContact(Guid id)
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);
    if (contact == null)
    {
        return NotFound();
    }
    contacts.Remove(contact);
    return NoContent();
}

// PUT: api/contact/{id}
[HttpPut("{id}")]
public IActionResult UpdateContact(Guid id, [FromBody] Contact updatedContact)
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);
    if (contact == null)
    {
        return NotFound();
    }
    contacts.Remove(contact);

    if (updatedContact == null || string.IsNullOrWhiteSpace(updatedContact.FirstName))
    {
        return BadRequest("Contact data is invalid.");
    }
    updatedContact.Id = id;
    contacts.Add(updatedContact);

    return Ok(updatedContact);
}

// GET: api/contact/{id}
[HttpGet("{id}")]
public IActionResult GetContact(Guid id)
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);
    if (contact == null)
    {
        return NotFound();
    }
    return Ok(contact);
}
}