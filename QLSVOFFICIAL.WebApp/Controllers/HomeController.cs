using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLSVOFFICIAL.Data.Models;
using System.Diagnostics;

namespace QLSVOFFICIAL.BackendApi1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //View lớp học phần
        public IActionResult ClassSubject()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
