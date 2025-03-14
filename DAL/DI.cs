using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DI
{
    public static void AddDAL(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SurveySystemContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IInterviewRepository, InterviewRepository>();
    }
}
