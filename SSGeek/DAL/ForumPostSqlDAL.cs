using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{

    public class ForumPostSqlDAL : IForumPostDAL
    {
        private string _connectionString = "";

        public ForumPostSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        //returns list
        public List<ForumPost> GetAllPosts()
        {
            List<ForumPost> result = new List<ForumPost>();

            //Connect to Database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                //Create sql statement
                const string sqlPost = "SELECT id, username, subject, message, post_date " +
                                       "FROM forum_post ";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlPost;
                cmd.Connection = conn;

                //Send command to database
                SqlDataReader reader = cmd.ExecuteReader();

                //Pull data off of result set
                while (reader.Read())
                {
                    ForumPost post = new ForumPost();

                    post.Id = Convert.ToInt32(reader["id"]);
                    post.Message = Convert.ToString(reader["message"]);
                    post.PostDate = Convert.ToDateTime(reader["post_date"]);
                    post.Subject = Convert.ToString(reader["subject"]);
                    post.Username = Convert.ToString(reader["username"]);

                    result.Add(post);
                }
            }
            return result;
        }

        public bool SaveNewPost(ForumPost newPost)
        {
            bool result = true;

            //Connect to Database
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                //Create sql statement
                string sqlReservation = "INSERT INTO forum_post (username, subject, message, post_date)" +
                                        $"VALUES(@username, @subject, @message, @post_date)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sqlReservation;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@username", newPost.Username);
                cmd.Parameters.AddWithValue("@subject", newPost.Subject);
                cmd.Parameters.AddWithValue("@message", newPost.Message);
                cmd.Parameters.AddWithValue("@post_date", newPost.PostDate);

                //Send command to database
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
