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
        public void Add(string _name, string _birthday)
        {
            if (!DateTime.TryParseExact(_birthday, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out DateTime _dateOfBirth))
            {
                throw new ArgumentException("Incorrect datetime");
            }
            this._userDAO.Add(new User() { Name = _name, DateOfBirth = _dateOfBirth });
        }

        public bool Remove(int _userID)
        {
            return this._userDAO.Remove(_userID);
        }

        public User GetByID(int _userID)
        {
            return this._userDAO.GetByID(_userID);
        }

        public IEnumerable<User> GetAll()
        {
            return this._userDAO.GetAll();
        }
        //ОПЕРАЦИИ С НАГРАДОЙ
        public void AddAward(int _userID, int _awardID)
        {
            this._userDAO.AddAward(_userID, _awardID);
        }
        public void RemoveAward(int _userID, int _awardID)
        {
            this._userDAO.RemoveAward(_userID, _awardID);
        }
        //ИЗМЕНЕНИЕ
        public void EditDateOfBirth(int _userID, DateTime _dateofbirth)
        {
            this._userDAO.EditDateOfBirth(_userID, _dateofbirth);
        }

        public void EditName(int _userID, string _name)
        {
            this._userDAO.EditName(_userID, _name);
        }
        //ПРОВЕРКИ
        public bool IsExist(int _userID)
        {
            return this._userDAO.IsExist(_userID);
        }
    }
}