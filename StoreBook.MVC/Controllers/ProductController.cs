using PagedList;
using StoreBook.Domain.Abstract;
using StoreBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreBook.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(int? page,string Category)
        {
            var products = _repository.Products
                .Where(p=> Category == null || p.Category == Category).OrderBy(p => p.ProductID);
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, PageSize));
        }
        public FileContentResult GetImage(int productId)
        {
            var prod = _repository.Products.FirstOrDefault(x => x.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

    }
}