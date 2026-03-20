namespace LibrarySystem.Api.Application.Dto;

public class LoanDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool Late => ReturnDate == null && DateTime.UtcNow > DueDate;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}