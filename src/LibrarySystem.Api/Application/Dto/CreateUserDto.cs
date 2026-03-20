using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Application.Dto;

public class CreateUserDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 100 caracteres")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [EmailAddress(ErrorMessage = "O email é inválido")]
    public string Email { get; set; } = string.Empty;
}