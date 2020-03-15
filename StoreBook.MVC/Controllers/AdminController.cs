using StoreBook.Domain.Abstract;
using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreBook.Controllers
{
    [Authorize(Roles ="Admins")]
    public class AdminController : Controller
    {
        private IProductRepository _repo;
        private IOrderRepository _repoOrder;
        public AdminController(IProductRepository repo,IOrderRepository orderRepo)
        {
            _repo = repo;
            _repoOrder = orderRepo;
        }
        public ActionResult Index()
        {
            return View(_repo.Products);
        }
        public ActionResult AddProduct()
        {
            return View("AddProduct", new Product());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="ProductID,Name,Category,Description,Price")]Product product,HttpPostedFileBase Image=null) 
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    product.ImageMimeType = Image.ContentType;
                    Stream str = Image.InputStream;
                    BinaryReader br = new BinaryReader(str);
                    product.ImageData = br.ReadBytes((Int32)str.Length);
                }
                _repo.SaveProduct(product);
                ViewBag.Message = String.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult Edit(int ProductID)
        {
            var Product = _repo.Products.FirstOrDefault(x => x.ProductID == ProductID);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View("AddProduct", Product);
        }
        [HttpPost]
        public ActionResult RemoveProduct(int ProductID)
        {
            var product = _repo.RemoveProduct(ProductID);
            if (product != null)
            {
                ViewBag.Message = String.Format("{0} was deleted", product.Name);

            }
            return RedirectToAction("Index");
        }

        public ActionResult GetOrders()
        {
            return View(_repoOrder.Orders);
        }
    }
}