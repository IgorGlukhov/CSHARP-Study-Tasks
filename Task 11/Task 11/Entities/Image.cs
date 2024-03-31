using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_11.Entities
{
    public class Image
    {
        private string _title;
        public string ImageID { get; set; }
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
        public byte[] Data { get; set; }
    }
}