using System;
using System.Linq;
using AmazonApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmazonApplication.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IAmazonRepository repository;

        //Constructor
        public NavigationMenuViewComponent (IAmazonRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            //This grabs the data from the category in url to determine the selected type
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category2)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
