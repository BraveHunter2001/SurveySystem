namespace DAL.Entities;

public class Interview
{
    public int Id { get; set; }

    public int SurveyId { get; set; }
    public Survey? Survey { get; set; }

    public int? CurrentQuestionId { get; set; }
    public Question? CurrentQuestion { get; set; }

    public bool IsFinished { get; set; }

    public ICollection<Result>? Results { get; set; }
}
