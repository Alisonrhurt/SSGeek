using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSGeek.DAL;
using SSGeek.Models;

namespace SSGeek.Controllers
{
    public class HomeController : Controller
    {
        private IForumPostDAL _dal;
        public HomeController(IForumPostDAL dal)
        {
            _dal = dal;
        }

        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Planets"); //<-- if user goes to .com/ this redirects to .com/planets/index
        }

        //GET: Forum Page

        public ActionResult SpaceForum()
        {
            var posts = _dal.GetAllPosts();
            return View("SpaceForum", posts);
        }

        //GET: New Forum Post Page

        public ActionResult NewForumPost()
        {
            return View("NewForumPost");
        }

        //POST: New Forum Post Page

        [HttpPost]
        public ActionResult NewForumPost(string userName, string subject, string message)
        {
            //Save post to DB
            ForumPost newPost = new ForumPost();
            newPost.Username = userName;
            newPost.PostDate = DateTime.Now;
            newPost.Subject = subject;
            newPost.Message = message;
            _dal.SaveNewPost(newPost);

            var posts = _dal.GetAllPosts();

            return View("SpaceForum", posts);
        }

    }
}