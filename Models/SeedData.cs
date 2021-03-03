using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonApplication.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            AmazonDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<AmazonDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category2 = "Classic",
                        Price = 9.95,
                        NumPages = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category2 = "Biography",
                        Price = 14.58,
                        NumPages = 944
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category2 = "Biography",
                        Price = 21.54,
                        NumPages = 832
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category2 = "Biography",
                        Price = 11.61,
                        NumPages = 864
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category2 = "Historical",
                        Price = 13.33,
                        NumPages = 528
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category2 = "Historical Fiction",
                        Price = 15.95,
                        NumPages = 288
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category2 = "Self-Help",
                        Price = 14.99,
                        NumPages = 304
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category2 = "Self-Help",
                        Price = 21.66,
                        NumPages = 240
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category2 = "Business",
                        Price = 29.16,
                        NumPages = 400
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category2 = "Thrillers",
                        Price = 15.03,
                        NumPages = 642
                    },

                    new Book
                    {
                        Title = "Sell or Be Sold",
                        AuthorFirst = "Grant",
                        AuthorLast = "Cardone",
                        Publisher = "Greenleaf Book Group Press",
                        ISBN = "978-1608322565",
                        Classification = "Non-Fiction",
                        Category2 = "Self-Help",
                        Price = 19.11,
                        NumPages = 200
                    },

                    new Book
                    {
                        Title = "Atomic Habits",
                        AuthorFirst = "James",
                        AuthorLast = "Clear",
                        Publisher = "Penguin Random House USA",
                        ISBN = "978-0593189641",
                        Classification = "Non-Fiction",
                        Category2 = "Self-Help",
                        Price = 15.99,
                        NumPages = 320
                    },

                    new Book
                    {
                        Title = "Can't Hurt Me: Master Your Mind and Defy the Odds",
                        AuthorFirst = "David",
                        AuthorLast = "Goggins",
                        Publisher = "Lioncrest Publishing",
                        ISBN = "978-1544507859",
                        Classification = "Non-Fiction",
                        Category2 = "Self-Help",
                        Price = 17.99,
                        NumPages = 364
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
