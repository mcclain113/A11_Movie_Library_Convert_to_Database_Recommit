using Microsoft.EntityFrameworkCore;
using System.Linq;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;

namespace A11_Movie_Library_Convert_to_Database.Dao;

public class MovieRepositoryDatabase : IRepository
{
    public void Run()
    {
        throw new NotImplementedException();
    }

    public void Get()
    {
        using (var db = new MovieContext())
        {
            string controller = "";
            int movieCount = 0;
            int count = 100;

            while (controller != "q" && movieCount < db.Movies.Count()-count)
            {
                
                var listOfMovies = db.Movies.Skip(movieCount).Take(count).ToList();

                foreach (var movie in listOfMovies)
                {
                    Console.WriteLine($"{movie.Id} {movie.Title}");
                }

                Console.WriteLine($"To show next 100, press Enter. To quit, press q.");
                movieCount += 100;

                controller = Console.ReadLine().ToLower();
            }

            if (db.Movies.Count()-movieCount < count)
            {
                var lastoutput = db.Movies.Skip(movieCount).Take(count).ToList();
                foreach (var movie in lastoutput)
                {
                    Console.WriteLine($"{movie.Id} {movie.Title}");
                }
                Console.WriteLine($"End of List");
            }
            
        }
    }

    public void Add()
    {

        
        Console.WriteLine("Enter New Movie Title: ");
        String movieTitle = Console.ReadLine();
        Console.WriteLine("Enter New Movie Realease Year (yyyy-mm-dd): ");
        DateTime movieYear = Convert.ToDateTime(Console.ReadLine());
        using (var db = new MovieContext())
        {
            var newMovie = new Movie()
            {
                Title = movieTitle,
                ReleaseDate = movieYear
            };
            db.Movies.Add(newMovie);
            db.SaveChanges();

            var newMovieCheck = db.Movies.FirstOrDefault(x => x.Title == movieTitle);
            Console.WriteLine($"{newMovieCheck.Id} {newMovie.Title} {newMovieCheck.ReleaseDate} has been added.");
        }
    }

    public void Update()
    {
        System.Console.WriteLine("Enter movie title to update: ");
        var movieTitle = Console.ReadLine();

        System.Console.WriteLine("Enter updated movie title: ");
        var movieTitleUpdate = Console.ReadLine();

        using (var db = new MovieContext())
        {
            var updateMovie = db.Movies.FirstOrDefault(x => x.Title == movieTitle);
            Console.WriteLine($"({updateMovie.Id}) {updateMovie.Title} has been updated to:");

            updateMovie.Title = movieTitleUpdate;

            db.Movies.Update(updateMovie);
            Console.WriteLine($"({updateMovie.Id}) {updateMovie.Title}");
            db.SaveChanges();
            

        }
    }

    public void Delete()
    {
        System.Console.WriteLine("Enter movie title to delete: ");
        var movieTitle = Console.ReadLine();

        using (var db = new MovieContext())
        {
            var deleteMovie = db.Movies.FirstOrDefault(x => x.Title == movieTitle);
            Console.WriteLine($"Removing ({deleteMovie.Id}) {deleteMovie.Title}");

           
            db.Movies.Remove(deleteMovie);
            db.SaveChanges();
        }

    }

    public void Exit()
    {
        Console.WriteLine($"See you later");
    }
}