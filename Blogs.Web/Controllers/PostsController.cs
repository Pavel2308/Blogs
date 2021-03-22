using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogs.Web.ViewModels.Posts;
using Blogs.Infrastructure.Data;
using Blogs.Infrastructure.Data.Models;
using Blogs.Web.Extensions;
using Blogs.Markdown.Intefaces;

namespace Blogs.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly BlogsContext _context;
        private readonly IParser _markdown;

        public PostsController(BlogsContext context, IParser markdown)
        {
            _context = context;
            _markdown = markdown;
        }

        public IActionResult Index()
        {
            var posts = _context.Posts.OrderByDescending(s => s.ReleaseDate);

            var indexViewModels = posts.Select(p => new IndexViewModel
            {
                Id = p.Id,
                Title = p.Title,
                ReleaseDate = p.ReleaseDate,
                Category = p.Category,
                ShortHtmlDesc = _markdown.Parse(p.MdDesc).ToShortHtmlDescription()
            }).ToList();

            return View(indexViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts.FirstOrDefault(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            var detailsViewModel = new DetailsViewModel
            {
                Id = post.Id,
                Title = post.Title,
                ReleaseDate = post.ReleaseDate,
                Category = post.Category,
                HtmlDesc = _markdown.Parse(post.MdDesc)
            };

            return View(detailsViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Category = createViewModel.Category,
                    Title = createViewModel.Title,
                    MdDesc = createViewModel.MdDesc,
                    ReleaseDate = DateTime.Now
                };

                _context.Posts.Add(post);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(createViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts.FirstOrDefault(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            var editViewModel = new EditViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Category = post.Category,
                MdDesc = post.MdDesc
            };

            return View(editViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditViewModel editViewModel)
        {
            if (id != editViewModel.Id)
            {
                return NotFound();
            }

            var post = _context.Posts.FirstOrDefault(x => x.Id == id);

            post.Title = editViewModel.Title;
            post.Category = editViewModel.Category;
            post.MdDesc = editViewModel.MdDesc;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Posts.Update(post);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Posts.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == id);
            _context.Posts.Remove(post);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
