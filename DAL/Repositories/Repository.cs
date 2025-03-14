using DAL.Context;

namespace DAL.Repositories;

public interface IRepository<T>
{
    void Create(T entity);
    void Insert(T entity);
    void Save();
}

internal abstract class Repository<T>(SurveySystemContext context) : IRepository<T> where T : class
{
    protected SurveySystemContext Context { get; set; } = context;
    public void Create(T entity) => Context.Add(entity);
    public void Insert(T entity) => Context.Update(entity);
    public void Save() => Context.SaveChanges();
}
