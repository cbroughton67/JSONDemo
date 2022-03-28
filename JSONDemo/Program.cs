using System;
using System.Collections.Generic;

namespace JSONDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define our variables
            bool keepGoing = true;
            string selection;
            string watchFile = "WatchFile.JSON";

            do // Keep looping until it's time to bail out
            {
                // Build a menu...
                Console.Clear();
                Console.WriteLine("1)\tAdd a Movie");
                Console.WriteLine("2)\tView Movie List");
                Console.WriteLine("\tAny other key to quit\n");
                
                // Get the user's selections...
                selection = Console.ReadKey().KeyChar.ToString();

                // ...and decide what to do with it
                switch (selection)
                {
                    case "1":
                        keepGoing = true;
                        AddAMovie(watchFile);
                        break;

                    case "2":
                        keepGoing = true;
                        ViewMovieList(watchFile);
                        break;

                    default:
                        // Any entry other than 1 or 2, pull the ripcord and bail out of the loop (and the program)
                        keepGoing = false;
                        Console.Clear();
                        Console.WriteLine("Bye Bye!");
                        break;
                }                    
            }
            while (keepGoing == true);
        }//Main



        static void AddAMovie(string filename)
        {
            Console.Clear();
            // Ask for a movie to add to the List
            Console.WriteLine("Enter a movie title:\n");
            string title = Console.ReadLine().ToString();
            
            // Pass the filename where we want to save the movie title
            // and the movie title itself to the WriteJSON method
            FileIO.WriteJSON(filename, title);

            // Give user warm fuzzies that we actually did something
            Console.WriteLine("\n" + title + " added to list. \nPress a key to continue.");
            Console.ReadKey();

        }//AddAMovie

        static void ViewMovieList(string filename)
        {
            // Start with a blank slate (ie. screen)
            Console.Clear();
            
            // Read the JSON file into a List
            List<string> movieList = FileIO.ReadJSON(filename);

            // Loop through each movie in the List and spew it onto the screen
            foreach (string movie in movieList)
            {
                Console.WriteLine(movie);
            }

            // Give the user a sec to read what was spewed onto the screen
            // before replacing it with the menu... 
            Console.WriteLine("\nPress any key to contine.");
            Console.ReadKey();

        }

    }//Program
}
