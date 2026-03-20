using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Application.Dto;

public class CreateAuthorDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 100 caracteres")]
    public string Name { get; set; } =  string.Empty;
    [StringLength(500, ErrorMessage = "A bibliografia deve ter no máximo 500 caracteres")]
    public string? Biography { get; set; } 
    [DataType(DataType.Date)]
    [CustomValidation(typeof(CreateAuthorDto), nameof(ValidateDateOfBirth))]
    public DateTime? DateOfBirth { get; set; }
    [StringLength(50, ErrorMessage = "A nacinalidade de ter no máximo 50 caracteres")]
    public string? Nationality { get; set; }
    
    public static ValidationResult? ValidateDateOfBirth(DateTime? dateOfBirth, ValidationContext context)
    {
        if (dateOfBirth.HasValue && dateOfBirth.Value > DateTime.Today)
            return new ValidationResult("A data de nascimento não pode ser futura.");
        return ValidationResult.Success;
    }
}