using GadgetHub.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetHub.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IGadgetsRepository repository;
        public NavController (IGadgetsRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Gadgets.Select(x => x.Category).Distinct().OrderBy(x => x);

            return PartialView(categories);
        }
    }
}