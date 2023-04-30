using A11_Movie_Library_Convert_to_Database.Dao;

namespace A11_Movie_Library_Convert_to_Database;

public class MenuGenerator : IMenuGenerator
{
    public void Menu(IRepository app)
    {

        char menuAnswer = 'a';

        while (menuAnswer != 'q')
        {
            
            //app.Run();
            Console.WriteLine("Welcome to the Movie Library Menu");
            Console.WriteLine("1. Enter 1 to search movie library");
            Console.WriteLine("2. Enter 2 to add movie to library");
            Console.WriteLine("3. Enter 3 to update movie title in library");
            Console.WriteLine("4. Enter 4 to delete movie in library");
            Console.WriteLine(".........................................");
            Console.Write("Please Enter Menu Number (q for quit): ");
            

            try
            {
                menuAnswer = Console.ReadLine().ToLower()[0];
                if (menuAnswer == '1')
                {
                    app.Get();
                }

                else if (menuAnswer == '2')
                {
                    app.Add();
                
                }
                else if (menuAnswer == '3')
                {
                    app.Update();
                
                }
                else if (menuAnswer == '4')
                {
                    app.Delete();
                
                }
                else if (menuAnswer == 'q')
                {
                    app.Exit();
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Try again\n\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"Pick a valid key");
                        
            }
                    
                    
        }
    }
    
}