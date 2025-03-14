using DAL.Entities;

namespace WebApi.ViewModels;

public class QuestionViewModel
{
    public int QuestionId { get; set; }
    public string Title { get; set; }
    public AnswerViewModel[] Answers { get; set; }
    public QuestionViewModel(Question question)
    {
        QuestionId = question.Id;
        Title = question.Title;
        Answers = question.Answers?.Select(a => new AnswerViewModel(a)).ToArray() ?? [];
    }

}

public class AnswerViewModel
{
    public int AnswerId { get; set; }
    public string Title { get; set; }

    public AnswerViewModel(Answer answer)
    {
        AnswerId = answer.Id;
        Title = answer.Title;
    }
}
