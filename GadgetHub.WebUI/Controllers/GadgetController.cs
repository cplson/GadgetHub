using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Concrete;
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
        //private EFDbContext db = new EFDbContext();
        public ViewResult List(int page = 1)
        {
            //var conn = db.Database.Connection;
            //System.Diagnostics.Debug.WriteLine(conn.DataSource);
            //System.Diagnostics.Debug.WriteLine(conn.Database);

            return View(myRepository.Gadgets.OrderBy(g => g.Id).Skip((page - 1) * PageSize).Take(PageSize));
        }
    }
}