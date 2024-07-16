using AutoMapper;
using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.DTOs;
using PasswordManager.Services;

namespace PasswordManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PasswordsController(PasswordManagerService passwordManagerService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<PasswordEntry>>> GetPasswords(string occurrenceInEmail = null)
    {
        var passwordEntries = await passwordManagerService.GetPasswordEntriesAsync(occurrenceInEmail);
        var output = mapper.Map<List<PasswordEntryDto>>(passwordEntries);
        return Ok(new { passwords = output});
    }

    [HttpPost]
    public async Task<ActionResult> AddPassword(CreatePasswordEntryDto passwordDto)
    {
        var passwordEntity = mapper.Map<PasswordEntry>(passwordDto);
        var passwordAdded = await passwordManagerService.TryAddPasswordEntryAsync(passwordEntity);
        if (!passwordAdded)
            return Conflict();
        var output = mapper.Map<PasswordEntryDto>(passwordEntity);
        return CreatedAtAction(nameof(AddPassword), new { id = passwordEntity.Id }, output);
    }
}