using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Task_10._1.DAL.Contracts;
using Task_10._1.Entities;

namespace Task_10._1.DAL.Logic
{
    internal class UserDAO : IUserDAO
    {
        private readonly List<User> _users = InMemoryStorage.Users;
        //БАЗА
        public void Add(User _user)
        {
            _user.UserID = this._users.Count + 1;
            this._users.Add(_user);
        }

        public bool Remove(int _userID)
        {
            try
            {
                return this._users.Remove(this.GetByID(_userID));
            }
            catch
            {
                return false;
            }
        }

        public User GetByID(int _userID)
        {
            return this._users.FirstOrDefault(_user => _user.UserID == _userID);
        }

        public IEnumerable<User> GetAll()
        {
            foreach (User _user in _users)
            {
                yield return _user;
            }
        }
        //ОПЕРАЦИИ С НАГРАДОЙ
        public void AddAward(int _userID, int _awardID)
        {
            GetByID(_userID).AwardID.Add(_awardID);
        }
        public void RemoveAward(int _userID, int _awardID)
        {
            GetByID(_userID).AwardID.Remove(_awardID);
        }
        //ИЗМЕНЕНИЕ
        public void EditDateOfBirth(int _userID, DateTime _dateofbirth)
        {
            GetByID(_userID).DateOfBirth = _dateofbirth;
        }

        public void EditName(int _userID, string _name)
        {
            GetByID(_userID).Name=_name;
        }
        //ПРОВЕРКИ
        public bool IsExist(int _userID)
        {
            return this._users.Exists(_user => _user.UserID == _userID);
        }
    }
}