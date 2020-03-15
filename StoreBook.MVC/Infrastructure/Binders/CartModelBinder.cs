using StoreBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace StoreBook.Infrastructure.Binders
{
    public class CartModelBinder : System.Web.Mvc.IModelBinder
    {
        private const string sessionKey = "cart";
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {

            // get the Cart from the session

            Cart cart = null;
            if (controllerContext.HttpContext.Session != null) 
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey]; 
            }
            // create the Cart if there wasn't one in the session data   
            if (cart == null) {    
                cart = new Cart();    
                if (controllerContext.HttpContext.Session != null)
                {      
                    controllerContext.HttpContext.Session[sessionKey] = cart;   
                }
            }
            // return the cart 
            return cart;    
        }
    }
}
