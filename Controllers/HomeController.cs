using Microsoft.AspNetCore.Mvc;
using News.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        NewsContext db;
        public HomeController(NewsContext context)
        {
            db = context;
            

        }
        public IActionResult Index()
        {
           var result= db.Categories.ToList();
            return View(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
          
            return View();
        }
        [HttpPost]
        public  async Task <IActionResult> SaveContact(ContactUs contact)
        {

            db.ContactUs.Add(contact);
            db.SaveChanges();
            var text = $"<p> thanks for your contact we will respond you soon you tell us about {contact.Message} and we will show this soom thanks {contact.Name}  </p>";
            using (var smtp = new SmtpClient()) 
            {
                var googleCredential = new NetworkCredential
                {
                    UserName = "ahmedelmajek2000@gmail.com",
                    Password="ahmedmandoo"
                };
                smtp.Credentials = googleCredential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                var message = new MailMessage();
                message.To.Add(contact.Email);
                message.Subject = "welcome from news website";
                message.IsBodyHtml = true;
                message.Body = text;
                message.From = new MailAddress("ahmedelmajek2000@gmail.com");
                await smtp.SendMailAsync(message);

            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Messages()
        {
            return View(db.ContactUs.ToList());
        }
        //get News By categoryId
        public IActionResult News(int id)
        {
            Category c = db.Categories.Find(id);
            ViewBag.Cat = c.Name;
            var result = db.News.Where(x => x.CategoryId == id).OrderByDescending(x => x.Date).ToList();
            return View(result);
        }
        public IActionResult Delete(int id)
        {
            var New = db.News.Find(id);
            db.News.Remove(New);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
