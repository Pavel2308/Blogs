using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcBlogs.Data;
using MvcBlogs.Models;

namespace MvcBlogs.Controllers
{
    public class ImagesController : Controller
    {
        IWebHostEnvironment _appEnvironment;
        public ImagesController( IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {

            return View(Directory.GetFiles(_appEnvironment.WebRootPath+"/images"));
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/images/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
