using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AkPod.Podcast.Models;
using Podcast.DataAccess.Data;
using Microsoft.AspNetCore.Hosting;

namespace Podcast.Controllers
{
    public class DashBoardController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<DashBoardController> _logger;

        public DashBoardController(ILogger<DashBoardController> logger, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }

        [Area("AppUser")]
        public IActionResult Index()
        {
            return View();
        }

        [Area("AppUser")]
        public IActionResult Privacy()
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
