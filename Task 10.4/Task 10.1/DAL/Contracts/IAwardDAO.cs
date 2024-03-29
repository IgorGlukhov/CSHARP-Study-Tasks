using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_10._1.Entities;

namespace Task_10._1.DAL.Contracts
{
    public interface IAwardDAO
    {
        //БАЗА
        void Add(Award _award);
        bool Remove(string _awardID);
        Award GetByID(string _awardID);
        IEnumerable<Award> GetAll();
        //ОПЕРАЦИИ С ВЛАДЕЛЬЦЕМ НАГРАДЫ
        void AddOwner(string _ownerID, string _awardID);
        void RemoveOwner(string _ownerID, string _awardID);
        //ИЗМЕНЕНИЕ 
        void EditTitle(string _awardID, string _title);
        //ПРОВЕРКИ
        bool IsExist(string _awardID);
    }
}
