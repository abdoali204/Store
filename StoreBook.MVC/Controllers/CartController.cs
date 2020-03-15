using StoreBook.Domain.Abstract;
using StoreBook.Domain.Entities;
using StoreBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreBook.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderRepository OrderRepository;
        public CartController(IProductRepository repo,IOrderRepository orderRepo)
        {
            repository = repo;
            OrderRepository = orderRepo;
        }
        public ActionResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel()
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });

        }
        public RedirectToRouteResult AddToCart(Cart cart,int ProductID, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(x => x.ProductID == ProductID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }
        public ActionResult RemoveFromCart(Cart cart,Product p, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(x => x.ProductID == p.ProductID);
            if (product != null)
            {
                cart.RemoveLine(p.ProductID);
            }

            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout() 
        { 
            return View();
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0) 
            { 
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid) 
            {
                OrderRepository.ProcessOrder(cart, shippingDetails);
                
                cart.Clear();
                return View("Completed");
            }
            else 
            { 
                return View(shippingDetails);
            }
        }

    }
}