using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;

namespace GadgetHub.WebUI.Controllers
{
    public class GadgetController : Controller
    {
        private IGadgetsRepository myRepository;

        public GadgetController (IGadgetsRepository gadgetsRepository)
        {
            this.myRepository = gadgetsRepository;
        }

        public ViewResult List()
        {
            return View(myRepository.Gadgets);
        }
    }
}