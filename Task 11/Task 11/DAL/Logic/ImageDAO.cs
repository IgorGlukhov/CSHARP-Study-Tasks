using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using Task_11.DAL.Contracts;
using Task_11.Entities;

namespace Task_11.DAL.Logic
{
    internal class ImageDAO : IImageDAO
    {
        //БАЗА
        public void Add(Image _image)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO dbo.Images (ImageID, Title, Data) VALUES (@ImageID, @Title, @Data); SELECT scope_identity()";
                    command.Parameters.AddWithValue("@ImageID", _image.ImageID);
                    command.Parameters.AddWithValue("@Title", _image.Title);
                    command.Parameters.AddWithValue("@Data", _image.Data);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool Remove(string _imageID)
        {
            try
            {
                using (var connection = new SqlConnection(MSSQLStorage.conStr))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM dbo.Images WHERE [ImageID]=@ImageID";
                        command.Parameters.AddWithValue("@ImageID", _imageID);
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
        public Image GetByID(string _imageID)
        {
            List<Image> _images = MSSQLStorage.GetImagesFromDB();
            return _images.FirstOrDefault(_image => _image.ImageID == _imageID);
        }

        public IEnumerable<Image> GetAll()
        {
            List<Image> _images = MSSQLStorage.GetImagesFromDB();
            foreach (Image _image in _images)
            {
                yield return _image;
            }
        }
        //ИЗМЕНЕНИЕ
        public void EditTitle(string _imageID, string _title)
        {
            using (var connection = new SqlConnection(MSSQLStorage.conStr))
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE dbo.Images SET [Title]=@Title WHERE [ImageID]=@ImageID";
                    command.Parameters.AddWithValue("@Title", _title);
                    command.Parameters.AddWithValue("@ImageID", _imageID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            GetByID(_imageID).Title = _title;
        }
        //ПРОВЕРКИ      
        public bool IsExist(string _imageID)
        {
            List<Image> _images = MSSQLStorage.GetImagesFromDB();
            return _images.Exists(_image => _image.ImageID == _imageID);
        }
    }
}