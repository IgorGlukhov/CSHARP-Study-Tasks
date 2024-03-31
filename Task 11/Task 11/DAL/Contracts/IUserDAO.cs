using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_11.Entities;

namespace Task_11.DAL.Contracts
{
    public interface IUserDAO
    {
        //БАЗА
        void Add(User _user);
        bool Remove(string _userID);
        User GetByID(string _userID);
        IEnumerable<User> GetAll();
        //ОПЕРАЦИИ С НАГРАДОЙ
        void AddAward(string _userID, string _awardID);
        void RemoveAward(string _userID, string _awardID);
        //ОПЕРАЦИИ С КАРТИНКОЙ
        void SetImage(string _userID, string _imageID, string _thumbID);
        //ИЗМЕНЕНИЕ 
        void EditName(string _userID, string _name);
        void EditDateOfBirth(string _userID, DateTime _dateofbirth);
        //ПРОВЕРКИ
        bool IsExist(string _userID);
    }
}
