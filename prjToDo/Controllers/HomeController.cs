using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjToDo.Models;

namespace prjToDo.Controllers
{
    public class HomeController : Controller
    {
        dbToDoEntities db = new dbToDoEntities();
        // GET: Home
        public ActionResult Index()
        {
            var todos = db.tToDo.OrderByDescending(m => m.Date).ToList();
            return View(todos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create
            (string title,string image,DateTime date)
        {
            tToDo toDo = new tToDo();
            toDo.Title = title;
            toDo.Image = image;
            toDo.Date = date;
            db.tToDo.Add(toDo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}