using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonApplication.Models
{
    public interface IAmazonRepository
    {
        IQueryable<Book> Books { get; }
    }
}
