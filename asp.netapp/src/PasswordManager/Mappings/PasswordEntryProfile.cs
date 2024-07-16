using AutoMapper;
using DomainLayer;
using Humanizer;
using Microsoft.OpenApi.Extensions;
using PasswordManager.DTOs;

namespace PasswordManager.Mappings;

public class PasswordEntryProfile : Profile
{
    public PasswordEntryProfile()
    {
        CreateMap<CreatePasswordEntryDto, PasswordEntry>()
           .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<EntryType>(src.Type, true)));

        CreateMap<PasswordEntry, PasswordEntryDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.GetDisplayName()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeExtensions.HumanizeDateTime(src.CreatedAt)));
    }
}

public static class DateTimeExtensions
{
    public static string HumanizeDateTime(DateTime dateTime)
    {
        return dateTime.Humanize(culture: System.Globalization.CultureInfo.CurrentCulture);
    }
}