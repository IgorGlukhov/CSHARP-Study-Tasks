using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Task_11.Entities;

namespace Task_11.DAL
{
    public class MSSQLStorage
    {
        public static readonly string conStr;
        static MSSQLStorage()
        {
            conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        }
        internal static List<Award> GetAwardsFromDB()
        {
            List<Award>  Awards = new List<Award>();
            using (var con = new SqlConnection(conStr))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM dbo.Awards";
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string ID = (string)reader["AwardID"];
                        Awards.Add(new Award
                        {
                            AwardID = ID,
                            Title = (string)reader["Title"]
                        });
                        using (var conlist = new SqlConnection(conStr))
                        {
                            using (var cmdlist = conlist.CreateCommand())
                            {
                                cmdlist.CommandText = "SELECT [UserID] FROM dbo.UserAward WHERE [AwardID]=@ID";
                                cmdlist.Parameters.AddWithValue("@ID", ID);
                                conlist.Open();
                                var readerlist = cmdlist.ExecuteReader();
                                while (readerlist.Read())
                                {
                                    Awards.Last().OwnerID.Add((string)readerlist["UserID"]);
                                }
                            }
                        }
                    }
                }

            }
            return Awards;
        }
        internal static List<User> GetUsersFromDB()
        {
            List<User> Users = new List<User>();
            using (var con = new SqlConnection(conStr))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM dbo.Users";
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string ID = (string)reader["UserID"];
                        Users.Add(new User
                        {
                            UserID = ID,
                            Name = (string)reader["Name"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            ThumbID = (string)reader["ThumbID"],
                            ImageID = (string)reader["ImageID"]
                        });
                        using (var conlist = new SqlConnection(conStr))
                        {
                            using (var cmdlist = conlist.CreateCommand())
                            {
                                cmdlist.CommandText = "SELECT [AwardID] FROM dbo.UserAward WHERE [UserID]=@ID";
                                cmdlist.Parameters.AddWithValue("@ID", ID);
                                conlist.Open();
                                var readerlist = cmdlist.ExecuteReader();
                                while (readerlist.Read())
                                {
                                    Users.Last().AwardID.Add((string)readerlist["AwardID"]);
                                }
                            }
                        }
                    }
                }
            }
            return Users;
        }
        internal static List<Image> GetImagesFromDB()
        {
            List<Image> Images = new List<Image>();
            using (var con = new SqlConnection(conStr))
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM dbo.Images";
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Images.Add(new Image
                        {
                            ImageID = (string)reader["ImageID"],
                            Title = (string)reader["Title"],
                            Data = reader["Data"] == DBNull.Value ? new byte[0] : (byte[])reader["Data"]
                        });
                    }
                }                
            }
            return Images;
        }
    }
}