using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Application.Dto;

public class CreateBookDto
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve conter entre 3 e 100 caracteres")]
    public string Title { get; set; } = string.Empty;
    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
    public string? Description { get; set; } 
    [Required]
    public Guid AuthorId { get; set; }
}