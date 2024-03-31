using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_11.BLL.Contracts;
using Task_11.DAL;
using Task_11.DAL.Contracts;
using Task_11.Entities;

namespace Task_11.BLL.Logic
{
    public class ImageBL : IImageBL
    {
        private readonly IImageDAO _imageDAO = FactoryDAO.CreateImageDAO();
        //БАЗА
        public void Add(Image image)
        {
            this._imageDAO.Add(image);
        }
        public bool Remove(string _imageID)
        {
            return this._imageDAO.Remove(_imageID);
        }
        public Image GetByID(string _imageID)
        {
            return this._imageDAO.GetByID(_imageID);
        }

        public IEnumerable<Image> GetAll()
        {
            return this._imageDAO.GetAll();
        }
        //ИЗМЕНЕНИЕ
        public void EditTitle(string _imageID, string _title)
        {
            this._imageDAO.EditTitle(_imageID, _title);
        }
        //ПРОВЕРКИ      
        public bool IsExist(string _imageID)
        {
            return this._imageDAO.IsExist(_imageID);
        }
    }
}