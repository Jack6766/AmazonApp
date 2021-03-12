using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AmazonApplication.Infrastructure;

namespace AmazonApplication.Models
{
    //The SessionCart class subclasses the Cart class and overrides the AddItem, RemoveLine, and
    //Clear methods so they call the base implementations and then store the updated state in the
    //session using the extension methods on the ISession interface.
    public class SessionCart : Cart
    {
        //The static GetCart method is a factory for creating SessionCart objects and providing them
        //with an ISession object so they can store themselves.
        public static Cart GetCart(IServiceProvider services)
        {
            //Getting hold of the ISession object is a little complicated. I obtain an instance of the
            //IHttpContextAccessor service, which provides me with access to an HttpContext object that,
            //in turn, provides me with the ISession. This indirect approach is required because the session
            //isn’t provided as a regular service.
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Book bk, int qty, double prce)
        {
            base.AddItem(bk, qty, prce);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Book bk)
        {
            base.RemoveLine(bk);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
