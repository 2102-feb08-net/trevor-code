using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EfDemo.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfDemo.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = File.ReadAllText("C:/revature/chinook-connection-string.txt");
            DbContextOptions<ChinookContext> options = new DbContextOptionsBuilder<ChinookContext>()
                .UseSqlServer(connectionString)
                .Options;
            using var context = new ChinookContext(options);

            DeleteTheNewTrack(context);

            Display5Tracks(context);

            EditOneOfThoseTracks(context);

            Display5Tracks(context);

            InsertANewTrack(context);

            Display5Tracks(context);

            DeleteTheNewTrack(context);

            Display5Tracks(context);
        }

        static void Display5Tracks(ChinookContext context)
        {
            var query = context.Tracks
                .Take(5);
            foreach(var track in query.ToList())
            {
                var genre = context.Genres.Find(track.GenreId);
                Console.WriteLine($"Title - {track.Name}\tGenre - {genre.Name}");
            }
            Console.WriteLine();
        }

        static void EditOneOfThoseTracks(ChinookContext context)
        {
            var track = context.Tracks.Find(1);
            string tempName = track.Name;
            track.Name = "Not my song";
            context.SaveChanges();
            Console.WriteLine($"Changed track name {tempName} to {track.Name}");
        }

        static void InsertANewTrack(ChinookContext context)
        {
            Track add = new Track { Name = "Cool song", MediaTypeId = 2, GenreId = 2, Composer = "Trevor", Milliseconds = 100, UnitPrice = 100 };
            context.Tracks.Add(add);
            context.SaveChanges();
            Console.WriteLine($"Added song \"{add.Name}\" to database");
        }

        static void DeleteTheNewTrack(ChinookContext context)
        {
            var delete = context.Tracks
                .Where(x => x.Name == "Cool song");
            context.Tracks.Remove(context.Tracks.Find(delete.First().TrackId));
            context.SaveChanges();
            Console.WriteLine($"Deleted song \"{delete.First().Name}\" from database");
        }
    }
}
