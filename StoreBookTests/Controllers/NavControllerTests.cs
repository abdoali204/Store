using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreBook.Controllers;
using StoreBook.Domain.Abstract;
using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBookTests.Controllers
{
    [TestClass]
    public class NavControllerTests
    {
        [TestMethod]
        public void Can_retrive_categories()
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
            NavController controller = new NavController(mock.Object);
            //act
            IEnumerable<string> result = controller.Menu().Model as IEnumerable<string>;
            //Assert
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("cat1", result.FirstOrDefault());
        }
    }
}
