using DiscussionForum.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DiscussionForum
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DiscussionForumService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DiscussionForumService.svc or DiscussionForumService.svc.cs at the Solution Explorer and start debugging.
    using BCrypt = BCrypt.Net.BCrypt;
    public class DiscussionForumService : IDiscussionForumService
    {
        SqlConnection con;
        public DiscussionForumService()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.Length - 30);
            Console.WriteLine(path);
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + path + @"DiscussionForum\App_Data\DiscussionForum.mdf';Integrated Security=True");
        }
        public bool addComment(Comment comment)
        {
            string Author = verifyToken(comment.token);
            if (Author == "")
            {
                ForumException forumException = new ForumException();
                forumException.ErrorCode = 1;
                forumException.Message = "Invalid token.";
                throw new FaultException<ForumException>(forumException, new FaultReason("Invalid token."));
            }
            bool result = false;
            string query = "INSERT INTO [Comment] (TopicId, Author, Comment, Timestamp) VALUES (@TopicId, @Author, @Comment, @Timestamp)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TopicId", comment.TopicId);
            cmd.Parameters.AddWithValue("@Author", Author);
            cmd.Parameters.AddWithValue("@Comment", comment.Comments);
            cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new FaultException<Exception>(ex, new FaultReason(ex.Message));
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public bool createTopic(Topic topic)
        {
            string Author = verifyToken(topic.token);
            if (Author == "")
            {
                ForumException forumException = new ForumException();
                forumException.ErrorCode = 1;
                forumException.Message = "Invalid token.";
                throw new FaultException<ForumException>(forumException, new FaultReason("Invalid token."));
            }
            bool result = false;
            string query = "INSERT INTO [Topic] (Name, Author, Discussion) VALUES (@Name, @Author, @Discussion)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", topic.Name);
            cmd.Parameters.AddWithValue("@Author", Author);
            Console.WriteLine(Author);
            cmd.Parameters.AddWithValue("@Discussion", topic.Discussion);
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new FaultException<Exception>(ex, new FaultReason(ex.Message));
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public TopicPage getTopicPage(int id)
        {
            TopicPage topicPage = new TopicPage();
            List<CommentPage> commentPages = new List<CommentPage>();
            string query = "SELECT NAME,AUTHOR,DISCUSSION FROM [TOPIC] WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    topicPage.Name = rdr["Name"].ToString();
                    topicPage.Author = rdr["Author"].ToString();
                    topicPage.Discussion = rdr["Discussion"].ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new FaultException<Exception>(ex, new FaultReason(ex.Message));
            }
            finally
            {
                con.Close();
            }
            query = "SELECT COMMENT,AUTHOR,TIMESTAMP FROM [COMMENT] WHERE TopicId = @TopicId";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TopicId", id);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommentPage commentPage = new CommentPage();
                    commentPage.Author = rdr["Author"].ToString();
                    commentPage.Comment = rdr["Comment"].ToString();
                    commentPage.Timestamp = rdr["Timestamp"].ToString();
                    commentPages.Add(commentPage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new FaultException<Exception>(ex, new FaultReason(ex.Message));
            }
            finally
            {
                con.Close();
            }
            topicPage.comments = commentPages;
            return topicPage;
        }

        public List<TopicIndex> getTopics()
        {
            List<TopicIndex> topicIndices = new List<TopicIndex>();
            string query = "SELECT Id, Name, Author FROM [Topic]";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TopicIndex topicIndex = new TopicIndex();
                    topicIndex.Id = Int32.Parse(rdr["Id"].ToString());
                    topicIndex.Name = rdr["Name"].ToString();
                    topicIndex.Author = rdr["Author"].ToString();
                    topicIndices.Add(topicIndex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return topicIndices;
        }

        public string login(Login loginObject)
        {
            string token = "";
            string query = "SELECT UserName, Password FROM [User] where Email = @Email";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Email", loginObject.Email);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    rdr.Read();
                    if (BCrypt.Verify(loginObject.Password, rdr["Password"].ToString()))
                    {
                        token = rdr["UserName"].ToString() + "," + BCrypt.HashPassword(rdr["UserName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return token;
        }

        public bool registerUser(Registration registration)
        {
            bool result = false;
            string query = "INSERT INTO [User] (Id, UserName, Email, Password) VALUES" +
                "(@Id, @UserName, @Email, @Password)";
            SqlCommand cmd = new SqlCommand(query, con);
            string Id = Guid.NewGuid().ToString();
            string hash = BCrypt.HashPassword(registration.Password);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@UserName", registration.UserName);
            cmd.Parameters.AddWithValue("@Email", registration.Email);
            cmd.Parameters.AddWithValue("@Password", hash);
            try
            {
                con.Open();
                int i = cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public string verifyToken(string token)
        {
            if (token.Contains(','))
            {
                string[] tokens = token.Split(',');
                if (BCrypt.Verify(tokens[0], tokens[1]))
                {
                    return tokens[0];
                }
            }
            return "";
        }
    }
}
