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
            this._users.Add(_user);
        }

        public bool Remove(string _userID)
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

        public User GetByID(string _userID)
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
        public void AddAward(string _userID, string _awardID)
        {
            GetByID(_userID).AwardID.Add(_awardID);
        }
        public void RemoveAward(string _userID, string _awardID)
        {
            GetByID(_userID).AwardID.Remove(_awardID);
        }
        //ОПЕРАЦИИ С КАРТИНКОЙ
        public void SetImage(string _userID, string _imageID, string _thumbID)
        {
            GetByID(_userID).ImageID=_imageID;
            GetByID(_userID).ThumbID = _thumbID;
        }
        //ИЗМЕНЕНИЕ
        public void EditDateOfBirth(string _userID, DateTime _dateofbirth)
        {
            GetByID(_userID).DateOfBirth = _dateofbirth;
        }

        public void EditName(string _userID, string _name)
        {
            GetByID(_userID).Name=_name;
        }
        //ПРОВЕРКИ
        public bool IsExist(string _userID)
        {
            return this._users.Exists(_user => _user.UserID == _userID);
        }
    }
}