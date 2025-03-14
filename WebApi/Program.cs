using DAL;
using Services;
namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string connectionString = builder.Configuration.GetValue<string>("connectString")!;

        builder.Services.AddDAL(connectionString);
        builder.Services.AddServices();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
