using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class SurveySystemContext : DbContext
{
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Result> Results { get; set; }

    public SurveySystemContext(DbContextOptions<SurveySystemContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne()
            .HasForeignKey(a => a.QuestionId);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.NextQuestion)
            .WithOne()
            .HasForeignKey<Question>(q => q.NextQuestionId);

        modelBuilder.Entity<Survey>()
            .HasMany(q => q.Questions)
            .WithOne()
            .HasForeignKey(a => a.SurveyId);

        modelBuilder.Entity<Interview>()
            .HasMany(i => i.Results)
            .WithOne()
            .HasForeignKey(r => r.InterviewId);

        modelBuilder.Entity<Interview>()
            .HasOne(i => i.CurrentQuestion)
            .WithOne()
            .HasForeignKey<Interview>(i => i.CurrentQuestionId);

        modelBuilder.Entity<Answer>().Property(e => e.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Interview>().Property(e => e.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Question>().Property(e => e.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Result>().Property(e => e.Id).UseIdentityAlwaysColumn();
        modelBuilder.Entity<Survey>().Property(e => e.Id).UseIdentityAlwaysColumn();


        base.OnModelCreating(modelBuilder);
    }
}
