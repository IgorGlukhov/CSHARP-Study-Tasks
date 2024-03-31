using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_11.Entities
{
    public class Award
    {
        private string _title;
        public string AwardID { get; set; }
        public string Title
        {
            get => this._title;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Title can not be empty or NULL");
                this._title = value;
            }
        }
        public List<string> OwnerID = new List<string>();
    }
}