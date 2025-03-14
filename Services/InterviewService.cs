using DAL.Entities;
using DAL.Repositories;
using Services.Dto;

namespace Services;

public interface IInterviewService
{
    Interview? GetInterviewId(int id);
    MovingNextQuestionResult MoveOnNextQuestion(Interview interview, int chosedAnswerId);
}
internal class InterviewService(IInterviewRepository interviewRepository) : IInterviewService
{
    public Interview? GetInterviewId(int id) => interviewRepository.GetInterviewId(id);


    public MovingNextQuestionResult MoveOnNextQuestion(Interview interview, int chosedAnswerId)
    {
        if (interview.IsFinished)
            return new MovingNextQuestionResult { IsInterviewFinished = true };

        var result = new Result()
        {
            InterviewId = interview.Id,
            QuestionId = interview.CurrentQuestionId!.Value,
            ChoosedAnswerId = chosedAnswerId,
        };

        (interview.Results ??= new List<Result>()).Add(result);

        var nextQuestion = interview.CurrentQuestion?.NextQuestion;
        bool wasFinished = nextQuestion is null;

        interview.CurrentQuestion = nextQuestion;
        interview.IsFinished = wasFinished;

        interviewRepository.Save();

        return new MovingNextQuestionResult
        {
            NextQuestionId = nextQuestion?.Id,
            IsInterviewFinished = interview.IsFinished
        };
    }
}
