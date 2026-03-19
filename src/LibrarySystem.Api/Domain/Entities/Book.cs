namespace LibrarySystem.Api.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; }
    
    ICollection<Loan> Loans { get; set; } =  new List<Loan>();
}