using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Task_11.DAL.Contracts;
using Task_11.Entities;

namespace Task_11.DAL.Logic
{
    internal class UserDAO : IUserDAO
    {
        //БАЗА
        public void Add(User _user)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO dbo.Users (UserID, Name, DateOfBirth, ThumbID, ImageID) VALUES (@UserID, @Name, @DateOfBirth, @ThumbID, @ImageID); " +
                        "SELECT scope_identity()";
                    command.Parameters.AddWithValue("@UserID", _user.UserID);
                    command.Parameters.AddWithValue("@Name", _user.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", _user.DateOfBirth);
                    command.Parameters.AddWithValue("@ThumbID", _user.ThumbID);
                    command.Parameters.AddWithValue("@ImageID", _user.ImageID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool Remove(string _userID)
        {
            try
            {
                using (var connection = new SqlConnection(MSSQLStorage.conStr))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE * FROM dbo.Users WHERE [UserID]=@UserID";
                        command.Parameters.AddWithValue("@UserID", _userID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                using (var connection = new SqlConnection(MSSQLStorage.conStr))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE * FROM dbo.UserAward WHERE [UserID]=@UserID";
                        command.Parameters.AddWithValue("@UserID", _userID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public User GetByID(string _userID)
        {
            List<User> _users = MSSQLStorage.GetUsersFromDB();
            return _users.FirstOrDefault(_user => _user.UserID == _userID);
        }
        public IEnumerable<User> GetAll()
        {
            List<User> _users = MSSQLStorage.GetUsersFromDB();
            foreach (User _user in _users)
            {
                yield return _user;
            }
        }
        //ОПЕРАЦИИ С НАГРАДОЙ
        public void AddAward(string _userID, string _awardID)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO dbo.UserAward (UserID, AwardID) VALUES (@UserID, @AwardID); SELECT scope_identity()";
                    command.Parameters.AddWithValue("@AwardID", _awardID);
                    command.Parameters.AddWithValue("@UserID", _userID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void RemoveAward(string _userID, string _awardID)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM dbo.UserAward WHERE [AwardID]=@AwardID AND [UserID]=@UserID";
                    command.Parameters.AddWithValue("@AwardID", _awardID);
                    command.Parameters.AddWithValue("@UserID", _userID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //ОПЕРАЦИИ С КАРТИНКОЙ
        public void SetImage(string _userID, string _imageID, string _thumbID)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE dbo.Users SET [ImageID]=@ImageID, [ThumbID]=@ThumbID WHERE [UserID]=@UserID";
                    command.Parameters.AddWithValue("@ImageID", _imageID);
                    command.Parameters.AddWithValue("@ThumbID", _thumbID);
                    command.Parameters.AddWithValue("@UserID", _userID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //ИЗМЕНЕНИЕ
        public void EditDateOfBirth(string _userID, DateTime _dateofbirth)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE dbo.Users SET [DateOfBirth]=@DateOfBirth WHERE [UserID]=@UserID";
                    command.Parameters.AddWithValue("@DateOfBirth", _dateofbirth);
                    command.Parameters.AddWithValue("@UserID", _userID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditName(string _userID, string _name)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE dbo.Users SET [Name]=@Name WHERE [UserID]=@UserID";
                    command.Parameters.AddWithValue("@Name", _name);
                    command.Parameters.AddWithValue("@UserID", _userID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //ПРОВЕРКИ
        public bool IsExist(string _userID)
        {
            List<User> _users = MSSQLStorage.GetUsersFromDB();
            return _users.Exists(_user => _user.UserID == _userID);
        }
    }
}