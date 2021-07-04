using System.Collections.Generic;
using System.Web.Mvc;
using TheMen.Models;
using System;

namespace TheMen.Controllers
{
    public class CartController : Controller
    {
        TheMenDbContext context = new TheMenDbContext();
        // GET: Cart
        public ActionResult Index()
        {   
            return View((List<Cart>)Session["cart"]);
        }
        public ActionResult AddToCart(int ProductId, int soluong)
        {
            if (Session["cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart { Product = context.Product.Find(ProductId), Soluong = soluong });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<Cart> cart = (List<Cart>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa?
                int index = isExist(ProductId);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].Soluong += soluong;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new Cart { Product = context.Product.Find(ProductId), Soluong = soluong });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        private int isExist(int id)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductId.Equals(id))
                    return i;
            return -1;
        }

        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(int ProductId)
        {
            List<Cart> li = (List<Cart>)Session["cart"];
            li.RemoveAll(x => x.Product.ProductId == ProductId);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

    }
}