using System;
using System.Collections.Generic;

namespace AmazonApplication.Models.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Book> Books { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}
