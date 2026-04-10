using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GadgetHub.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IGadgetsRepository repository;

        public AdminController(IGadgetsRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Gadgets);
        }

        public ViewResult Edit(int id)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault(g => g.Id == id);

            return View(gadget);
        }

        [HttpPost]
        public ActionResult Edit(Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGadget(gadget);
                TempData["message"] = string.Format("{0} has been saved", gadget.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(gadget);
            }
        }

        public ViewResult Create()
        {
            ViewBag.operation = "create";
            return View("Edit", new Gadget());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Console.WriteLine("AdminController Id: ", Id);

            Gadget deletedGadget = repository.DeleteGadget(Id);

            if (deletedGadget != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedGadget.Name);
            }
            return RedirectToAction("Index");
        }
    }
}