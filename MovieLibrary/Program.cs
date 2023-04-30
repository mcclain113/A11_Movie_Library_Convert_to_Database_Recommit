﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;
using MovieLibraryEntities.Models;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
           // cRud - READ
System.Console.WriteLine("Enter Occupation Name: ");
var occ = Console.ReadLine();

using (var db = new MovieContext())
{
    var occupation = db.Occupations.FirstOrDefault(x => x.Name == occ);
    System.Console.WriteLine($"({occupation.Id}) {occupation.Name}");
}


// Crud - CREATE
System.Console.WriteLine("Enter NEW Occupation Name: ");
var occ2 = Console.ReadLine();

using (var db = new MovieContext())
{
    var occupation = new Occupation()
    {
        Name = occ2
    };
    db.Occupations.Add(occupation);
    db.SaveChanges();

    var newOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ2);
    System.Console.WriteLine($"({newOccupation.Id}) {newOccupation.Name}");
}

// crUd - UPDATE
System.Console.WriteLine("Enter Occupation Name to Update: ");
var occ3 = Console.ReadLine();

System.Console.WriteLine("Enter Updated Occupation Name: ");
var occUpdate = Console.ReadLine();

using (var db = new MovieContext())
{
    var updateOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ3);
    System.Console.WriteLine($"({updateOccupation.Id}) {updateOccupation.Name}");

    updateOccupation.Name = occUpdate;

    db.Occupations.Update(updateOccupation);
    db.SaveChanges();

}

// cruD - DELETE
System.Console.WriteLine("Enter Occupation Name to Delete: ");
var occ4 = Console.ReadLine();

using (var db = new MovieContext())
{
    var deleteOccupation = db.Occupations.FirstOrDefault(x => x.Name == occ4);
    System.Console.WriteLine($"({deleteOccupation.Id}) {deleteOccupation.Name}");

    // verify exists first
    db.Occupations.Remove(deleteOccupation);
    db.SaveChanges();
}


using (var db = new MovieContext())
{
    var users = db.Users.Include(x => x.Occupation)
                    .Take(10).ToList();
    foreach (var user in users)
    {
        System.Console.WriteLine($"({user.Id}) {user.Gender} {user.Occupation.Name}");
    }
}

// SELECT - ONE-TO-ONE Relationship
using (var db = new MovieContext())
{
    var users = db.Users.Include(x => x.Occupation)
                        .Where(x => x.Id == 1).ToList();
    foreach (var user in users)
    {
        System.Console.WriteLine($"Display user: ({user.Id}) {user.Gender} {user.Occupation.Name}");
    }
}

// MANY-TO-MANY Relationship
using (var db = new MovieContext())
{
    var selectedUser = db.Users.Where(x => x.Id == 2);
    var users = selectedUser.Include(x => x.UserMovies).ThenInclude(x => x.Movie).ToList();

    foreach (var user in users)
    {
        System.Console.WriteLine($"Added user: ({user.Id}) {user.Gender} {user.Occupation.Name}");

        foreach (var movie in user.UserMovies.OrderBy(x => x.Rating))
        {
            System.Console.WriteLine($"\t\t\t{movie.Rating} {movie.Movie.Title}");
        }
    }
}

// Display genres for a movie
using (var db = new MovieContext())
{
    //var movie = db.Movies
    //    .Include(x => x.MovieGenres)
    //    .ThenInclude(x => x.Genre)
    //    .FirstOrDefault(mov => mov.Title.Contains("Babe"));
    var movie = db.Movies
        .FirstOrDefault(mov => mov.Title.Contains("Babe"));

    System.Console.WriteLine($"Movie: {movie?.Title} {movie?.ReleaseDate:MM-dd-yyyy}");

    System.Console.WriteLine("Genres:");

    foreach (var genre in movie?.MovieGenres ?? new List<MovieGenre>())
    {
        System.Console.WriteLine($"\t{genre.Genre.Name}");
    }
}

// Add userMovie
using (var db = new MovieContext())
{
    // build user object (not database)
    var user = db.Users.FirstOrDefault(u => u.Id == 943);
    var movie = db.Movies.FirstOrDefault(m => m.Title.Contains("Babe"));

    // build user/movie relationship object (not database)
    var userMovie = new UserMovie()
    {
        Rating = 2,
        RatedAt = DateTime.Now
    };

    // set up the database relationships
    userMovie.User = user;
    userMovie.Movie = movie;

    // db.Users.Add(user);
    db.UserMovies.Add(userMovie);

    // commit
    db.SaveChanges();

}

// Get user movie rating details
using (var db = new MovieContext())
{
    var users = db.Users;
    //.Include(x => x.Occupation)
    //.Include(x => x.UserMovies)
    //.ThenInclude(x => x.Movie);

    var limitedUsers = users.Take(10);

    Console.WriteLine("The users are :");
    foreach (var user in limitedUsers.ToList())
    {
        Console.WriteLine($"User: {user.Id} {user.Gender} {user.ZipCode}");
        Console.WriteLine($"Occupation: {user.Occupation.Name}");
        Console.WriteLine($"Rated Movies:");
        foreach (var userMovie in user.UserMovies)
        {
            Console.WriteLine(userMovie.Movie.Title);
        }
    }
}

/*
// DEPENDENCY INJECTION
var serviceProvider = new ServiceCollection()
    .AddSingleton<IRepository, FileRepository>()
    .AddSingleton<IContext, MovieContext>()
    .AddSingleton<IMenu, Menu>()
    .BuildServiceProvider();

// ** still have a dependency here **
// var repository = new MyNewRepository();
// var context = new MovieContext(repository);
// var menu = new Menu(repository, context);

var menu = serviceProvider.GetService<IMenu>();
var userSelection = menu.GetMainMenuSelection();

while (menu.IsValid)
{
    menu.Process(userSelection);

    userSelection = menu.GetMainMenuSelection();
} 
*/
            
            
            
            
        }
    }

    /*internal class FileRepository
    {
    }*/
}