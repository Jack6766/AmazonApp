using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonApplication.Models
{
    public class AmazonDbContext : DbContext
    {
        public AmazonDbContext (DbContextOptions<AmazonDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
