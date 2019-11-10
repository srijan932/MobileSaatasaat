using MobileSaatasaat.Models;
using MobileSaatasaat.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MobileSaatasaat.Controllers
{
    public class PostsController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
           if (Session["UserId"] != null)
            {
                base.OnActionExecuting(filterContext);
            }
            else
                filterContext.Result = new RedirectResult("~/Login/Index");
        }

        PostRepo db = new PostRepo();
        // GET: Posts
        public ActionResult Index()
        {
            var userid = Convert.ToInt32(Session["UserId"]);
            //int userid = ses.userid;
            var list = db.GetPostList(userid);
            return View(list);
        }

        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase Image, HttpPostedFileBase ImageOfBox, HttpPostedFileBase ImageOfMobile)
        {
            Post post = new Post();
           
                post.Title = collection["Title"];
                post.Description = collection["Description"];

            if (Image != null)
            {

                string[] fileext = Image.FileName.Split('.');
                string fileName = Image.FileName;  // + "." + fileext[fileext.Count() - 1];
                string path = "~/images/post";
                string filePath = Path.Combine(Server.MapPath(path), Path.GetFileName(fileName));
                Image.SaveAs(filePath);
                post.Image = fileName;
            }

            if (ImageOfBox != null)
            {

                string[] fileext = ImageOfBox.FileName.Split('.');
                string fileName = ImageOfBox.FileName;  // + "." + fileext[fileext.Count() - 1];
                string path = "~/images/box";
                string filePath = Path.Combine(Server.MapPath(path), Path.GetFileName(fileName));
                ImageOfBox.SaveAs(filePath);
                post.ImageOfBox = fileName;
            }

            if (ImageOfMobile != null)
            {

                string[] fileext = ImageOfMobile.FileName.Split('.');
                string fileName = ImageOfMobile.FileName;  // + "." + fileext[fileext.Count() - 1];
                string path = "~/images/mobile";
                string filePath = Path.Combine(Server.MapPath(path), Path.GetFileName(fileName));
                ImageOfMobile.SaveAs(filePath);
                post.ImageOfMobile = fileName;
            }
            post.Price = collection["Price"];
            post.CreatedBy = Convert.ToInt32(Session["UserId"]);

            db.AddPost(post);
                return RedirectToAction("Index");
            
        }

        //public ActionResult Details(int id)
        //{
        //    Session["UserId"] = 2;
           
        //    if (id == 0)
        //    {
        //        return HttpNotFound();
        //    }
        //    var detail = db.GetPostById(id);
        //    return View(detail);
        //}

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var post = db.GetPostById(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase Image, HttpPostedFileBase ImageOfBox, HttpPostedFileBase ImageOfMobile)
        {
            Post post = new Post();

                post.PostId = id;
                post.Title = collection["Title"];
                post.Description = collection["Description"];
                post.Image = collection["OldImage"];

             if (Image != null)
                {

                    string[] fileext = Image.FileName.Split('.');
                    string fileName = Image.FileName;  // + "." + fileext[fileext.Count() - 1];
                    string path = "~/images/post";
                    string filePath = Path.Combine(Server.MapPath(path), Path.GetFileName(fileName));
                    Image.SaveAs(filePath);
                    post.Image = fileName;
                }
                post.ImageOfBox = collection["OldImageOfBox"];
            if (ImageOfBox != null)
                {

                    string[] fileext = ImageOfBox.FileName.Split('.');
                    string fileName = ImageOfBox.FileName;  // + "." + fileext[fileext.Count() - 1];
                    string path = "~/images/box";
                    string filePath = Path.Combine(Server.MapPath(path), Path.GetFileName(fileName));
                    ImageOfBox.SaveAs(filePath);
                    post.ImageOfBox = fileName;
                }
                 post.ImageOfMobile = collection["OldImageOfMobile"];
            if (ImageOfMobile != null)
                {

                    string[] fileext = ImageOfMobile.FileName.Split('.');
                    string fileName = ImageOfMobile.FileName;  // + "." + fileext[fileext.Count() - 1];
                    string path = "~/images/mobile";
                    string filePath = Path.Combine(Server.MapPath(path), Path.GetFileName(fileName));
                    ImageOfMobile.SaveAs(filePath);
                    post.ImageOfMobile = fileName;
                }
                post.Price = collection["Price"];
                post.CreatedBy = Convert.ToInt32(Session["UserId"]);

                db.EditPost(post);
                return RedirectToAction("Index");
            
          
        }

        public ActionResult Delete(int id)
        {
            db.RemovePost(id);
            return RedirectToAction("Index");
        }

    }
}