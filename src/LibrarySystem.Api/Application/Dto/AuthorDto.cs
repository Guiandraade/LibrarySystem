using LibrarySystem.Api.Domain.Entities;

namespace LibrarySystem.Api.Application.Dto;

public class AuthorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } =  string.Empty;
    public string? Biography { get; set; } 
    public DateTime? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; }
}