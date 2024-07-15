using System.ComponentModel.DataAnnotations;
using DomainLayer;

namespace PasswordManager.DTOs;

public record PasswordEntryDto([Required]string Name, [Required]string Password, string Type);