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
    public class CartControllerTest
    {
        [TestMethod]
        public void Can_Add_Item_To_Card()
        {
            //Arrange -Create Mock product
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Category="cat1" },
                new Product{ProductID = 2 , Category = "cat2"},
                new Product{ProductID = 3 ,Category = "cat1"},
                new Product{ProductID = 4 ,Category="cat3"},
                new Product{ProductID = 5 ,Category="cat1"}
            }.AsQueryable());
            //Arrange Create mock for Order
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            //arrange create Controller
            CartController controller = new CartController(mock.Object,orderMock.Object);
            //Arrange - Create Cart
            Cart cart = new Cart();
            //Act
            var result =  controller.AddToCart(cart, 1, null);
            //Assert
            Assert.AreEqual(cart.Lines.Count(),1);
            Assert.AreEqual(cart.Lines.ElementAt(0).Quantity, 1);
            Assert.AreEqual(cart.Lines.ElementAt(0).Product.ProductID, 1);

        }
        [TestMethod]
        public void Can_Add_ExistingItem_ToCart()
        {      
            //Arrange -Create Mock product
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Category="cat1" },
                new Product{ProductID = 2 , Category = "cat2"},
                new Product{ProductID = 3 ,Category = "cat1"},
                new Product{ProductID = 4 ,Category="cat3"},
                new Product{ProductID = 5 ,Category="cat1"}
            }.AsQueryable());
            //Arrange Create mock for Order
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            //arrange create Controller
            CartController controller = new CartController(mock.Object, orderMock.Object);
            //Arrange - Create Cart
            Cart cart = new Cart();
      
       
            //Act
            var result = controller.AddToCart(cart, 1, null);
            //act add the same product again
            result = controller.AddToCart(cart, 1, null);
            //Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ElementAt(0).Quantity, 2);
            Assert.AreEqual(cart.Lines.ElementAt(0).Product.ProductID, 1);

        }
        [TestMethod]
        public void Can_Remove_ItemFromCart()
        {
            //Arrange -Create Mock product
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Category="cat1" },
                new Product{ProductID = 2 , Category = "cat2"},
                new Product{ProductID = 3 ,Category = "cat1"},
                new Product{ProductID = 4 ,Category="cat3"},
                new Product{ProductID = 5 ,Category="cat1"}
            }.AsQueryable());
            //Arrange Create mock for Order
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            //arrange create Controller
            CartController controller = new CartController(mock.Object, orderMock.Object);
            //Arrange - Create Cart
            Cart cart = new Cart();
            //Arrange -Product
            Product p = new Product() { ProductID = 1, Description = "desc" };
            //arrange add prod to cart
            cart.AddItem(p, 1);
            //ACT -Remove ITem
            var result =  controller.RemoveFromCart(cart, p, null);
            //Assert
            Assert.AreEqual(cart.Lines.Count(),0);
        }
        [TestMethod]
        public void Cannot_Checkout_EmptyCart()
        {
            //Arrange -Create Mock product
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Category="cat1" },
                new Product{ProductID = 2 , Category = "cat2"},
                new Product{ProductID = 3 ,Category = "cat1"},
                new Product{ProductID = 4 ,Category="cat3"},
                new Product{ProductID = 5 ,Category="cat1"}
            }.AsQueryable());
            //Arrange Create mock for Order
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            //arrange create Controller
            CartController controller = new CartController(mock.Object, orderMock.Object);
            //Arrange - Create Cart
            Cart cart = new Cart();
            //Arrange - shippingDetails
            ShippingDetails sp = new ShippingDetails() { City = "a", Country = "b", Line1 = "1",ShippingDetailsID = 1 };
            //ACt
            var result = controller.Checkout(cart, sp);
            //Assert
            Assert.IsTrue(result.ViewData.ModelState[""].Errors.Count  > 0);
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
        }

    }
}
