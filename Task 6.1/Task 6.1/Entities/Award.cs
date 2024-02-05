using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Task_6._1.Entities
{
    public class Award 
    {
        private string _title;
        public int AwardID { get; set; }
        public string Title 
        { 
            get=>this._title;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Title can not be empty or NULL");
                this._title = value;
            }
        }
        public List<int> OwnerID=new List<int>();
    }
}
