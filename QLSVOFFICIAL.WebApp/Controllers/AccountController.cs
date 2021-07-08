using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using QLSVOFFICIAL.Data.Models;
using QLSVOFFICIAL.Data.EF;

namespace QLSVOFFICIAL.BackendApi1.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();

        QLSVContext db = new QLSVContext();

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Validate(AppUser us)
        {
            var _admin = db.Users.Where(s => s.UserName == us.UserName);
            //var _role = db.Roles.Where(s => s.IdRole == us.IdRole);
            if(_admin.Any())
            {
                if(_admin.Where(s => s.Password == us.Password).Any())
                {
                    HttpContext.Session.SetString("FullName", _admin.First().FullName);
                    //HttpContext.Session.SetString("Role", _role.First().RoleName);
                    return View("Index");
                }
                else
                {
                    ViewBag.ErrorMsg = "Password is wrong!";
                    return View("Login");
                }
            }
            else
            {
                ViewBag.ErrorMsg = "MSSV or Password is wrong";
                return View("Login");
            }
        }
        //View thông tin sinh viên
        public IActionResult Inf()
        {
            return View();
        }
        //View xuất thông báo có thực sự muốn thoát đăng xuất khỏi trang
        public IActionResult OutNotification()
        {
            return View();
        }
    }
}
