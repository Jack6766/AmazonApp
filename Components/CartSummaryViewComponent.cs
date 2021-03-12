//This view component is able to take advantage of the service that I created earlier in the chapter to receive a Cart object as a constructor argument.
//The result is a simple view component class that passes on the Cart to the View method to generate the fragment of HTML that will be included in the layout.

using Microsoft.AspNetCore.Mvc;
using AmazonApplication.Models;
namespace AmazonApplication.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
