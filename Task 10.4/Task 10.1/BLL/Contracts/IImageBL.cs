using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_10._1.Entities;

namespace Task_10._1.BLL.Contracts
{
    public interface IImageBL
    {
        //БАЗА
        void Add(Image image);
        bool Remove(string _imageID);
        Image GetByID(string _imageID);
        IEnumerable<Image> GetAll();
        //ИЗМЕНЕНИЕ 
        void EditTitle(string _imageID, string _title);
        //ПРОВЕРКИ
        bool IsExist(string _imageID);
    }
}