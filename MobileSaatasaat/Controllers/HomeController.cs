using MobileSaatasaat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileSaatasaat.Controllers
{
    public class HomeController : Controller
    {
        PostRepo db = new PostRepo();
        public ActionResult Index(string Title = "")
        {
            //int userid = ses.userid;
            var list = db.GetPostList(Title);
            return View(list);
        }

    }
}