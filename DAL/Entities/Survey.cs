namespace DAL.Entities;

public class Survey
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Question>? Questions { get; set; }
}
