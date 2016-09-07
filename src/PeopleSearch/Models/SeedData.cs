using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeopleSearch.Data;
using System;
using System.Linq;

namespace PeopleSearch.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }

                context.Person.AddRange(
                     new Person
                     {
                         FirstName = "John",
                         LastName = "Smith",
                         Address = "100 S 100 E, Salt LAke City, UT 84000",
                         Age = 25,
                         Interests = "Football",
                         //Picture = ImageToByteArray(@"C:\Temp\PeopleSearch-master_Update\PeopleSearch-master\src\PeopleSearch\Images\IMG_00017.JPG"),
                     },

                     new Person
                     {
                         FirstName = "Tom",
                         LastName = "Lee",
                         Address = "100 S State Street, Salt LAke City, UT 84005",
                         Age = 55,
                         Interests = "Hiking",
                         //Picture = ImageToByteArray(@"C:\Temp\PeopleSearch-master_Update\PeopleSearch-master\src\PeopleSearch\Images\IMG_00017.JPG"),
                     },

                     new Person
                     {
                         FirstName = "Susan",
                         LastName = "French",
                         Address = "100 E Redwood Dr., Salt LAke City, UT 84012",
                         Age = 30,
                         Interests = "Swimming",
                         //Picture = ImageToByteArray(@"C:\Temp\PeopleSearch-master_Update\PeopleSearch-master\src\PeopleSearch\Images\IMG_00017.JPG"),
                     },

                   new Person
                   {
                       FirstName = "Anna",
                       LastName = "Smith",
                       Address = "3500 S 4000 W, West Valley City, UT 84100",
                       Age = 60,
                       Interests = "Reading",
                       //Picture = ImageToByteArray(@"C:\Temp\PeopleSearch-master_Update\PeopleSearch-master\src\PeopleSearch\Images\IMG_00017.JPG"),
                   }
                );
                context.SaveChanges();
            }
        }


        private static byte[] ImageToByteArray(string filePath)
        {
            return (System.IO.File.ReadAllBytes(filePath));
        }

    }
}
