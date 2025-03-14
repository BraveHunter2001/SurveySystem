using DAL.Entities;
using DAL.Repositories;

namespace Services;

public interface IQuestionService
{
    Question? GetQuestionById(int id);
}
internal class QuestionService(IQuestionRepository questionRepository) : IQuestionService
{
    public Question? GetQuestionById(int id) => questionRepository.GetQuestionById(id);

}
