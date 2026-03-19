namespace LibrarySystem.Api.Domain.Entities;

public class User 
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}