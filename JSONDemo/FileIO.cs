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

            // Load the current movie list, if it exists
            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + filename))
            {
                string movies = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + filename);
                movieList = JsonSerializer.Deserialize<List<string>>(movies);
            }
            
            // Add the new moving to the list
            movieList.Add(movieTitle);

            // Save the updated list to the JSON file
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + filename, JsonSerializer.Serialize(movieList));

        }

        public static List<string> ReadJSON(string filename)
        {
            List<string> movieList = new List<string>();

            // Make sure the file is there before attempting to read it
            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + filename))
            {
                string movies = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + filename);
                
                // Deserialize the JSON file into the List
                movieList = JsonSerializer.Deserialize<List<string>>(movies);

               
            }

            // Return the List to the caller
            return movieList;

        }
    }
}
