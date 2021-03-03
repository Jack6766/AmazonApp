using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonApplication.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; }
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^)?=(?:\D*\d{3}(?:(?:\D*\d{10})?$)[\d-]+$",
            ErrorMessage = "ISBN is not in required format of ###-##########")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        public string Category2 { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int NumPages { get; set; }
    }
}
