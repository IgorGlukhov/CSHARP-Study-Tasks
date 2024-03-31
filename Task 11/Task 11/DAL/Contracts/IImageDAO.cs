using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities;

namespace Task_11.DAL.Contracts
{
    public interface IImageDAO
    {
        //БАЗА
        void Add(Image _image);
        bool Remove(string _imageID);
        Image GetByID(string _imageID);
        IEnumerable<Image> GetAll();
        //ИЗМЕНЕНИЕ 
        void EditTitle(string _imageID, string _title);
        //ПРОВЕРКИ
        bool IsExist(string _imageID);
    }
}
