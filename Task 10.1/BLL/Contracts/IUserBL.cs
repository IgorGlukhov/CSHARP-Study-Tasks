﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_10._1.Entities;

namespace Task_10._1.BLL.Contracts
{
    public interface IUserBL
    {
        //БАЗА
        void Add(string _name, string _dateOfBirth);
        bool Remove(int _userID);
        User GetByID(int _userID);
        IEnumerable<User> GetAll();
        //ОПЕРАЦИИ С НАГРАДОЙ
        void AddAward(int _userID, int _awardID);
        void RemoveAward(int _userID, int _awardID);
        //ИЗМЕНЕНИЕ 
        void EditName(int _userID, string _name);
        void EditDateOfBirth(int _userID, DateTime _dateofbirth);
        //ПРОВЕРКИ
        bool IsExist(int _userID);
    }
}