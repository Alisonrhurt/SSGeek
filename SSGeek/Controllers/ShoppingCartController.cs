using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSGeek.DAL;
using SSGeek.Models;

namespace SSGeek.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductDAL _dal;

        public ShoppingCartController(IProductDAL dal)
        {
            _dal = dal;
        }

        // GET: ShoppingCart Product List View
        public ActionResult Index()
        {
            List<Product> products = _dal.GetProducts();
            return View("Index", products);
        }

        // GET: ShoppingCart Product Detail Page
        public ActionResult ProductDetail(string productID)
        {
            int id = int.Parse(productID);
            Product product = _dal.GetProduct(id);
            return View("ProductDetail", product);
        }

        //GET: ShoppingCart Page
        public ActionResult ViewCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }


        // POST: Add product to shopping cart
        [HttpPost]
        public ActionResult AddToCart(int productID, int quantity)
        {
            // Add whichever Product productId represents to the shopping cart

            //1.  Get the Product associated with id
            var product = _dal.GetProduct(productID);

            //2.  Add Product, qty 1 to our active shopping cart
            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, quantity);


            return RedirectToAction("ViewCart");
        }


        //GET: Shopping Cart

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            // See if the user has a shopping cart stored in session
            if (Session["Shopping_Cart"] == null)
            {
                cart = new ShoppingCart();
                Session["Shopping_Cart"] = cart;        // <-- saves the shopping cart into session
            }
            else
            {
                cart = Session["Shopping_Cart"] as ShoppingCart; // <-- gets the shopping cart out of session
            }

            // If not, create one for them

            return cart;
        }



    }
}