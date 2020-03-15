using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PagedList;
using StoreBook.Controllers;
using StoreBook.Domain.Abstract;
using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBook.Controllers.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void ListTest()
        {
            //Arrange -Create Mock
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1 },
                new Product{ProductID = 2 },
                new Product{ProductID = 3 },
                new Product{ProductID = 4 },
                new Product{ProductID = 5 },
            }.AsQueryable());
            //arrange create Controller
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 1;
            //Act
            var result = controller.List(null, null).Model as IPagedList<Product>;
            //Assert
            Assert.AreEqual(1, result.PageSize);
            Assert.AreEqual(5, result.PageCount);
            Assert.AreEqual(1, result.PageNumber);
        }
        [TestMethod]
        public void Can_retrive_Product_WithCategory()
        {
            //Arrange -Create Mock
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Category="cat1" },
                new Product{ProductID = 2 , Category = "cat2"},
                new Product{ProductID = 3 ,Category = "cat1"},
                new Product{ProductID = 4 ,Category="cat3"},
                new Product{ProductID = 5 ,Category="cat1"}
            }.AsQueryable());
            //arrange create Controller
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 5;
            //act
            var result = controller.List(1, "cat1").Model as IPagedList<Product>;
            //assert
            Assert.AreEqual(result.ElementAt(0).ProductID, 1);
            Assert.AreEqual(result.ElementAt(1).ProductID, 3);
            Assert.AreEqual(result.Count(), 3);
        }
    }
}