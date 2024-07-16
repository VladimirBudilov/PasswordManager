using System.ComponentModel.DataAnnotations;

namespace PasswordManager.DTOs;

public record CreatePasswordEntryDto([Required]string Name, [Required]string Password, [Required]string Type);