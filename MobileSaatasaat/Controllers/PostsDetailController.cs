using MobileSaatasaat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileSaatasaat.Controllers
{
    public class PostsDetailController : Controller
    {
        PostRepo db = new PostRepo();
        // GET: PostsDetail
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var detail = db.GetPostById(id);
            return View(detail);
        }
    }
}