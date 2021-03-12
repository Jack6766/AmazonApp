using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonApplication.Infrastructure;
using AmazonApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmazonApplication.Pages
{
    public class CartModel : PageModel
    {
        private IAmazonRepository repository;

        //Constructor indicates that the model class needs a Cart object
        public CartModel (IAmazonRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = repository.Books
                .FirstOrDefault(p => p.BookID == bookID);

            Cart.AddItem(book, 1, book.Price);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookID == bookID).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
