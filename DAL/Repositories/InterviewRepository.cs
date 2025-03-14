using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public interface IInterviewRepository : IRepository<Interview>
{
    Interview? GetInterviewId(int id);
}
internal class InterviewRepository(SurveySystemContext context) : Repository<Interview>(context), IInterviewRepository
{
    public Interview? GetInterviewId(int id)
    {
        var interview = Context.Interviews
             .Include(i => i.CurrentQuestion).ThenInclude(q => q!.NextQuestion)
             .Include(i => i.Results)
             .FirstOrDefault(i => i.Id == id);

        return interview;
    }
}
