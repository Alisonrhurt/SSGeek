using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class MockForumPostSqlDAL : IForumPostDAL
    {
        private string _connectionString = "";

        static private List<ForumPost> _posts = new List<ForumPost>();

        public MockForumPostSqlDAL(string connectionString)
        {
            PopulateDatabase();
            //_connectionString = connectionString;
        }

        public void PopulateDatabase()
        {
            if(_posts.Count <= 0)
            {
                ForumPost post = new ForumPost();
                post.Id = 1;
                post.Message = "Message";
                post.Username = "Test User";
                post.PostDate = DateTime.Now;
                post.Subject = "Subject";

                _posts.Add(post);
            }
        }

        //returns list
        public List<ForumPost> GetAllPosts()
        {
            //List<ForumPost> result = new List<ForumPost>();

            //ForumPost post = new ForumPost();
            //post.Id = 1;
            //post.Message = "Message";
            return _posts;

        }

        public bool SaveNewPost(ForumPost newPost)
        {
            newPost.PostDate = DateTime.Now;
            newPost.Id = _posts[_posts.Count() - 1].Id + 1;
            _posts.Add(newPost);

            bool result = true;
            if(_posts.Count<1)
            {
                result = false;
            }

            return result;
        }
    }
}