using GadgetHub.Domain.Abstract;
using GadgetHub.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GadgetHub.WebUI.Controllers
{
    public class GadgetController : Controller
    {
        private IGadgetsRepository myRepository;

        public GadgetController (IGadgetsRepository gadgetsRepository)
        {
            this.myRepository = gadgetsRepository;
        }

        public int PageSize = 4;
        public ViewResult List(int page = 1)
        {


            GadgetsListViewModel model = new GadgetsListViewModel
            {
                Gadgets = myRepository.Gadgets.OrderBy(g => g.Id).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = myRepository.Gadgets.Count()
                }
            };
            return View(model);
        }
    }
}