using Newtonsoft.Json;
using BGExcursion.DAL;
using BGExcursion.Models;
using BGExcursion.Models.Home;
using BGExcursion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BGExcursion.Controllers
{

    public class HomeController : Controller
    {
        BGExcursionEntities ctx = new BGExcursionEntities();
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        public ActionResult Index(string search, int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
           return View(model.CreateModel(search, 4, page));
        }
        //public ActionResult Index()
        //{
        //    var cat = ctx.Tbl_Category.ToList();
        //    return View(cat);
        //}
        public ActionResult CheckoutDetails()
        {
            return View();
        }

        public ActionResult ShippingDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShippingDetails(Tbl_ShippingDetails tbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetRepositoryInstance<Tbl_ShippingDetails>().Add(tbl);
                return RedirectToAction("ShippingDetails");
            }
            return View(tbl);
        }
        public ActionResult CartDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CartDetails(Tbl_CartStatus tbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetRepositoryInstance<Tbl_CartStatus>().Add(tbl);
                return RedirectToAction("CartDetails");
            }
            return View(tbl);
            
        }
        public ActionResult DecreaseQty(int productId)
        {
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = ctx.Tbl_Product.Find(productId);
                foreach (var item in cart)
                {
                    if (item.Product.ProductId == productId)
                    {
                        int prevQty = item.Quantity;
                        if (prevQty > 0)
                        {
                            cart.Remove(item);
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = prevQty - 1
                            });
                        }
                        break;
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("CheckoutDetails");
        }
        public ActionResult AddToCart(int productId, string url)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = ctx.Tbl_Product.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var count = cart.Count();
                var product = ctx.Tbl_Product.Find(productId);

                for (int i = 0; i < count; i++)
                {
                    if (cart[i].Product.ProductId == productId)
                    {
                        int prevQty = cart[i].Quantity;
                        cart.Remove(cart[i]);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Quantity = prevQty + 1
                        });
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.Product.ProductId == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = 1
                            });
                        }
                    }
                }
                Session["cart"] = cart;
            }
            return Redirect("Index");
        }
        public ActionResult RemoveFromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == productId)
                {
                    cart.Remove(item);
                   // ctx.SaveChanges();
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }
        public JsonResult checkQuantity(int id)
        {
            System.Threading.Thread.Sleep(200);
            var SearchData = ctx.Tbl_Product.Where(x => x.Quantity == id).SingleOrDefault();
            if (SearchData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }        

    }
}