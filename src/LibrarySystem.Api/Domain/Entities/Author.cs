namespace LibrarySystem.Api.Domain.Entities;

public class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; } =  string.Empty;
    public string? Biography { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    
    ICollection<Book> Books { get; set; } =  new List<Book>();
}