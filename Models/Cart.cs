using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonApplication.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //here we add an item with the following attributes
        public virtual void AddItem (Book bk, int qty, double prce)
        {
            //After that we build a new CartLine which is a container that we built below.
            //The Lines object is is a list of CartLines built at the beginning of the class that is being assigned to line.
            //We go to the Lines object and select where the book that was passed in is equal to the Book in the Lines and
            //then select the first. If the line isn't found, we'll create it, otherwise, we will increase the quantity.
            CartLine line = Lines
                .Where(price => price.Book.BookID == bk.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bk,
                    Quantity = qty,
                    Price = prce
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book bk) =>
            Lines.RemoveAll(x => x.Book.BookID == bk.BookID);


        //This clears the entire cart
        public virtual void Clear() => Lines.Clear();

        //Computes the total sum
        public decimal ComputeTotalSum() =>
            (decimal)(double)Lines.Sum(e => (decimal)e.Book.Price * e.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
            public double Subtotal { get; set; }
            public double Total { get; set; }
        }

    }
}
