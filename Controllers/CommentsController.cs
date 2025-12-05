using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCvSite.Data;
using MyCvSite.Models;
using System.Linq;

namespace MyCvSite.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var comments = _context.Comments
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            return View(comments);
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] CommentInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Text))
            {
                return BadRequest();
            }

            var authorName = string.IsNullOrWhiteSpace(model.AuthorName)
                ? (User.Identity?.IsAuthenticated == true ? User.Identity!.Name! : "Анонимен")
                : model.AuthorName.Trim();

            var comment = new Comment
            {
                AuthorName = authorName,
                Text = model.Text.Trim(),
                CreatedAt = DateTime.Now,
                LikesCount = 0
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return Json(new
            {
                id = comment.Id,
                authorName = comment.AuthorName,
                text = comment.Text,
                createdAt = comment.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
                likesCount = comment.LikesCount
            });
        }

        [HttpPost]
        public IActionResult Like([FromBody] LikeInputModel model)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == model.Id);
            if (comment == null) return NotFound();

            comment.LikesCount++;
            _context.SaveChanges();

            return Json(new { likesCount = comment.LikesCount });
        }
    }

    public class CommentInputModel
    {
        public string? AuthorName { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    public class LikeInputModel
    {
        public int Id { get; set; }
    }
}
