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


        public static void WritePeopleJSON(string filename, People SomePerson)
        {
            List<People> folks = new List<People>();
            var opt = new JsonSerializerOptions() { WriteIndented = true };

            // Load the current movie list, if it exists
            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + filename))
            {
                string peeps = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + filename);
                folks = JsonSerializer.Deserialize<List<People>>(peeps, opt);
            }

            // Add the new moving to the list
            folks.Add(new People { FirstName = SomePerson.FirstName, LastName = SomePerson.LastName, Age = SomePerson.Age});

            //Console.WriteLine( );
            //Console.ReadKey();

            // Save the updated list to the JSON file
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + filename, JsonSerializer.Serialize(folks));
         
        } //WritePeopleJSON
        

        public static List<People> ReadPeopleJSON(string filename)
        {
            List<People> folks = new List<People>();
            var opt = new JsonSerializerOptions() { WriteIndented = true };


            // Make sure the file is there before attempting to read it
            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + filename))
            {
                string peeps = File.ReadAllText(Directory.GetCurrentDirectory() + "\\" + filename);

                // Deserialize the JSON file into the List
                folks = JsonSerializer.Deserialize<List<People>>(peeps, opt);
            }

            // Return the List to the caller
            return folks;

        }//ReadPeopleJSON
    }
}
