namespace LibrarySystem.Api.Domain.Entities;

public class Loan
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public bool Late => ReturnDate == null && DateTime.UtcNow > DueDate;
    
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; }
}