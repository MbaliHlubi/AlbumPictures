using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2.Database;
using Project2.Domains;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext db;

        public HomeController(ILogger<HomeController> logger, DBContext database)
        {
            _logger = logger;
            db = database;
        }

        public IActionResult Index()
        {
            People user = db.people.Where(e => e.person_userName.Equals(HttpContext.Request.Cookies["user"])).First();
            IEnumerable<Images> images = db.images.Where(e => e.person.person_id.Equals(user.person_id));
            return View(images);
        }

        public IActionResult UploadImages()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImages(Images img,IFormFile file)
        {
            Images photo = new Images();
            MemoryStream stream = new MemoryStream();
            file.CopyToAsync(stream);
            photo.image = stream.ToArray();
            if (img.image_name != null) {
                photo.image_id = new Guid();
                photo.image_name = img.image_name;
                photo.image_Tag = img.image_Tag;
                photo.image_Geolocation = img.image_Geolocation;
                photo.image_CapturedBy = img.image_CapturedBy;
                photo.image_CapturedDate = img.image_CapturedDate;
                photo.person = db.people.Where(e => e.person_userName.Equals(HttpContext.Request.Cookies["user"])).First();
                photo.album = "Main";
                db.images.Add(photo);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = db.images.Find(id);
            if (image != null)
            {
                return View(image);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Images img)
        {
            Images photo = db.images.Find(img.image_id);
           
            photo.image_name = img.image_name;
            photo.image_CapturedBy = img.image_CapturedBy;
            photo.image_CapturedDate = img.image_CapturedDate;
            photo.image_Geolocation = img.image_Geolocation;
            photo.image_Tag = img.image_Tag;
            photo.album = img.album;
        
            

            db.images.Update(photo);
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = db.images.Find(id);
            if (image != null)
            {
                return View(image);
            }
            return View();
        }

        [HttpPost]
        public IActionResult delete(Images img)
        {
            Images pic = db.images.Find(img.image_id);
            if (img ==null)
            {
                return View();
            }
            db.images.Remove(pic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SharedImages() {
            People user = db.people.Where(e=>e.person_userName.Equals(HttpContext.Request.Cookies["user"])).FirstOrDefault();
            IEnumerable<SharedImages> images = db.shareImages.Where(e=>e.person_id.Equals(user.person_id)).ToList();
            List<Images> myimages = new List<Images>();
            foreach (var img in images) {
                myimages.Add(db.images.Where(e=>e.image_id.Equals(img.image_id)).FirstOrDefault());
            }
            return View(myimages);
        }

        public IActionResult Sharedwithme() {
            IEnumerable<SharedImages> images = db.shareImages.Where(e => e.sendTo.Equals(HttpContext.Request.Cookies["user"])).ToList();
            List<Images> myimages = new List<Images>();
            foreach (var img in images)
            {
                myimages.Add(db.images.Where(e => e.image_id.Equals(img.image_id)).FirstOrDefault());
            }
            return View(myimages);
        }

        public IActionResult DeleteShared(Guid id) {
            return View();
        }

        public IActionResult DeleteShared(SharedImages img)
        {
            SharedImages image = new SharedImages();
            image.person_id = img.person_id;
            image.image_id = img.image_id;
            image.sendTo = img.sendTo;

            db.shareImages.Remove(image);
            db.SaveChanges();

            return RedirectToAction("SharedImages");
        }

        public IActionResult share(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = db.images.Find(id);
            if (image != null)
            {
                return View(image);
            }
            return View();
        }

        [HttpPost]
        public IActionResult share()
        {
            string image_id = Request.Form["image_id"].ToString();
            string user_to_send = Request.Form["user_to_send_id"];
            People person = db.people.Where(e=> e.person_userName.Equals(HttpContext.Request.Cookies["user"])).FirstOrDefault();
            Images image = db.images.Where(e => e.image_id.Equals(Guid.Parse(image_id))).FirstOrDefault();
            bool exist = db.people.Where(e=>e.person_userName.Equals(user_to_send)).Any();

            SharedImages imageshare = new SharedImages();
            imageshare.person_id = person.person_id;
            imageshare.image_id = image.image_id;
            imageshare.sendTo = user_to_send;

            if (exist) {
                db.shareImages.Add(imageshare);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound("User Not Found");
        }

        public IActionResult Albums()
        {
            return View();
        }

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
