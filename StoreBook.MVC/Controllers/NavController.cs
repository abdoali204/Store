﻿using StoreBook.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreBook.Controllers
{
    public class NavController : Controller
    {
        IProductRepository _repository;
        public NavController(IProductRepository repo)
        {
            _repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = _repository.Products
                .Select(prod => prod.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}