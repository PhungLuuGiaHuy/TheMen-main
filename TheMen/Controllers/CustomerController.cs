using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TheMen.Models;

namespace TheMen.Controllers
{
    //protected override void InitializeCulture()
    //{
    //    CultureInfo CI = new CultureInfo("en-EN");
    //    CI.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

    //    Thread.CurrentThread.CurrentCulture = CI;
    //    Thread.CurrentThread.CurrentUICulture = CI;
    //    base.InitializeCulture();
    //}
    public class CustomerController : Controller
    {
        TheMenDbContext context = new TheMenDbContext();
        // GET: Customer
        

        public ActionResult Index()
        {
            return View();
        }

      

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //hàm Registration(post) nhận dl từ trang Registration và thực hiện tạo mới dl
        [HttpPost]
        public ActionResult Registration(FormCollection collection, Customer cus)
        {
            //gán các giá trị người dùng nhập
            var name = collection["Name"];
            var account = collection["Account"];
            var pass = collection["Pass"];
            var nhaplaipass = collection["NhapLaiPass"];
            var email = collection["Email"];
            var phone = collection["Phone"];
            var ngaysinh = String.Format("{0:MM/dd/YYYY}", collection["Ngaysinh"]);

            if (String.IsNullOrEmpty(name))
            {
                ViewData["Loi1"] = "Họ tên không được để trống nho";
            }
            else if (String.IsNullOrEmpty(account))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được để trống nho";
            }
            else if (String.IsNullOrEmpty(pass))
            {
                ViewData["Loi3"] = "Mật khẩu không được để trống nho";
            }
            else if (String.IsNullOrEmpty(nhaplaipass))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu nho";
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được để trống nho";
            }
            if (String.IsNullOrEmpty(phone))
            {
                ViewData["Loi6"] = "Số điện thoại không được để trống nho";
            }
            else
            {
                //gán giá trị cho đối tượng đc tạo mới (cus)
                cus.Name = name;
                cus.Account = account;
                cus.Pass = pass;
                cus.Email = email;
                cus.Phone = phone;
                cus.Ngaysinh = DateTime.Parse(ngaysinh);

                //context.Customer.InsertOnSubmit(cus);
                context.Customer.Add(cus);
                context.SaveChanges();

                return RedirectToAction("Login");
            }
            return this.Registration();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var account = collection["Account"];
            var pass = collection["Pass"];
            if (String.IsNullOrEmpty(account))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(pass))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (kh)

                Customer kh = context.Customer.SingleOrDefault(n => n.Account == account && n.Pass == pass);
                if (kh != null)
                {
                    // ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Account"] = kh;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
    }
}