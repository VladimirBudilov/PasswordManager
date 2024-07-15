using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.DTOs;
using PasswordManager.Services;

namespace PasswordManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PasswordsController(PasswordManagerService passwordManagerService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PasswordEntry>>> GetPasswords(string occurrenceInEmail = null)
    {
        var passwords = await passwordManagerService.GetPasswordEntriesAsync(occurrenceInEmail);
        return Ok(passwords);
    }

    [HttpPost]
    public async Task<ActionResult> AddPassword(PasswordEntryDto passwordDto)
    {
        
        //convert dto to domain object
        var entryType = Enum.Parse<EntryType>(passwordDto.Type, true);
        await passwordManagerService.TryAddPasswordEntryAsync(passwordDto.Name, passwordDto.Password, entryType);
        return Ok();
    }

}