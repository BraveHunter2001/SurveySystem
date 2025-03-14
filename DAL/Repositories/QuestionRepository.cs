using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public interface IQuestionRepository: IRepository<Question>
{
    Question? GetQuestionById(int id);
}

internal class QuestionRepository(SurveySystemContext context) : Repository<Question>(context), IQuestionRepository
{
    public Question? GetQuestionById(int id)
    {
        var question = Context.Questions
            .Include(q => q.Answers)
            .FirstOrDefault(q => q.Id == id);

        return question;
    }
}
