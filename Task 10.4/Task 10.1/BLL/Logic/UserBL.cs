using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_10._1.BLL.Contracts;
using Task_10._1.DAL;
using Task_10._1.DAL.Contracts;
using Task_10._1.Entities;

namespace Task_10._1.BLL.Logic
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAO _userDAO = FactoryDAO.CreateUserDAO();
        
        //БАЗА
        public void Add(User user)
        {
            this._userDAO.Add(user);
        }

        public bool Remove(string _userID)
        {
            return this._userDAO.Remove(_userID);
        }

        public User GetByID(string _userID)
        {
            return this._userDAO.GetByID(_userID);
        }

        public IEnumerable<User> GetAll()
        {
            return this._userDAO.GetAll();
        }
        //ОПЕРАЦИИ С НАГРАДОЙ
        public void AddAward(string _userID, string _awardID)
        {
            this._userDAO.AddAward(_userID, _awardID);
        }
        public void RemoveAward(string _userID, string _awardID)
        {
            this._userDAO.RemoveAward(_userID, _awardID);
        }
        //ОПЕРАЦИИ С КАРТИНКОЙ
        public void SetImage(string _userID, string _imageID, string _thumbID)
        {
            this._userDAO.SetImage(_userID, _imageID, _thumbID);
        }
        //ИЗМЕНЕНИЕ
        public void EditDateOfBirth(string _userID, DateTime _dateofbirth)
        {
            this._userDAO.EditDateOfBirth(_userID, _dateofbirth);
        }

        public void EditName(string _userID, string _name)
        {
            this._userDAO.EditName(_userID, _name);
        }
        //ПРОВЕРКИ
        public bool IsExist(string _userID)
        {
            return this._userDAO.IsExist(_userID);
        }
    }
}