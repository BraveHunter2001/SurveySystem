namespace DAL.Entities;

public class Question
{
    public int Id { get; set; }
    public required string Title { get; set; }

    public ICollection<Answer>? Answers { get; set; } 
    public int SurveyId { get; set; }

    public int? NextQuestionId { get; set; }
    public Question? NextQuestion { get; set; }
}
