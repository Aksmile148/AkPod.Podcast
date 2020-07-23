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
using Podcast.DataAccess.Data.Repository;
using Podcast.DataAccess.Data.Repository.IRepository;
using Podcast.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

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

        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            var podcasts = await  _context.Pods.ToListAsync();
            return View(podcasts);
        }

        [Area("Admin")]
        public IActionResult New()
        {
            return View();
        }


        [Area("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(PodcastViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Pod pod = new Pod  
                {
                    Title = model.Title,
                    AudioFile = uniqueFileName,
                    dateUploaded = model.dateUploaded,
                    Description = model.Description,
                    Tag = model.Tag
                };
                _context.Add(pod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(PodcastViewModel model)
        {
            string uniqueFileName = null;

            if (model.Audio != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "audios");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Audio.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Audio.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [Area("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _context.Pods.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (id != objFromDb.Id)
            {
                ViewBag.pod = "Podcast not found!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _context.Remove(objFromDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
