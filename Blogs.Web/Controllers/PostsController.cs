using System;
using System.Linq;
using Blogs.Web.Managers;
using Blogs.Core.Markdown;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogs.SharedKernel.Models;
using System.Collections.Generic;
using Blogs.Web.ViewModels.Posts;

namespace Blogs.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostManager _postManager;
        private readonly Markdown _markdown;
        public PostsController(PostManager postManager, Markdown markdown)
        {
            _postManager = postManager;
            _markdown = markdown;
        }


        public IActionResult Index()
        {
            var posts = _postManager.List().OrderByDescending(s => s.ReleaseDate).ToList();
            var indexViewModels = new List<IndexViewModel>();
            foreach (var post in posts)
            {
                indexViewModels.Add(
                    new IndexViewModel()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        ReleaseDate = post.ReleaseDate,
                        Category = post.Category,
                        MdDesc = post.MdDesc,
                        HtmlDesc = post.HtmlDesc,
                        ShortHtmlDesc = _postManager.GetShortHtmlDesc(post.HtmlDesc)
                    });
            }
            return View(indexViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postManager.GetPostById((int)id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,ReleaseDate,Category,MdDesc,HtmlDesc")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.ReleaseDate = DateTime.Now;
                _markdown.Set(post.MdDesc);
                post.HtmlDesc = _markdown.ToHtml(); ;
                _postManager.Insert(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postManager.GetPostById((int)id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Category,MdDesc,HtmlDesc")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }
            _markdown.Set(post.MdDesc);
            post.HtmlDesc = _markdown.ToHtml();
            if (ModelState.IsValid)
            {
                try
                {
                    _postManager.Update(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var post = _postManager.GetPostById(id);
            _postManager.Delete(post);
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _postManager.Exists(id);
        }
    }
}
