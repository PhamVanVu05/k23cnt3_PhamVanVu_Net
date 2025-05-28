using Microsoft.AspNetCore.Mvc;
using Pvvlab6.Models;
using System.Diagnostics;

namespace Pvvlab6.Controllers
{
    public class PvvHomeController : Controller
    {
        private readonly ILogger<PvvHomeController> _logger;

        public PvvHomeController(ILogger<PvvHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PvvIndex()
        {
            return View();
        }

        public IActionResult PvvAbout()
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
