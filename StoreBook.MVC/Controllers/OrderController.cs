using StoreBook.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreBook.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _repo;
        public OrderController(IOrderRepository repo)
        {
            _repo = repo;
        }
        public ViewResult Index()
        {
            return View();
        }
    }
}