using A11_Movie_Library_Convert_to_Database.Dao;
using A11_Movie_Library_Convert_to_Database.Services;
using Microsoft.Extensions.DependencyInjection;

namespace A11_Movie_Library_Convert_to_Database;

public class Startup
{
    public ServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();
        //services.AddSingleton<>();
        services.AddSingleton<IMainService, MainServices>();
        services.AddSingleton<IRepository, MovieRepositoryDatabase>();
        //services.AddSingleton<IRepository, MovieRepositoryCsv>();
        services.AddSingleton<IMenuGenerator,MenuGenerator >();
        return services.BuildServiceProvider();
    }
}