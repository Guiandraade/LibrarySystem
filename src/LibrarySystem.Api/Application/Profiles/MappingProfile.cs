using AutoMapper;
using LibrarySystem.Api.Application.Dto;
using LibrarySystem.Api.Domain.Entities;

namespace LibrarySystem.Api.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateAuthorDto, Author>();

        CreateMap<Book, BookDto>();
        CreateMap<CreateBookDto, Book>();

        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();

        CreateMap<CreateLoanDto, Loan>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.ReturnDate, opt => opt.Ignore());

        CreateMap<Loan, LoanDto>()
            .ForMember(dest => dest.Late, opt => opt.MapFrom(src =>
                src.ReturnDate == null && src.DueDate < DateTime.UtcNow));
    }
}