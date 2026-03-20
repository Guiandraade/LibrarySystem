using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Api.Application.Dto;

public class CreateLoanDto
{
    [Required]
    public Guid BookId { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(CreateLoanDto), nameof(ValidateDueDate))]
    public DateTime DueDate { get; set; }

    public static ValidationResult ValidateDueDate(DateTime dueDate, ValidationContext context)
    {
        if (dueDate.Date < DateTime.UtcNow.Date)
            return new ValidationResult("A data de vencimento não pode ser no passado");
        
        return ValidationResult.Success;
    }
    
}