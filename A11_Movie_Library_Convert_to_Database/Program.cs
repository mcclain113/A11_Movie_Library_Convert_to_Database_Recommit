using A11_Movie_Library_Convert_to_Database;
using A11_Movie_Library_Convert_to_Database.Services;
using Microsoft.Extensions.DependencyInjection;

namespace A11_Movie_Library_Convert_to_Database;
    
    class Program
    {

        
        static void Main(string[] args)
        {
            
            //What I am moving to dependency injection:
            /*MovieApp movieapp = new MovieApp();
            MenuGenerator generator = new MenuGenerator();
            generator.MovieGenerator(movieapp);*/

            var startup = new Startup();
            var serviceProvider = startup.ConfigureServices();
            var service = serviceProvider.GetService<IMainService>();
            service?.Invoke();
            

        }

    }
