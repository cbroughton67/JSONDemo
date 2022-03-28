using System;
using System.Collections.Generic;

namespace JSONDemo
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            bool keepGoing = true;
            string selection;
            string watchFile = "WatchFile.JSON";

            do
            {
                Console.Clear();
                Console.WriteLine("1)\tAdd a Movie");
                Console.WriteLine("2)\tView Movie List");
                Console.WriteLine("\tAny other key to quit\n");
                
                selection = Console.ReadKey().KeyChar.ToString();

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
            Console.WriteLine("Enter a movie title:\n");
            string title = Console.ReadLine().ToString();

            FileIO.WriteJSON(filename, title);

            Console.WriteLine("\n" + title + " added to list. \nPress a key to continue.");
            Console.ReadKey();

        }//AddAMovie

        static void ViewMovieList(string filename)
        {

            Console.Clear();

            List<string> movieList = FileIO.ReadJSON(filename);

            foreach (string movie in movieList)
            {
                Console.WriteLine(movie);
            }

            Console.WriteLine("\nPress any key to contine.");
            Console.ReadKey();

        }

    }//Program
}
