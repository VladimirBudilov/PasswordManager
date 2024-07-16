using System.Net.Mail;
using DomainLayer;
using FluentValidation;
using Microsoft.OpenApi.Extensions;
using PasswordManager.DTOs;

namespace PasswordManager.Validations;

public class PasswordEntryDtoValidator : AbstractValidator<CreatePasswordEntryDto>
{
    public PasswordEntryDtoValidator()
    {
        RuleFor(x => x.Type).Must(x => x == EntryType.Website.GetDisplayName() || x == EntryType.Email.GetDisplayName()) 
            .WithMessage("Type must be a valid entry type.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .DependentRules(() =>
            {
                RuleFor(x => x.Name)
                    .Must(BeAValidEmail).When(x => x.Type == EntryType.Email.GetDisplayName())
                    .WithMessage("Name must be a valid email address for email type.");
            });
        
        RuleFor(x => x.Password)
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
        
    }
    
    private static bool BeAValidEmail(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            return mailAddress.Address == email;
        }
        catch
        {
            return false;
        }
    }
}