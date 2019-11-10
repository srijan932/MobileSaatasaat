using Dapper;
using MobileSaatasaat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSaatasaat.Repository
{
    public class PostRepo
    {
        //posts by id
        public List<Post> GetPostList(int userid)
        {
            string query = "Select * from Posts where CreatedBy =" + userid;
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<Post>(query).ToList();
                return result;
            }
        }

        //searched post
        //public List<Post> GetPostListSearched()
        //{
        //    string query = "Select * from Posts where Title like 'samsung'";
        //    using (var db = DBHelper.GetDbConnection())
        //    {
        //        var result = db.Query<Post>(query).ToList();
        //        return result;
        //    }
        //}s

        //all posts
        public List<Post> GetPostList(string Title)
        {
            string sql = "Select * from Posts" ;
            if (!string.IsNullOrEmpty(Title))
            {
                sql += " where Title like '%" + Title + "%'";
            }
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<Post>(sql).ToList();
                return result;
            }
        }

        public Post GetPostById(int id)
        {
            string query = "Select p.Image, p.ImageOfBox, p.ImageOfMobile, p.Title, p.Description, p.Price," +
                " u.FullName, u.Phone from Posts p"+
                " left join Users u on u.UserId = p.CreatedBy" +
                " where PostId = " + id;
            using (var db = DBHelper.GetDbConnection())
            {
                var result = db.Query<Post>(query).SingleOrDefault();
                return result;
            }
        }

        public void AddPost(Post posts)
        {
            string query = "Insert into Posts (Title, Description, Image, ImageOfBox, ImageOfMobile, Price, CreatedBy) " +
                " values (@Title, @Description, @Image, @ImageOfBox, @ImageOfMobile, @Price, @CreatedBy)";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, posts);
                db.Close();
            }
        }

        public void EditPost(Post post)
        {
            string query = "Update Posts set Title = @Title, Description = @Description, " +
                " Image = @Image, ImageOfBox = @ImageOfBox, ImageOfMobile = @ImageOfMobile where PostId = @PostId";
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query, post);
                db.Close();
            }
        }

        public void RemovePost(int id)
        {
            string query = "Delete Posts where PostId = " + id;
            using (var db = DBHelper.GetDbConnection())
            {
                db.Execute(query);
                db.Close();
            }
        }
    }
}