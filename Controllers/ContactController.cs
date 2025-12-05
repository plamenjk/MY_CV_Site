using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCvSite.Data;
using MyCvSite.Models;

namespace MyCvSite.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string email, string messageText)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(messageText))
            {
                ViewBag.Error = "Моля, попълнете всички полета.";
                return View();
            }

            var msg = new ContactMessage
            {
                Name = name.Trim(),
                Email = email.Trim(),
                MessageText = messageText.Trim(),
                SentAt = DateTime.Now
            };

            _context.ContactMessages.Add(msg);
            _context.SaveChanges();

            ViewBag.Success = "Съобщението е изпратено успешно.";
            return View();
        }
    }
}
