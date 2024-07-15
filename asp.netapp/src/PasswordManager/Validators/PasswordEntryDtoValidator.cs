using DomainLayer;

namespace PasswordManager.Validators;

using FluentValidation;
using PasswordManager.DTOs;

public class PasswordEntryDtoValidator : AbstractValidator<PasswordEntryDto>
{
    public PasswordEntryDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Password)
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.");
        RuleFor(x => x.Type).IsEnumName(typeof(EntryType), caseSensitive: false).WithMessage("Type must be a valid entry type.");
    }
}