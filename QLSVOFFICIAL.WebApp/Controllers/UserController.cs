using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using QLSVOFFICIAL.Data.Models;
using QLSVOFFICIAL.Application.System.Users;
using QLSVOFFICIAL.ViewModels.System.Users;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace QLSVOFFICIAL.BackendApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();

        QLSVContext db = new QLSVContext();

        public UserController (IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]// Chưa đăng nhập vẫn có thể gọi được hàm này
        public async Task<IActionResult> Authenticate([FromForm]LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _userService.Authencate(request);
            if(string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("MSSV hoặc password sai!");
            }
            return Ok(new { token = resultToken });
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Validate(User us)
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
        //View đổi mật khẩu
        public IActionResult ChangePass()
        {
            return View();
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
