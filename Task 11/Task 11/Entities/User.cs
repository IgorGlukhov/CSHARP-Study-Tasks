﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_11.Entities
{
    public class User
    {
        private string _name;
        private DateTime _dateOfBirth;
        public List<string> AwardID = new List<string>();
        public string ImageID;
        public string ThumbID;
        public string UserID { get; set; }
        public string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name can not be empty or NULL");
                this._name = value;
            }
        }
        public DateTime DateOfBirth
        {
            get => this._dateOfBirth;
            set
            {
                this._dateOfBirth = value;
                if ((_dateOfBirth > DateTime.Today) || (_dateOfBirth < DateTime.Today.AddYears(-150)))
                    throw new ArgumentException("Incorrect date of birth");
            }
        }
        public int Age => GetYears(this.DateOfBirth);//уга буга помоги мне лямбда оператор
        private static int GetYears(DateTime date)
        {
            DateTime today = DateTime.Today;

            int result = today.Year - date.Year;

            return (date > today.AddYears(-result)) ? (result - 1) : result;
        }
    }
}