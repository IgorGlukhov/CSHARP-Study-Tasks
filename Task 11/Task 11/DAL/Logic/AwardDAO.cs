using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Task_11.DAL.Contracts;
using Task_11.Entities;

namespace Task_11.DAL.Logic
{
    internal class AwardDAO : IAwardDAO
    {
        //БАЗА
        public void Add(Award _award)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO dbo.Awards (AwardID, Title) VALUES (@ImageID, @Title); SELECT scope_identity()";
                    command.Parameters.AddWithValue("@ImageID", _award.AwardID);
                    command.Parameters.AddWithValue("@Title", _award.Title);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool Remove(string _awardID)
        {
            try
            {
                using (var connection = new SqlConnection(MSSQLStorage.conStr))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM dbo.Awards WHERE [AwardID]=@AwardID";
                        command.Parameters.AddWithValue("@AwardID", _awardID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                using (var connection = new SqlConnection(MSSQLStorage.conStr))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM dbo.UserAward WHERE [AwardID]=@AwardID";
                        command.Parameters.AddWithValue("@AwardID", _awardID);
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
        public Award GetByID(string _awardID)
        {
            List<Award> _awards = MSSQLStorage.GetAwardsFromDB();
            return _awards.FirstOrDefault(_award => _award.AwardID == _awardID);
        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> _awards = MSSQLStorage.GetAwardsFromDB();
            foreach (Award _award in _awards)
            {
                yield return _award;
            }
        }
        //ОПЕРАЦИИ С ВЛАДЕЛЬЦЕМ НАГРАДЫ
        public void AddOwner(string _ownerID, string _awardID)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO dbo.UserAward (UserID, AwardID) VALUES (@OwnerID, @AwardID); SELECT scope_identity()";
                    command.Parameters.AddWithValue("@AwardID", _awardID);
                    command.Parameters.AddWithValue("@OwnerID", _ownerID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void RemoveOwner(string _ownerID, string _awardID)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE * FROM dbo.UserAward WHERE [AwardID]=@AwardID AND [UserID]=@OwnerID";
                    command.Parameters.AddWithValue("@AwardID", _awardID);
                    command.Parameters.AddWithValue("@OwnerID", _ownerID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //ИЗМЕНЕНИЕ
        public void EditTitle(string _awardID, string _title)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE dbo.Awards SET [Title]=@Title WHERE [AwardID]=@AwardID";
                    command.Parameters.AddWithValue("@Title", _title);
                    command.Parameters.AddWithValue("@AwardID", _awardID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        //ПРОВЕРКИ      
        public bool IsExist(string _awardID)
        {
            List<Award> _awards = MSSQLStorage.GetAwardsFromDB();
            return _awards.Exists(_award => _award.AwardID == _awardID);
        }
    }
}