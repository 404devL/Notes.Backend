namespace WebAPI;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        using (var scope = app.Services.CreateScope()) { }

        app.Run();
    }
}

