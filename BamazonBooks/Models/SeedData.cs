using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BamazonBooks.Models // this whole page can be deleted after the DB is created
{
    public class SeedData
    {
        //private const double V = 9.99;

        public static void EnsurePopulated (IApplicationBuilder application) //receives an IApplivationBuilder argument, which is the interface used in the Configure method of the Startup class to register middleware components to handle HTTP requests. Also provides access to the app's services 
        {
            BamazonDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BamazonDbContext>(); //related to user sessions? 
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any()) // checks if there are any Books objects in the database. if not the database is populated using a collection of Books objects using the AddRange method.
            {
                context.Books.AddRange(
                    new Book
                    {
                        //BookId = 1,
                        Title = "Les Miserables",
                        AuthorGivenName ="Victor",
                        AuthorMiddleInitial = " ",
                        AuthorLastName ="Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95, 
                        NumPages = 1488

                    },
                    new Book
                    {
                        //BookId = 2,
                        Title = "Team of Rivals",
                        AuthorGivenName = "Doris",
                        AuthorMiddleInitial ="K.",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58, 
                        NumPages = 944

                    },
                    new Book
                    {
                        //BookId = 3,
                        Title = "The Snowball",
                        AuthorGivenName = "Alice",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54, 
                        NumPages = 832

                    },
                    new Book
                    {
                        //BookId = 4,
                        Title = "American Ulysses",
                        AuthorGivenName = "Ronald",
                        AuthorMiddleInitial = "C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61, 
                        NumPages = 864

                    },
                    new Book
                    {
                        //BookId = 5,
                        Title = "Unbroken",
                        AuthorGivenName = "Laura",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        NumPages = 528
                    },
                    new Book
                    {
                        //BookId = 6,
                        Title = "The Great Train Robbery",
                        AuthorGivenName = "Michael",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95, 
                        NumPages = 288

                    },

                    new Book
                    {
                        //BookId = 7,
                        Title = "Deep Work",
                        AuthorGivenName = "Cal",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        NumPages = 304
                    },
                    new Book
                    {
                        //BookId = 8,
                        Title = "It's Your Ship",
                        AuthorGivenName = "Michael",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66, 
                        NumPages = 240
                    },
                    new Book
                    {
                        //BookId = 9,
                        Title = "The Virgin Way",
                        AuthorGivenName = "Richard",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16, 
                        NumPages = 400
                    },
                    new Book
                    {
                        //BookId = 10,
                        Title = "Sycamore Row",
                        AuthorGivenName = "John",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03, 
                        NumPages = 642
                    },
                    new Book
                    {
                        //BookId = 11,
                        Title = "Outliers",
                        AuthorGivenName = "Malcolm",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Gladwell",
                        Publisher = "Back Bay Books",
                        ISBN = "978-0316017930",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 7.79,
                        NumPages = 336
                    },
                    new Book
                    {
                        //BookId = 12,
                        Title = "The Boys in the Boat",
                        AuthorGivenName = "Daniel",
                        AuthorMiddleInitial = "J.",
                        AuthorLastName = "Brown",
                        Publisher = "Penguin",
                        ISBN = "978-0316497039",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 10.94,
                        NumPages = 404
                    },
                    new Book
                    {
                        //BookId = 13,
                        Title = "A Man Called Ove",
                        AuthorGivenName = "Fredrik",
                        AuthorMiddleInitial = " ",
                        AuthorLastName = "Backman",
                        Publisher = "Washington Square Press",
                        ISBN = "978-1476738024",
                        Classification = "Fiction",
                        Category = "Novel",
                        Price = 8.98,
                        NumPages = 337
                    }

                ) ;

                context.SaveChanges(); //written to the database using the SaveChanges
            }
        }
    }
}
