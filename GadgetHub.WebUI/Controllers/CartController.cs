using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using GadgetHub.WebUI.Models;

namespace GadgetHub.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IGadgetsRepository repository;
        public CartController (IGadgetsRepository repo)
        {
            repository = repo;
        }

        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];

        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}

        public RedirectToRouteResult AddToCart(Cart cart, int gadgetId, string returnUrl)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault(g => g.Id == gadgetId);
            if (gadget != null)
            {
                cart.AddItem(gadget, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int gadgetId, string returnUrl)
        {
            Gadget gadget = repository.Gadgets.FirstOrDefault(g => g.Id == gadgetId);
            if (gadget != null)
            {
                cart.RemoveLine(gadget);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }
    }
}