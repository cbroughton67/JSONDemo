using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace JSONDemo
{
    internal class FileIO
    {
        public static void WriteJSON(string filename, string movieTitle)
        {
            List<string> movieList = new List<string>();

            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + filename))
            {
                string movies = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + filename);
                movieList = JsonSerializer.Deserialize<List<string>>(movies);
            }

            movieList.Add(movieTitle);

            File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + filename, JsonSerializer.Serialize(movieList));

        }

        public static List<string> ReadJSON(string filename)
        {
            List<string> movieList = new List<string>();

            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + filename))
            {
                string movies = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + filename);
                movieList = JsonSerializer.Deserialize<List<string>>(movies);

               
            }
            //else
            //{
            //    Console.WriteLine("No movies to display.\nPress any key to continue.");
            //    Console.ReadKey();
            //}

            return movieList;

        }
    }
}
